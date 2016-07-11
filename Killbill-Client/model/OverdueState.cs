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






public class OverdueState : KillBillObject {

    private string name;
    private string externalMessage;
    private List<Integer> daysBetweenPaymentRetries;
    private bool disableEntitlementAndChangesBlocked;
    private bool blockChanges;
    private bool isClearState;
    private Int64 reevaluationIntervalDays;

    
    public OverdueState(@JsonProperty("name") string name,
                        @JsonProperty("externalMessage") string externalMessage,
                        @JsonProperty("daysBetweenPaymentRetries") List<Integer> daysBetweenPaymentRetries,
                        @JsonProperty("disableEntitlementAndChangesBlocked") bool disableEntitlementAndChangesBlocked,
                        @JsonProperty("blockChanges") bool blockChanges,
                        @JsonProperty("clearState") bool isClearState,
                        @JsonProperty("reevaluationIntervalDays") Int64 reevaluationIntervalDays) {
        this.name = name;
        this.externalMessage = externalMessage;
        this.daysBetweenPaymentRetries = daysBetweenPaymentRetries;
        this.disableEntitlementAndChangesBlocked = disableEntitlementAndChangesBlocked;
        this.blockChanges = blockChanges;
        this.isClearState = isClearState;
        this.reevaluationIntervalDays = reevaluationIntervalDays;
    }

    public string getName() {
        return name;
    }

    public void setName(string name) {
        this.name = name;
    }

    public string getExternalMessage() {
        return externalMessage;
    }

    public void setExternalMessage(string externalMessage) {
        this.externalMessage = externalMessage;
    }

    public List<Integer> getDaysBetweenPaymentRetries() {
        return daysBetweenPaymentRetries;
    }

    public void setDaysBetweenPaymentRetries(List<Integer> daysBetweenPaymentRetries) {
        this.daysBetweenPaymentRetries = daysBetweenPaymentRetries;
    }

    public bool getDisableEntitlementAndChangesBlocked() {
        return disableEntitlementAndChangesBlocked;
    }

    public void setDisableEntitlementAndChangesBlocked(bool disableEntitlementAndChangesBlocked) {
        this.disableEntitlementAndChangesBlocked = disableEntitlementAndChangesBlocked;
    }

    public bool getBlockChanges() {
        return blockChanges;
    }

    public void setBlockChanges(bool blockChanges) {
        this.blockChanges = blockChanges;
    }

    public bool getIsClearState() {
        return isClearState;
    }

    public void setIsClearState(bool isClearState) {
        this.isClearState = isClearState;
    }

    public Int64 getReevaluationIntervalDays() {
        return reevaluationIntervalDays;
    }

    public void setReevaluationIntervalDays(Int64 reevaluationIntervalDays) {
        this.reevaluationIntervalDays = reevaluationIntervalDays;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("OverdueState{");
        sb.Append("name='").append(name).append('\'');
        sb.Append(", externalMessage='").append(externalMessage).append('\'');
        sb.Append(", daysBetweenPaymentRetries=").append(daysBetweenPaymentRetries);
        sb.Append(", disableEntitlementAndChangesBlocked=").append(disableEntitlementAndChangesBlocked);
        sb.Append(", blockChanges=").append(blockChanges);
        sb.Append(", isClearState=").append(isClearState);
        sb.Append(", reevaluationIntervalDays=").append(reevaluationIntervalDays);
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

        OverdueState that = (OverdueState) o;

        if (blockChanges != null ? !blockChanges.equals(that.blockChanges) : that.blockChanges != null) {
            return false;
        }
        if (daysBetweenPaymentRetries != null ? !daysBetweenPaymentRetries.equals(that.daysBetweenPaymentRetries) : that.daysBetweenPaymentRetries != null) {
            return false;
        }
        if (disableEntitlementAndChangesBlocked != null ? !disableEntitlementAndChangesBlocked.equals(that.disableEntitlementAndChangesBlocked) : that.disableEntitlementAndChangesBlocked != null) {
            return false;
        }
        if (externalMessage != null ? !externalMessage.equals(that.externalMessage) : that.externalMessage != null) {
            return false;
        }
        if (isClearState != null ? !isClearState.equals(that.isClearState) : that.isClearState != null) {
            return false;
        }
        if (name != null ? !name.equals(that.name) : that.name != null) {
            return false;
        }
        if (reevaluationIntervalDays != null ? !reevaluationIntervalDays.equals(that.reevaluationIntervalDays) : that.reevaluationIntervalDays != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = name != null ? name.GetHashCode() : 0;
        result = 31 * result + (externalMessage != null ? externalMessage.GetHashCode() : 0);
        result = 31 * result + (daysBetweenPaymentRetries != null ? daysBetweenPaymentRetries.GetHashCode() : 0);
        result = 31 * result + (disableEntitlementAndChangesBlocked != null ? disableEntitlementAndChangesBlocked.GetHashCode() : 0);
        result = 31 * result + (blockChanges != null ? blockChanges.GetHashCode() : 0);
        result = 31 * result + (isClearState != null ? isClearState.GetHashCode() : 0);
        result = 31 * result + (reevaluationIntervalDays != null ? reevaluationIntervalDays.GetHashCode() : 0);
        return result;
    }
}
