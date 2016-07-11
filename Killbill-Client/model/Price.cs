
using System;
using System.Numerics;
using System.Text;

namespace Killbill_Client.model
{

    public class Price : KillBillObject
    {

        private string currency;
        private BigInteger value;

        public string ToString()
        {
            StringBuilder sb = new StringBuilder("Price{");
            sb.Append("currency='").Append(currency).Append('\'');
            sb.Append(", value=").Append(value);
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

            Price price = (Price)o;

            if (currency != null ? !currency.Equals(price.currency) : price.currency != null)
            {
                return false;
            }
            if (value != null ? !value.Equals(price.value) : price.value != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = currency != null ? currency.GetHashCode() : 0;
            result = 31 * result + (value != null ? value.GetHashCode() : 0);
            return result;
        }
    }
}