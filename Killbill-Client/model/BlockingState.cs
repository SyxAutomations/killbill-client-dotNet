
using System;
using System.Collections.Generic;

namespace Killbill_Client.model
{

    public class BlockingState : KillBillObject
    {


        private Guid blockedId;
        private string stateName;
        private string service;
        private bool blockChange;
        private bool blockEntitlement;
        private bool blockBilling;
        private DateTime effectiveDate;
        private BlockingStateType type;



        public BlockingState(Guid blockedId,
            string stateName,
            string service,
            bool blockChange,
            bool blockEntitlement,
            bool blockBilling,
            DateTime effectiveDate,
            BlockingStateType type,
            List<AuditLog> auditLogs)
        {

            this.blockedId = blockedId;
            this.stateName = stateName;
            this.service = service;
            this.blockChange = blockChange;
            this.blockEntitlement = blockEntitlement;
            this.blockBilling = blockBilling;
            this.effectiveDate = effectiveDate;
            this.type = type;
        }

        public Guid getBlockedId()
        {
            return blockedId;
        }

        public string getStateName()
        {
            return stateName;
        }

        public string getService()
        {
            return service;
        }

        public bool getBlockChange()
        {
            return blockChange;
        }

        public bool getBlockEntitlement()
        {
            return blockEntitlement;
        }

        public bool getBlockBilling()
        {
            return blockBilling;
        }

        public DateTime getEffectiveDate()
        {
            return effectiveDate;
        }

        public BlockingStateType getType()
        {
            return type;
        }


        public override bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (!(o is BlockingState))
            {
                return false;
            }

            BlockingState that = (BlockingState)o;

            if (blockedId != null ? !blockedId.Equals(that.blockedId) : that.blockedId != null)
            {
                return false;
            }
            if (stateName != null ? !stateName.Equals(that.stateName) : that.stateName != null)
            {
                return false;
            }
            if (service != null ? !service.Equals(that.service) : that.service != null)
            {
                return false;
            }
            if (blockChange != null ? !blockChange.Equals(that.blockChange) : that.blockChange != null)
            {
                return false;
            }
            if (blockEntitlement != null
                ? !blockEntitlement.Equals(that.blockEntitlement)
                : that.blockEntitlement != null)
            {
                return false;
            }
            if (blockBilling != null ? !blockBilling.Equals(that.blockBilling) : that.blockBilling != null)
            {
                return false;
            }
            if (effectiveDate != null ? effectiveDate.CompareTo(that.effectiveDate) != 0 : that.effectiveDate != null)
            {
                return false;
            }
            return type == that.type;

        }


        public override int GetHashCode()
        {
            int result = blockedId != null ? blockedId.GetHashCode() : 0;
            result = 31 * result + (stateName != null ? stateName.GetHashCode() : 0);
            result = 31 * result + (service != null ? service.GetHashCode() : 0);
            result = 31 * result + (blockChange != null ? blockChange.GetHashCode() : 0);
            result = 31 * result + (blockEntitlement != null ? blockEntitlement.GetHashCode() : 0);
            result = 31 * result + (blockBilling != null ? blockBilling.GetHashCode() : 0);
            result = 31 * result + (effectiveDate != null ? effectiveDate.GetHashCode() : 0);
            result = 31 * result + (type != null ? type.GetHashCode() : 0);
            return result;
        }


        public override string ToString()
        {
            return "BlockingState{" +
                   "blockedId=" + blockedId +
                   ", stateName='" + stateName + "\'" +
                   ", service='" + service + "\'" +
                   ", blockChange=" + blockChange +
                   ", blockEntitlement=" + blockEntitlement +
                   ", blockBilling=" + blockBilling +
                   ", effectiveDate=" + effectiveDate +
                   ", type=" + type +
                   "}";
        }
    }
}
