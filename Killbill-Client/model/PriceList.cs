/*
 * Copyright 2010-2013 Ning, Inc.
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






public class PriceList {

    private string name;
    private List<String> plans;

    
    public PriceList(@JsonProperty("name") string name,
                         @JsonProperty("plans") List<String> plans) {
        this.name = name;
        this.plans = plans;
    }

    public string getName() {
        return name;
    }

    public List<String> getPlans() {
        return plans;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("PriceList{");
        sb.Append("name='").append(name).append('\'');
        sb.Append(", plans=").append(plans);
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

        PriceList that = (PriceList) o;

        if (name != null ? !name.equals(that.name) : that.name != null) {
            return false;
        }
        return !(plans != null ? !plans.equals(that.plans) : that.plans != null);

    }

    
    public int GetHashCode() {
        int result = name != null ? name.GetHashCode() : 0;
        result = 31 * result + (plans != null ? plans.GetHashCode() : 0);
        return result;
    }

}
