using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using MM.Library.Entities;
using AutoMapper;


namespace MM.Library.Collections
{
    [Serializable()]
    public class PartyAddresses : BusinessListBase<PartyAddresses, PartyAddressEdit>
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

        internal List<MM.DAL.AddressAssignDTO> LoadAddresses()
        {
            var myList = new List<MM.DAL.AddressAssignDTO>();
            foreach (var address in this)
            {
                var myDto = new MM.DAL.AddressAssignDTO
                {                 
                    AddressType = address.Type,
                    AddressID = -1,
                    LineOne = address.LineOne,
                    LineTwo = address.LineTwo,
                    LineThree = address.LineThree,
                    CityTown = address.CityTown,
                    StateProvince = address.StateProvince,
                    PostalCode = address.PostalCode,
                    Country = address.Country             
                };       
                myList.Add(myDto);
            }
            return myList;           
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

        //private void Child_Fetch(List<MM.DAL.AddressDTO> data)
        //{
        //    var rlce = RaiseListChangedEvents;
        //    RaiseListChangedEvents = false;
        //    foreach (var item in data)
        //        Add(DataPortal.FetchChild<PartyAddressEdit>(item));
        //    RaiseListChangedEvents = rlce;
         
        //}
#endif

    }
}
