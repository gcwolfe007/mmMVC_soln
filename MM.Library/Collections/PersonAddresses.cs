using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using MM.Library.Entities;

namespace MM.Library.Collections
{
    [Serializable()]
    public class PersonAddresses : BusinessListBase<PersonAddresses, PartyAddressEdit>
    {
#if SILVERLIGHT
    //TODO: add BeginAssign method
#else
        public PartyAddressEdit Assign(int addressID)
        {
            if (!(Contains(addressID)))
            {
                var address = PartyAddressEditCreator.GetPartyAddressEditCreator(addressID).Result;
                this.Add(address);
                return address;
            }
            else
            {
                throw new InvalidOperationException("Address already assigned to Renter");
            }
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
        private void Child_Fetch(int renterID)
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IAddressAssignmentDAL>();
                var data = dal.FetchForParty(renterID);
                var rlce = RaiseListChangedEvents;
                RaiseListChangedEvents = false;
                foreach (var item in data)
                    Add(DataPortal.FetchChild<PartyAddressEdit>(item));
                RaiseListChangedEvents = rlce;
            }
        }
#endif

    }
}
