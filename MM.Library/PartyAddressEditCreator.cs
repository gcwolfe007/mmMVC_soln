using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using MM.Library.Entities;

namespace MM.Library
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PartyAddressEditCreator : ReadOnlyBase<PartyAddressEditCreator>
    {
        public static PropertyInfo<PartyAddressEdit> ResultProperty = RegisterProperty<PartyAddressEdit>(c => c.Result);
        public PartyAddressEdit Result
        {
            get { return GetProperty(ResultProperty); }
            private set { LoadProperty(ResultProperty, value); }
        }


        /// <summary>
        /// Gets the address edit creator.
        /// </summary>
        /// <param name="addressID">The address ID.</param>
        /// <param name="callback">The callback.</param>
        public static void GetPartyAddressEditCreator(int addressID, EventHandler<DataPortalResult<PartyAddressEditCreator>> callback)
        {
            DataPortal.BeginFetch<PartyAddressEditCreator>(addressID, callback);
        }


        /// <summary>
        /// Gets the address edit creator.
        /// </summary>
        /// <param name="partyID">The party ID.</param>
        /// <param name="addressID">The address ID.</param>
        /// <param name="callback">The callback.</param>
        public static void GetPartyAddressEditCreator(int partyID, int addressID,
          EventHandler<DataPortalResult<PartyAddressEditCreator>> callback)
        {
            DataPortal.BeginFetch<PartyAddressEditCreator>(
              new AddressEditCriteria { RenterID = partyID, AddressID = addressID }, callback);
        }

#if !SILVERLIGHT

        /// <summary>
        /// Gets the address edit creator creator.
        /// </summary>
        /// <param name="addressID">The address ID.</param>
        /// <returns></returns>
        public static PartyAddressEditCreator GetPartyAddressEditCreator(int addressID)
        {
            return DataPortal.Fetch<PartyAddressEditCreator>(addressID);
        }


        /// <summary>
        /// Gets the address edit creator.
        /// </summary>
        /// <param name="partyID">The party ID.</param>
        /// <param name="addressID">The address ID.</param>
        /// <returns></returns>
        public static PartyAddressEditCreator GetPartyAddressEditCreator(int partyID, int addressID)
        {
            return DataPortal.Fetch<PartyAddressEditCreator>(new AddressEditCriteria { RenterID = partyID, AddressID = addressID });
        }

        /// <summary>
        /// Datas the portal_ fetch.
        /// </summary>
        /// <param name="addressID">The address ID.</param>
        private void DataPortal_Fetch(int addressID)
        {
            Result = DataPortal.CreateChild<PartyAddressEdit>(addressID);
        }

        private void DataPortal_Fetch(AddressEditCriteria criteria)
        {
            Result = DataPortal.FetchChild<PartyAddressEdit>(criteria.RenterID, criteria.AddressID);
        }
#endif


        [Serializable]
        public class AddressEditCriteria : CriteriaBase<AddressEditCriteria>
        {
            public static readonly PropertyInfo<int> RenterIDProperty = RegisterProperty<int>(c => c.RenterID);
            public int RenterID
            {
                get { return ReadProperty(RenterIDProperty); }
                set { LoadProperty(RenterIDProperty, value); }
            }

            public static readonly PropertyInfo<int> AddressIDProperty = RegisterProperty<int>(c => c.AddressID);
            public int AddressID
            {
                get { return ReadProperty(AddressIDProperty); }
                set { LoadProperty(AddressIDProperty, value); }
            }
        }
    }
}
