using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using MM.Library.Entities;

namespace MM.Library.Collections
{
   public class TenantInfoList : ReadOnlyListBase<TenantInfoList, TenantInfo> 
    {
        public void RemoveChild(int accountID)
        {
            var iro = IsReadOnly;
            IsReadOnly = false;
            try
            {
                var item = this.Where(r => r.AccountID == accountID).FirstOrDefault();
                if (item != null)
                {
                    var index = this.IndexOf(item);
                    Remove(item);
                }
            }
            finally
            {
                IsReadOnly = iro;
            }
        }

        public static void GetTenantInfoList(EventHandler<DataPortalResult<TenantInfoList>> callback)
        {
            DataPortal.BeginFetch<TenantInfoList>(callback);
        }

        public static void GetTenantInfoList(string name, EventHandler<DataPortalResult<TenantInfoList>> callback)
        {
            DataPortal.BeginCreate<TenantInfoList>(name, callback);
        }
#if !SILVERLIGHT
        public static TenantInfoList GetTenantInfoList()
        {
            return DataPortal.Fetch<TenantInfoList>();
        }

        public static TenantInfoList  GetTenantInfoList(string name)
        {
            return DataPortal.Fetch<TenantInfoList>(name);
        }

        private void DataPortal_Fetch()
        {
            DataPortal_Fetch(null);
        }

        private void DataPortal_Fetch(string name)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            IsReadOnly = false;
            using (var ctx = MM.DAL.DalFactory.GetManager())
            {
                var dal = ctx.GetProvider<MM.DAL.IRenterAccountDAL>();
                List<MM.DAL.TenantInfoDTO> list = null;
                if (name == null)
                    list = dal.FetchTenants();
                else
                    list = dal.FetchTenants(name);
                foreach (var item in list)
                    Add(DataPortal.FetchChild<TenantInfo>(item));
            }
            IsReadOnly = true;
            RaiseListChangedEvents = rlce;
        }
#endif
    }
}
