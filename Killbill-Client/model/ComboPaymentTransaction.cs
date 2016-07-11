using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{
    public class ComboPaymentTransaction : ComboPayment
    {

        private PaymentTransaction transaction;
        private List<PluginProperty> transactionPluginProperties;

        public ComboPaymentTransaction()
        {
        }


        public ComboPaymentTransaction(Account account,
            PaymentMethod paymentMethod,
            PaymentTransaction transaction,
            List<PluginProperty> paymentMethodPluginProperties,
            List<PluginProperty> transactionPluginProperties)
        {
            this.transaction = transaction;
            this.transactionPluginProperties = transactionPluginProperties;
        }

        public PaymentTransaction getTransaction()
        {
            return transaction;
        }

        public void setTransaction(PaymentTransaction transaction)
        {
            this.transaction = transaction;
        }

        public List<PluginProperty> getTransactionPluginProperties()
        {
            return transactionPluginProperties;
        }

        public void setTransactionPluginProperties(List<PluginProperty> transactionPluginProperties)
        {
            this.transactionPluginProperties = transactionPluginProperties;
        }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("ComboPaymentTransaction{");
            sb.Append("transaction=").Append(transaction);
            sb.Append(", transactionPluginProperties=").Append(transactionPluginProperties);
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
            if (!base.Equals(o))
            {
                return false;
            }

            ComboPaymentTransaction that = (ComboPaymentTransaction)o;

            if (transaction != null ? !transaction.Equals(that.transaction) : that.transaction != null)
            {
                return false;
            }
            return
                !(transactionPluginProperties != null
                    ? !transactionPluginProperties.Equals(that.transactionPluginProperties)
                    : that.transactionPluginProperties != null);
        }


        public int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (transaction != null ? transaction.GetHashCode() : 0);
            result = 31 * result + (transactionPluginProperties != null ? transactionPluginProperties.GetHashCode() : 0);
            return result;
        }
    }
}
