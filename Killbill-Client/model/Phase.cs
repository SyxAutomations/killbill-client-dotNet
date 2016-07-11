
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{
    public class Phase : KillBillObject
    {

        private string type;
        private List<Price> prices;
        private List<Price> fixedPrices;
        private Duration duration;

        public string ToString()
        {
            StringBuilder sb = new StringBuilder("Phase{");
            sb.Append("type='").Append(type).Append('\'');
            sb.Append(", prices=").Append(prices);
            sb.Append(", fixedPrices=").Append(fixedPrices);
            sb.Append(", duration=").Append(duration);
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

            Phase phase = (Phase) o;

            if (prices != null ? !prices.Equals(phase.prices) : phase.prices != null)
            {
                return false;
            }
            if (type != null ? !type.Equals(phase.type) : phase.type != null)
            {
                return false;
            }
            if (fixedPrices != null ? !fixedPrices.Equals(phase.fixedPrices) : phase.fixedPrices != null)
            {
                return false;
            }
            if (duration != null ? !duration.Equals(phase.duration) : phase.duration != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = type != null ? type.GetHashCode() : 0;
            result = 31*result + (prices != null ? prices.GetHashCode() : 0);
            result = 31*result + (fixedPrices != null ? fixedPrices.GetHashCode() : 0);
            result = 31*result + (duration != null ? duration.GetHashCode() : 0);
            return result;
        }
    }
}