/*
 * Copyright 2014-2016 Groupon, Inc
 * Copyright 2014-2016 The Billing Project, LLC
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







public class SubscriptionUsageRecord {

    private Guid subscriptionId;
    private List<UnitUsageRecord> unitUsageRecords;

    public SubscriptionUsageRecord() {}

    
    public SubscriptionUsageRecord(@JsonProperty("subscriptionId") Guid subscriptionId,
                                   @JsonProperty("unitUsageRecords") List<UnitUsageRecord> unitUsageRecords) {
        this.subscriptionId = subscriptionId;
        this.unitUsageRecords = unitUsageRecords;
    }

    public Guid getSubscriptionId() {
        return subscriptionId;
    }

    public void setSubscriptionId(Guid subscriptionId) {
        this.subscriptionId = subscriptionId;
    }

    public List<UnitUsageRecord> getUnitUsageRecords() {
        return unitUsageRecords;
    }

    public void setUnitUsageRecords(List<UnitUsageRecord> unitUsageRecords) {
        this.unitUsageRecords = unitUsageRecords;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("SubscriptionUsageRecord{");
        sb.Append("subscriptionId=").append(subscriptionId);
        sb.Append(", unitUsageRecords=").append(unitUsageRecords);
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

        SubscriptionUsageRecord that = (SubscriptionUsageRecord) o;

        if (subscriptionId != null ? !subscriptionId.equals(that.subscriptionId) : that.subscriptionId != null) {
            return false;
        }
        return unitUsageRecords != null ? unitUsageRecords.equals(that.unitUsageRecords) : that.unitUsageRecords == null;

    }

    
    public int GetHashCode() {
        int result = subscriptionId != null ? subscriptionId.GetHashCode() : 0;
        result = 31 * result + (unitUsageRecords != null ? unitUsageRecords.GetHashCode() : 0);
        return result;
    }
}
