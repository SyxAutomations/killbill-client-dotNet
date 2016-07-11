
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model {

    public class BundleTimeline : KillBillObject
    {

        private string accountId;
        private string bundleId;
        private string externalKey;
        private List<EventSubscription> events;


        public BundleTimeline(string accountId,
            string bundleId,
            string externalKey,
            List<EventSubscription> events,
            List<AuditLog> auditLogs)
        {
            this.accountId = accountId;
            this.bundleId = bundleId;
            this.externalKey = externalKey;
            this.events = events;
        }

        public BundleTimeline()
        {
        }

        public string getAccountId()
        {
            return accountId;
        }

        public void setAccountId(string accountId)
        {
            this.accountId = accountId;
        }

        public string getBundleId()
        {
            return bundleId;
        }

        public void setBundleId(string bundleId)
        {
            this.bundleId = bundleId;
        }

        public string getExternalKey()
        {
            return externalKey;
        }

        public void setExternalKey(string externalKey)
        {
            this.externalKey = externalKey;
        }

        public List<EventSubscription> getEvents()
        {
            return events;
        }

        public void setEvents(List<EventSubscription> events)
        {
            this.events = events;
        }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("BundleTimeline{");
            sb.Append("accountId='").Append(accountId).Append('\'');
            sb.Append(", bundleId='").Append(bundleId).Append('\'');
            sb.Append(", externalKey='").Append(externalKey).Append('\'');
            sb.Append(", events=").Append(events);
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

            BundleTimeline that = (BundleTimeline) o;

            if (accountId != null ? !accountId.Equals(that.accountId) : that.accountId != null)
            {
                return false;
            }
            if (bundleId != null ? !bundleId.Equals(that.bundleId) : that.bundleId != null)
            {
                return false;
            }
            if (events != null ? !events.Equals(that.events) : that.events != null)
            {
                return false;
            }
            if (externalKey != null ? !externalKey.Equals(that.externalKey) : that.externalKey != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = accountId != null ? accountId.GetHashCode() : 0;
            result = 31*result + (bundleId != null ? bundleId.GetHashCode() : 0);
            result = 31*result + (externalKey != null ? externalKey.GetHashCode() : 0);
            result = 31*result + (events != null ? events.GetHashCode() : 0);
            return result;
        }
    }
}
