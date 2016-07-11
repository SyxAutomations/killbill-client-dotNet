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













public class InvoiceItem : KillBillObject {

    private Guid invoiceItemId;
    private Guid invoiceId;
    private Guid linkedInvoiceItemId;
    private Guid accountId;
    private Guid bundleId;
    private Guid subscriptionId;
    private string planName;
    private string phaseName;
    private string usageName;
    private string itemType;
    private string description;
    private LocalDate startDate;
    private LocalDate endDate;
    private BigDecimal amount;
    private Currency currency;

    public InvoiceItem() {}

    
    public InvoiceItem(@JsonProperty("invoiceItemId") Guid invoiceItemId,
                       @JsonProperty("invoiceId") Guid invoiceId,
                       @JsonProperty("linkedInvoiceItemId") Guid linkedInvoiceItemId,
                       @JsonProperty("accountId") Guid accountId,
                       @JsonProperty("bundleId") Guid bundleId,
                       @JsonProperty("subscriptionId") Guid subscriptionId,
                       @JsonProperty("planName") string planName,
                       @JsonProperty("phaseName") string phaseName,
                       @JsonProperty("usageName") string usageName,
                       @JsonProperty("itemType") string itemType,
                       @JsonProperty("description") string description,
                       @JsonProperty("startDate") LocalDate startDate,
                       @JsonProperty("endDate") LocalDate endDate,
                       @JsonProperty("amount") BigDecimal amount,
                       @JsonProperty("currency") Currency currency,
                       @JsonProperty("auditLogs") @Nullable List<AuditLog> auditLogs) {
       auditLogs);
        this.invoiceItemId = invoiceItemId;
        this.invoiceId = invoiceId;
        this.linkedInvoiceItemId = linkedInvoiceItemId;
        this.accountId = accountId;
        this.bundleId = bundleId;
        this.subscriptionId = subscriptionId;
        this.planName = planName;
        this.phaseName = phaseName;
        this.itemType = itemType;
        this.description = description;
        this.startDate = startDate;
        this.endDate = endDate;
        this.amount = amount;
        this.currency = currency;
    }

    public Guid getInvoiceItemId() {
        return invoiceItemId;
    }

    public void setInvoiceItemId(Guid invoiceItemId) {
        this.invoiceItemId = invoiceItemId;
    }

    public Guid getInvoiceId() {
        return invoiceId;
    }

    public void setInvoiceId(Guid invoiceId) {
        this.invoiceId = invoiceId;
    }

    public Guid getLinkedInvoiceItemId() {
        return linkedInvoiceItemId;
    }

    public void setLinkedInvoiceItemId(Guid linkedInvoiceItemId) {
        this.linkedInvoiceItemId = linkedInvoiceItemId;
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

    public string getPlanName() {
        return planName;
    }

    public string getUsageName() {
        return usageName;
    }

    public void setPlanName(string planName) {
        this.planName = planName;
    }

    public string getPhaseName() {
        return phaseName;
    }

    public void setPhaseName(string phaseName) {
        this.phaseName = phaseName;
    }

    public void setUsageName(string usageName) {
        this.usageName = usageName;
    }

    public string getItemType() {
        return itemType;
    }

    public void setItemType(string itemType) {
        this.itemType = itemType;
    }

    public string getDescription() {
        return description;
    }

    public void setDescription(string description) {
        this.description = description;
    }

    public LocalDate getStartDate() {
        return startDate;
    }

    public void setStartDate(LocalDate startDate) {
        this.startDate = startDate;
    }

    public LocalDate getEndDate() {
        return endDate;
    }

    public void setEndDate(LocalDate endDate) {
        this.endDate = endDate;
    }

    public BigDecimal getAmount() {
        return amount;
    }

    public void setAmount(BigDecimal amount) {
        this.amount = amount;
    }

    public Currency getCurrency() {
        return currency;
    }

    public void setCurrency(Currency currency) {
        this.currency = currency;
    }

    
    public bool equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        InvoiceItem that = (InvoiceItem) o;

        if (accountId != null ? !accountId.equals(that.accountId) : that.accountId != null) {
            return false;
        }
        if (amount != null ? amount.compareTo(that.amount) != 0 : that.amount != null) {
            return false;
        }
        if (bundleId != null ? !bundleId.equals(that.bundleId) : that.bundleId != null) {
            return false;
        }
        if (currency != that.currency) {
            return false;
        }
        if (description != null ? !description.equals(that.description) : that.description != null) {
            return false;
        }
        if (endDate != null ? endDate.compareTo(that.endDate) != 0 : that.endDate != null) {
            return false;
        }
        if (invoiceId != null ? !invoiceId.equals(that.invoiceId) : that.invoiceId != null) {
            return false;
        }
        if (invoiceItemId != null ? !invoiceItemId.equals(that.invoiceItemId) : that.invoiceItemId != null) {
            return false;
        }
        if (itemType != null ? !itemType.equals(that.itemType) : that.itemType != null) {
            return false;
        }
        if (linkedInvoiceItemId != null ? !linkedInvoiceItemId.equals(that.linkedInvoiceItemId) : that.linkedInvoiceItemId != null) {
            return false;
        }
        if (phaseName != null ? !phaseName.equals(that.phaseName) : that.phaseName != null) {
            return false;
        }
        if (planName != null ? !planName.equals(that.planName) : that.planName != null) {
            return false;
        }
        if (usageName != null ? !usageName.equals(that.usageName) : that.usageName != null) {
            return false;
        }
        if (startDate != null ? startDate.compareTo(that.startDate) != 0 : that.startDate != null) {
            return false;
        }
        if (subscriptionId != null ? !subscriptionId.equals(that.subscriptionId) : that.subscriptionId != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = invoiceItemId != null ? invoiceItemId.GetHashCode() : 0;
        result = 31 * result + (invoiceId != null ? invoiceId.GetHashCode() : 0);
        result = 31 * result + (linkedInvoiceItemId != null ? linkedInvoiceItemId.GetHashCode() : 0);
        result = 31 * result + (accountId != null ? accountId.GetHashCode() : 0);
        result = 31 * result + (bundleId != null ? bundleId.GetHashCode() : 0);
        result = 31 * result + (subscriptionId != null ? subscriptionId.GetHashCode() : 0);
        result = 31 * result + (planName != null ? planName.GetHashCode() : 0);
        result = 31 * result + (phaseName != null ? phaseName.GetHashCode() : 0);
        result = 31 * result + (usageName != null ? usageName.GetHashCode() : 0);
        result = 31 * result + (itemType != null ? itemType.GetHashCode() : 0);
        result = 31 * result + (description != null ? description.GetHashCode() : 0);
        result = 31 * result + (startDate != null ? startDate.GetHashCode() : 0);
        result = 31 * result + (endDate != null ? endDate.GetHashCode() : 0);
        result = 31 * result + (amount != null ? amount.GetHashCode() : 0);
        result = 31 * result + (currency != null ? currency.GetHashCode() : 0);
        return result;
    }
}
