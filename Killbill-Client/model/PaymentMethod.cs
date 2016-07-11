
using System;
using System.Text;

namespace Killbill_Client.model
{

    public class PaymentMethod : KillBillObject
    {

        private Guid paymentMethodId;
        private string externalKey;
        private Guid accountId;
        private bool isDefault;
        private string pluginName;
        private PaymentMethodPluginDetail pluginInfo;

        public string ToString()
        {
            StringBuilder sb = new StringBuilder("PaymentMethod{");
            sb.Append("paymentMethodId='").Append(paymentMethodId).Append('\'');
            sb.Append(", accountId='").Append(accountId).Append('\'');
            sb.Append(", externalKey='").Append(externalKey).Append('\'');
            sb.Append(", isDefault=").Append(isDefault);
            sb.Append(", pluginName='").Append(pluginName).Append('\'');
            sb.Append(", pluginInfo=").Append(pluginInfo);
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

            PaymentMethod that = (PaymentMethod) o;

            if (accountId != null ? !accountId.Equals(that.accountId) : that.accountId != null)
            {
                return false;
            }
            if (externalKey != null ? !externalKey.Equals(that.externalKey) : that.externalKey != null)
            {
                return false;
            }
            if (isDefault != null ? !isDefault.Equals(that.isDefault) : that.isDefault != null)
            {
                return false;
            }
            if (paymentMethodId != null ? !paymentMethodId.Equals(that.paymentMethodId) : that.paymentMethodId != null)
            {
                return false;
            }
            if (pluginInfo != null ? !pluginInfo.Equals(that.pluginInfo) : that.pluginInfo != null)
            {
                return false;
            }
            if (pluginName != null ? !pluginName.Equals(that.pluginName) : that.pluginName != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = paymentMethodId != null ? paymentMethodId.GetHashCode() : 0;
            result = 31*result + (accountId != null ? accountId.GetHashCode() : 0);
            result = 31*result + (externalKey != null ? externalKey.GetHashCode() : 0);
            result = 31*result + (isDefault != null ? isDefault.GetHashCode() : 0);
            result = 31*result + (pluginName != null ? pluginName.GetHashCode() : 0);
            result = 31*result + (pluginInfo != null ? pluginInfo.GetHashCode() : 0);
            return result;
        }
    }
}