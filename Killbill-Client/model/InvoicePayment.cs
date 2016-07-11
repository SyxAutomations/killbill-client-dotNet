
using System;
using System.Collections.Generic;

namespace Killbill_Client.model
{

    public class InvoicePayment : Payment
    {

        private Guid targetInvoiceId;

        public bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (!(o is InvoicePayment))
            {
                return false;
            }
            if (!base.Equals(o))
            {
                return false;
            }

            InvoicePayment that = (InvoicePayment) o;

            if (targetInvoiceId != null ? !targetInvoiceId.Equals(that.targetInvoiceId) : that.targetInvoiceId != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31*result + (targetInvoiceId != null ? targetInvoiceId.GetHashCode() : 0);
            return result;
        }
    }
}
