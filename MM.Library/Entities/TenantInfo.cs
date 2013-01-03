using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using System.ComponentModel.DataAnnotations;

namespace MM.Library.Entities
{
   
        [Serializable()]
        public class TenantInfo : ReadOnlyBase<TenantInfo>
        {
            public static PropertyInfo<int> AccountIDProperty = RegisterProperty<int>(c => c.AccountID);
            [Display(Name = "Account ID")]
            public int AccountID
            {
                get { return GetProperty(AccountIDProperty); }
                private set { LoadProperty(AccountIDProperty, value); }
            }

            public static readonly PropertyInfo<string> AccountNumberProperty = RegisterProperty<string>(c => c.AccountNumber);
            [Display(Name="Account Number")]
            public string AccountNumber
            {
                get { return GetProperty(AccountNumberProperty); }
                private set { LoadProperty(AccountNumberProperty, value); }
            }

            public static PropertyInfo<string> FullNameProperty = RegisterProperty<string>(c => c.FullName);
            [Display(Name = "Tenant Name")]
            public string FullName
            {
                get { return GetProperty(FullNameProperty); }
                private set { LoadProperty(FullNameProperty, value); }
            }

            public static readonly PropertyInfo<SmartDate> DateAddedProperty = RegisterProperty<SmartDate>(c => c.DateAdded, null, new SmartDate());
            public string DateAdded
            {
                get { return GetPropertyConvert<SmartDate, string>(DateAddedProperty); }
                private set { LoadPropertyConvert<SmartDate, string>(DateAddedProperty, value); }
            }

            public static readonly PropertyInfo<string> CityTownProperty = RegisterProperty<string>(c => c.CityTown);
            public string CityTown
            {
                get { return GetProperty(CityTownProperty); }
                private set { LoadProperty(CityTownProperty, value); }
            }

            public static readonly PropertyInfo<string> EmailProperty = RegisterProperty<string>(c => c.Email);
            [Display(Name="Email/UserName")]
            public string Email
            {
                get { return GetProperty(EmailProperty); }
                private set { LoadProperty(EmailProperty, value); }
            }

            public override string ToString()
            {
                return FullName;
            }

#if !SILVERLIGHT
            private void Child_Fetch(MM.DAL.TenantInfoDTO item)
            {
                AccountID = item.AccountID;
                AccountNumber = item.AccountNumber;
                Email = item.Email;
                DateAdded = new SmartDate(item.CreateDate);
                CityTown = item.CityTown;
                FullName = item.FirstName + " " + item.MiddleName + " " + item.LastName;
                FullName = FullName.Trim();
                

            }
#endif
        }
   
}
