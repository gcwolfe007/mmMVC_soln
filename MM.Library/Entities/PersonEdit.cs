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
    public class PersonEdit : BusinessBase<PersonEdit> , IRentingParty
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

        public static readonly PropertyInfo<AddressesEdit> AddressesProperty =
            RegisterProperty<AddressesEdit>(c => c.Addresses, RelationshipTypes.Child);
        public AddressesEdit Addresses
        {
            get
            {
                if (!(FieldManager.FieldExists(AddressesProperty)))
                    LoadProperty(AddressesProperty, DataPortal.CreateChild<AddressesEdit>());
                return GetProperty(AddressesProperty);
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
#endif

   #endregion

        #region Data Access
        
        [RunLocal]
        private void DataPortal_Create()
        {
            var myAddress = AddressEdit.NewAddressEdit();
            myAddress.Type = (int)AddressEdit.TypeAddress.Mailing;
            
          

            Addresses.Add(myAddress);

        }

        private void DataPortal_Fetch(SingleCriteria<PersonEdit, int> criteria)
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
            DataPortal_Delete(new SingleCriteria<PersonEdit, int>(ReadProperty<int>(RenterIDProperty)));
        }

        private void DataPortal_Delete(SingleCriteria<PersonEdit, int> criteria)
        {
            // TODO: delete object's data
        }

        #endregion

    }
}
 