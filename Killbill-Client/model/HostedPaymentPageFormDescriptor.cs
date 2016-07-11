using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model {

    public class HostedPaymentPageFormDescriptor : KillBillObject
    {
        public Guid KbAccountId { get; set; }
        public string FormMethod { get; set; }
        public string FormUrl { get; set; }
        public Dictionary<string, string> FormFields { get; set; }
        public Dictionary<string, string> Properties { get; set; }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder("HostedPaymentPageFormDescriptor{");
            sb.Append("kbAccountId='").Append(KbAccountId).Append('\'');
            sb.Append(", formMethod='").Append(FormMethod).Append('\'');
            sb.Append(", formUrl='").Append(FormUrl).Append('\'');
            sb.Append(", formFields=").Append(FormFields);
            sb.Append(", properties=").Append(Properties);
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

            HostedPaymentPageFormDescriptor that = (HostedPaymentPageFormDescriptor) o;

            if (FormFields != null ? !FormFields.Equals(that.FormFields) : that.FormFields != null)
            {
                return false;
            }
            if (FormMethod != null ? !FormMethod.Equals(that.FormMethod) : that.FormMethod != null)
            {
                return false;
            }
            if (FormUrl != null ? !FormUrl.Equals(that.FormUrl) : that.FormUrl != null)
            {
                return false;
            }
            if (KbAccountId != null ? !KbAccountId.Equals(that.KbAccountId) : that.KbAccountId != null)
            {
                return false;
            }
            if (Properties != null ? !Properties.Equals(that.Properties) : that.Properties != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = this.KbAccountId != null ? this.KbAccountId.GetHashCode() : 0;
            result = 31*result + (FormMethod != null ? FormMethod.GetHashCode() : 0);
            result = 31*result + (FormUrl != null ? FormUrl.GetHashCode() : 0);
            result = 31*result + (FormFields != null ? FormFields.GetHashCode() : 0);
            result = 31*result + (Properties != null ? Properties.GetHashCode() : 0);
            return result;
        }
    }
}
