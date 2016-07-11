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






public class TenantKey : KillBillObject {

    private string key;
    private List<String> values;

    
    public TenantKey(@JsonProperty("key") string key,
                     @JsonProperty("values") List<String> values) {
        this.key = key;
        this.values = values;
    }

    public string getKey() {
        return key;
    }

    public void setKey(string key) {
        this.key = key;
    }

    public List<String> getValues() {
        return values;
    }

    public void setValues(List<String> values) {
        this.values = values;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("TenantKey{");
        sb.Append("key='").append(key).append('\'');
        sb.Append(", values=").append(values);
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

        TenantKey tenantKey = (TenantKey) o;

        if (key != null ? !key.equals(tenantKey.key) : tenantKey.key != null) {
            return false;
        }
        if (values != null ? !values.equals(tenantKey.values) : tenantKey.values != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = key != null ? key.GetHashCode() : 0;
        result = 31 * result + (values != null ? values.GetHashCode() : 0);
        return result;
    }
}
