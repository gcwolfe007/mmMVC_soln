using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Csla;
using MM.Library.Collections;

namespace MM.Library.Entities
{
    [Serializable]
    public class PersonEdit : BusinessBase<PersonEdit>, IRentingParty
    {

        #region Business Methods


        #region IRentingParty Members

        [Key]
        public static readonly PropertyInfo<int> RenterIDProperty = RegisterProperty<int>(c => c.RenterID);
        public int RenterID
        {
            get { return GetProperty(RenterIDProperty); }
            private set { LoadProperty(RenterIDProperty, value); }
        }


        public static readonly PropertyInfo<SmartDate> CreateDateProperty =
            RegisterProperty<SmartDate>(c => c.CreateDate, null, new SmartDate(DateTime.Now));
        [Display(Name = "Create Date")]
        [Required(ErrorMessage = "'A First Name' is required")]
        public string CreateDate
        {
            get { return GetPropertyConvert<SmartDate, string>(CreateDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(CreateDateProperty, value); }
        }

        public static readonly PropertyInfo<PartyAddresses> AddressesProperty =
            RegisterProperty<PartyAddresses>(c => c.Addresses, RelationshipTypes.Child);
        public PartyAddresses Addresses
        {
            get
            {
                if (!(FieldManager.FieldExists(AddressesProperty)))
                    LoadProperty(AddressesProperty, DataPortal.CreateChild<PartyAddresses>());
                return GetProperty(AddressesProperty);
            }
            set { SetProperty(AddressesProperty, value); }
        }
        
        public static readonly PropertyInfo<PartyContactInfoItems> ContactItemsProperty =
            RegisterProperty<PartyContactInfoItems>(c => c.ContactItems, RelationshipTypes.Child);
        public PartyContactInfoItems ContactItems
        {
            get
            {
                if (!(FieldManager.FieldExists(ContactItemsProperty)))
                    LoadProperty(ContactItemsProperty, DataPortal.CreateChild<PartyContactInfoItems>());
                return GetProperty(ContactItemsProperty);
            }
            set { SetProperty(AddressesProperty, value); }
        }

        #endregion

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>      
        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "'A First Name' is required")]
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty); }
            set { SetProperty(FirstNameProperty, value); }
        }

        /// <summary>
        /// The last name property
        /// </summary>
        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "'Last Name' is required")]
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
            set { SetProperty(LastNameProperty, value); }
        }

        /// <summary>
        /// The middle name property
        /// </summary>    
        public static readonly PropertyInfo<string> MiddleNameProperty = RegisterProperty<string>(c => c.MiddleName);
        [Display(Name = "Middle Name")]
        public string MiddleName
        {
            get { return GetProperty(MiddleNameProperty); }
            set { SetProperty(MiddleNameProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> ModifyDateProperty = RegisterProperty<SmartDate>(c => c.ModifyDate, null, new SmartDate(DateTime.Now));
        [Display(Name = "Last Modified Date")]
        public string ModifyDate
        {
            get { return GetPropertyConvert<SmartDate, string>(ModifyDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(ModifyDateProperty, value); }
        }


        protected override void OnChildChanged(Csla.Core.ChildChangedEventArgs e)
        {
            if (e.ChildObject is PartyAddresses)
            {
                BusinessRules.CheckRules(AddressesProperty);
                OnPropertyChanged(AddressesProperty);
            }
            base.OnChildChanged(e);
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

        public static void NewPersonEdit(EventHandler<DataPortalResult<PersonEdit>> callback)
        {
            DataPortal.BeginCreate<PersonEdit>(callback);
        }

        public static void GetPersonEdit(int id, EventHandler<DataPortalResult<PersonEdit>> callback)
        {
            DataPortal.BeginFetch<PersonEdit>(id, callback);
        }

#if !SILVERLIGHT
        public static PersonEdit NewPersonEdit()
        {
            return DataPortal.Create<PersonEdit>();
        }

        public static PersonEdit GetPersonEdit(int id)
        {
            return DataPortal.Fetch<PersonEdit>(id);
        }

        public static void DeletePersonEdit(int id)
        {
            DataPortal.Delete<PersonEdit>(id);
        }

        public static bool Exists(int id)
        {
            var cmd = new PartyExistsCommand(id);
            cmd = DataPortal.Execute<PartyExistsCommand>(cmd);
            return cmd.PartyExists;
        }

#endif

        #endregion

        #region Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            //var myAddress = AddressEdit.NewAddressEdit();
            //myAddress.Type = (int)AddressEdit.TypeAddress.Mailing;  
            //Addresses.Add(myAddress);

            Addresses.Assign(-1);

            base.DataPortal_Create();

        }

        private void DataPortal_Fetch(int id)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IRenterDAL>();
                var data = dal.Fetch(id);
                using (BypassPropertyChecks)
                {
                    RenterID = data.RenterID;
                    FirstName = data.FirstName;
                    MiddleName = data.MiddleName;
                    LastName = data.LastName;
                    CreateDate = data.CreateDate.ToShortDateString();
                    ModifyDate = data.ModifyDate.ToShortDateString();
                    Addresses = DataPortal.FetchChild<PartyAddresses>(id);

                }
            }
        }

        protected override void DataPortal_Insert()
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IRenterDAL>();
                using (BypassPropertyChecks)
                {

                    var mydate = FieldManager.GetFieldData(CreateDateProperty).Value;
                    var item = new MM.DAL.RenterDTO
                    {
                        FirstName = this.FirstName,
                        MiddleName = this.MiddleName,
                        LastName = this.LastName,
                        CreateDate = (SmartDate)mydate,
                        Addresses = Addresses.LoadAddresses(),
                        ContactInfoItems = ContactItems.LoadContactInfoItems()
                    };

                    dal.Insert(item);
                    RenterID = item.RenterID;

                }
                //FieldManager.UpdateChildren();
            }
        }

        protected override void DataPortal_Update()
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IRenterDAL>();
                using (BypassPropertyChecks)
                {
                    var item = new MM.DAL.RenterDTO
                    {
                        RenterID = this.RenterID,
                        FirstName = this.FirstName,
                        MiddleName = this.MiddleName,
                        LastName = this.LastName,
                        CreateDate = (DateTime)FieldManager.GetFieldData(CreateDateProperty).Value,
                    };
                    dal.Update(item);
                    FieldManager.GetFieldData(ModifyDateProperty).Value = item.ModifyDate;
                }
                FieldManager.UpdateChildren(this);
            }
        }

        protected override void DataPortal_DeleteSelf()
        {
            using (BypassPropertyChecks)
                DataPortal_Delete(this.RenterID);
        }

        private void DataPortal_Delete(int id)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                Addresses.Clear();
                FieldManager.UpdateChildren(this);
                var dal = ctx.GetProvider<MM.DAL.IRenterDAL>();
                dal.Delete(RenterID);
            }
        }



        #endregion




    }
}
 