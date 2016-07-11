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






public class UnitUsageRecord {

    private string unitType;
    private List<UsageRecord> usageRecords;

    public UnitUsageRecord() {}

    
    public UnitUsageRecord(@JsonProperty("unitType") string unitType,
                           @JsonProperty("usageRecords") List<UsageRecord> usageRecords) {
        this.unitType = unitType;
        this.usageRecords = usageRecords;
    }

    public string getUnitType() {
        return unitType;
    }

    public void setUnitType(string unitType) {
        this.unitType = unitType;
    }

    public List<UsageRecord> getUsageRecords() {
        return usageRecords;
    }

    public void setUsageRecords(List<UsageRecord> usageRecords) {
        this.usageRecords = usageRecords;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("UnitUsageRecord{");
        sb.Append("unitType=").append(unitType);
        sb.Append(", usageRecords=").append(usageRecords);
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

        UnitUsageRecord that = (UnitUsageRecord) o;

        if (unitType != null ? !unitType.equals(that.unitType) : that.unitType != null) {
            return false;
        }
        return usageRecords != null ? usageRecords.equals(that.usageRecords) : that.usageRecords == null;

    }

    
    public int GetHashCode() {
        int result = unitType != null ? unitType.GetHashCode() : 0;
        result = 31 * result + (usageRecords != null ? usageRecords.GetHashCode() : 0);
        return result;
    }
}
