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






public class Tenant : KillBillObject {

    private Guid tenantId;
    private string externalKey;
    private string apiKey;
    private string apiSecret;

    public Tenant() {}

    
    public Tenant(@JsonProperty("tenantId") Guid tenantId,
                  @JsonProperty("externalKey") string externalKey,
                  @JsonProperty("apiKey") string apiKey,
                  @JsonProperty("apiSecret") string apiSecret) {
        this.tenantId = tenantId;
        this.externalKey = externalKey;
        this.apiKey = apiKey;
        this.apiSecret = apiSecret;
    }

    public Guid getTenantId() {
        return tenantId;
    }

    public void setTenantId(Guid tenantId) {
        this.tenantId = tenantId;
    }

    public string getExternalKey() {
        return externalKey;
    }

    public void setExternalKey(string externalKey) {
        this.externalKey = externalKey;
    }

    public string getApiKey() {
        return apiKey;
    }

    public void setApiKey(string apiKey) {
        this.apiKey = apiKey;
    }

    public string getApiSecret() {
        return apiSecret;
    }

    public void setApiSecret(string apiSecret) {
        this.apiSecret = apiSecret;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("Tenant{");
        sb.Append("tenantId='").append(tenantId).append('\'');
        sb.Append(", externalKey='").append(externalKey).append('\'');
        sb.Append(", apiKey='").append(apiKey).append('\'');
        sb.Append(", apiSecret='").append(apiSecret).append('\'');
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

        Tenant tenant = (Tenant) o;

        if (apiKey != null ? !apiKey.equals(tenant.apiKey) : tenant.apiKey != null) {
            return false;
        }
        if (apiSecret != null ? !apiSecret.equals(tenant.apiSecret) : tenant.apiSecret != null) {
            return false;
        }
        if (externalKey != null ? !externalKey.equals(tenant.externalKey) : tenant.externalKey != null) {
            return false;
        }
        if (tenantId != null ? !tenantId.equals(tenant.tenantId) : tenant.tenantId != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = tenantId != null ? tenantId.GetHashCode() : 0;
        result = 31 * result + (externalKey != null ? externalKey.GetHashCode() : 0);
        result = 31 * result + (apiKey != null ? apiKey.GetHashCode() : 0);
        result = 31 * result + (apiSecret != null ? apiSecret.GetHashCode() : 0);
        return result;
    }
}
