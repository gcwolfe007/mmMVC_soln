using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MM.Library.Entities;
using Csla;

namespace MM.Library
{
    [Serializable] 
    public  class PartyAddressUpdater : CommandBase<PartyAddressUpdater>
    {
        public static readonly PropertyInfo<int> ProjectIdProperty = RegisterProperty<int>(c => c.RenterID);
        public int RenterID
        {
            get { return ReadProperty(ProjectIdProperty); }
            private set { LoadProperty(ProjectIdProperty, value); }
        }

        public static readonly PropertyInfo<PartyAddressEdit> PartyAddressProperty = RegisterProperty<PartyAddressEdit>(c => c.PartyAddress);
        public PartyAddressEdit PartyAddress
        {
            get { return ReadProperty(PartyAddressProperty); }
            private set { LoadProperty(PartyAddressProperty, value); }
        }

#if !SILVERLIGHT
        public static PartyAddressEdit Update(int renterID, PartyAddressEdit partyAddress)
        {
            var cmd = new PartyAddressUpdater { RenterID = renterID, PartyAddress = partyAddress };
            cmd = DataPortal.Execute<PartyAddressUpdater>(cmd);
            return cmd.PartyAddress;
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                DataPortal.UpdateChild(PartyAddress, RenterID);
            }
        }
#endif

    }
}
