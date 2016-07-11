/*
 * Copyright 2010-2014 Ning, Inc.
 * Copyright 2015 Groupon, Inc
 * Copyright 2015 The Billing Project, LLC
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










public class EventSubscription : KillBillObject {

    private string eventId;
    private string billingPeriod;
    private LocalDate requestedDate;
    private LocalDate effectiveDate;
    private string product;
    private string priceList;
    private string eventType;
    private bool isBlockedBilling;
    private bool isBlockedEntitlement;
    private string serviceName;
    private string serviceStateName;
    private string phase;

    
    public EventSubscription(@JsonProperty("eventId") string eventId,
                             @JsonProperty("billingPeriod") string billingPeriod,
                             @JsonProperty("requestedDt") LocalDate requestedDate,
                             @JsonProperty("effectiveDt") LocalDate effectiveDate,
                             @JsonProperty("product") string product,
                             @JsonProperty("priceList") string priceList,
                             @JsonProperty("eventType") string eventType,
                             @JsonProperty("isBlockedBilling") bool isBlockedBilling,
                             @JsonProperty("isBlockedEntitlement") bool isBlockedEntitlement,
                             @JsonProperty("serviceName") string serviceName,
                             @JsonProperty("serviceStateName") string serviceStateName,
                             @JsonProperty("phase") string phase,
                             @JsonProperty("auditLogs") @Nullable List<AuditLog> auditLogs) {
       auditLogs);
        this.eventId = eventId;
        this.billingPeriod = billingPeriod;
        this.requestedDate = requestedDate;
        this.effectiveDate = effectiveDate;
        this.product = product;
        this.priceList = priceList;
        this.eventType = eventType;
        this.isBlockedBilling = isBlockedBilling;
        this.isBlockedEntitlement = isBlockedEntitlement;
        this.serviceName = serviceName;
        this.serviceStateName = serviceStateName;
        this.phase = phase;
    }

    public string getEventId() {
        return eventId;
    }

    public void setEventId(string eventId) {
        this.eventId = eventId;
    }

    public string getBillingPeriod() {
        return billingPeriod;
    }

    public void setBillingPeriod(string billingPeriod) {
        this.billingPeriod = billingPeriod;
    }

    public LocalDate getRequestedDate() {
        return requestedDate;
    }

    public void setRequestedDate(LocalDate requestedDate) {
        this.requestedDate = requestedDate;
    }

    public LocalDate getEffectiveDate() {
        return effectiveDate;
    }

    public void setEffectiveDate(LocalDate effectiveDate) {
        this.effectiveDate = effectiveDate;
    }

    public string getProduct() {
        return product;
    }

    public void setProduct(string product) {
        this.product = product;
    }

    public string getPriceList() {
        return priceList;
    }

    public void setPriceList(string priceList) {
        this.priceList = priceList;
    }

    public string getEventType() {
        return eventType;
    }

    public void setEventType(string eventType) {
        this.eventType = eventType;
    }

    public bool getIsBlockedBilling() {
        return isBlockedBilling;
    }

    public void setIsBlockedBilling(bool isBlockedBilling) {
        this.isBlockedBilling = isBlockedBilling;
    }

    public bool getIsBlockedEntitlement() {
        return isBlockedEntitlement;
    }

    public void setIsBlockedEntitlement(bool isBlockedEntitlement) {
        this.isBlockedEntitlement = isBlockedEntitlement;
    }

    public string getServiceName() {
        return serviceName;
    }

    public void setServiceName(string serviceName) {
        this.serviceName = serviceName;
    }

    public string getServiceStateName() {
        return serviceStateName;
    }

    public void setServiceStateName(string serviceStateName) {
        this.serviceStateName = serviceStateName;
    }

    public string getPhase() {
        return phase;
    }

    public void setPhase(string phase) {
        this.phase = phase;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("EventSubscriptionJson{");
        sb.Append("eventId='").append(eventId).append('\'');
        sb.Append(", billingPeriod='").append(billingPeriod).append('\'');
        sb.Append(", requestedDate=").append(requestedDate);
        sb.Append(", effectiveDate=").append(effectiveDate);
        sb.Append(", product='").append(product).append('\'');
        sb.Append(", priceList='").append(priceList).append('\'');
        sb.Append(", eventType='").append(eventType).append('\'');
        sb.Append(", isBlockedBilling=").append(isBlockedBilling);
        sb.Append(", isBlockedEntitlement=").append(isBlockedEntitlement);
        sb.Append(", serviceName='").append(serviceName).append('\'');
        sb.Append(", serviceStateName='").append(serviceStateName).append('\'');
        sb.Append(", phase='").append(phase).append('\'');
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

        EventSubscription that = (EventSubscription) o;

        if (billingPeriod != null ? !billingPeriod.equals(that.billingPeriod) : that.billingPeriod != null) {
            return false;
        }
        if (effectiveDate != null ? effectiveDate.compareTo(that.effectiveDate) != 0 : that.effectiveDate != null) {
            return false;
        }
        if (eventId != null ? !eventId.equals(that.eventId) : that.eventId != null) {
            return false;
        }
        if (eventType != null ? !eventType.equals(that.eventType) : that.eventType != null) {
            return false;
        }
        if (isBlockedBilling != null ? !isBlockedBilling.equals(that.isBlockedBilling) : that.isBlockedBilling != null) {
            return false;
        }
        if (isBlockedEntitlement != null ? !isBlockedEntitlement.equals(that.isBlockedEntitlement) : that.isBlockedEntitlement != null) {
            return false;
        }
        if (phase != null ? !phase.equals(that.phase) : that.phase != null) {
            return false;
        }
        if (priceList != null ? !priceList.equals(that.priceList) : that.priceList != null) {
            return false;
        }
        if (product != null ? !product.equals(that.product) : that.product != null) {
            return false;
        }
        if (requestedDate != null ? requestedDate.compareTo(that.requestedDate) != 0 : that.requestedDate != null) {
            return false;
        }
        if (serviceName != null ? !serviceName.equals(that.serviceName) : that.serviceName != null) {
            return false;
        }
        if (serviceStateName != null ? !serviceStateName.equals(that.serviceStateName) : that.serviceStateName != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = eventId != null ? eventId.GetHashCode() : 0;
        result = 31 * result + (billingPeriod != null ? billingPeriod.GetHashCode() : 0);
        result = 31 * result + (requestedDate != null ? requestedDate.GetHashCode() : 0);
        result = 31 * result + (effectiveDate != null ? effectiveDate.GetHashCode() : 0);
        result = 31 * result + (product != null ? product.GetHashCode() : 0);
        result = 31 * result + (priceList != null ? priceList.GetHashCode() : 0);
        result = 31 * result + (eventType != null ? eventType.GetHashCode() : 0);
        result = 31 * result + (isBlockedBilling != null ? isBlockedBilling.GetHashCode() : 0);
        result = 31 * result + (isBlockedEntitlement != null ? isBlockedEntitlement.GetHashCode() : 0);
        result = 31 * result + (serviceName != null ? serviceName.GetHashCode() : 0);
        result = 31 * result + (serviceStateName != null ? serviceStateName.GetHashCode() : 0);
        result = 31 * result + (phase != null ? phase.GetHashCode() : 0);
        return result;
    }
}
