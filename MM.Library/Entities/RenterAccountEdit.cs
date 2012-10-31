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
   public class RenterAccountEdit : BusinessBase<RenterAccountEdit>
   {
       #region Business Methods

       public static readonly PropertyInfo<int> IDProperty = RegisterProperty<int>(c => c.ID, RelationshipTypes.PrivateField);
       // [NotUndoable, NonSerialized]
       private int _id = IDProperty.DefaultValue;
       public int ID
       {
           get { return GetProperty(IDProperty, _id); }
           set { SetProperty(IDProperty, ref _id, value); }
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

       public static void NewRenterAccountEdit(EventHandler<DataPortalResult<RenterAccountEdit>> callback)
       {
           DataPortal.BeginCreate<RenterAccountEdit>(callback);
       }

       public static void GetRenterAccountEdit(int id, EventHandler<DataPortalResult<RenterAccountEdit>> callback)
       {
           DataPortal.BeginFetch<RenterAccountEdit>(id, callback);
       }

#if !SILVERLIGHT
       public static RenterAccountEdit NewRenterAccountEdit()
       {
           return DataPortal.Create<RenterAccountEdit>();
       }

       public static RenterAccountEdit GetRenterAccountEdit(int id)
       {
           return DataPortal.Fetch<RenterAccountEdit>(id);
       }

       public static void DeleteRenterAccountEdit(int id)
       {
           DataPortal.Delete<RenterAccountEdit>(id);
       }

#endif
       #endregion

       #region Data Access

       private void DataPortal_Fetch(SingleCriteria<RenterAccountEdit, int> criteria)
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
           DataPortal_Delete(new SingleCriteria<RenterAccountEdit, int>(ReadProperty<int>(IDProperty)));
       }

       private void DataPortal_Delete(SingleCriteria<RenterAccountEdit, int> criteria)
       {
           // TODO: delete object's data
       }

       #endregion
   
   
   }
}
