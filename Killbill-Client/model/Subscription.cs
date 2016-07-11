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
















public class Subscription : KillBillObject {

    private Guid accountId;
    private Guid bundleId;
    private Guid subscriptionId;
    private string externalKey;
    private LocalDate startDate;
    private string productName;
    private ProductCategory productCategory;
    private BillingPeriod billingPeriod;
    private PhaseType phaseType;
    private string priceList;
    private EntitlementState state;
    private EntitlementSourceType sourceType;
    private LocalDate cancelledDate;
    private LocalDate chargedThroughDate;
    private LocalDate billingStartDate;
    private LocalDate billingEndDate;
    private List<EventSubscription> events;
    private List<PhasePriceOverride> priceOverrides;

    public Subscription() { }

    
    public Subscription(@JsonProperty("accountId") @Nullable Guid accountId,
                        @JsonProperty("bundleId") @Nullable Guid bundleId,
                        @JsonProperty("subscriptionId") @Nullable Guid subscriptionId,
                        @JsonProperty("externalKey") @Nullable string externalKey,
                        @JsonProperty("startDate") @Nullable LocalDate startDate,
                        @JsonProperty("productName") @Nullable string productName,
                        @JsonProperty("productCategory") @Nullable ProductCategory productCategory,
                        @JsonProperty("billingPeriod") @Nullable BillingPeriod billingPeriod,
                        @JsonProperty("phaseType") @Nullable PhaseType phaseType,
                        @JsonProperty("priceList") @Nullable string priceList,
                        @JsonProperty("state") @Nullable EntitlementState state,
                        @JsonProperty("sourceType") @Nullable EntitlementSourceType sourceType,
                        @JsonProperty("cancelledDate") @Nullable LocalDate cancelledDate,
                        @JsonProperty("chargedThroughDate") @Nullable LocalDate chargedThroughDate,
                        @JsonProperty("billingStartDate") @Nullable LocalDate billingStartDate,
                        @JsonProperty("billingEndDate") @Nullable LocalDate billingEndDate,
                        @JsonProperty("events") @Nullable List<EventSubscription> events,
                        @JsonProperty("priceOverrides") @Nullable List<PhasePriceOverride> priceOverrides,
                        @JsonProperty("auditLogs") @Nullable List<AuditLog> auditLogs) {
       auditLogs);
        this.startDate = startDate;
        this.productName = productName;
        this.productCategory = productCategory;
        this.billingPeriod = billingPeriod;
        this.phaseType = phaseType;
        this.priceList = priceList;
        this.state = state;
        this.sourceType = sourceType;
        this.cancelledDate = cancelledDate;
        this.chargedThroughDate = chargedThroughDate;
        this.billingStartDate = billingStartDate;
        this.billingEndDate = billingEndDate;
        this.accountId = accountId;
        this.bundleId = bundleId;
        this.subscriptionId = subscriptionId;
        this.externalKey = externalKey;
        this.events = events;
        this.priceOverrides = priceOverrides;
    }

    public Guid getAccountId() {
        return accountId;
    }

    public void setAccountId(Guid accountId) {
        this.accountId = accountId;
    }

    public Guid getBundleId() {
        return bundleId;
    }

    public void setBundleId(Guid bundleId) {
        this.bundleId = bundleId;
    }

    public Guid getSubscriptionId() {
        return subscriptionId;
    }

    public void setSubscriptionId(Guid subscriptionId) {
        this.subscriptionId = subscriptionId;
    }

    public string getExternalKey() {
        return externalKey;
    }

    public void setExternalKey(string externalKey) {
        this.externalKey = externalKey;
    }

    public LocalDate getStartDate() {
        return startDate;
    }

    public void setStartDate(LocalDate startDate) {
        this.startDate = startDate;
    }

    public string getProductName() {
        return productName;
    }

    public void setProductName(string productName) {
        this.productName = productName;
    }

    public ProductCategory getProductCategory() {
        return productCategory;
    }

    public void setProductCategory(ProductCategory productCategory) {
        this.productCategory = productCategory;
    }

    public BillingPeriod getBillingPeriod() {
        return billingPeriod;
    }

    public void setBillingPeriod(BillingPeriod billingPeriod) {
        this.billingPeriod = billingPeriod;
    }

    public PhaseType getPhaseType() {
        return phaseType;
    }

    public void setPhaseType(PhaseType phaseType) {
        this.phaseType = phaseType;
    }

    public string getPriceList() {
        return priceList;
    }

    public void setPriceList(string priceList) {
        this.priceList = priceList;
    }

    public EntitlementState getState() {
        return state;
    }

    public void setState(EntitlementState state) {
        this.state = state;
    }

    public EntitlementSourceType getSourceType() {
        return sourceType;
    }

    public void setSourceType(EntitlementSourceType sourceType) {
        this.sourceType = sourceType;
    }

    public LocalDate getCancelledDate() {
        return cancelledDate;
    }

    public void setCancelledDate(LocalDate cancelledDate) {
        this.cancelledDate = cancelledDate;
    }

    public LocalDate getChargedThroughDate() {
        return chargedThroughDate;
    }

    public void setChargedThroughDate(LocalDate chargedThroughDate) {
        this.chargedThroughDate = chargedThroughDate;
    }

    public LocalDate getBillingStartDate() {
        return billingStartDate;
    }

    public void setBillingStartDate(LocalDate billingStartDate) {
        this.billingStartDate = billingStartDate;
    }

    public LocalDate getBillingEndDate() {
        return billingEndDate;
    }

    public void setBillingEndDate(LocalDate billingEndDate) {
        this.billingEndDate = billingEndDate;
    }

    public List<EventSubscription> getEvents() {
        return events;
    }

    public void setEvents(List<EventSubscription> events) {
        this.events = events;
    }

    public List<PhasePriceOverride> getPriceOverrides() {
        return priceOverrides;
    }

    public void setPriceOverrides(List<PhasePriceOverride> priceOverrides) {
        this.priceOverrides = priceOverrides;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("Subscription{");
        sb.Append("accountId=").append(accountId);
        sb.Append(", bundleId=").append(bundleId);
        sb.Append(", subscriptionId=").append(subscriptionId);
        sb.Append(", externalKey='").append(externalKey).append('\'');
        sb.Append(", startDate=").append(startDate);
        sb.Append(", productName='").append(productName).append('\'');
        sb.Append(", productCategory=").append(productCategory);
        sb.Append(", billingPeriod=").append(billingPeriod);
        sb.Append(", phaseType=").append(phaseType);
        sb.Append(", priceList='").append(priceList).append('\'');
        sb.Append(", state=").append(state);
        sb.Append(", sourceType=").append(sourceType);
        sb.Append(", cancelledDate=").append(cancelledDate);
        sb.Append(", chargedThroughDate=").append(chargedThroughDate);
        sb.Append(", billingStartDate=").append(billingStartDate);
        sb.Append(", billingEndDate=").append(billingEndDate);
        sb.Append(", events=").append(events);
        sb.Append(", priceOverrides=").append(priceOverrides);
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

        Subscription that = (Subscription) o;

        if (accountId != null ? !accountId.equals(that.accountId) : that.accountId != null) {
            return false;
        }
        if (billingEndDate != null ? billingEndDate.compareTo(that.billingEndDate) != 0 : that.billingEndDate != null) {
            return false;
        }
        if (billingPeriod != that.billingPeriod) {
            return false;
        }
        if (billingStartDate != null ? billingStartDate.compareTo(that.billingStartDate) != 0 : that.billingStartDate != null) {
            return false;
        }
        if (bundleId != null ? !bundleId.equals(that.bundleId) : that.bundleId != null) {
            return false;
        }
        if (cancelledDate != null ? cancelledDate.compareTo(that.cancelledDate) != 0 : that.cancelledDate != null) {
            return false;
        }
        if (chargedThroughDate != null ? chargedThroughDate.compareTo(that.chargedThroughDate) != 0 : that.chargedThroughDate != null) {
            return false;
        }
        if (events != null ? !events.equals(that.events) : that.events != null) {
            return false;
        }
        if (priceOverrides != null ? !priceOverrides.equals(that.priceOverrides) : that.priceOverrides != null) {
            return false;
        }
        if (externalKey != null ? !externalKey.equals(that.externalKey) : that.externalKey != null) {
            return false;
        }
        if (phaseType != that.phaseType) {
            return false;
        }
        if (priceList != null ? !priceList.equals(that.priceList) : that.priceList != null) {
            return false;
        }
        if (productCategory != that.productCategory) {
            return false;
        }
        if (productName != null ? !productName.equals(that.productName) : that.productName != null) {
            return false;
        }
        if (sourceType != that.sourceType) {
            return false;
        }
        if (startDate != null ? startDate.compareTo(that.startDate) != 0 : that.startDate != null) {
            return false;
        }
        if (state != that.state) {
            return false;
        }
        if (subscriptionId != null ? !subscriptionId.equals(that.subscriptionId) : that.subscriptionId != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = accountId != null ? accountId.GetHashCode() : 0;
        result = 31 * result + (bundleId != null ? bundleId.GetHashCode() : 0);
        result = 31 * result + (subscriptionId != null ? subscriptionId.GetHashCode() : 0);
        result = 31 * result + (externalKey != null ? externalKey.GetHashCode() : 0);
        result = 31 * result + (startDate != null ? startDate.GetHashCode() : 0);
        result = 31 * result + (productName != null ? productName.GetHashCode() : 0);
        result = 31 * result + (productCategory != null ? productCategory.GetHashCode() : 0);
        result = 31 * result + (billingPeriod != null ? billingPeriod.GetHashCode() : 0);
        result = 31 * result + (phaseType != null ? phaseType.GetHashCode() : 0);
        result = 31 * result + (priceList != null ? priceList.GetHashCode() : 0);
        result = 31 * result + (state != null ? state.GetHashCode() : 0);
        result = 31 * result + (sourceType != null ? sourceType.GetHashCode() : 0);
        result = 31 * result + (cancelledDate != null ? cancelledDate.GetHashCode() : 0);
        result = 31 * result + (chargedThroughDate != null ? chargedThroughDate.GetHashCode() : 0);
        result = 31 * result + (billingStartDate != null ? billingStartDate.GetHashCode() : 0);
        result = 31 * result + (billingEndDate != null ? billingEndDate.GetHashCode() : 0);
        result = 31 * result + (events != null ? events.GetHashCode() : 0);
        result = 31 * result + (priceOverrides != null ? priceOverrides.GetHashCode() : 0);
        return result;
    }
}
