using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using System.ComponentModel.DataAnnotations;

namespace MM.Library.Entities
{
   public class ContactInfoEdit : BusinessBase<ContactInfoEdit>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> ContactInfoIDProperty = RegisterProperty<int>(c => c.ContactInfoID);
        public int ContactInfoID
        {
            get { return GetProperty(ContactInfoIDProperty); }
            set { SetProperty(ContactInfoIDProperty, value); }
        }

        public static readonly PropertyInfo<string> ContactInfoItemProperty = RegisterProperty<string>(c => c.ContactInfoItem);
       
       [Required] 
       public string ContactInfoItem
        {
            get { return GetProperty(ContactInfoItemProperty); }
            set { SetProperty(ContactInfoItemProperty, value); }
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

        public static ContactInfoEdit NewContactInfoEdit()
        {
            return DataPortal.Create<ContactInfoEdit>();
        }

        public static ContactInfoEdit GetContactInfoEdit(int id)
        {
            return DataPortal.Fetch<ContactInfoEdit>(id);
        }

        public static void DeleteContactInfoEdit(int id)
        {
            DataPortal.Delete<ContactInfoEdit>(id);
        }
       
        #region Data Access

        private void DataPortal_Fetch(SingleCriteria<ContactInfoEdit, int> criteria)
        {
            // TODO: load values into object
        }

        protected override void DataPortal_Insert()
        {
            // TODO: insert object's data
        }

        protected override void DataPortal_Update()
        {
            // TODO: update object's data
        }

        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<ContactInfoEdit, int>(ReadProperty<int>(ContactInfoIDProperty)));
        }

        private void DataPortal_Delete(SingleCriteria<ContactInfoEdit, int> criteria)
        {
            // TODO: delete object's data
        }

        #endregion





    }
}
