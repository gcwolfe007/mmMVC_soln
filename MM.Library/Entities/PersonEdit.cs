using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Csla;
using MM.Library.Collections;

namespace MM.Library.Entities
{
    public class PersonEdit : BusinessBase<PersonEdit> , IRentingParty
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
        
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Display(Name = "First Name")]
        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty); }
            set { SetProperty(FirstNameProperty, value); }
        }
       
        /// <summary>
        /// The last name property
        /// </summary>
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "'LastName' is required")]
        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
            set { SetProperty(LastNameProperty, value); }
        }

        /// <summary>
        /// The middle name property
        /// </summary>
        [Display(Name = "Middle Name")]
        public static readonly PropertyInfo<string> MiddleNameProperty = RegisterProperty<string>(c => c.MiddleName);
        public string MiddleName
        {
            get { return GetProperty(MiddleNameProperty); }
            set { SetProperty(MiddleNameProperty, value); }
        }





    }
}
