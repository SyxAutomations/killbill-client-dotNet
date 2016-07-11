
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model {

public class PaymentMethodPluginDetail {

    private string externalPaymentMethodId;
    private bool isDefaultPaymentMethod;
    private List<PluginProperty> properties;

    

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("PaymentMethodPluginDetail{");
        sb.Append("externalPaymentMethodId='").Append(externalPaymentMethodId).Append('\'');
        sb.Append(", isDefaultPaymentMethod=").Append(isDefaultPaymentMethod);
        sb.Append(", properties=").Append(properties);
        sb.Append('}');
        return sb.ToString();
    }

    
    public bool Equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || GetType() != o.GetType()) {
            return false;
        }

        PaymentMethodPluginDetail that = (PaymentMethodPluginDetail) o;

        if (externalPaymentMethodId != null ? !externalPaymentMethodId.Equals(that.externalPaymentMethodId) : that.externalPaymentMethodId != null) {
            return false;
        }
        if (isDefaultPaymentMethod != null ? !isDefaultPaymentMethod.Equals(that.isDefaultPaymentMethod) : that.isDefaultPaymentMethod != null) {
            return false;
        }
        if (properties != null ? !properties.Equals(that.properties) : that.properties != null) {
            return false;
        }
        return true;
    }

    
    public int GetHashCode() {
        int result = externalPaymentMethodId != null ? externalPaymentMethodId.GetHashCode() : 0;
        result = 31 * result + (isDefaultPaymentMethod != null ? isDefaultPaymentMethod.GetHashCode() : 0);
        result = 31 * result + (properties != null ? properties.GetHashCode() : 0);
        return result;
    }
}
