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
    public class PartyAddressEdit : BusinessBase<PartyAddressEdit>
    {
        #region Business Methods

        public enum TypeAddress
        {
            Mailing = 0,
            Home = 1,
            Work = 2,
            Shipping = 3
        }


        public static readonly PropertyInfo<int> AddressIDProperty = RegisterProperty<int>(c => c.AddressID);
        public int AddressID
        {
            get { return GetProperty(AddressIDProperty); }
            private set { LoadProperty(AddressIDProperty, value); }
        }

        public static readonly PropertyInfo<string> LineOneProperty = RegisterProperty<string>(c => c.LineOne);
        [Display(Name = "Address First Line")]
        public string LineOne
        {
            get { return GetProperty(LineOneProperty); }
            set { SetProperty(LineOneProperty, value); }
        }

        public static readonly PropertyInfo<string> LineTwoProperty = RegisterProperty<string>(c => c.LineTwo);
        public string LineTwo
        {
            get { return GetProperty(LineTwoProperty); }
            set { SetProperty(LineTwoProperty, value); }
        }

        public static readonly PropertyInfo<string> LineThreeProperty = RegisterProperty<string>(c => c.LineThree);
        public string LineThree
        {
            get { return GetProperty(LineThreeProperty); }
            set { SetProperty(LineThreeProperty, value); }
        }
        
        public static readonly PropertyInfo<string> CityTownProperty = RegisterProperty<string>(c => c.CityTown);
        public string CityTown
        {
            get { return GetProperty(CityTownProperty); }
            set { SetProperty(CityTownProperty, value); }
        }

        public static readonly PropertyInfo<string> StateProvinceProperty = RegisterProperty<string>(c => c.StateProvince);
        public string StateProvince
        {
            get { return GetProperty(StateProvinceProperty); }
            set { SetProperty(StateProvinceProperty, value); }
        }


        public static readonly PropertyInfo<string> PostalCodeProperty = RegisterProperty<string>(c => c.PostalCode);
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

        public static readonly PropertyInfo<DateTime> AssignedProperty =
        RegisterProperty<DateTime>(c => c.Assigned);
        [Display(Name = "Date assigned")]
        public DateTime Assigned
        {
            get { return GetProperty(AssignedProperty); }
            private set { LoadProperty(AssignedProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> ModifyDateProperty = RegisterProperty<SmartDate>(c => c.ModifyDate, null, new SmartDate(DateTime.Now));
        [Display(Name="Last Modified Date")]
        public string ModifyDate
        {
            get { return GetPropertyConvert<SmartDate, string>(ModifyDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(ModifyDateProperty, value); }
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

#if !SILVERLIGHT
        /// <summary>
        /// Used when you Have an Address in the db and want to add to Party(Renter)
        /// </summary>      ,.
        /// <param name="addressId">The address id.</param>
        private void Child_Create(int addressId)
        {
            using (BypassPropertyChecks)
            {
               
                AddressID = addressId;
                Type = Collections.AddressTypeList.DefaultType();
                LoadProperty(AssignedProperty, DateTime.Today);

                using (var ctx = MM.DAL.DalFactory.GetManager())
                {
                    var dal = ctx.GetProvider<MM.DAL.IAddressDAL>();
                    var address = dal.Fetch(addressId);
                    LineOne = address.LineOne;
                    LineTwo = address.LineTwo;
                    LineThree = address.LineThree;
                    CityTown = address.CityTown;
                    StateProvince = address.StateProvince;
                    PostalCode = address.PostalCode;                   
                    Country = address.Country;

                }
            }
            base.Child_Create();
        }


        private void Child_Create()
        {
            AddressID = -1;
            Type = (int)TypeAddress.Mailing;            
            //Type = Collections.AddressTypeList.DefaultType();
            LoadProperty(AssignedProperty, DateTime.Now);
                        
            base.Child_Create();
        }
        
        
        private void Child_Fetch(int partyID, int addressId)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IAddressAssignmentDAL>();
                var data = dal.Fetch(partyID, addressId);
                Child_Fetch(data);
            }
        }

        private void Child_Fetch(MM.DAL.AddressAssignmentDTO data)
        {
            using (BypassPropertyChecks)
            {                              
                AddressID = data.AddressID;
                Type = data.AddressType;
                LoadProperty(AssignedProperty, data.Assigned);

                var query = from address in data.AddressList
                            where address.AddressID == AddressID
                            select address;

                var myaddress = query.FirstOrDefault();
                LineOne = myaddress.LineOne;
                LineTwo = myaddress.LineTwo;
                LineThree = myaddress.LineThree;
                CityTown = myaddress.CityTown;
                StateProvince = myaddress.StateProvince;
                PostalCode = myaddress.PostalCode;
                Country = myaddress.Country;

                //Rocky's method of calling the DAL again
                //using (var ctx = MM.DAL.DalFactory.GetManager())
                //{
                //    var dal = ctx.GetProvider<MM.DAL.IAddressDAL>();
                //    var address = dal.Fetch(data.AddressID);
                //    LineOne = address.LineOne;
                //    LineTwo = address.LineTwo;
                //    LineThree = address.LineThree;
                //    CityTown = address.CityTown;
                //    StateProvince = address.StateProvince;
                //    PostalCode = address.PostalCode;
                //    Country = address.Country;
                //}
            }
        }
        
        
        private void Child_Insert(PersonEdit person)
        {
            Child_Insert(person.RenterID);
        }

        private void Child_Insert(int renterID)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IAddressAssignmentDAL>();
                using (BypassPropertyChecks)
                {
                    var item = new MM.DAL.AddressAssignmentDTO
                    {
                        RenterID = renterID,
                        AddressID = this.AddressID,
                        Assigned = ReadProperty(AssignedProperty),
                        AddressType = this.Type,
                        ModifyDate = ModifyDateProperty.DefaultValue,
                    };
                    dal.Insert(item);                    
                }
            }
        }

        private void Child_Update(PersonEdit person)
        {
            Child_Update(person.RenterID);
        }

        private void Child_Update(int renterID)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IAddressAssignmentDAL>();
                using (BypassPropertyChecks)
                {
                    var item = dal.Fetch(renterID, AddressID);
                    item.Assigned = ReadProperty(AssignedProperty);
                    item.AddressType = Type;
                    item.ModifyDate = ModifyDateProperty.DefaultValue;
                    dal.Update(item);
                 
                }
            }
        }

        private void Child_DeleteSelf(PersonEdit person)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IAddressAssignmentDAL>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(person.RenterID, AddressID);
                }
            }
        }
#endif
    }
}
