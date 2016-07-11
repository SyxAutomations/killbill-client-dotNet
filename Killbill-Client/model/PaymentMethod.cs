/*
 * Copyright 2010-2014 Ning, Inc.
 *
 * Ning licenses this file to you under the Apache License, version 2.0
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






public class PaymentMethod : KillBillObject {

    private Guid paymentMethodId;
    private string externalKey;
    private Guid accountId;
    private bool isDefault;
    private string pluginName;
    private PaymentMethodPluginDetail pluginInfo;

    public PaymentMethod() {}

    
    public PaymentMethod(@JsonProperty("paymentMethodId") Guid paymentMethodId,
                         @JsonProperty("externalKey") string externalKey,
                         @JsonProperty("accountId") Guid accountId,
                         @JsonProperty("isDefault") bool isDefault,
                         @JsonProperty("pluginName") string pluginName,
                         @JsonProperty("pluginInfo") PaymentMethodPluginDetail pluginInfo) {
        this.paymentMethodId = paymentMethodId;
        this.externalKey = externalKey;
        this.accountId = accountId;
        this.isDefault = isDefault;
        this.pluginName = pluginName;
        this.pluginInfo = pluginInfo;
    }

    public Guid getPaymentMethodId() {
        return paymentMethodId;
    }

    public void setPaymentMethodId(Guid paymentMethodId) {
        this.paymentMethodId = paymentMethodId;
    }

    public Guid getAccountId() {
        return accountId;
    }

    public void setAccountId(Guid accountId) {
        this.accountId = accountId;
    }

    public bool getIsDefault() {
        return isDefault;
    }

    public void setIsDefault(bool isDefault) {
        this.isDefault = isDefault;
    }

    public string getPluginName() {
        return pluginName;
    }

    public void setPluginName(string pluginName) {
        this.pluginName = pluginName;
    }

    public PaymentMethodPluginDetail getPluginInfo() {
        return pluginInfo;
    }

    public void setPluginInfo(PaymentMethodPluginDetail pluginInfo) {
        this.pluginInfo = pluginInfo;
    }

    public string getExternalKey() {
        return externalKey;
    }

    public void setExternalKey(string externalKey) {
        this.externalKey = externalKey;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("PaymentMethod{");
        sb.Append("paymentMethodId='").append(paymentMethodId).append('\'');
        sb.Append(", accountId='").append(accountId).append('\'');
        sb.Append(", externalKey='").append(externalKey).append('\'');
        sb.Append(", isDefault=").append(isDefault);
        sb.Append(", pluginName='").append(pluginName).append('\'');
        sb.Append(", pluginInfo=").append(pluginInfo);
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

        PaymentMethod that = (PaymentMethod) o;

        if (accountId != null ? !accountId.equals(that.accountId) : that.accountId != null) {
            return false;
        }
        if (externalKey != null ? !externalKey.equals(that.externalKey) : that.externalKey != null) {
            return false;
        }
        if (isDefault != null ? !isDefault.equals(that.isDefault) : that.isDefault != null) {
            return false;
        }
        if (paymentMethodId != null ? !paymentMethodId.equals(that.paymentMethodId) : that.paymentMethodId != null) {
            return false;
        }
        if (pluginInfo != null ? !pluginInfo.equals(that.pluginInfo) : that.pluginInfo != null) {
            return false;
        }
        if (pluginName != null ? !pluginName.equals(that.pluginName) : that.pluginName != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = paymentMethodId != null ? paymentMethodId.GetHashCode() : 0;
        result = 31 * result + (accountId != null ? accountId.GetHashCode() : 0);
        result = 31 * result + (externalKey != null ? externalKey.GetHashCode() : 0);
        result = 31 * result + (isDefault != null ? isDefault.GetHashCode() : 0);
        result = 31 * result + (pluginName != null ? pluginName.GetHashCode() : 0);
        result = 31 * result + (pluginInfo != null ? pluginInfo.GetHashCode() : 0);
        return result;
    }
}
