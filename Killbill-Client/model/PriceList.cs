
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{

    public class PriceList
    {

        private string name;
        private List<String> plans;


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("PriceList{");
            sb.Append("name='").Append(name).Append('\'');
            sb.Append(", plans=").Append(plans);
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

            PriceList that = (PriceList)o;

            if (name != null ? !name.Equals(that.name) : that.name != null)
            {
                return false;
            }
            return !(plans != null ? !plans.Equals(that.plans) : that.plans != null);

        }


        public int GetHashCode()
        {
            int result = name != null ? name.GetHashCode() : 0;
            result = 31 * result + (plans != null ? plans.GetHashCode() : 0);
            return result;
        }

    }
}