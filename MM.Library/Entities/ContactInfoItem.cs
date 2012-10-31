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
        public static readonly PropertyInfo<int> IDProperty = RegisterProperty<int>(c => c.ID, RelationshipTypes.PrivateField);
        // [NotUndoable, NonSerialized]
        private int _id = IDProperty.DefaultValue;
        public int ID
        {
            get { return GetProperty(IDProperty, _id); }
            set { SetProperty(IDProperty, ref _id, value); }
        }

        /// <summary>
        /// The contact info value property
        /// </summary>
        public static readonly PropertyInfo<string> ContactInfoValueProperty = RegisterProperty<string>(c => c.ContactInfoValue, RelationshipTypes.PrivateField);
        // [NotUndoable, NonSerialized]
        private string _contactInfoValue = ContactInfoValueProperty.DefaultValue;
        public string ContactInfoValue
        {
            get { return GetProperty(ContactInfoValueProperty, _contactInfoValue); }
            set { SetProperty(ContactInfoValueProperty, ref _contactInfoValue, value); }
        }

        
        [Required]
        public virtual ContactInfoType ContactItemType { get; set; }

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
