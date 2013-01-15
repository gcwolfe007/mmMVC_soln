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
    public class PersonEdit : BusinessBase<PersonEdit>
    {

        #region Business Methods



        [Key]
        public static readonly PropertyInfo<int> RenterIDProperty = RegisterProperty<int>(c => c.RenterID);
        /// <summary>
        /// Gets the renter ID.
        /// </summary>
        /// <value>
        /// The renter ID.
        /// </value>
        public int RenterID
        {
            get { return GetProperty(RenterIDProperty); }
            private set { LoadProperty(RenterIDProperty, value); }
        }
        
        /// <summary>
        /// The create date property
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CreateDateProperty =
            RegisterProperty<SmartDate>(c => c.CreateDate, null, new SmartDate(DateTime.Now));
        [Display(Name = "Create Date")]
        [Required(ErrorMessage = "'A Create Date' is required")] 
        public string CreateDate
        {
            get { return GetPropertyConvert<SmartDate, string>(CreateDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(CreateDateProperty, value); }
        }


        public static readonly PropertyInfo<int> CreateUserProperty = RegisterProperty<int>(c => c.CreateUser);
        public int CreateUser
        {
            get { return GetProperty(CreateUserProperty); }
            set { SetProperty(CreateUserProperty, value); }
        }
        
        
        /// <summary>
        /// The addresses property
        /// </summary>
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

        /// <summary>
        /// The contact items property
        /// </summary>
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

        public static readonly PropertyInfo<string> EmailProperty = RegisterProperty<string>(c => c.Email);

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "'Email address' is required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Must provide a valid Email address.")]
        public string Email
        {
            get { return GetProperty(EmailProperty); }
            set { SetProperty(EmailProperty, value); }
        }

        public static readonly PropertyInfo<string> FriendlyNameProperty = RegisterProperty<string>(c => c.FriendlyName);
        [Display(Name = "Preferred Name")]
        public string FriendlyName
        {
            get { return GetProperty(FriendlyNameProperty); }
            set { SetProperty(FriendlyNameProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> ModifyDateProperty = RegisterProperty<SmartDate>(c => c.ModifyDate, null, new SmartDate(DateTime.Now));
        [Display(Name = "Last Modified Date")]
        public string ModifyDate
        {
            get { return GetPropertyConvert<SmartDate, string>(ModifyDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(ModifyDateProperty, value); }
        }

        public static readonly PropertyInfo<string> FullNameProperty = RegisterProperty<string>(c => c.FullName);
        [Display(Name="Tenant Name")] 
        public string FullName
        {
            get
            {
                    return GetProperty(FirstNameProperty) + " " 
                    + GetProperty(MiddleNameProperty) + " "
                    + GetProperty(LastNameProperty); 
            }
            private set { LoadProperty(FullNameProperty, value); }
        }


        public override string ToString()
        {
            var fullname = GetProperty(FirstNameProperty) + " " + GetProperty(MiddleNameProperty) + " " + GetProperty(LastNameProperty);

            return fullname;
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
            //BusinessRules.AddRule(new StartDateGTEndDate { PrimaryProperty = StartedProperty, AffectedProperties = { EndedProperty } });
            //BusinessRules.AddRule(new StartDateGTEndDate { PrimaryProperty = EndedProperty, AffectedProperties = { StartedProperty } });

            //BusinessRules.AddRule(new Csla.Rules.CommonRules.IsInRole(Csla.Rules.AuthorizationActions.WriteProperty, NameProperty, "ProjectManager"));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.IsInRole(Csla.Rules.AuthorizationActions.WriteProperty, StartedProperty, "ProjectManager"));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.IsInRole(Csla.Rules.AuthorizationActions.WriteProperty, EndedProperty, "ProjectManager"));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.IsInRole(Csla.Rules.AuthorizationActions.WriteProperty, DescriptionProperty, "ProjectManager"));
            //BusinessRules.AddRule(new NoDuplicateResource { PrimaryProperty = ResourcesProperty });
        }

        #endregion

        #region Authorization Rules

        private static void AddObjectAuthorizationRules()
        {
            // TODO: add object-level authorization rules
            Csla.Rules.BusinessRules.AddRule(typeof(PersonEdit),
                new Csla.Rules.CommonRules.IsInRole
                    (Csla.Rules.AuthorizationActions.CreateObject, "Administrator"));
            Csla.Rules.BusinessRules.AddRule(typeof(PersonEdit),
                new Csla.Rules.CommonRules.IsInRole
                    (Csla.Rules.AuthorizationActions.EditObject, "Administrator"));
            Csla.Rules.BusinessRules.AddRule(typeof(PersonEdit), 
                new Csla.Rules.CommonRules.IsInRole
                    (Csla.Rules.AuthorizationActions.DeleteObject, "ProjectManager", "Administrator"));
            Csla.Rules.BusinessRules.AddRule(typeof(PersonEdit),
               new Csla.Rules.CommonRules.IsInRole
                   (Csla.Rules.AuthorizationActions.GetObject, "ProjectManager", "Administrator"));
        }

        #endregion

        #region Factory Methods

        public static PersonEdit NewPersonEdit()
        {
            return DataPortal.Create<PersonEdit>();
        }

        public static PersonEdit GetPersonEdit(int id)
        {
            return DataPortal.Fetch<PersonEdit>(id);
        }

        public static PersonEdit GetPersonEdit(MM.DAL.RenterDTO myDTO)
        {
           return DataPortal.Fetch<PersonEdit>(myDTO);
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

        #endregion

        #region Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            //var myAddress = AddressEdit.NewAddressEdit();
            //myAddress.Type = (int)AddressEdit.TypeAddress.Mailing;  
            //Addresses.Add(myAddress);

            


            Addresses.Assign(-1);

            var result = ContactInfoTypeList.GetList().GetItemByValue("Home Phone").Key;

            ContactItems.Assign(-1, result);

            base.DataPortal_Create();

        }

        private void Child_Fetch(MM.DAL.RenterDTO mydto)
        {
            var data = mydto;
            using (BypassPropertyChecks)
            {
                RenterID = data.RenterID;
                FirstName = data.FirstName;
                MiddleName = data.MiddleName;
                LastName = data.LastName;
                CreateDate = data.CreateDate.ToShortDateString();
                ModifyDate = data.ModifyDate.ToShortDateString();
                Addresses = DataPortal.FetchChild<PartyAddresses>(mydto);

            }
        
        
        }
        private void DataPortal_Fetch(MM.DAL.RenterDTO mydto)
        {

            var data = mydto;
            using (BypassPropertyChecks)
            {
                RenterID = data.RenterID;
                FirstName = data.FirstName;
                MiddleName = data.MiddleName;
                LastName = data.LastName;
                CreateDate = data.CreateDate.ToShortDateString();
                ModifyDate = data.ModifyDate.ToShortDateString();
                Addresses = DataPortal.FetchChild<PartyAddresses>(mydto);

            }
        
        
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
                var dal = ctx.GetProvider<MM.DAL.IRenterAccountDAL>();
                using (BypassPropertyChecks)
                {

                    var mydate = FieldManager.GetFieldData(CreateDateProperty).Value;
                    var item = new MM.DAL.RenterDTO
                    {
                        FirstName = this.FirstName,
                        MiddleName = this.MiddleName,
                        LastName = this.LastName,
                        Email = this.Email,
                        CreateUserID = this.CreateUser, 
                        CreateDate = (SmartDate)mydate,
                        Addresses = Addresses.LoadAddresses(),
                        ContactInfoItems = ContactItems.LoadContactInfoItems()
                    };

                    var myDTO = new MM.DAL.RenterAccountDTO();
                    myDTO.Renter = item;

                    dal.Insert(myDTO);
                    RenterID = myDTO.Renter.RenterID;

                }
                //FieldManager.UpdateChildren();
            }
        }

        protected override void DataPortal_Update()
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IRenterAccountDAL>();
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
                var dal = ctx.GetProvider<MM.DAL.IRenterAccountDAL>();
                dal.Delete(RenterID);
            }
        }



        #endregion




    }
}
 