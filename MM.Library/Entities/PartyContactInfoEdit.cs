using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using System.ComponentModel.DataAnnotations;
using MM.Library.Collections;

namespace MM.Library.Entities
{
     [Serializable]
    public  class PartyContactInfoEdit : BusinessBase<PartyContactInfoEdit>
    {

        #region Business Methods

        public static readonly PropertyInfo<int> ContactInfoIDProperty = RegisterProperty<int>(c => c.ContactInfoID);
        public int ContactInfoID
        {
            get { return GetProperty(ContactInfoIDProperty); }
            private set { LoadProperty(ContactInfoIDProperty, value); }
        }

        public static readonly PropertyInfo<string> ContactInfoItemProperty = RegisterProperty<string>(c => c.ContactInfoItem);
        public string ContactInfoItem
        {
            get { return GetProperty(ContactInfoItemProperty); }
            set { SetProperty(ContactInfoItemProperty, value); }
        }
        

        public static readonly PropertyInfo<DateTime> AssignedProperty =   
          RegisterProperty<DateTime>(c => c.Assigned);
        [Display(Name = "Date assigned")]
        public DateTime Assigned
        {
            get { return GetProperty(AssignedProperty); }
            private set { LoadProperty(AssignedProperty, value); }
        }

        public static readonly PropertyInfo<int> ContactInfoTypeProperty =
          RegisterProperty<int>(c => c.ContactInfoType);
        [Display(Name = "Type assigned")]
        public int ContactInfoType
        {
            get { return GetProperty(ContactInfoTypeProperty); }
            set
            {
                SetProperty(ContactInfoTypeProperty, value);
                OnPropertyChanged("ContactType");
            }
        }

        [Display(Name = "Contact Type")]
        public string ContactType
        {
            get
            {
                var result = "none";
                if (ContactInfoTypeList.GetList().ContainsKey(ContactInfoType))
                    result = ContactInfoTypeList.GetList().GetItemByKey(ContactInfoType).Value;
                return result;
            }
        }

        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            // TODO: add validation rules
        }

        #endregion

        #region Authorization Rules

        private static void AddObjectAuthorizationRules()
        {
            // TODO: add object-level authorization rules
        }

        #endregion

        #region Factory Methods

        public static PartyContactInfoEdit NewPartyContactInfoEdit()
        {
            return DataPortal.Create<PartyContactInfoEdit>();
        }

        public static PartyContactInfoEdit GetPartyContactInfoEdit(int id)
        {
            return DataPortal.Fetch<PartyContactInfoEdit>(id);
        }

        public static void DeletePartyContactInfoEdit(int id)
        {
            DataPortal.Delete<PartyContactInfoEdit>(id);
        }

        #endregion

        #region Data Access

        private void Child_Create(int contactInfoID)
        {
            using (BypassPropertyChecks)
            {
                ContactInfoID = contactInfoID;
                ContactInfoType = ContactInfoTypeList.DefaultType();
                LoadProperty(AssignedProperty, DateTime.Today);
                using (var ctx = MM.DAL.DalFactory.GetManager())
                {
                    var dal = ctx.GetProvider<MM.DAL.IContactInfo>();
                    var contactInfo = dal.Fetch(contactInfoID);
                    ContactInfoID = contactInfo.ContactInfoID;
                    ContactInfoItem  = contactInfo.ContactInfoItem;
                }
            }
            base.Child_Create();
        }

        private void Child_Fetch(int personID, int contactInfoID)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IContactInfoAssignmentDAL>();
                var data = dal.Fetch(personID, contactInfoID);
                Child_Fetch(data);
            }
        }

        private void Child_Fetch(MM.DAL.ContactInfoAssignmentDTO data)
        {
            using (BypassPropertyChecks)
            {
                ContactInfoID = data.ContactInfoItemID;
                ContactInfoType = data.ContactInfoType;
                LoadProperty(AssignedProperty, data.Assigned);


                var query = from contactInfo in data.ContactInfoList
                            where contactInfo.ContactInfoID == ContactInfoID
                            select contactInfo;

                var myContactInfo = query.FirstOrDefault();

                    ContactInfoItem = myContactInfo.ContactInfoItem;
                     Assigned = myContactInfo.CreateDate;
                }
            }
       
        private void Child_Insert(PersonEdit person)
        {
            Child_Insert(person.RenterID);
        }

        private void Child_Insert(int personID)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IContactInfoAssignmentDAL>();
                using (BypassPropertyChecks)
                {
                    var item = new MM.DAL.ContactInfoAssignmentDTO
                    {
                        RenterID = personID,
                        ContactInfoItemID = this.ContactInfoID,
                        Assigned = ReadProperty(AssignedProperty),
                        ContactInfoType = this.ContactInfoType
                    };
                    dal.Insert(item);
                    
                }
            }
        }

        private void Child_Update(PersonEdit person)
        {
            Child_Update(person.RenterID);
        }

        private void Child_Update(int personID)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IContactInfoAssignmentDAL>();
                using (BypassPropertyChecks)
                {
                    var item = dal.Fetch(personID, ContactInfoID);
                    item.Assigned = ReadProperty(AssignedProperty);
                    item.ContactInfoType = ContactInfoType; 
                    dal.Update(item);
                 
                }
            }
        }

        private void Child_DeleteSelf(PersonEdit person)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IContactInfoAssignmentDAL>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(person.RenterID, ContactInfoID);
                }
            }
        }

        #endregion
       


        

    }
}
