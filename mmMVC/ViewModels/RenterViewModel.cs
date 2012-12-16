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
        public RenterViewModel()
        {
            ModelObject = PersonEdit.NewPersonEdit();
            _addressesEdit = ModelObject.Addresses;
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


    }
}