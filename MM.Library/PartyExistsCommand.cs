using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using MM.Library.Entities;

namespace MM.Library
{
   [Serializable]
   public class PartyExistsCommand : CommandBase<PartyExistsCommand>
    {
       public static PropertyInfo<int> RenterIDProperty = RegisterProperty<int>(c => c.RenterID);
        private int RenterID
        {
          get { return ReadProperty(RenterIDProperty); }
          set { LoadProperty(RenterIDProperty, value); }
        }

        public static PropertyInfo<bool> PartyExistsProperty = RegisterProperty<bool>(c => c.PartyExists);
        public bool PartyExists
        {
          get { return ReadProperty(PartyExistsProperty); }
          private set { LoadProperty(PartyExistsProperty, value); }
        }

        public PartyExistsCommand(int id)
        {
          RenterID = id;
        }

    #if !SILVERLIGHT
        protected override void DataPortal_Execute()
        {
          using (var ctx = MM.DAL.DalFactory.GetManager())
          {
            var dal = ctx.GetProvider<MM.DAL.IRenterAccountDAL>();
            PartyExists = dal.Exists(RenterID);
          }
        }
    #endif
    }
}
