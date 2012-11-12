using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using System.ComponentModel.DataAnnotations;
using MM.Library.Collections;


namespace MM.Library.Entities
{
    public class CompanyEdit : BusinessBase<CompanyEdit>, IRentingParty
    {
        #region IRentingParty Members


        public static readonly PropertyInfo<int> RenterIDProperty = RegisterProperty<int>(c => c.RenterID);
        public int RenterID
        {
            get { return GetProperty(RenterIDProperty); }
            private set { LoadProperty(RenterIDProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(c => c.CreateDate, null, new SmartDate());
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

        [Required]
        [Display(Name = "Company Name")]
        public static readonly PropertyInfo<string> CompanyNameProperty = RegisterProperty<string>(c => c.CompanyName);
        public string CompanyName
        {
            get { return GetProperty(CompanyNameProperty); }
            set { SetProperty(CompanyNameProperty, value); }
        }


    }
}
