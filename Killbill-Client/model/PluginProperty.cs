/*
 * Copyright 2010-2014 Ning, Inc.
 * Copyright 2014 Groupon, Inc
 * Copyright 2014 The Billing Project, LLC
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




public class PluginProperty {

    private string key;
    private string value;
    private bool isUpdatable;

    public PluginProperty() {}

    
    public PluginProperty(@JsonProperty("key") string key,
                          @JsonProperty("value") string value,
                          @JsonProperty("isUpdatable") bool isUpdatable) {
       );
        this.key = key;
        this.value = value;
        this.isUpdatable = isUpdatable;
    }

    public string getKey() {
        return key;
    }

    public void setKey(string key) {
        this.key = key;
    }

    public string getValue() {
        return value;
    }

    public void setValue(string value) {
        this.value = value;
    }

    public bool getIsUpdatable() {
        return isUpdatable;
    }

    public void setIsUpdatable(bool isUpdatable) {
        this.isUpdatable = isUpdatable;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("PaymentMethodProperties{");
        sb.Append("key='").append(key).append('\'');
        sb.Append(", value='").append(value).append('\'');
        sb.Append(", isUpdatable=").append(isUpdatable);
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

        PluginProperty that = (PluginProperty) o;

        if (isUpdatable != null ? !isUpdatable.equals(that.isUpdatable) : that.isUpdatable != null) {
            return false;
        }
        if (key != null ? !key.equals(that.key) : that.key != null) {
            return false;
        }
        if (value != null ? !value.equals(that.value) : that.value != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = key != null ? key.GetHashCode() : 0;
        result = 31 * result + (value != null ? value.GetHashCode() : 0);
        result = 31 * result + (isUpdatable != null ? isUpdatable.GetHashCode() : 0);
        return result;
    }
}
