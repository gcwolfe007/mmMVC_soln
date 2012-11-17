using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using Csla.Serialization;
using MM.Library.Entities;

namespace MM.Library
{
    [Serializable]
    public class RenterEditCreator : ReadOnlyBase<RenterEditCreator>
    {
        public enum RenterType
        {
            Person=0,
            Company=1
        }
        
        public static PropertyInfo<IRentingParty> ResultProperty = RegisterProperty<IRentingParty>(c => c.Result);
        public IRentingParty Result
        {
            get { return GetProperty(ResultProperty); }
            private set { LoadProperty(ResultProperty, value); }
        }

        /// <summary>
        /// Gets the address edit creator.
        /// </summary>
        /// <param name="typeParty">The address ID.</param>
        /// <param name="callback">The callback.</param>
        public static void GetRenterEditCreator(int typeParty, EventHandler<DataPortalResult<RenterEditCreator>> callback)
        {
            DataPortal.BeginFetch<RenterEditCreator>(typeParty, callback);
        }


#if !SILVERLIGHT

        /// <summary>
        /// Gets the address edit creator creator.
        /// </summary>
        /// <param name="typeParty">The address ID.</param>
        /// <returns></returns>
        public static RenterEditCreator GetRenterEditCreator(RenterType typeParty)
        {
            return DataPortal.Fetch<RenterEditCreator>(typeParty);
        }


 
        /// <summary>
        /// Datas the portal_ fetch.
        /// </summary>
        /// <param name="typeParty">The address ID.</param>
        private void DataPortal_Fetch(RenterType typeParty)
        {
            if (typeParty == RenterType.Person)
            {
                Result = DataPortal.CreateChild<PersonEdit>();
            }
            else
            {
                Result = DataPortal.CreateChild<CompanyEdit>();
            }
            
            
        }

        private void DataPortal_Fetch(RenterEditCriteria criteria)
        {
            Result = DataPortal.FetchChild<IRentingParty>(criteria.PartyID);
        }
#endif

        [Serializable]
        public class RenterEditCriteria : CriteriaBase<RenterEditCriteria>
        {
            public static readonly PropertyInfo<int> PartyIDProperty = RegisterProperty<int>(c => c.PartyID);
            public int PartyID
            {
                get { return ReadProperty(PartyIDProperty); }
                set { LoadProperty(PartyIDProperty, value); }
            }

        }
    }
}
