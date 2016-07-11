
using System;
using System.Collections.Generic;

namespace Killbill_Client.model
{

    public class InvoicePaymentTransaction : PaymentTransaction
    {

        private bool isAdjusted;
        private List<InvoiceItem> adjustments;

        public bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (!(o is InvoicePaymentTransaction))
            {
                return false;
            }
            if (!base.Equals(o))
            {
                return false;
            }

            InvoicePaymentTransaction that = (InvoicePaymentTransaction)o;

            if (adjustments != null ? !adjustments.Equals(that.adjustments) : that.adjustments != null)
            {
                return false;
            }
            if (isAdjusted != null ? !isAdjusted.Equals(that.isAdjusted) : that.isAdjusted != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (isAdjusted != null ? isAdjusted.GetHashCode() : 0);
            result = 31 * result + (adjustments != null ? adjustments.GetHashCode() : 0);
            return result;
        }
    }
}
