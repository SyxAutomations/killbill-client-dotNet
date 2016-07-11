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








public class Plan : KillBillObject {

    private string name;
    private BillingPeriod billingPeriod;
    private List<Phase> phases;

    
    public Plan(@JsonProperty("name") string name,
                @JsonProperty("billingPeriod") BillingPeriod billingPeriod,
                @JsonProperty("phases") List<Phase> phases) {
        this.name = name;
        this.billingPeriod = billingPeriod;
        this.phases = phases;
    }

    public string getName() {
        return name;
    }

    public BillingPeriod getBillingPeriod() {
        return billingPeriod;
    }

    public List<Phase> getPhases() {
        return phases;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("Plan{");
        sb.Append("name='").append(name).append('\'');
        sb.Append(", billingPeriod='").append(billingPeriod).append('\'');
        sb.Append(", phases=").append(phases);
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

        Plan plan = (Plan) o;

        if (name != null ? !name.equals(plan.name) : plan.name != null) {
            return false;
        }
        if (billingPeriod != null ? !billingPeriod.equals(plan.billingPeriod) : plan.billingPeriod != null) {
            return false;
        }
        if (phases != null ? !phases.equals(plan.phases) : plan.phases != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = name != null ? name.GetHashCode() : 0;
        result = 31 * result + (billingPeriod != null ? billingPeriod.GetHashCode() : 0);
        result = 31 * result + (phases != null ? phases.GetHashCode() : 0);
        return result;
    }
}
