
using System;
using System.Text;
namespace Killbill_Client.model
{
    public class PluginProperty
    {
        private string key;
        private string value;
        private bool isUpdatable;
        
        public string ToString()
        {
            StringBuilder sb = new StringBuilder("PaymentMethodProperties{");
            sb.Append("key='").Append(key).Append('\'');
            sb.Append(", value='").Append(value).Append('\'');
            sb.Append(", isUpdatable=").Append(isUpdatable);
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

            PluginProperty that = (PluginProperty) o;

            if (isUpdatable != null ? !isUpdatable.Equals(that.isUpdatable) : that.isUpdatable != null)
            {
                return false;
            }
            if (key != null ? !key.Equals(that.key) : that.key != null)
            {
                return false;
            }
            if (value != null ? !value.Equals(that.value) : that.value != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = key != null ? key.GetHashCode() : 0;
            result = 31*result + (value != null ? value.GetHashCode() : 0);
            result = 31*result + (isUpdatable != null ? isUpdatable.GetHashCode() : 0);
            return result;
        }
    }
}