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
    public class PartyType : BusinessBase<PartyType>
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
        public static readonly PropertyInfo<string> ContactInfoValueProperty = RegisterProperty<string>(c => c.PartyTypeValue, RelationshipTypes.PrivateField);
        // [NotUndoable, NonSerialized]
        private string _partyTypeValue = ContactInfoValueProperty.DefaultValue;
        public string PartyTypeValue
        {
            get { return GetProperty(ContactInfoValueProperty, _partyTypeValue); }
            set { SetProperty(ContactInfoValueProperty, ref _partyTypeValue, value); }
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
