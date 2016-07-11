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









public class RolledUpUsage {

    private Guid subscriptionId;
    private LocalDate startDate;
    private LocalDate endDate;
    private List<RolledUpUnit> rolledUpUnits;

    public RolledUpUsage() {}

    
    public RolledUpUsage(@JsonProperty("subscriptionId") Guid subscriptionId,
                         @JsonProperty("startDate") LocalDate startDate,
                         @JsonProperty("endDate") LocalDate endDate,
                         @JsonProperty("rolledUpUnits") List<RolledUpUnit> rolledUpUnits) {
        this.subscriptionId = subscriptionId;
        this.startDate = startDate;
        this.endDate = endDate;
        this.rolledUpUnits = rolledUpUnits;
    }

    public Guid getSubscriptionId() {
        return subscriptionId;
    }

    public void setSubscriptionId(Guid subscriptionId) {
        this.subscriptionId = subscriptionId;
    }

    public LocalDate getStartDate() {
        return startDate;
    }

    public void setStartDate(LocalDate startDate) {
        this.startDate = startDate;
    }

    public LocalDate getEndDate() {
        return endDate;
    }

    public void setEndDate(LocalDate endDate) {
        this.endDate = endDate;
    }

    public List<RolledUpUnit> getRolledUpUnits() {
        return rolledUpUnits;
    }

    public void setRolledUpUnits(List<RolledUpUnit> rolledUpUnits) {
        this.rolledUpUnits = rolledUpUnits;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("RolledUpUsage{");
        sb.Append("subscriptionId=").append(subscriptionId);
        sb.Append(", startDate=").append(startDate);
        sb.Append(", endDate=").append(endDate);
        sb.Append(", rolledUpUnits=").append(rolledUpUnits);
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

        RolledUpUsage that = (RolledUpUsage) o;

        if (subscriptionId != null ? !subscriptionId.equals(that.subscriptionId) : that.subscriptionId != null) {
            return false;
        }
        if (startDate != null ? !startDate.equals(that.startDate) : that.startDate != null) {
            return false;
        }
        if (endDate != null ? !endDate.equals(that.endDate) : that.endDate != null) {
            return false;
        }
        return rolledUpUnits != null ? rolledUpUnits.equals(that.rolledUpUnits) : that.rolledUpUnits == null;

    }

    
    public int GetHashCode() {
        int result = subscriptionId != null ? subscriptionId.GetHashCode() : 0;
        result = 31 * result + (startDate != null ? startDate.GetHashCode() : 0);
        result = 31 * result + (endDate != null ? endDate.GetHashCode() : 0);
        result = 31 * result + (rolledUpUnits != null ? rolledUpUnits.GetHashCode() : 0);
        return result;
    }
}
