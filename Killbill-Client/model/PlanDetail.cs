
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{
    public class PlanDetail : KillBillObject
    {

        private string product;
        private string plan;
        private BillingPeriod finalPhaseBillingPeriod;
        private string priceList;
        private List<Price> finalPhaseRecurringPrice;





        public string ToString()
        {
            StringBuilder sb = new StringBuilder("PlanDetail{");
            sb.Append("product='").Append(product).Append('\'');
            sb.Append(", plan='").Append(plan).Append('\'');
            sb.Append(", finalPhaseBillingPeriod=").Append(finalPhaseBillingPeriod);
            sb.Append(", priceList='").Append(priceList).Append('\'');
            sb.Append(", finalPhaseRecurringPrice=").Append(finalPhaseRecurringPrice);
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

            PlanDetail that = (PlanDetail)o;

            if (finalPhaseBillingPeriod != that.finalPhaseBillingPeriod)
            {
                return false;
            }
            if (finalPhaseRecurringPrice != null
                ? !finalPhaseRecurringPrice.Equals(that.finalPhaseRecurringPrice)
                : that.finalPhaseRecurringPrice != null)
            {
                return false;
            }
            if (plan != null ? !plan.Equals(that.plan) : that.plan != null)
            {
                return false;
            }
            if (priceList != null ? !priceList.Equals(that.priceList) : that.priceList != null)
            {
                return false;
            }
            if (product != null ? !product.Equals(that.product) : that.product != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = product != null ? product.GetHashCode() : 0;
            result = 31 * result + (plan != null ? plan.GetHashCode() : 0);
            result = 31 * result + (finalPhaseBillingPeriod != null ? finalPhaseBillingPeriod.GetHashCode() : 0);
            result = 31 * result + (priceList != null ? priceList.GetHashCode() : 0);
            result = 31 * result + (finalPhaseRecurringPrice != null ? finalPhaseRecurringPrice.GetHashCode() : 0);
            return result;
        }
    }
}