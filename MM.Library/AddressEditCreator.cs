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
    public class AddressEditCreator : ReadOnlyBase<AddressEditCreator>
    {
        public static PropertyInfo<AddressEdit> ResultProperty = RegisterProperty<AddressEdit>(c => c.Result);
        public AddressEdit Result
        {
            get { return GetProperty(ResultProperty); }
            private set { LoadProperty(ResultProperty, value); }
        }


        /// <summary>
        /// Gets the address edit creator.
        /// </summary>
        /// <param name="addressID">The address ID.</param>
        /// <param name="callback">The callback.</param>
        public static void GetAddressEditCreator(int addressID, EventHandler<DataPortalResult<AddressEditCreator>> callback)
        {
            DataPortal.BeginFetch<AddressEditCreator>(addressID, callback);
        }


        /// <summary>
        /// Gets the address edit creator.
        /// </summary>
        /// <param name="partyID">The party ID.</param>
        /// <param name="addressID">The address ID.</param>
        /// <param name="callback">The callback.</param>
        public static void GetAddressEditCreator(int partyID, int addressID,
          EventHandler<DataPortalResult<AddressEditCreator>> callback)
        {
            DataPortal.BeginFetch<AddressEditCreator>(
              new AddressEditCriteria { PartyID = partyID, AddressID = addressID }, callback);
        }

#if !SILVERLIGHT

        /// <summary>
        /// Gets the address edit creator creator.
        /// </summary>
        /// <param name="addressID">The address ID.</param>
        /// <returns></returns>
        public static AddressEditCreator GetAddressEditCreator(int addressID)
        {
            return DataPortal.Fetch<AddressEditCreator>(addressID);
        }


        /// <summary>
        /// Gets the address edit creator.
        /// </summary>
        /// <param name="partyID">The party ID.</param>
        /// <param name="addressID">The address ID.</param>
        /// <returns></returns>
        public static AddressEditCreator GetAddressEditCreator(int partyID, int addressID)
        {
            return DataPortal.Fetch<AddressEditCreator>(new AddressEditCriteria { PartyID = partyID, AddressID = addressID });
        }

        /// <summary>
        /// Datas the portal_ fetch.
        /// </summary>
        /// <param name="addressID">The address ID.</param>
        private void DataPortal_Fetch(int addressID)
        {
            Result = DataPortal.CreateChild<AddressEdit>(addressID);
        }

        private void DataPortal_Fetch(AddressEditCriteria criteria)
        {
            Result = DataPortal.FetchChild<AddressEdit>(criteria.PartyID, criteria.AddressID);
        }
#endif


        [Serializable]
        public class AddressEditCriteria : CriteriaBase<AddressEditCriteria>
        {
            public static readonly PropertyInfo<int> PartyIDProperty = RegisterProperty<int>(c => c.PartyID);
            public int PartyID
            {
                get { return ReadProperty(PartyIDProperty); }
                set { LoadProperty(PartyIDProperty, value); }
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
