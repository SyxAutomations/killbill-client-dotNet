
using System;
using System.Text;

namespace Killbill_Client.model {

    public class InvoiceEmail : KillBillObject
    {

        public Guid accountId;
        public bool isNotifiedForInvoices;


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("InvoiceEmail{");
            sb.Append("accountId='").Append(accountId).Append('\'');
            sb.Append(", isNotifiedForInvoices=").Append(isNotifiedForInvoices);
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

            InvoiceEmail that = (InvoiceEmail) o;

            if (isNotifiedForInvoices != that.isNotifiedForInvoices)
            {
                return false;
            }
            if (accountId != null ? !accountId.Equals(that.accountId) : that.accountId != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = accountId != null ? accountId.GetHashCode() : 0;
            result = 31*result + (isNotifiedForInvoices ? 1 : 0);
            return result;
        }
    }
}
