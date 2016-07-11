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

using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{
    public class Bundle : KillBillObject
    {

        private Guid accountId;
        private Guid bundleId;
        private string externalKey;
        private List<Subscription> subscriptions;
        private BundleTimeline timeline;


        public Bundle(Guid accountId,
            Guid bundleId,
            string externalKey,
            List<Subscription> subscriptions,
            BundleTimeline timeline,
            List<AuditLog> auditLogs)
        {
            this.accountId = accountId;
            this.bundleId = bundleId;
            this.externalKey = externalKey;
            this.subscriptions = subscriptions;
            this.timeline = timeline;
        }

        public Bundle()
        {
        }

        public Guid getAccountId()
        {
            return accountId;
        }

        public void setAccountId(Guid accountId)
        {
            this.accountId = accountId;
        }

        public Guid getBundleId()
        {
            return bundleId;
        }

        public void setBundleId(Guid bundleId)
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

        public List<Subscription> getSubscriptions()
        {
            return subscriptions;
        }

        public void setSubscriptions(List<Subscription> subscriptions)
        {
            this.subscriptions = subscriptions;
        }

        public BundleTimeline getTimeline()
        {
            return timeline;
        }

        public void setTimeline(BundleTimeline timeline)
        {
            this.timeline = timeline;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Bundle{");
            sb.Append("accountId=").Append(accountId);
            sb.Append(", bundleId=").Append(bundleId);
            sb.Append(", externalKey='").Append(externalKey).Append('\'');
            sb.Append(", subscriptions=").Append(subscriptions);
            sb.Append(", timeline=").Append(timeline);
            sb.Append('}');
            return sb.ToString();
        }


        public override bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            Bundle bundle = (Bundle)o;

            if (accountId != null ? !accountId.Equals(bundle.accountId) : bundle.accountId != null)
            {
                return false;
            }
            if (bundleId != null ? !bundleId.Equals(bundle.bundleId) : bundle.bundleId != null)
            {
                return false;
            }
            if (externalKey != null ? !externalKey.Equals(bundle.externalKey) : bundle.externalKey != null)
            {
                return false;
            }
            if (subscriptions != null ? !subscriptions.Equals(bundle.subscriptions) : bundle.subscriptions != null)
            {
                return false;
            }
            if (timeline != null ? !timeline.Equals(bundle.timeline) : bundle.timeline != null)
            {
                return false;
            }

            return true;
        }


        public override int GetHashCode()
        {
            int result = accountId != null ? accountId.GetHashCode() : 0;
            result = 31 * result + (bundleId != null ? bundleId.GetHashCode() : 0);
            result = 31 * result + (externalKey != null ? externalKey.GetHashCode() : 0);
            result = 31 * result + (subscriptions != null ? subscriptions.GetHashCode() : 0);
            result = 31 * result + (timeline != null ? timeline.GetHashCode() : 0);
            return result;
        }
    }
}
