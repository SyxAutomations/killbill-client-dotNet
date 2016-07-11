using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{
    public abstract class ComboPayment : KillBillObject
    {

        private Account account;
        private PaymentMethod paymentMethod;
        private List<PluginProperty> paymentMethodPluginProperties;

        public ComboPayment()
        {
        }


        public ComboPayment(Account account,
            PaymentMethod paymentMethod,
            List<PluginProperty> paymentMethodPluginProperties)
        {

            this.account = account;
            this.paymentMethod = paymentMethod;
            this.paymentMethodPluginProperties = paymentMethodPluginProperties;
        }

        public Account getAccount()
        {
            return account;
        }

        public void setAccount(Account account)
        {
            this.account = account;
        }

        public PaymentMethod getPaymentMethod()
        {
            return paymentMethod;
        }

        public void setPaymentMethod(PaymentMethod paymentMethod)
        {
            this.paymentMethod = paymentMethod;
        }

        public List<PluginProperty> getPaymentMethodPluginProperties()
        {
            return paymentMethodPluginProperties;
        }

        public void setPaymentMethodPluginProperties(List<PluginProperty> paymentMethodPluginProperties)
        {
            this.paymentMethodPluginProperties = paymentMethodPluginProperties;
        }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("ComboPayment{");
            sb.Append("account=").Append(account);
            sb.Append(", paymentMethod=").Append(paymentMethod);
            sb.Append(", paymentMethodPluginProperties=").Append(paymentMethodPluginProperties);
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

            ComboPayment that = (ComboPayment)o;

            if (account != null ? !account.Equals(that.account) : that.account != null)
            {
                return false;
            }
            if (paymentMethod != null ? !paymentMethod.Equals(that.paymentMethod) : that.paymentMethod != null)
            {
                return false;
            }
            return
                !(paymentMethodPluginProperties != null
                    ? !paymentMethodPluginProperties.Equals(that.paymentMethodPluginProperties)
                    : that.paymentMethodPluginProperties != null);
        }


        public int GetHashCode()
        {
            int result = account != null ? account.GetHashCode() : 0;
            result = 31 * result + (paymentMethod != null ? paymentMethod.GetHashCode() : 0);
            result = 31 * result +
                     (paymentMethodPluginProperties != null ? paymentMethodPluginProperties.GetHashCode() : 0);
            return result;
        }
    }
}
