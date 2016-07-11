
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{

    public class Subscription : KillBillObject
    {

        private Guid accountId;
        private Guid bundleId;
        private Guid subscriptionId;
        private string externalKey;
        private DateTime startDate;
        private string productName;
        private ProductCategory productCategory;
        private BillingPeriod billingPeriod;
        private PhaseType phaseType;
        private string priceList;
        private EntitlementState state;
        private EntitlementSourceType sourceType;
        private DateTime cancelledDate;
        private DateTime chargedThroughDate;
        private DateTime billingStartDate;
        private DateTime billingEndDate;
        private List<EventSubscription> events;
        private List<PhasePriceOverride> priceOverrides;



        public string ToString()
        {
            StringBuilder sb = new StringBuilder("Subscription{");
            sb.Append("accountId=").Append(accountId);
            sb.Append(", bundleId=").Append(bundleId);
            sb.Append(", subscriptionId=").Append(subscriptionId);
            sb.Append(", externalKey='").Append(externalKey).Append('\'');
            sb.Append(", startDate=").Append(startDate);
            sb.Append(", productName='").Append(productName).Append('\'');
            sb.Append(", productCategory=").Append(productCategory);
            sb.Append(", billingPeriod=").Append(billingPeriod);
            sb.Append(", phaseType=").Append(phaseType);
            sb.Append(", priceList='").Append(priceList).Append('\'');
            sb.Append(", state=").Append(state);
            sb.Append(", sourceType=").Append(sourceType);
            sb.Append(", cancelledDate=").Append(cancelledDate);
            sb.Append(", chargedThroughDate=").Append(chargedThroughDate);
            sb.Append(", billingStartDate=").Append(billingStartDate);
            sb.Append(", billingEndDate=").Append(billingEndDate);
            sb.Append(", events=").Append(events);
            sb.Append(", priceOverrides=").Append(priceOverrides);
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

            Subscription that = (Subscription) o;

            if (accountId != null ? !accountId.Equals(that.accountId) : that.accountId != null)
            {
                return false;
            }
            if (billingEndDate != null
                ? billingEndDate.CompareTo(that.billingEndDate) != 0
                : that.billingEndDate != null)
            {
                return false;
            }
            if (billingPeriod != that.billingPeriod)
            {
                return false;
            }
            if (billingStartDate != null
                ? billingStartDate.CompareTo(that.billingStartDate) != 0
                : that.billingStartDate != null)
            {
                return false;
            }
            if (bundleId != null ? !bundleId.Equals(that.bundleId) : that.bundleId != null)
            {
                return false;
            }
            if (cancelledDate != null ? cancelledDate.CompareTo(that.cancelledDate) != 0 : that.cancelledDate != null)
            {
                return false;
            }
            if (chargedThroughDate != null
                ? chargedThroughDate.CompareTo(that.chargedThroughDate) != 0
                : that.chargedThroughDate != null)
            {
                return false;
            }
            if (events != null ? !events.Equals(that.events) : that.events != null)
            {
                return false;
            }
            if (priceOverrides != null ? !priceOverrides.Equals(that.priceOverrides) : that.priceOverrides != null)
            {
                return false;
            }
            if (externalKey != null ? !externalKey.Equals(that.externalKey) : that.externalKey != null)
            {
                return false;
            }
            if (phaseType != that.phaseType)
            {
                return false;
            }
            if (priceList != null ? !priceList.Equals(that.priceList) : that.priceList != null)
            {
                return false;
            }
            if (productCategory != that.productCategory)
            {
                return false;
            }
            if (productName != null ? !productName.Equals(that.productName) : that.productName != null)
            {
                return false;
            }
            if (sourceType != that.sourceType)
            {
                return false;
            }
            if (startDate != null ? startDate.CompareTo(that.startDate) != 0 : that.startDate != null)
            {
                return false;
            }
            if (state != that.state)
            {
                return false;
            }
            if (subscriptionId != null ? !subscriptionId.Equals(that.subscriptionId) : that.subscriptionId != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = accountId != null ? accountId.GetHashCode() : 0;
            result = 31*result + (bundleId != null ? bundleId.GetHashCode() : 0);
            result = 31*result + (subscriptionId != null ? subscriptionId.GetHashCode() : 0);
            result = 31*result + (externalKey != null ? externalKey.GetHashCode() : 0);
            result = 31*result + (startDate != null ? startDate.GetHashCode() : 0);
            result = 31*result + (productName != null ? productName.GetHashCode() : 0);
            result = 31*result + (productCategory != null ? productCategory.GetHashCode() : 0);
            result = 31*result + (billingPeriod != null ? billingPeriod.GetHashCode() : 0);
            result = 31*result + (phaseType != null ? phaseType.GetHashCode() : 0);
            result = 31*result + (priceList != null ? priceList.GetHashCode() : 0);
            result = 31*result + (state != null ? state.GetHashCode() : 0);
            result = 31*result + (sourceType != null ? sourceType.GetHashCode() : 0);
            result = 31*result + (cancelledDate != null ? cancelledDate.GetHashCode() : 0);
            result = 31*result + (chargedThroughDate != null ? chargedThroughDate.GetHashCode() : 0);
            result = 31*result + (billingStartDate != null ? billingStartDate.GetHashCode() : 0);
            result = 31*result + (billingEndDate != null ? billingEndDate.GetHashCode() : 0);
            result = 31*result + (events != null ? events.GetHashCode() : 0);
            result = 31*result + (priceOverrides != null ? priceOverrides.GetHashCode() : 0);
            return result;
        }
    }
}