using System;
using System.Text;

namespace Killbill_Client.model
{

    public class Tenant : KillBillObject
    {

        private Guid tenantId;
        private string externalKey;
        private string apiKey;
        private string apiSecret;



        public string ToString()
        {
            StringBuilder sb = new StringBuilder("Tenant{");
            sb.Append("tenantId='").Append(tenantId).Append('\'');
            sb.Append(", externalKey='").Append(externalKey).Append('\'');
            sb.Append(", apiKey='").Append(apiKey).Append('\'');
            sb.Append(", apiSecret='").Append(apiSecret).Append('\'');
            sb.Append('}');
            return sb.ToString();
        }


        public bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            Tenant tenant = (Tenant) o;

            if (apiKey != null ? !apiKey.Equals(tenant.apiKey) : tenant.apiKey != null)
            {
                return false;
            }
            if (apiSecret != null ? !apiSecret.Equals(tenant.apiSecret) : tenant.apiSecret != null)
            {
                return false;
            }
            if (externalKey != null ? !externalKey.Equals(tenant.externalKey) : tenant.externalKey != null)
            {
                return false;
            }
            if (tenantId != null ? !tenantId.Equals(tenant.tenantId) : tenant.tenantId != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = tenantId != null ? tenantId.GetHashCode() : 0;
            result = 31*result + (externalKey != null ? externalKey.GetHashCode() : 0);
            result = 31*result + (apiKey != null ? apiKey.GetHashCode() : 0);
            result = 31*result + (apiSecret != null ? apiSecret.GetHashCode() : 0);
            return result;
        }
    }
}