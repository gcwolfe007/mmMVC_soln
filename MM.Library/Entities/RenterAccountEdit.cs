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

       public static readonly PropertyInfo<PersonEdit> RenterProperty = RegisterProperty<PersonEdit>(c => c.Renter, RelationshipTypes.Child);
       public PersonEdit Renter
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

       public static readonly PropertyInfo<int> ModifyUserProperty = RegisterProperty<int>(c => c.ModifyUser);
       public int ModifyUser
       {
           get { return GetProperty(ModifyUserProperty); }
           set { SetProperty(ModifyUserProperty, value); }
       }
       
       
       public static readonly PropertyInfo<SmartDate> ModifyDateProperty = RegisterProperty<SmartDate>(c => c.ModifyDate, null, new SmartDate(DateTime.Now));
       [Display(Name = "Last Modified Date")]
       public string ModifyDate
       {
           get { return GetPropertyConvert<SmartDate, string>(ModifyDateProperty); }
           set { SetPropertyConvert<SmartDate, string>(ModifyDateProperty, value); }
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

       
       private void DataPortal_Fetch(int accountID)
       {
           using (var ctx = MM.DAL.DalFactory.GetManager())
           {
               var dal = ctx.GetProvider<MM.DAL.IRenterAccountDAL>();
               var data = dal.Fetch(accountID);
               using (BypassPropertyChecks)
               {
                   RenterAccountID = data.AccountID;
                   AccountNumber = data.AccountNumber;
                   LoadProperty(CreateDateProperty, data.CreateDate);
                   LoadProperty(ModifyDateProperty, data.ModifyDate);
                  
                   CreateUserID = data.CreateUserID;
                   Renter = DataPortal.FetchChild<PersonEdit>(data.Renter);
               }
           }
       }

       protected override void DataPortal_Insert()
       {
           // TODO: insert object's data
       }

       protected override void DataPortal_Update()
       {
           using (var ctx = MM.DAL.DalFactory.GetManager())
           {
               var dal = ctx.GetProvider<MM.DAL.IRenterAccountDAL>();
               using (BypassPropertyChecks)
               {
                   var item = new MM.DAL.RenterAccountDTO
                   {
                       AccountID = this.RenterAccountID,
                       AccountNumber = this.AccountNumber,
                      
                      
                       CreateDate = (DateTime)FieldManager.GetFieldData(CreateDateProperty).Value,
                   };
                   dal.Update(item);
                   FieldManager.GetFieldData(ModifyDateProperty).Value = item.ModifyDate;
               }
               FieldManager.UpdateChildren(this);
           }
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
