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

        public static readonly PropertyInfo<int> IDProperty = RegisterProperty<int>(c => c.ID, RelationshipTypes.PrivateField);
        private int _id = IDProperty.DefaultValue;
        public int ID
        {
            get { return GetProperty(IDProperty, _id); }
            private set { _id = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly PropertyInfo<string> LineOneProperty =
            RegisterProperty<string>(c => c.LineOne, RelationshipTypes.PrivateField);
        private string _lineone = LineOneProperty.DefaultValue;
        public string LineOne
        {
            get { return GetProperty(LineOneProperty, _lineone); }
            private set { _lineone = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly PropertyInfo<string> LineTwoProperty =
            RegisterProperty<string>(c => c.LineTwo, RelationshipTypes.PrivateField);
        private string _linetwo = LineTwoProperty.DefaultValue;
        public string LineTwo
        {
            get { return GetProperty(LineTwoProperty, _linetwo); }
            private set { _linetwo = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly PropertyInfo<string> CityProperty =
            RegisterProperty<string>(c => c.City, RelationshipTypes.PrivateField);
        private string _city = CityProperty.DefaultValue;
        public string City
        {
            get { return GetProperty(CityProperty, _city); }
            private set { _city = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly PropertyInfo<string> StateProvinceProperty =
            RegisterProperty<string>(c => c.StateProvince, RelationshipTypes.PrivateField);
        private string _stateProvince = StateProvinceProperty.DefaultValue;
        public string StateProvince
        {
            get { return GetProperty(StateProvinceProperty, _stateProvince); }
            private set { _stateProvince = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly PropertyInfo<string> PostalCodeProperty =
            RegisterProperty<string>(c => c.PostalCode, RelationshipTypes.PrivateField);
        private string _postalCode = PostalCodeProperty.DefaultValue;
        public string PostalCode
        {
            get { return GetProperty(PostalCodeProperty, _postalCode); }
            private set { _postalCode = value; }
        }

        public static readonly PropertyInfo<string> CountryProperty = RegisterProperty<string>(c => c.Country, RelationshipTypes.PrivateField);
        // [NotUndoable, NonSerialized]
        private string _country = CountryProperty.DefaultValue;
        public string Country
        {
            get { return GetProperty(CountryProperty, _country); }
            set { SetProperty(CountryProperty, ref _country, value); }
        }

        public static readonly PropertyInfo<AddressType> AddressTypeProperty = RegisterProperty<AddressType>(c => c.AddressType, RelationshipTypes.PrivateField);
        // [NotUndoable, NonSerialized]
        private AddressType _addressType = AddressTypeProperty.DefaultValue;
        public AddressType AddressType
        {
            get { return GetProperty(AddressTypeProperty, _addressType); }
            set { SetProperty(AddressTypeProperty, ref _addressType, value); }
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

        public static void NewAddressEdit(EventHandler<DataPortalResult<AddressEdit>> callback)
        {
            DataPortal.BeginCreate<AddressEdit>(callback);
        }

        public static void GetAddressEdit(int id, EventHandler<DataPortalResult<AddressEdit>> callback)
        {
            DataPortal.BeginFetch<AddressEdit>(id, callback);
        }

#if !SILVERLIGHT
        public static AddressEdit NewAddressEdit()
        {
            return DataPortal.Create<AddressEdit>();
        }

        public static AddressEdit GetAddressEdit(int id)
        {
            return DataPortal.Fetch<AddressEdit>(id);
        }

        public static void DeleteAddressEdit(int id)
        {
            DataPortal.Delete<AddressEdit>(id);
        }

#endif
        
        
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
            DataPortal_Delete(new SingleCriteria<AddressEdit, int>(ReadProperty<int>(IDProperty)));
        }

        private void DataPortal_Delete(SingleCriteria<AddressEdit, int> criteria)
        {
            // TODO: delete object's data
        }

        #endregion
    
    }
}
