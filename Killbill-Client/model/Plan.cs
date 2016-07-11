
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{

    public class Plan : KillBillObject
    {

        private string name;
        private BillingPeriod billingPeriod;
        private List<Phase> phases;



        public string ToString()
        {
            StringBuilder sb = new StringBuilder("Plan{");
            sb.Append("name='").Append(name).Append('\'');
            sb.Append(", billingPeriod='").Append(billingPeriod).Append('\'');
            sb.Append(", phases=").Append(phases);
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

            Plan plan = (Plan) o;

            if (name != null ? !name.Equals(plan.name) : plan.name != null)
            {
                return false;
            }
            if (billingPeriod != null ? !billingPeriod.Equals(plan.billingPeriod) : plan.billingPeriod != null)
            {
                return false;
            }
            if (phases != null ? !phases.Equals(plan.phases) : plan.phases != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = name != null ? name.GetHashCode() : 0;
            result = 31*result + (billingPeriod != null ? billingPeriod.GetHashCode() : 0);
            result = 31*result + (phases != null ? phases.GetHashCode() : 0);
            return result;
        }
    }
}