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
   [Serializable]
   public class RenterAccountEdit : BusinessBase<RenterAccountEdit>
   {
       #region Business Methods

       private RenterEditCreator.RenterType _newRenterType;

       /// <summary>
       /// The ID property
       /// </summary>
       public static readonly PropertyInfo<int> RenterAccountIDProperty = RegisterProperty<int>(c => c.RenterAccountID,"Account ID");
       public int RenterAccountID
       {
           get { return GetProperty(RenterAccountIDProperty); }
           private set { LoadProperty(RenterAccountIDProperty, value); }
       }

       public static readonly PropertyInfo<IRentingParty> RenterProperty = RegisterProperty<IRentingParty>(c => c.Renter, RelationshipTypes.Child);
       public IRentingParty Renter
       {
           get
           {
               if (!(FieldManager.FieldExists(RenterProperty)))
               {
                   var creator = RenterEditCreator.GetRenterEditCreator(_newRenterType);
                   Renter = creator.Result;
       //            LoadProperty(RenterProperty, DataPortal.CreateChild<IRentingParty>());
               }
               return GetProperty(RenterProperty);

       
              
           }
           private set { SetProperty(RenterProperty, value); }
       }
    
       public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(c => c.CreateDate, null, new SmartDate());
       [Display(Name = "Create Date")]
       [Required(ErrorMessage = "'Create Date' is required")]
       public string CreateDate
       {
           get { return GetPropertyConvert<SmartDate, string>(CreateDateProperty); }
           set { SetPropertyConvert<SmartDate, string>(CreateDateProperty, value); }
       }

       public static readonly PropertyInfo<int> CreateUserIDProperty = RegisterProperty<int>(c => c.CreateUserID);
       public int CreateUserID
       {
           get { return GetProperty(CreateUserIDProperty); }
           set { SetProperty(CreateUserIDProperty, value); }
       }

       public static readonly PropertyInfo<string> AccountNumberProperty = RegisterProperty<string>(c => c.AccountNumber);
       public string AccountNumber
       {
           get { return GetProperty(AccountNumberProperty); }
           set { SetProperty(AccountNumberProperty, value); }
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
       public static RenterAccountEdit NewRenterAccountEdit(int renterType)
       {
           return DataPortal.Create<RenterAccountEdit>(new RenterTypeCriteria { RenterType = renterType });
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


       [Serializable]
       public class RenterTypeCriteria : CriteriaBase<RenterTypeCriteria>
       {
           public static readonly PropertyInfo<int> RenterTypeProperty = RegisterProperty<int>(c => c.RenterType);
           public int RenterType
           {
               get { return ReadProperty(RenterTypeProperty); }
               set { LoadProperty(RenterTypeProperty, value); }
           }
       }

        [RunLocal]
       protected void DataPortal_Create(RenterTypeCriteria criteria)
        {

            _newRenterType = (RenterEditCreator.RenterType)criteria.RenterType;
            base.DataPortal_Create();
           
       }

       
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
           DataPortal_Delete(new SingleCriteria<RenterAccountEdit, int>(ReadProperty<int>(RenterAccountIDProperty)));
       }

       private void DataPortal_Delete(SingleCriteria<RenterAccountEdit, int> criteria)
       {
           // TODO: delete object's data
       }

       #endregion
   
   
   }
}
