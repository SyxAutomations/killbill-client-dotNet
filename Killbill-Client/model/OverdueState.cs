
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model {

public class OverdueState : KillBillObject {

    private string name;
    private string externalMessage;
    private List<Int64> daysBetweenPaymentRetries;
    private bool disableEntitlementAndChangesBlocked;
    private bool blockChanges;
    private bool isClearState;
    private Int64 reevaluationIntervalDays;

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("OverdueState{");
        sb.Append("name='").Append(name).Append('\'');
        sb.Append(", externalMessage='").Append(externalMessage).Append('\'');
        sb.Append(", daysBetweenPaymentRetries=").Append(daysBetweenPaymentRetries);
        sb.Append(", disableEntitlementAndChangesBlocked=").Append(disableEntitlementAndChangesBlocked);
        sb.Append(", blockChanges=").Append(blockChanges);
        sb.Append(", isClearState=").Append(isClearState);
        sb.Append(", reevaluationIntervalDays=").Append(reevaluationIntervalDays);
        sb.Append('}');
        return sb.ToString();
    }

    
    public bool Equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || GetType() != o.GetType()) {
            return false;
        }

        OverdueState that = (OverdueState) o;

        if (blockChanges != null ? !blockChanges.Equals(that.blockChanges) : that.blockChanges != null) {
            return false;
        }
        if (daysBetweenPaymentRetries != null ? !daysBetweenPaymentRetries.Equals(that.daysBetweenPaymentRetries) : that.daysBetweenPaymentRetries != null) {
            return false;
        }
        if (disableEntitlementAndChangesBlocked != null ? !disableEntitlementAndChangesBlocked.Equals(that.disableEntitlementAndChangesBlocked) : that.disableEntitlementAndChangesBlocked != null) {
            return false;
        }
        if (externalMessage != null ? !externalMessage.Equals(that.externalMessage) : that.externalMessage != null) {
            return false;
        }
        if (isClearState != null ? !isClearState.Equals(that.isClearState) : that.isClearState != null) {
            return false;
        }
        if (name != null ? !name.Equals(that.name) : that.name != null) {
            return false;
        }
        if (reevaluationIntervalDays != null ? !reevaluationIntervalDays.Equals(that.reevaluationIntervalDays) : that.reevaluationIntervalDays != null) {
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
