using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{

    public class UnitUsageRecord
    {

        private string unitType;
        private List<UsageRecord> usageRecords;


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("UnitUsageRecord{");
            sb.Append("unitType=").Append(unitType);
            sb.Append(", usageRecords=").Append(usageRecords);
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

            UnitUsageRecord that = (UnitUsageRecord) o;

            if (unitType != null ? !unitType.Equals(that.unitType) : that.unitType != null)
            {
                return false;
            }
            return usageRecords != null ? usageRecords.Equals(that.usageRecords) : that.usageRecords == null;

        }


        public int GetHashCode()
        {
            int result = unitType != null ? unitType.GetHashCode() : 0;
            result = 31*result + (usageRecords != null ? usageRecords.GetHashCode() : 0);
            return result;
        }
    }
}