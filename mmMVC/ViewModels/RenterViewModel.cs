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
        private AddressesEdit _addressesEdit;
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
    }
}