using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model {

    public class HostedPaymentPageFields : KillBillObject
    {

        public List<PluginProperty> FormFields { get; set; }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder("HostedPaymentPageFields{");
            sb.Append("formFields=").Append(FormFields);
            sb.Append('}');
            return sb.ToString();
        }


        public bool equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            HostedPaymentPageFields that = (HostedPaymentPageFields) o;

            if (FormFields != null ? !FormFields.Equals(that.FormFields) : that.FormFields != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            return FormFields != null ? FormFields.GetHashCode() : 0;
        }
    }
}
