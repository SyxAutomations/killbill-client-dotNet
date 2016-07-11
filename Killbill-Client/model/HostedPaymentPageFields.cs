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






public class HostedPaymentPageFields : KillBillObject {

    private List<PluginProperty> formFields;

    public HostedPaymentPageFields() {}

    
    public HostedPaymentPageFields(@JsonProperty("formFields") List<PluginProperty> formFields) {
       );
        this.formFields = formFields;
    }

    public List<PluginProperty> getFormFields() {
        return formFields;
    }

    public void setFormFields(List<PluginProperty> formFields) {
        this.formFields = formFields;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("HostedPaymentPageFields{");
        sb.Append("formFields=").append(formFields);
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

        HostedPaymentPageFields that = (HostedPaymentPageFields) o;

        if (formFields != null ? !formFields.equals(that.formFields) : that.formFields != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        return formFields != null ? formFields.GetHashCode() : 0;
    }
}
