
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{

    public class SubscriptionUsageRecord
    {

        private Guid subscriptionId;
        private List<UnitUsageRecord> unitUsageRecords;


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("SubscriptionUsageRecord{");
            sb.Append("subscriptionId=").Append(subscriptionId);
            sb.Append(", unitUsageRecords=").Append(unitUsageRecords);
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

            SubscriptionUsageRecord that = (SubscriptionUsageRecord) o;

            if (subscriptionId != null ? !subscriptionId.Equals(that.subscriptionId) : that.subscriptionId != null)
            {
                return false;
            }
            return unitUsageRecords != null
                ? unitUsageRecords.Equals(that.unitUsageRecords)
                : that.unitUsageRecords == null;

        }


        public int GetHashCode()
        {
            int result = subscriptionId != null ? subscriptionId.GetHashCode() : 0;
            result = 31*result + (unitUsageRecords != null ? unitUsageRecords.GetHashCode() : 0);
            return result;
        }
    }
}