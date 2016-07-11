
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Killbill_Client.model {

    public class Invoice : KillBillObject
    {
        public BigInteger Amount { get; }
        public Currency Currency { get; private set; }
        public Guid InvoiceId { get; }
        public DateTime InvoiceDate { get; set; }
        public DateTime TargetDate { get; private set; }
        public long InvoiceNumber { get; private set; }
        public BigInteger Balance { get; private set; }
        public BigInteger CreditAdj { get; private set; }
        public BigInteger RefundAdj { get; private set; }
        public Guid AccountId { get; private set; }
        public List<InvoiceItem> Items { get; private set; }
        public string BundleKeys { get; private set; }
        public List<Credit> Credits { get; private set; }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("Invoice{");
            sb.Append("amount=").Append(Amount);
            sb.Append(", currency='").Append(Currency).Append('\'');
            sb.Append(", invoiceId='").Append(InvoiceId).Append('\'');
            sb.Append(", invoiceDate=").Append(InvoiceDate);
            sb.Append(", targetDate=").Append(TargetDate);
            sb.Append(", invoiceNumber='").Append(InvoiceNumber).Append('\'');
            sb.Append(", balance=").Append(Balance);
            sb.Append(", creditAdj=").Append(CreditAdj);
            sb.Append(", refundAdj=").Append(RefundAdj);
            sb.Append(", accountId='").Append(AccountId).Append('\'');
            sb.Append(", items=").Append(Items);
            sb.Append(", bundleKeys='").Append(BundleKeys).Append('\'');
            sb.Append(", credits=").Append(Credits);
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

            Invoice invoice = (Invoice) o;

            if (AccountId != null ? !AccountId.Equals(invoice.AccountId) : invoice.AccountId != null)
            {
                return false;
            }
            if (Amount != null ? Amount.CompareTo(invoice.Amount) != 0 : invoice.Amount != null)
            {
                return false;
            }
            if (Balance != null ? Balance.CompareTo(invoice.Balance) != 0 : invoice.Balance != null)
            {
                return false;
            }
            if (BundleKeys != null ? !BundleKeys.Equals(invoice.BundleKeys) : invoice.BundleKeys != null)
            {
                return false;
            }
            if (CreditAdj != null ? CreditAdj.CompareTo(invoice.CreditAdj) != 0 : invoice.CreditAdj != null)
            {
                return false;
            }
            if (Credits != null ? !Credits.Equals(invoice.Credits) : invoice.Credits != null)
            {
                return false;
            }
            if (Currency != null ? !Currency.Equals(invoice.Currency) : invoice.Currency != null)
            {
                return false;
            }
            if (InvoiceDate != null ? InvoiceDate.CompareTo(invoice.InvoiceDate) != 0 : invoice.InvoiceDate != null)
            {
                return false;
            }
            if (InvoiceId != null ? !InvoiceId.Equals(invoice.InvoiceId) : invoice.InvoiceId != null)
            {
                return false;
            }
            if (InvoiceNumber != null ? !InvoiceNumber.Equals(invoice.InvoiceNumber) : invoice.InvoiceNumber != null)
            {
                return false;
            }
            if (Items != null ? !Items.Equals(invoice.Items) : invoice.Items != null)
            {
                return false;
            }
            if (RefundAdj != null ? RefundAdj.CompareTo(invoice.RefundAdj) != 0 : invoice.RefundAdj != null)
            {
                return false;
            }
            if (TargetDate != null ? TargetDate.CompareTo(invoice.TargetDate) != 0 : invoice.TargetDate != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = Amount != null ? Amount.GetHashCode() : 0;
            result = 31*result + (Currency != null ? Currency.GetHashCode() : 0);
            result = 31*result + (InvoiceId != null ? InvoiceId.GetHashCode() : 0);
            result = 31*result + (InvoiceDate != null ? InvoiceDate.GetHashCode() : 0);
            result = 31*result + (TargetDate != null ? TargetDate.GetHashCode() : 0);
            result = 31*result + (InvoiceNumber != null ? InvoiceNumber.GetHashCode() : 0);
            result = 31*result + (Balance != null ? Balance.GetHashCode() : 0);
            result = 31*result + (CreditAdj != null ? CreditAdj.GetHashCode() : 0);
            result = 31*result + (RefundAdj != null ? RefundAdj.GetHashCode() : 0);
            result = 31*result + (AccountId != null ? AccountId.GetHashCode() : 0);
            result = 31*result + (Items != null ? Items.GetHashCode() : 0);
            result = 31*result + (BundleKeys != null ? BundleKeys.GetHashCode() : 0);
            result = 31*result + (Credits != null ? Credits.GetHashCode() : 0);
            return result;
        }
    }
}
