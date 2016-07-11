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






public class Product : KillBillObject {

    private string type;
    private string name;
    private List<Plan> plans;
    private List<String> included;
    private List<String> available;

    
    public Product(@JsonProperty("type") string type,
                   @JsonProperty("name") string name,
                   @JsonProperty("plans") List<Plan> plans,
                   @JsonProperty("included") List<String> included,
                   @JsonProperty("available") List<String> available) {
        this.type = type;
        this.name = name;
        this.plans = plans;
        this.included = included;
        this.available = available;
    }

    public string getType() {
        return type;
    }

    public void setType(string type) {
        this.type = type;
    }

    public string getName() {
        return name;
    }

    public void setName(string name) {
        this.name = name;
    }

    public List<Plan> getPlans() {
        return plans;
    }

    public void setPlans(List<Plan> plans) {
        this.plans = plans;
    }

    public List<String> getIncluded() {
        return included;
    }

    public void setIncluded(List<String> included) {
        this.included = included;
    }

    public List<String> getAvailable() {
        return available;
    }

    public void setAvailable(List<String> available) {
        this.available = available;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("Product{");
        sb.Append("type='").append(type).append('\'');
        sb.Append(", name='").append(name).append('\'');
        sb.Append(", plans=").append(plans);
        sb.Append(", included=").append(included);
        sb.Append(", available=").append(available);
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

        Product product = (Product) o;

        if (available != null ? !available.equals(product.available) : product.available != null) {
            return false;
        }
        if (included != null ? !included.equals(product.included) : product.included != null) {
            return false;
        }
        if (name != null ? !name.equals(product.name) : product.name != null) {
            return false;
        }
        if (plans != null ? !plans.equals(product.plans) : product.plans != null) {
            return false;
        }
        if (type != null ? !type.equals(product.type) : product.type != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = type != null ? type.GetHashCode() : 0;
        result = 31 * result + (name != null ? name.GetHashCode() : 0);
        result = 31 * result + (plans != null ? plans.GetHashCode() : 0);
        result = 31 * result + (included != null ? included.GetHashCode() : 0);
        result = 31 * result + (available != null ? available.GetHashCode() : 0);
        return result;
    }
}
