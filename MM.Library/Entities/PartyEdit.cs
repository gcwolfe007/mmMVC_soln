﻿using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Csla;
using Csla.Data;
using Csla.Security;
using Csla.Serialization;
using System.ComponentModel;


namespace MM.Library.Entities
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
        public static readonly PropertyInfo<int> PartyIDProperty = RegisterProperty<int>(c => c.PartyID);
        public int PartyID
        {
            get { return GetProperty(PartyIDProperty); }
            private set { LoadProperty(PartyIDProperty, value); }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Display(Name = "First Name")]
        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty); }
            set { SetProperty(FirstNameProperty, value); }
        }

        


        /// <summary>
        /// The last name property
        /// </summary>
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "'LastName' is required")]
        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
            set { SetProperty(LastNameProperty, value); }
        }
        


        /// <summary>
        /// The middle name property
        /// </summary>
        [Display(Name = "Middle Name")]
        public static readonly PropertyInfo<string> MiddleNameProperty = RegisterProperty<string>(c => c.MiddleName);
        public string MiddleName
        {
            get { return GetProperty(MiddleNameProperty); }
            set { SetProperty(MiddleNameProperty, value); }
        }
        /// <summary>
        /// The create date property
        /// </summary>
        [Required]
        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(c => c.CreateDate, null, new SmartDate());
        public string CreateDate
        {
            get { return GetPropertyConvert<SmartDate, string>(CreateDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(CreateDateProperty, value); }
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

        #region Data Access

#if !SILVERLIGHT

        private void Child_Create(int partyID)
        {
            using (BypassPropertyChecks)
            {
                PartyID = partyID;
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


     
        #endregion



   }

}
