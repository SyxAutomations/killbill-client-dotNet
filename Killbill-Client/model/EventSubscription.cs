
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{
    public class EventSubscription : KillBillObject
    {
        public string EventId { get; private set; }
        public string BillingPeriod { get; private set; }
        public DateTime RequestedDate { get; private set; }
        public DateTime EffectiveDate { get; private set; }
        public string Product { get; private set; }
        public string PriceList { get; private set; }
        public string EventType { get; private set; }
        public bool IsBlockedBilling { get; private set; }
        public bool IsBlockedEntitlement { get; private set; }
        public string ServiceName { get; private set; }
        public string ServiceStateName { get; private set; }
        public string Phase { get; private set; }
        
        public string ToString()
        {
            StringBuilder sb = new StringBuilder("EventSubscriptionJson{");
            sb.Append("eventId='").Append(EventId).Append('\'');
            sb.Append(", billingPeriod='").Append(BillingPeriod).Append('\'');
            sb.Append(", requestedDate=").Append(RequestedDate);
            sb.Append(", effectiveDate=").Append(EffectiveDate);
            sb.Append(", product='").Append(Product).Append('\'');
            sb.Append(", priceList='").Append(PriceList).Append('\'');
            sb.Append(", eventType='").Append(EventType).Append('\'');
            sb.Append(", isBlockedBilling=").Append(IsBlockedBilling);
            sb.Append(", isBlockedEntitlement=").Append(IsBlockedEntitlement);
            sb.Append(", serviceName='").Append(ServiceName).Append('\'');
            sb.Append(", serviceStateName='").Append(ServiceStateName).Append('\'');
            sb.Append(", phase='").Append(Phase).Append('\'');
            sb.Append('}');
            return sb.ToString();
        }


        public bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            EventSubscription that = (EventSubscription)o;

            if (BillingPeriod != null ? !BillingPeriod.Equals(that.BillingPeriod) : that.BillingPeriod != null)
            {
                return false;
            }
            if (EffectiveDate != null ? EffectiveDate.CompareTo(that.EffectiveDate) != 0 : that.EffectiveDate != null)
            {
                return false;
            }
            if (EventId != null ? !EventId.Equals(that.EventId) : that.EventId != null)
            {
                return false;
            }
            if (EventType != null ? !EventType.Equals(that.EventType) : that.EventType != null)
            {
                return false;
            }
            if (IsBlockedBilling != null
                ? !IsBlockedBilling.Equals(that.IsBlockedBilling)
                : that.IsBlockedBilling != null)
            {
                return false;
            }
            if (IsBlockedEntitlement != null
                ? !IsBlockedEntitlement.Equals(that.IsBlockedEntitlement)
                : that.IsBlockedEntitlement != null)
            {
                return false;
            }
            if (Phase != null ? !Phase.Equals(that.Phase) : that.Phase != null)
            {
                return false;
            }
            if (PriceList != null ? !PriceList.Equals(that.PriceList) : that.PriceList != null)
            {
                return false;
            }
            if (Product != null ? !Product.Equals(that.Product) : that.Product != null)
            {
                return false;
            }
            if (RequestedDate != null ? RequestedDate.CompareTo(that.RequestedDate) != 0 : that.RequestedDate != null)
            {
                return false;
            }
            if (ServiceName != null ? !ServiceName.Equals(that.ServiceName) : that.ServiceName != null)
            {
                return false;
            }
            if (ServiceStateName != null
                ? !ServiceStateName.Equals(that.ServiceStateName)
                : that.ServiceStateName != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = EventId != null ? EventId.GetHashCode() : 0;
            result = 31 * result + (BillingPeriod != null ? BillingPeriod.GetHashCode() : 0);
            result = 31 * result + (RequestedDate != null ? RequestedDate.GetHashCode() : 0);
            result = 31 * result + (EffectiveDate != null ? EffectiveDate.GetHashCode() : 0);
            result = 31 * result + (Product != null ? Product.GetHashCode() : 0);
            result = 31 * result + (PriceList != null ? PriceList.GetHashCode() : 0);
            result = 31 * result + (EventType != null ? EventType.GetHashCode() : 0);
            result = 31 * result + (IsBlockedBilling != null ? IsBlockedBilling.GetHashCode() : 0);
            result = 31 * result + (IsBlockedEntitlement != null ? IsBlockedEntitlement.GetHashCode() : 0);
            result = 31 * result + (ServiceName != null ? ServiceName.GetHashCode() : 0);
            result = 31 * result + (ServiceStateName != null ? ServiceStateName.GetHashCode() : 0);
            result = 31 * result + (Phase != null ? Phase.GetHashCode() : 0);
            return result;
        }
    }
}
