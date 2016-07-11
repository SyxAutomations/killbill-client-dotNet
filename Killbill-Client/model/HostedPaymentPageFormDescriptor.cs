/*
 * Copyright 2014 Groupon, Inc
 * Copyright 2014 The Billing Project, LLC
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







public class HostedPaymentPageFormDescriptor : KillBillObject {

    private Guid kbAccountId;
    private string formMethod;
    private string formUrl;
    private Map<String, String> formFields;
    private Map<String, String> properties;

    public HostedPaymentPageFormDescriptor() {}

    
    public HostedPaymentPageFormDescriptor(@JsonProperty("kbAccountId") Guid kbAccountId,
                                           @JsonProperty("formMethod") string formMethod,
                                           @JsonProperty("formUrl") string formUrl,
                                           @JsonProperty("formFields") Map<String, String> formFields,
                                           @JsonProperty("properties") Map<String, String> properties) {
       );
        this.kbAccountId = kbAccountId;
        this.formMethod = formMethod;
        this.formUrl = formUrl;
        this.formFields = formFields;
        this.properties = properties;
    }

    public Guid getKbAccountId() {
        return kbAccountId;
    }

    public void setKbAccountId(Guid kbAccountId) {
        this.kbAccountId = kbAccountId;
    }

    public string getFormMethod() {
        return formMethod;
    }

    public void setFormMethod(string formMethod) {
        this.formMethod = formMethod;
    }

    public string getFormUrl() {
        return formUrl;
    }

    public void setFormUrl(string formUrl) {
        this.formUrl = formUrl;
    }

    public Map<String, String> getFormFields() {
        return formFields;
    }

    public void setFormFields(Map<String, String> formFields) {
        this.formFields = formFields;
    }

    public Map<String, String> getProperties() {
        return properties;
    }

    public void setProperties(Map<String, String> properties) {
        this.properties = properties;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("HostedPaymentPageFormDescriptor{");
        sb.Append("kbAccountId='").append(kbAccountId).append('\'');
        sb.Append(", formMethod='").append(formMethod).append('\'');
        sb.Append(", formUrl='").append(formUrl).append('\'');
        sb.Append(", formFields=").append(formFields);
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

        HostedPaymentPageFormDescriptor that = (HostedPaymentPageFormDescriptor) o;

        if (formFields != null ? !formFields.equals(that.formFields) : that.formFields != null) {
            return false;
        }
        if (formMethod != null ? !formMethod.equals(that.formMethod) : that.formMethod != null) {
            return false;
        }
        if (formUrl != null ? !formUrl.equals(that.formUrl) : that.formUrl != null) {
            return false;
        }
        if (kbAccountId != null ? !kbAccountId.equals(that.kbAccountId) : that.kbAccountId != null) {
            return false;
        }
        if (properties != null ? !properties.equals(that.properties) : that.properties != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = kbAccountId != null ? kbAccountId.GetHashCode() : 0;
        result = 31 * result + (formMethod != null ? formMethod.GetHashCode() : 0);
        result = 31 * result + (formUrl != null ? formUrl.GetHashCode() : 0);
        result = 31 * result + (formFields != null ? formFields.GetHashCode() : 0);
        result = 31 * result + (properties != null ? properties.GetHashCode() : 0);
        return result;
    }
}
