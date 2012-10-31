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
    /// <summary>
    /// 
    /// </summary>
   [Serializable()]
    public class PartyEdit :BusinessBase<PartyEdit>
    {

        #region Business Methods

        [Display(Name = "Party ID")]
        [Required]
        public static readonly PropertyInfo<int> IDProperty = RegisterProperty<int>(c => c.ID, RelationshipTypes.PrivateField);
        private int _id = IDProperty.DefaultValue;
        public int ID
        {
            get { return GetProperty(IDProperty, _id); }
            private set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Display(Name = "First Name")]
        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName, RelationshipTypes.PrivateField);
        // [NotUndoable, NonSerialized]
        private string _firstName = FirstNameProperty.DefaultValue;
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty, _firstName); }
            set { SetProperty(FirstNameProperty, ref _firstName, value); }
        }


        /// <summary>
        /// The last name property
        /// </summary>
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "'LastName' is required")]
        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName, RelationshipTypes.PrivateField);
        // [NotUndoable, NonSerialized]
        private string _name = LastNameProperty.DefaultValue;
        public string LastName
        {
            get { return GetProperty(LastNameProperty, _name); }
            set { SetProperty(LastNameProperty, ref _name, value); }
        }


        /// <summary>
        /// The middle name property
        /// </summary>
        [Display(Name = "Middle Name")]
        public static readonly PropertyInfo<string> MiddleNameProperty = RegisterProperty<string>(c => c.MiddleName, RelationshipTypes.PrivateField);
        // [NotUndoable, NonSerialized]
        private string _middleName = MiddleNameProperty.DefaultValue;
        public string MiddleName
        {
            get { return GetProperty(MiddleNameProperty, _middleName); }
            set { SetProperty(MiddleNameProperty, ref _middleName, value); }
        }

        /// <summary>
        /// The create date property
        /// </summary>
        [Required]
        public static readonly PropertyInfo<DateTime> CreateDateProperty = RegisterProperty<DateTime>(c => c.CreateDate, RelationshipTypes.PrivateField);
        // [NotUndoable, NonSerialized]
        private DateTime _createDate = CreateDateProperty.DefaultValue;
        public DateTime CreateDate
        {
            get { return GetProperty(CreateDateProperty, _createDate); }
            set { SetProperty(CreateDateProperty, ref _createDate, value); }
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

        #region Factory Methods

 public static void NewPartyEdit(EventHandler<DataPortalResult<PartyEdit>> callback)
        {
            DataPortal.BeginCreate<PartyEdit>(callback);
        }

        public static void GetPartyEdit(int id, EventHandler<DataPortalResult<PartyEdit>> callback)
        {
            DataPortal.BeginFetch<PartyEdit>(id, callback);
        }

#if !SILVERLIGHT
        public static PartyEdit NewPartyEdit()
        {
            return DataPortal.Create<PartyEdit>();
        }

        public static PartyEdit GetPartyEdit(int id)
        {
            return DataPortal.Fetch<PartyEdit>(id);
        }

        public static void DeletePartyEdit(int id)
        {
            DataPortal.Delete<PartyEdit>(id);
        }

#endif

       #endregion

        #region Data Access

        private void DataPortal_Fetch(SingleCriteria<PartyEdit, int> criteria)
        {
            // TODO: load values into object
        }

        protected override void DataPortal_Insert()
        {
            // TODO: insert object's data
        }

        protected override void DataPortal_Update()
        {
            // TODO: update object's data
        }

        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<PartyEdit, int>(ReadProperty<int>(IDProperty)));
        }

        private void DataPortal_Delete(SingleCriteria<PartyEdit, int> criteria)
        {
            // TODO: delete object's data
        }

        #endregion



   }

}
