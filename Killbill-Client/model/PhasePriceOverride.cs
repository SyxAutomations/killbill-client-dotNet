
using System;
using System.Numerics;

namespace Killbill_Client.model
{

    public class PhasePriceOverride
    {

        private string phaseName;
        private string phaseType;
        private BigInteger fixedPrice;
        private BigInteger recurringPrice;



        public bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (!(o is PhasePriceOverride))
            {
                return false;
            }

            PhasePriceOverride that = (PhasePriceOverride) o;

            if (phaseName != null ? !phaseName.Equals(that.phaseName) : that.phaseName != null)
            {
                return false;
            }
            if (phaseType != null ? !phaseType.Equals(that.phaseType) : that.phaseType != null)
            {
                return false;
            }
            if (fixedPrice != null ? fixedPrice.CompareTo(that.fixedPrice) != 0 : that.fixedPrice != null)
            {
                return false;
            }
            if (recurringPrice != null
                ? recurringPrice.CompareTo(that.recurringPrice) != 0
                : that.recurringPrice != null)
            {
                return false;
            }
            return true;
        }


        public int GetHashCode()
        {
            int result = phaseName != null ? phaseName.GetHashCode() : 0;
            result = 31*result + (phaseType != null ? phaseType.GetHashCode() : 0);
            result = 31*result + (fixedPrice != null ? fixedPrice.GetHashCode() : 0);
            result = 31*result + (recurringPrice != null ? recurringPrice.GetHashCode() : 0);
            return result;
        }
    }
}
