using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using Csla.Serialization;

namespace MM.Library.Entities
{
    [Serializable]
    public class PartyContactInfoEditCreator   : ReadOnlyBase<PartyContactInfoEditCreator>
    {
        public static PropertyInfo<PartyContactInfoEdit> ResultProperty = RegisterProperty<PartyContactInfoEdit>(c => c.Result);
        public PartyContactInfoEdit Result
        {
            get { return GetProperty(ResultProperty); }
            private set { LoadProperty(ResultProperty, value); }
        }


        /// <summary>
        /// Creates a new PartyContactInfoEdit object.
        /// </summary>
        public static PartyContactInfoEditCreator GetPartyContactInfoEditCreator(int contactInfoID)
        {
            return DataPortal.Fetch<PartyContactInfoEditCreator>(contactInfoID);
        }

        /// <summary>
        /// Gets an existing PartyContactInfoEdit object.
        /// </summary>
        public static PartyContactInfoEditCreator GetPartyContactInfoEditCreator(int partyID, int contactInfoID)
        {
            return DataPortal.Fetch<PartyContactInfoEditCreator>(new PartyContactInfoCriteria { PartyID = partyID, ContactInfoID = contactInfoID });
        }

        private void DataPortal_Fetch(int contactInfoID)
        {

            if (contactInfoID == -1)
            {
                Result = DataPortal.CreateChild<PartyContactInfoEdit>();
            }
            else
            {
                Result = DataPortal.CreateChild<PartyContactInfoEdit>(contactInfoID);
            }          
            
            
          //  Result = DataPortal.CreateChild<PartyContactInfoEdit>(contactInfoID);
        }

        private void DataPortal_Fetch(PartyContactInfoCriteria criteria)
        {
            Result = DataPortal.FetchChild<PartyContactInfoEdit>(criteria.PartyID, criteria.ContactInfoID);
        }

        [Serializable]
        public class PartyContactInfoCriteria : CriteriaBase<PartyContactInfoCriteria>
        {
            public static readonly PropertyInfo<int> PartyIDProperty = RegisterProperty<int>(c => c.PartyID);
            public int PartyID
            {
                get { return ReadProperty(PartyIDProperty); }
                set { LoadProperty(PartyIDProperty, value); }
            }

            public static readonly PropertyInfo<int> ContactInfoIDProperty = RegisterProperty<int>(c => c.ContactInfoID);
            public int ContactInfoID
            {
                get { return ReadProperty(ContactInfoIDProperty); }
                set { LoadProperty(ContactInfoIDProperty, value); }
            }
        }

    }
}
