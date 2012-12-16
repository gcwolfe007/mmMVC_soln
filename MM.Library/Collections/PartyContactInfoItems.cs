using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using MM.Library.Entities;


namespace MM.Library.Collections
{
    [Serializable()]
    public class PartyContactInfoItems : BusinessListBase<PartyContactInfoItems, PartyContactInfoEdit>
    {

        public PartyContactInfoEdit Assign(int contactInfoID)
        {
            var contactInfo = PartyContactInfoEditCreator.GetPartyContactInfoEditCreator(contactInfoID).Result;
            this.Add(contactInfo);
            return contactInfo;
        }

        internal List<MM.DAL.ContactInfoAssignDTO> LoadContactInfoItems()
        {
            var myList = new List<MM.DAL.ContactInfoAssignDTO>();
            foreach (var contactInfo in this)
            {
                var myDto = new MM.DAL.ContactInfoAssignDTO
                {
                    ContactInfoTypeID = contactInfo.ContactInfoType,
                    ContactInfoID = -1,
                    ContactInfoItem = contactInfo.ContactInfoItem, 
                };
                myList.Add(myDto);
            }
            return myList;
        }


    public void Remove(int contactInfoID)
    {
      var item = (from r in this
                    where r.ContactInfoID == contactInfoID
                    select r).FirstOrDefault();
      if (item != null)
        Remove(item);
    }

    public bool Contains(int contactInfoID)
    {
      var item = (from r in this
                  where r.ContactInfoID == contactInfoID
                  select r).Count();
      return item > 0;
    }

    public bool ContainsDeleted(int contactInfoID)
    {
      var item = (from r in DeletedList
                  where r.ContactInfoID == contactInfoID
                  select r).Count();
      return item > 0;
    }


    private void Child_Fetch(int personID)
    {
      using (var ctx = MM.DAL.DalFactory.GetManager())
      {
        var dal = ctx.GetProvider<MM.DAL.IContactInfoAssignmentDAL>();
        var data = dal.FetchForParty(personID);
        var rlce = RaiseListChangedEvents;
        RaiseListChangedEvents = false;
        foreach (var item in data)
          Add(DataPortal.FetchChild<PartyContactInfoEdit>(item));
        RaiseListChangedEvents = rlce;
      }
    }

  }

}

