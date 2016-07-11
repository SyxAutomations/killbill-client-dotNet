/*
 * Copyright 2010-2013 Ning, Inc.
 * Copyright 2014 Groupon, Inc
 * Copyright 2014 The Billing Project, LLC
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

















public class InvoiceDryRun {

    private DryRunType dryRunType;
    private SubscriptionEventType dryRunAction;
    private PhaseType phaseType;
    private string productName;
    private ProductCategory productCategory;
    private BillingPeriod billingPeriod;
    private string priceListName;
    private LocalDate effectiveDate;
    private Guid subscriptionId;
    private Guid bundleId;
    private BillingActionPolicy billingPolicy;
    private List<PhasePriceOverride> priceOverrides;

    
    public InvoiceDryRun(@JsonProperty("dryRunType") @Nullable DryRunType dryRunType,
                         @JsonProperty("dryRunAction") @Nullable SubscriptionEventType dryRunAction,
                         @JsonProperty("phaseType") @Nullable PhaseType phaseType,
                         @JsonProperty("productName") @Nullable string productName,
                         @JsonProperty("productCategory") @Nullable ProductCategory productCategory,
                         @JsonProperty("billingPeriod") @Nullable BillingPeriod billingPeriod,
                         @JsonProperty("priceListName") @Nullable string priceListName,
                         @JsonProperty("subscriptionId") @Nullable Guid subscriptionId,
                         @JsonProperty("bundleId") @Nullable Guid bundleId,
                         @JsonProperty("effectiveDate") @Nullable LocalDate effectiveDate,
                         @JsonProperty("billingPolicy") @Nullable BillingActionPolicy billingPolicy,
                         @JsonProperty("priceOverrides") @Nullable List<PhasePriceOverride> priceOverrides) {
        this.dryRunType = dryRunType;
        this.dryRunAction = dryRunAction;
        this.phaseType = phaseType;
        this.productName = productName;
        this.productCategory = productCategory;
        this.billingPeriod = billingPeriod;
        this.priceListName = priceListName;
        this.subscriptionId = subscriptionId;
        this.bundleId = bundleId;
        this.effectiveDate = effectiveDate;
        this.billingPolicy = billingPolicy;
        this.priceOverrides= priceOverrides;
    }

    public DryRunType getDryRunType() {
        return dryRunType;
    }

    public SubscriptionEventType getDryRunAction() {
        return dryRunAction;
    }

    public PhaseType getPhaseType() {
        return phaseType;
    }

    public string getProductName() {
        return productName;
    }

    public ProductCategory getProductCategory() {
        return productCategory;
    }

    public BillingPeriod getBillingPeriod() {
        return billingPeriod;
    }

    public string getPriceListName() {
        return priceListName;
    }

    public LocalDate getEffectiveDate() {
        return effectiveDate;
    }

    public Guid getSubscriptionId() {
        return subscriptionId;
    }

    public Guid getBundleId() {
        return bundleId;
    }

    public BillingActionPolicy getBillingPolicy() {
        return billingPolicy;
    }

    public List<PhasePriceOverride> getPriceOverrides() {
        return priceOverrides;
    }
}
