
using System;
using System.Text;

namespace Killbill_Client.model
{

    public class UsageRecord
    {

        private DateTime recordDate;
        private long amount;

        public string ToString()
        {
            StringBuilder sb = new StringBuilder("UsageRecord{");
            sb.Append("recordDate=").Append(recordDate);
            sb.Append(", amount=").Append(amount);
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

            UsageRecord that = (UsageRecord) o;

            if (recordDate != null ? recordDate.CompareTo(that.recordDate) != 0 : that.recordDate != null)
            {
                return false;
            }
            return amount != null ? amount.Equals(that.amount) : that.amount == null;
        }


        public int GetHashCode()
        {
            int result = recordDate != null ? recordDate.GetHashCode() : 0;
            result = 31*result + (amount != null ? amount.GetHashCode() : 0);
            return result;
        }
    }
}