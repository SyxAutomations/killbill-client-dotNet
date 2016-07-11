
using System;
using System.Text;

namespace Killbill_Client.model
{

    public class RolledUpUnit
    {

        private string unitType;
        private long amount;

        public RolledUpUnit()
        {
        }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("RolledUpUnit{");
            sb.Append("unitType=").Append(unitType);
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

            RolledUpUnit that = (RolledUpUnit) o;

            if (unitType != null ? !unitType.Equals(that.unitType) : that.unitType != null)
            {
                return false;
            }
            return amount != null ? amount.Equals(that.amount) : that.amount == null;

        }


        public int GetHashCode()
        {
            int result = unitType != null ? unitType.GetHashCode() : 0;
            result = 31*result + (amount != null ? amount.GetHashCode() : 0);
            return result;
        }
    }
}