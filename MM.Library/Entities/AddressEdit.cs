using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Csla;
using Csla.Data;
using Csla.Security;
using Csla.Serialization;
using System.ComponentModel;

namespace MM.Library.Entities
{

    [Serializable()]
    public class AddressEdit :BusinessBase<AddressEdit>
    {
        #region Business Methods

        public enum TypeAddress
        {
            Mailing=0,
            Home=1,
            Work=2,
            Shipping=3
        }


        public static readonly PropertyInfo<int> AddressIDProperty = RegisterProperty<int>(c => c.AddressID);
        public int AddressID
        {
            get { return GetProperty(AddressIDProperty); }
            private set { LoadProperty(AddressIDProperty, value); }
        }

        public static readonly PropertyInfo<string> LineOneProperty = RegisterProperty<string>(c => c.LineOne);
        [Display(Name="Address First Line")]
        public string LineOne
        {
            get { return GetProperty(LineOneProperty); }
            set { SetProperty(LineOneProperty, value); }
        }

        public static readonly PropertyInfo<string> LineTwoProperty = RegisterProperty<string>(c => c.LineTwo);
       [Display(Name = "Address Second Line")]
        public string LineTwo
        {
            get { return GetProperty(LineTwoProperty); }
            set { SetProperty(LineTwoProperty, value); }
        }
        
        public static readonly PropertyInfo<string> LineThreeProperty = RegisterProperty<string>(c => c.LineThree);
        [Display(Name = "Address Third Line")]
        public string LineThree
        {
            get { return GetProperty(LineThreeProperty); }
            set { SetProperty(LineThreeProperty, value); }
        }

        public static readonly PropertyInfo<string> CityTownProperty = RegisterProperty<string>(c => c.CityTown);
        [Display(Name = "City/Town")]
        public string CityTown
        {
            get { return GetProperty(CityTownProperty); }
            set { SetProperty(CityTownProperty, value); }
        }

        public static readonly PropertyInfo<string> StateProvinceProperty = RegisterProperty<string>(c => c.StateProvince);
        [Display(Name = "State")]
        public string StateProvince
        {
            get { return GetProperty(StateProvinceProperty); }
            set { SetProperty(StateProvinceProperty, value); }
        }


        public static readonly PropertyInfo<string> PostalCodeProperty = RegisterProperty<string>(c => c.PostalCode);
        [Display(Name = "ZipCode")]
        public string PostalCode
        {
            get { return GetProperty(PostalCodeProperty); }
            set { SetProperty(PostalCodeProperty, value); }
        }

        public static readonly PropertyInfo<string> CountryProperty = RegisterProperty<string>(c => c.Country);
        public string Country
        {
            get { return GetProperty(CountryProperty); }
            set { SetProperty(CountryProperty, value); }
        }

        [Required]
        [Display(Name = "Address Type")]
        public static readonly PropertyInfo<int> AddressTypeProperty = RegisterProperty<int>(c => c.Type);
        public int Type
        {
            get { return GetProperty(AddressTypeProperty); }
            set
            {
                SetProperty(AddressTypeProperty, value);
                OnPropertyChanged("AddressType");
            }
        }

        public static readonly PropertyInfo<DateTime> AssignedProperty =
        RegisterProperty<DateTime>(c => c.Assigned);
        [Display(Name = "Date assigned")]
        public DateTime Assigned
        {
            get { return GetProperty(AssignedProperty); }
            private set { LoadProperty(AssignedProperty, value); }
        }

        [Display(Name = "Type")]
        public string AddressType
        {
            get
            {
                var result = "none";
                if (Collections.AddressTypeList.GetList().ContainsKey(Type))
                    result = Collections.AddressTypeList.GetList().GetItemByKey(Type).Value;
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

        public static AddressEdit NewAddressEdit()
        {
            return DataPortal.CreateChild<AddressEdit>();
        }

        public static AddressEdit GetAddressEdit(int id)
        {
            return DataPortal.Fetch<AddressEdit>(id);
        }

        public static void DeleteAddressEdit(int id)
        {
            DataPortal.Delete<AddressEdit>(id);
        }
        
        #endregion

        #region Data Access

        private void DataPortal_Fetch(SingleCriteria<AddressEdit, int> criteria)
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
            DataPortal_Delete(new SingleCriteria<AddressEdit, int>(ReadProperty<int>(AddressIDProperty)));
        }

        private void DataPortal_Delete(SingleCriteria<AddressEdit, int> criteria)
        {
            // TODO: delete object's data
        }

        #endregion
    
    }
}
