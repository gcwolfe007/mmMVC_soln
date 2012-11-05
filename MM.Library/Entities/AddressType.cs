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
    public class AddressType :BusinessBase<AddressType>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> AddressTypeIDProperty = RegisterProperty<int>(c => c.AddressTypeID);
        public int AddressTypeID
        {
            get { return GetProperty(AddressTypeIDProperty); }
            private set { LoadProperty(AddressTypeIDProperty, value); }
        }

        [Required]
        public static readonly PropertyInfo<string> TypeNameProperty = RegisterProperty<string>(c => c.TypeName);
        public string TypeName
        {
            get { return GetProperty(TypeNameProperty); }
            set { SetProperty(TypeNameProperty, value); }
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
    }
}
