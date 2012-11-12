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
    public class ContactInfoItemEdit : BusinessBase<ContactInfoItemEdit>
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
        /// The contact info value property
        /// </summary>
        public static readonly PropertyInfo<string> ContactInfoValueProperty = RegisterProperty<string>(c => c.ContactInfoValue);
        public string ContactInfoValue
        {
            get { return GetProperty(ContactInfoValueProperty); }
            set { SetProperty(ContactInfoValueProperty, value); }
        }


        /// <summary>
        /// The contact info type property
        /// </summary>
        [Required]
        [Display(Name = "ContactInfo Type")]
        public static readonly PropertyInfo<int> ContactInfoTypeProperty = RegisterProperty<int>(c => c.Type);
        public int Type
        {
            get { return GetProperty(ContactInfoTypeProperty); }
            set
            {
                SetProperty(ContactInfoTypeProperty, value);
                OnPropertyChanged("ContactInfoType");
            }
        }

        [Display(Name = "Type")]
        public string ContactInfoType
        {
            get
            {
                var result = "none";
                if (Collections.ContactInfoTypeList.GetList().ContainsKey(Type))
                    result = Collections.ContactInfoTypeList.GetList().GetItemByKey(Type).Value;
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

    }
}
