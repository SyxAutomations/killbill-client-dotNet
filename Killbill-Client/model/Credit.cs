using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Killbill_Client.model
{
    public class Credit : KillBillObject
    {

        private BigInteger creditAmount;
        private Guid invoiceId;
        private string invoiceNumber;
        private DateTime effectiveDate;
        private Guid accountId;

        public Credit()
        {
        }


        public Credit(BigInteger creditAmount,
            Guid invoiceId,
            string invoiceNumber,
            DateTime effectiveDate,
            Guid accountId,
            List<AuditLog> auditLogs)
        {
            this.creditAmount = creditAmount;
            this.invoiceId = invoiceId;
            this.invoiceNumber = invoiceNumber;
            this.effectiveDate = effectiveDate;
            this.accountId = accountId;
        }

        public BigInteger getCreditAmount()
        {
            return creditAmount;
        }

        public void setCreditAmount(BigInteger creditAmount)
        {
            this.creditAmount = creditAmount;
        }

        public Guid getInvoiceId()
        {
            return invoiceId;
        }

        public void setInvoiceId(Guid invoiceId)
        {
            this.invoiceId = invoiceId;
        }

        public string getInvoiceNumber()
        {
            return invoiceNumber;
        }

        public void setInvoiceNumber(string invoiceNumber)
        {
            this.invoiceNumber = invoiceNumber;
        }

        public DateTime getEffectiveDate()
        {
            return effectiveDate;
        }

        public void setEffectiveDate(DateTime effectiveDate)
        {
            this.effectiveDate = effectiveDate;
        }

        public Guid getAccountId()
        {
            return accountId;
        }

        public void setAccountId(Guid accountId)
        {
            this.accountId = accountId;
        }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("Credit{");
            sb.Append("creditAmount=").Append(creditAmount);
            sb.Append(", invoiceId='").Append(invoiceId).Append('\'');
            sb.Append(", invoiceNumber='").Append(invoiceNumber).Append('\'');
            sb.Append(", effectiveDate=").Append(effectiveDate);
            sb.Append(", accountId='").Append(accountId).Append('\'');
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

            Credit credit = (Credit)o;

            if (accountId != null ? !accountId.Equals(credit.accountId) : credit.accountId != null)
            {
                return false;
            }
            if (creditAmount != null ? creditAmount.CompareTo(credit.creditAmount) != 0 : credit.creditAmount != null)
            {
                return false;
            }
            if (effectiveDate != null
                ? effectiveDate.CompareTo(credit.effectiveDate) != 0
                : credit.effectiveDate != null)
            {
                return false;
            }
            if (invoiceId != null ? !invoiceId.Equals(credit.invoiceId) : credit.invoiceId != null)
            {
                return false;
            }
            if (invoiceNumber != null ? !invoiceNumber.Equals(credit.invoiceNumber) : credit.invoiceNumber != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = creditAmount != null ? creditAmount.GetHashCode() : 0;
            result = 31 * result + (invoiceId != null ? invoiceId.GetHashCode() : 0);
            result = 31 * result + (invoiceNumber != null ? invoiceNumber.GetHashCode() : 0);
            result = 31 * result + (effectiveDate != null ? effectiveDate.GetHashCode() : 0);
            result = 31 * result + (accountId != null ? accountId.GetHashCode() : 0);
            return result;
        }
    }
}
