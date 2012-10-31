using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Csla;
using Csla.Data;
using Csla.Security;
using Csla.Serialization;
using System.ComponentModel;

namespace MM.Library
{
    public class AddressType :BusinessBase<AddressType>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> IDProperty = RegisterProperty<int>(c => c.ID, RelationshipTypes.PrivateField);
        private int _id = IDProperty.DefaultValue;
        public int ID
        {
            get { return GetProperty(IDProperty, _id); }
            private set { _id = value; }
        }

        [Required]
        public static readonly PropertyInfo<string> TypeNameProperty = RegisterProperty<string>(c => c.TypeName, RelationshipTypes.PrivateField);
        // [NotUndoable, NonSerialized]
        private string _typeName = TypeNameProperty.DefaultValue;
        public string TypeName
        {
            get { return GetProperty(TypeNameProperty, _typeName); }
            set { SetProperty(TypeNameProperty, ref _typeName, value); }
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
