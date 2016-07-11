
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Killbill_Client.model
{

    public class PaymentTransaction : KillBillObject
    {

        private Guid transactionId;
        private string transactionExternalKey;
        private Guid paymentId;
        private string paymentExternalKey;
        private string transactionType;
        private DateTime effectiveDate;
        private string status;
        private BigDecimal amount;
        private string currency;
        private string gatewayErrorCode;
        private string gatewayErrorMsg;
        // Plugin specific fields
        private string firstPaymentReferenceId;
        private string secondPaymentReferenceId;
        // Avoid null iterable field
        private List<PluginProperty> properties = ImmutableList.<
        PluginProperty
    >
        of();




        public string ToString()
        {
            StringBuilder sb = new StringBuilder("PaymentTransaction{");
            sb.Append("transactionId=").Append(transactionId);
            sb.Append(", transactionExternalKey='").Append(transactionExternalKey).Append('\'');
            sb.Append(", paymentId=").Append(paymentId);
            sb.Append(", paymentExternalKey='").Append(paymentExternalKey).Append('\'');
            sb.Append(", transactionType='").Append(transactionType).Append('\'');
            sb.Append(", effectiveDate=").Append(effectiveDate);
            sb.Append(", status='").Append(status).Append('\'');
            sb.Append(", amount=").Append(amount);
            sb.Append(", currency='").Append(currency).Append('\'');
            sb.Append(", gatewayErrorCode='").Append(gatewayErrorCode).Append('\'');
            sb.Append(", gatewayErrorMsg='").Append(gatewayErrorMsg).Append('\'');
            sb.Append(", firstPaymentReferenceId='").Append(firstPaymentReferenceId).Append('\'');
            sb.Append(", secondPaymentReferenceId='").Append(secondPaymentReferenceId).Append('\'');
            sb.Append(", properties=").Append(properties);
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

            PaymentTransaction that = (PaymentTransaction)o;

            if (amount != null ? amount.compareTo(that.amount) != 0 : that.amount != null)
            {
                return false;
            }
            if (currency != null ? !currency.Equals(that.currency) : that.currency != null)
            {
                return false;
            }
            if (paymentExternalKey != null
                ? !paymentExternalKey.Equals(that.paymentExternalKey)
                : that.paymentExternalKey != null)
            {
                return false;
            }
            if (paymentId != null ? !paymentId.Equals(that.paymentId) : that.paymentId != null)
            {
                return false;
            }
            if (transactionExternalKey != null
                ? !transactionExternalKey.Equals(that.transactionExternalKey)
                : that.transactionExternalKey != null)
            {
                return false;
            }
            if (transactionId != null ? !transactionId.Equals(that.transactionId) : that.transactionId != null)
            {
                return false;
            }
            if (effectiveDate != null ? effectiveDate.CompareTo(that.effectiveDate) != 0 : that.effectiveDate != null)
            {
                return false;
            }
            if (firstPaymentReferenceId != null
                ? !firstPaymentReferenceId.Equals(that.firstPaymentReferenceId)
                : that.firstPaymentReferenceId != null)
            {
                return false;
            }
            if (gatewayErrorCode != null
                ? !gatewayErrorCode.Equals(that.gatewayErrorCode)
                : that.gatewayErrorCode != null)
            {
                return false;
            }
            if (gatewayErrorMsg != null ? !gatewayErrorMsg.Equals(that.gatewayErrorMsg) : that.gatewayErrorMsg != null)
            {
                return false;
            }
            if (properties != null ? !properties.Equals(that.properties) : that.properties != null)
            {
                return false;
            }
            if (secondPaymentReferenceId != null
                ? !secondPaymentReferenceId.Equals(that.secondPaymentReferenceId)
                : that.secondPaymentReferenceId != null)
            {
                return false;
            }
            if (status != null ? !status.Equals(that.status) : that.status != null)
            {
                return false;
            }
            if (transactionType != null ? !transactionType.Equals(that.transactionType) : that.transactionType != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = transactionId != null ? transactionId.GetHashCode() : 0;
            result = 31 * result + (transactionExternalKey != null ? transactionExternalKey.GetHashCode() : 0);
            result = 31 * result + (paymentId != null ? paymentId.GetHashCode() : 0);
            result = 31 * result + (paymentExternalKey != null ? paymentExternalKey.GetHashCode() : 0);
            result = 31 * result + (transactionType != null ? transactionType.GetHashCode() : 0);
            result = 31 * result + (effectiveDate != null ? effectiveDate.GetHashCode() : 0);
            result = 31 * result + (status != null ? status.GetHashCode() : 0);
            result = 31 * result + (amount != null ? amount.GetHashCode() : 0);
            result = 31 * result + (currency != null ? currency.GetHashCode() : 0);
            result = 31 * result + (gatewayErrorCode != null ? gatewayErrorCode.GetHashCode() : 0);
            result = 31 * result + (gatewayErrorMsg != null ? gatewayErrorMsg.GetHashCode() : 0);
            result = 31 * result + (firstPaymentReferenceId != null ? firstPaymentReferenceId.GetHashCode() : 0);
            result = 31 * result + (secondPaymentReferenceId != null ? secondPaymentReferenceId.GetHashCode() : 0);
            result = 31 * result + (properties != null ? properties.GetHashCode() : 0);
            return result;
        }
    }
}