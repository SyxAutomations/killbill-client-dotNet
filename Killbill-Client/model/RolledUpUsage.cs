using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{

    public class RolledUpUsage
    {

        private Guid subscriptionId;
        private DateTime startDate;
        private DateTime endDate;
        private List<RolledUpUnit> rolledUpUnits;



        public string ToString()
        {
            StringBuilder sb = new StringBuilder("RolledUpUsage{");
            sb.Append("subscriptionId=").Append(subscriptionId);
            sb.Append(", startDate=").Append(startDate);
            sb.Append(", endDate=").Append(endDate);
            sb.Append(", rolledUpUnits=").Append(rolledUpUnits);
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

            RolledUpUsage that = (RolledUpUsage) o;

            if (subscriptionId != null ? !subscriptionId.Equals(that.subscriptionId) : that.subscriptionId != null)
            {
                return false;
            }
            if (startDate != null ? !startDate.Equals(that.startDate) : that.startDate != null)
            {
                return false;
            }
            if (endDate != null ? !endDate.Equals(that.endDate) : that.endDate != null)
            {
                return false;
            }
            return rolledUpUnits != null ? rolledUpUnits.Equals(that.rolledUpUnits) : that.rolledUpUnits == null;

        }


        public int GetHashCode()
        {
            int result = subscriptionId != null ? subscriptionId.GetHashCode() : 0;
            result = 31*result + (startDate != null ? startDate.GetHashCode() : 0);
            result = 31*result + (endDate != null ? endDate.GetHashCode() : 0);
            result = 31*result + (rolledUpUnits != null ? rolledUpUnits.GetHashCode() : 0);
            return result;
        }
    }
}