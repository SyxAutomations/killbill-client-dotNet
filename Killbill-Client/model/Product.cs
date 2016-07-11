
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{

    public class Product : KillBillObject
    {

        private string type;
        private string name;
        private List<Plan> plans;
        private List<String> included;
        private List<String> available;



        public string ToString()
        {
            StringBuilder sb = new StringBuilder("Product{");
            sb.Append("type='").Append(type).Append('\'');
            sb.Append(", name='").Append(name).Append('\'');
            sb.Append(", plans=").Append(plans);
            sb.Append(", included=").Append(included);
            sb.Append(", available=").Append(available);
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

            Product product = (Product)o;

            if (available != null ? !available.Equals(product.available) : product.available != null)
            {
                return false;
            }
            if (included != null ? !included.Equals(product.included) : product.included != null)
            {
                return false;
            }
            if (name != null ? !name.Equals(product.name) : product.name != null)
            {
                return false;
            }
            if (plans != null ? !plans.Equals(product.plans) : product.plans != null)
            {
                return false;
            }
            if (type != null ? !type.Equals(product.type) : product.type != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = type != null ? type.GetHashCode() : 0;
            result = 31 * result + (name != null ? name.GetHashCode() : 0);
            result = 31 * result + (plans != null ? plans.GetHashCode() : 0);
            result = 31 * result + (included != null ? included.GetHashCode() : 0);
            result = 31 * result + (available != null ? available.GetHashCode() : 0);
            return result;
        }
    }
}