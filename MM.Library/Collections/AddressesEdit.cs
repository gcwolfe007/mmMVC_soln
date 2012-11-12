using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using MM.Library.Entities;

namespace MM.Library.Collections
{
   public class AddressesEdit : BusinessListBase<AddressesEdit,AddressEdit>
    {
#if !SILVERLIGHT
       public AddressEdit Assign(int addressID)
        {
            var address = AddressEditCreator.GetAddressEditCreator(addressID).Result;
            this.Add(address);
            return address;
        }
#endif

        public void Remove(int addressID)
        {
            var item = (from r in this
                        where r.AddressID == addressID
                        select r).FirstOrDefault();
            if (item != null)
                Remove(item);
        }

        public bool Contains(int addressID)
        {
            var item = (from r in this
                        where r.AddressID == addressID
                        select r).Count();
            return item > 0;
        }

        public bool ContainsDeleted(int addressID)
        {
            var item = (from r in DeletedList
                        where r.AddressID == addressID
                        select r).Count();
            return item > 0;
        }

#if !SILVERLIGHT
        private void Child_Fetch(int projectId)
        {
            using (var ctx = MM.DAL.DalFactory.GetDataStore())
            {
                //var dal = ctx.GetProvider<ProjectTracker.Dal.IAssignmentDal>();
                //var data = dal.FetchForProject(projectId);
                //var rlce = RaiseListChangedEvents;
                //RaiseListChangedEvents = false;
                //foreach (var item in data)
                //    Add(DataPortal.FetchChild<ProjectResourceEdit>(item));
                //RaiseListChangedEvents = rlce;
            }
        }
#endif
    }
}
