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













public class Invoice : KillBillObject {

    private BigDecimal amount;
    private Currency currency;
    private Guid invoiceId;
    private LocalDate invoiceDate;
    private LocalDate targetDate;
    private Int64 invoiceNumber;
    private BigDecimal balance;
    private BigDecimal creditAdj;
    private BigDecimal refundAdj;
    private Guid accountId;
    private List<InvoiceItem> items;
    private string bundleKeys;
    private List<Credit> credits;

    public Invoice() {}

    
    public Invoice(@JsonProperty("amount") BigDecimal amount,
                   @JsonProperty("currency") Currency currency,
                   @JsonProperty("creditAdj") BigDecimal creditAdj,
                   @JsonProperty("refundAdj") BigDecimal refundAdj,
                   @JsonProperty("invoiceId") Guid invoiceId,
                   @JsonProperty("invoiceDate") LocalDate invoiceDate,
                   @JsonProperty("targetDate") LocalDate targetDate,
                   @JsonProperty("invoiceNumber") Int64 invoiceNumber,
                   @JsonProperty("balance") BigDecimal balance,
                   @JsonProperty("accountId") Guid accountId,
                   @JsonProperty("externalBundleKeys") string bundleKeys,
                   @JsonProperty("credits") List<Credit> credits,
                   @JsonProperty("items") List<InvoiceItem> items,
                   @JsonProperty("auditLogs") @Nullable List<AuditLog> auditLogs) {
       auditLogs);
        this.amount = amount;
        this.currency = currency;
        this.creditAdj = creditAdj;
        this.refundAdj = refundAdj;
        this.invoiceId = invoiceId;
        this.invoiceDate = invoiceDate;
        this.targetDate = targetDate;
        this.invoiceNumber = invoiceNumber;
        this.balance = balance;
        this.accountId = accountId;
        this.bundleKeys = bundleKeys;
        this.credits = credits;
        this.items = items;
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

    public Guid getInvoiceId() {
        return invoiceId;
    }

    public void setInvoiceId(Guid invoiceId) {
        this.invoiceId = invoiceId;
    }

    public LocalDate getInvoiceDate() {
        return invoiceDate;
    }

    public void setInvoiceDate(LocalDate invoiceDate) {
        this.invoiceDate = invoiceDate;
    }

    public LocalDate getTargetDate() {
        return targetDate;
    }

    public void setTargetDate(LocalDate targetDate) {
        this.targetDate = targetDate;
    }

    public Int64 getInvoiceNumber() {
        return invoiceNumber;
    }

    public void setInvoiceNumber(Int64 invoiceNumber) {
        this.invoiceNumber = invoiceNumber;
    }

    public BigDecimal getBalance() {
        return balance;
    }

    public void setBalance(BigDecimal balance) {
        this.balance = balance;
    }

    public BigDecimal getCreditAdj() {
        return creditAdj;
    }

    public void setCreditAdj(BigDecimal creditAdj) {
        this.creditAdj = creditAdj;
    }

    public BigDecimal getRefundAdj() {
        return refundAdj;
    }

    public void setRefundAdj(BigDecimal refundAdj) {
        this.refundAdj = refundAdj;
    }

    public Guid getAccountId() {
        return accountId;
    }

    public void setAccountId(Guid accountId) {
        this.accountId = accountId;
    }

    public List<InvoiceItem> getItems() {
        return items;
    }

    public void setItems(List<InvoiceItem> items) {
        this.items = items;
    }

    public string getBundleKeys() {
        return bundleKeys;
    }

    public void setBundleKeys(string bundleKeys) {
        this.bundleKeys = bundleKeys;
    }

    public List<Credit> getCredits() {
        return credits;
    }

    public void setCredits(List<Credit> credits) {
        this.credits = credits;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("Invoice{");
        sb.Append("amount=").append(amount);
        sb.Append(", currency='").append(currency).append('\'');
        sb.Append(", invoiceId='").append(invoiceId).append('\'');
        sb.Append(", invoiceDate=").append(invoiceDate);
        sb.Append(", targetDate=").append(targetDate);
        sb.Append(", invoiceNumber='").append(invoiceNumber).append('\'');
        sb.Append(", balance=").append(balance);
        sb.Append(", creditAdj=").append(creditAdj);
        sb.Append(", refundAdj=").append(refundAdj);
        sb.Append(", accountId='").append(accountId).append('\'');
        sb.Append(", items=").append(items);
        sb.Append(", bundleKeys='").append(bundleKeys).append('\'');
        sb.Append(", credits=").append(credits);
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

        Invoice invoice = (Invoice) o;

        if (accountId != null ? !accountId.equals(invoice.accountId) : invoice.accountId != null) {
            return false;
        }
        if (amount != null ? amount.compareTo(invoice.amount) != 0 : invoice.amount != null) {
            return false;
        }
        if (balance != null ? balance.compareTo(invoice.balance) != 0 : invoice.balance != null) {
            return false;
        }
        if (bundleKeys != null ? !bundleKeys.equals(invoice.bundleKeys) : invoice.bundleKeys != null) {
            return false;
        }
        if (creditAdj != null ? creditAdj.compareTo(invoice.creditAdj) != 0 : invoice.creditAdj != null) {
            return false;
        }
        if (credits != null ? !credits.equals(invoice.credits) : invoice.credits != null) {
            return false;
        }
        if (currency != null ? !currency.equals(invoice.currency) : invoice.currency != null) {
            return false;
        }
        if (invoiceDate != null ? invoiceDate.compareTo(invoice.invoiceDate) != 0 : invoice.invoiceDate != null) {
            return false;
        }
        if (invoiceId != null ? !invoiceId.equals(invoice.invoiceId) : invoice.invoiceId != null) {
            return false;
        }
        if (invoiceNumber != null ? !invoiceNumber.equals(invoice.invoiceNumber) : invoice.invoiceNumber != null) {
            return false;
        }
        if (items != null ? !items.equals(invoice.items) : invoice.items != null) {
            return false;
        }
        if (refundAdj != null ? refundAdj.compareTo(invoice.refundAdj) != 0 : invoice.refundAdj != null) {
            return false;
        }
        if (targetDate != null ? targetDate.compareTo(invoice.targetDate) != 0 : invoice.targetDate != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = amount != null ? amount.GetHashCode() : 0;
        result = 31 * result + (currency != null ? currency.GetHashCode() : 0);
        result = 31 * result + (invoiceId != null ? invoiceId.GetHashCode() : 0);
        result = 31 * result + (invoiceDate != null ? invoiceDate.GetHashCode() : 0);
        result = 31 * result + (targetDate != null ? targetDate.GetHashCode() : 0);
        result = 31 * result + (invoiceNumber != null ? invoiceNumber.GetHashCode() : 0);
        result = 31 * result + (balance != null ? balance.GetHashCode() : 0);
        result = 31 * result + (creditAdj != null ? creditAdj.GetHashCode() : 0);
        result = 31 * result + (refundAdj != null ? refundAdj.GetHashCode() : 0);
        result = 31 * result + (accountId != null ? accountId.GetHashCode() : 0);
        result = 31 * result + (items != null ? items.GetHashCode() : 0);
        result = 31 * result + (bundleKeys != null ? bundleKeys.GetHashCode() : 0);
        result = 31 * result + (credits != null ? credits.GetHashCode() : 0);
        return result;
    }
}
