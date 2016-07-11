using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killbill_Client.model
{
    public class AccountTimeline
    {
        private Account account;
        private List<Bundle> bundles;
        private List<Invoice> invoices;
        private List<InvoicePayment> payments;

        public AccountTimeline() { }

        public AccountTimeline(Account account,
                              List<Bundle> bundles,
                               List<Invoice> invoices,
                                List<InvoicePayment> payments)
        {
            this.account = account;
            this.bundles = bundles;
            this.invoices = invoices;
            this.payments = payments;
        }

        public Account getAccount()
        {
            return account;
        }

        public void setAccount(Account account)
        {
            this.account = account;
        }

        public List<Bundle> getBundles()
        {
            return bundles;
        }

        public void setBundles(List<Bundle> bundles)
        {
            this.bundles = bundles;
        }

        public List<Invoice> getInvoices()
        {
            return invoices;
        }

        public void setInvoices(List<Invoice> invoices)
        {
            this.invoices = invoices;
        }

        public List<InvoicePayment> getPayments()
        {
            return payments;
        }

        public void setPayments(List<InvoicePayment> payments)
        {
            this.payments = payments;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("AccountTimeline{");
            sb.Append("account=").Append(account);
            sb.Append(", bundles=").Append(bundles);
            sb.Append(", invoices=").Append(invoices);
            sb.Append(", payments=").Append(payments);
            sb.Append('}');
            return sb.ToString();
        }


        public override bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            AccountTimeline that = (AccountTimeline)o;

            if (account != null ? !account.Equals(that.account) : that.account != null)
            {
                return false;
            }
            if (bundles != null ? !bundles.Equals(that.bundles) : that.bundles != null)
            {
                return false;
            }
            if (invoices != null ? !invoices.Equals(that.invoices) : that.invoices != null)
            {
                return false;
            }
            if (payments != null ? !payments.Equals(that.payments) : that.payments != null)
            {
                return false;
            }

            return true;
        }


        public override int GetHashCode()
        {
            int result = account != null ? account.GetHashCode() : 0;
            result = 31 * result + (bundles != null ? bundles.GetHashCode() : 0);
            result = 31 * result + (invoices != null ? invoices.GetHashCode() : 0);
            result = 31 * result + (payments != null ? payments.GetHashCode() : 0);
            return result;
        }
    }
}
