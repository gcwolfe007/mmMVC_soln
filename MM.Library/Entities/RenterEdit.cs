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
   public class RenterEdit :BusinessBase<RenterEdit>
    {
        #region Business Methods

        public static readonly PropertyInfo<int> RenterIDProperty = RegisterProperty<int>(c => c.RenterID);
        public int RenterID
        {
            get { return GetProperty(RenterIDProperty); }
            private set { LoadProperty(RenterIDProperty, value); }
        }

        public static readonly PropertyInfo<PartyEdit> RenterProperty = RegisterProperty<PartyEdit>(c => c.Renter, RelationshipTypes.Child);
        public PartyEdit Renter
        {
            get
            {
                if (!(FieldManager.FieldExists(RenterProperty)))
                    LoadProperty(RenterProperty, DataPortal.CreateChild<PartyEdit>());
                return GetProperty(RenterProperty);
            }
            private set { SetProperty(RenterProperty, value); }
        }

        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(c => c.CreateDate, null, new SmartDate());
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

#if !SILVERLIGHT

        private void Child_Create(int renterID)
        {
            using (BypassPropertyChecks)
            {
                RenterID = renterID;
               // Role = RoleList.DefaultRole();
                LoadProperty(CreateDateProperty, DateTime.Today);
                using (var ctx = MM.DAL.DalFactory.GetDataStore())
                {
                    //var dal = ctx.GetProvider<ProjectTracker.Dal.IResourceDal>();
                    //var person = dal.Fetch(renterID);
                    //FirstName = person.FirstName;
                    //LastName = person.LastName;
                }
            }
            base.Child_Create();
        }

        private void Child_Fetch(int accountID, int renterID)
        {
            using (var ctx = MM.DAL.DalFactory.GetDataStore())
            {
                //var dal = ctx.GetProvider<ProjectTracker.Dal.IAssignmentDal>();
                //var data = dal.Fetch(projectId, resourceId);
                //Child_Fetch(data);
            }
        }

        private void Child_Fetch(MM.DAL.AssignmentDto data)
        {
            using (BypassPropertyChecks)
            {
                //ResourceId = data.ResourceId;
                //Role = data.RoleId;
              //  LoadProperty(CreateDateProperty, data.Assigned);
                //TimeStamp = data.LastChanged;
                using (var ctx = MM.DAL.DalFactory.GetDataStore())
                {
                  //  var dal = ctx.GetProvider<ProjectTracker.Dal.IResourceDal>();
                    //var person = dal.Fetch(data.ResourceId);
                    //FirstName = person.FirstName;
                    //LastName = person.LastName;
                }
            }
        }
        private void Child_Insert(RenterAccountEdit account)
        {
            Child_Insert(account.RenterAccountID);
        }

        private void Child_Insert(int accountID)
        {
            using (var ctx = MM.DAL.DalFactory.GetDataStore())
            {
              //  var dal = ctx.GetProvider<ProjectTracker.Dal.IAssignmentDal>();
                using (BypassPropertyChecks)
                {
                    //var item = new ProjectTracker.Dal.AssignmentDto
                    //{
                    //    ProjectId = accountID,
                    //    ResourceId = this.ResourceId,
                    //    Assigned = ReadProperty(AssignedProperty),
                    //    RoleId = this.Role
                    //};
                    //dal.Insert(item);
                    //TimeStamp = item.LastChanged;
                }
            }
        }

        private void Child_Update(RenterAccountEdit account)
        {
            Child_Update(account.RenterAccountID);
        }

        private void Child_Update(int accountID)
        {
            using (var ctx = MM.DAL.DalFactory.GetDataStore())
            {
             //   var dal = ctx.GetProvider<ProjectTracker.Dal.IAssignmentDal>();
                using (BypassPropertyChecks)
                {
                    //var item = dal.Fetch(projectId, ResourceId);
                    //item.Assigned = ReadProperty(AssignedProperty);
                    //item.RoleId = Role;
                    //item.LastChanged = TimeStamp;
                    //dal.Update(item);
                    //TimeStamp = item.LastChanged;
                }
            }
        }

        private void Child_DeleteSelf(RenterAccountEdit account)
        {
            using (var ctx = MM.DAL.DalFactory.GetDataStore())
            {
              // var dal = ctx.GetProvider<ProjectTracker.Dal.IAssignmentDal>();
                using (BypassPropertyChecks)
                {
                 //   dal.Delete(account.Id, RenterID);
                }
            }
        }
#endif

    }
}
