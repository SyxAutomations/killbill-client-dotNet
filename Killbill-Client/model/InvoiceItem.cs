using System;
using System.Numerics;

namespace Killbill_Client.model
{

    public class InvoiceItem : KillBillObject
    {

        public Guid invoiceItemId;
        public Guid invoiceId;
        public Guid linkedInvoiceItemId;
        public Guid accountId;
        public Guid bundleId;
        public Guid subscriptionId;
        public string planName;
        public string phaseName;
        public string usageName;
        public string itemType;
        public string description;
        public DateTime startDate;
        public DateTime endDate;
        public BigInteger amount;
        public Currency currency;


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

            InvoiceItem that = (InvoiceItem)o;

            if (accountId != null ? !accountId.Equals(that.accountId) : that.accountId != null)
            {
                return false;
            }
            if (amount != null ? amount.CompareTo(that.amount) != 0 : that.amount != null)
            {
                return false;
            }
            if (bundleId != null ? !bundleId.Equals(that.bundleId) : that.bundleId != null)
            {
                return false;
            }
            if (currency != that.currency)
            {
                return false;
            }
            if (description != null ? !description.Equals(that.description) : that.description != null)
            {
                return false;
            }
            if (endDate != null ? endDate.CompareTo(that.endDate) != 0 : that.endDate != null)
            {
                return false;
            }
            if (invoiceId != null ? !invoiceId.Equals(that.invoiceId) : that.invoiceId != null)
            {
                return false;
            }
            if (invoiceItemId != null ? !invoiceItemId.Equals(that.invoiceItemId) : that.invoiceItemId != null)
            {
                return false;
            }
            if (itemType != null ? !itemType.Equals(that.itemType) : that.itemType != null)
            {
                return false;
            }
            if (linkedInvoiceItemId != null
                ? !linkedInvoiceItemId.Equals(that.linkedInvoiceItemId)
                : that.linkedInvoiceItemId != null)
            {
                return false;
            }
            if (phaseName != null ? !phaseName.Equals(that.phaseName) : that.phaseName != null)
            {
                return false;
            }
            if (planName != null ? !planName.Equals(that.planName) : that.planName != null)
            {
                return false;
            }
            if (usageName != null ? !usageName.Equals(that.usageName) : that.usageName != null)
            {
                return false;
            }
            if (startDate != null ? startDate.CompareTo(that.startDate) != 0 : that.startDate != null)
            {
                return false;
            }
            if (subscriptionId != null ? !subscriptionId.Equals(that.subscriptionId) : that.subscriptionId != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = invoiceItemId != null ? invoiceItemId.GetHashCode() : 0;
            result = 31 * result + (invoiceId != null ? invoiceId.GetHashCode() : 0);
            result = 31 * result + (linkedInvoiceItemId != null ? linkedInvoiceItemId.GetHashCode() : 0);
            result = 31 * result + (accountId != null ? accountId.GetHashCode() : 0);
            result = 31 * result + (bundleId != null ? bundleId.GetHashCode() : 0);
            result = 31 * result + (subscriptionId != null ? subscriptionId.GetHashCode() : 0);
            result = 31 * result + (planName != null ? planName.GetHashCode() : 0);
            result = 31 * result + (phaseName != null ? phaseName.GetHashCode() : 0);
            result = 31 * result + (usageName != null ? usageName.GetHashCode() : 0);
            result = 31 * result + (itemType != null ? itemType.GetHashCode() : 0);
            result = 31 * result + (description != null ? description.GetHashCode() : 0);
            result = 31 * result + (startDate != null ? startDate.GetHashCode() : 0);
            result = 31 * result + (endDate != null ? endDate.GetHashCode() : 0);
            result = 31 * result + (amount != null ? amount.GetHashCode() : 0);
            result = 31 * result + (currency != null ? currency.GetHashCode() : 0);
            return result;
        }
    }
}
