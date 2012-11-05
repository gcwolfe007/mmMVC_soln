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
        public static readonly PropertyInfo<int> IDProperty = RegisterProperty<int>(c => c.ID);
        public int ID
        {
            get { return GetProperty(IDProperty); }
            set { SetProperty(IDProperty, value); }
        }

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
