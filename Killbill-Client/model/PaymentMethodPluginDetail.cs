/*
 * Copyright 2010-2014 Ning, Inc.
 * Copyright 2015 Groupon, Inc
 * Copyright 2015 The Billing Project, LLC
 *
 * The Billing Project licenses this file to you under the Apache License, version 2.0
 * (the "License"); you may not use this file except in compliance with the
 * License.  You may obtain a copy of the License at:
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

namespace Killbill_Client.model {






public class PaymentMethodPluginDetail {

    private string externalPaymentMethodId;
    private bool isDefaultPaymentMethod;
    private List<PluginProperty> properties;

    public PaymentMethodPluginDetail() {}

    
    public PaymentMethodPluginDetail(@JsonProperty("externalPaymentMethodId") string externalPaymentMethodId,
                                     @JsonProperty("isDefaultPaymentMethod") bool isDefaultPaymentMethod,
                                     @JsonProperty("properties") List<PluginProperty> properties) {
        this.externalPaymentMethodId = externalPaymentMethodId;
        this.isDefaultPaymentMethod = isDefaultPaymentMethod;
        this.properties = properties;
    }

    public string getExternalPaymentMethodId() {
        return externalPaymentMethodId;
    }

    public void setExternalPaymentMethodId(string externalPaymentMethodId) {
        this.externalPaymentMethodId = externalPaymentMethodId;
    }

    public bool getIsDefaultPaymentMethod() {
        return isDefaultPaymentMethod;
    }

    public void setIsDefaultPaymentMethod(bool isDefaultPaymentMethod) {
        this.isDefaultPaymentMethod = isDefaultPaymentMethod;
    }

    public List<PluginProperty> getProperties() {
        return properties;
    }

    public void setProperties(List<PluginProperty> properties) {
        this.properties = properties;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("PaymentMethodPluginDetail{");
        sb.Append("externalPaymentMethodId='").append(externalPaymentMethodId).append('\'');
        sb.Append(", isDefaultPaymentMethod=").append(isDefaultPaymentMethod);
        sb.Append(", properties=").append(properties);
        sb.Append('}');
        return sb.ToString();
    }

    
    public bool equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        PaymentMethodPluginDetail that = (PaymentMethodPluginDetail) o;

        if (externalPaymentMethodId != null ? !externalPaymentMethodId.equals(that.externalPaymentMethodId) : that.externalPaymentMethodId != null) {
            return false;
        }
        if (isDefaultPaymentMethod != null ? !isDefaultPaymentMethod.equals(that.isDefaultPaymentMethod) : that.isDefaultPaymentMethod != null) {
            return false;
        }
        if (properties != null ? !properties.equals(that.properties) : that.properties != null) {
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
