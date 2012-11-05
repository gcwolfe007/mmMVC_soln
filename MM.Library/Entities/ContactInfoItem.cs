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
    public class ContactInfoItem : BusinessBase<ContactInfoItem>
    {
        #region Business Methods

        /// <summary>
        /// The ID property
        /// </summary>
        public static readonly PropertyInfo<int> ContactInfoItemIDProperty = RegisterProperty<int>(c => c.ContactInfoItemID);
        public int ContactInfoItemID
        {
            get { return GetProperty(ContactInfoItemIDProperty); }
            private set { LoadProperty(ContactInfoItemIDProperty, value); }
        }

        /// <summary>
        /// The contact info valve property
        /// </summary>
        public static readonly PropertyInfo<string> ContactInfoValveProperty = RegisterProperty<string>(c => c.ContactInfoValve);
        public string ContactInfoValve
        {
            get { return GetProperty(ContactInfoValveProperty); }
            set { SetProperty(ContactInfoValveProperty, value); }
        }


        /// <summary>
        /// The contact info type property
        /// </summary>
        [Required]
        public static readonly PropertyInfo<ContactInfoType> ContactInfoTypeProperty = RegisterProperty<ContactInfoType>(c => c.ContactInfoType);
        public ContactInfoType ContactInfoType
        {
            get { return GetProperty(ContactInfoTypeProperty); }
            set { SetProperty(ContactInfoTypeProperty, value); }
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
