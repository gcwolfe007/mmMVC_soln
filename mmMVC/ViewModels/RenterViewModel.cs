using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MM.Library.Entities;
using MM.Library.Collections;
using System.ComponentModel.DataAnnotations;


namespace mmMVC.ViewModels
{   
   

    public class RenterViewModel : Csla.Web.Mvc.ViewModelBase<PersonEdit>
    {
        private PartyAddresses _addressesEdit;
        private PartyContactInfoItems _contactInfoItems;

        public RenterViewModel()
        {
            ModelObject = PersonEdit.NewPersonEdit();
            _addressesEdit = ModelObject.Addresses;
            _contactInfoItems = ModelObject.ContactItems;
        }

        [Display(Name = "Address First Line")]
        public string LineOne
        {
            get
            {
                return _addressesEdit[0].LineOne;
            }
            set
            {
                _addressesEdit[0].LineOne = value;
            }

        }

        [Display(Name = "Address Second Line")]
        public string LineTwo
        {
            get
            {
                return _addressesEdit[0].LineTwo;
            }
            set
            {
                _addressesEdit[0].LineTwo = value;
            }

        }

        [Display(Name = "City/Town")]
        public string CityTown
        {
            get
            {
                return _addressesEdit[0].CityTown;
            }
            set
            {
                _addressesEdit[0].CityTown = value;
            }

        }

        [Display(Name = "State/Province")]
        public string StateProvince
        {
            get
            {
                return _addressesEdit[0].StateProvince;
            }
            set
            {
                _addressesEdit[0].StateProvince = value;
            }

        }

        [Display(Name = "Postal Code")]
        public string PostalCode
        {
            get
            {
                return _addressesEdit[0].PostalCode;
            }
            set
            {
                _addressesEdit[0].PostalCode = value;
            }

        }

        [Display(Name = "Email Adderss")]
        [Required(ErrorMessage="Email Address is Required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Must provide valid Email address.")]
        public string Email 
        {
            get
            {
                return _contactInfoItems[0].ContactInfoItem;
            }
            set 
            {
                _contactInfoItems[0].ContactInfoItem = value;          
            }
        }








    }
}