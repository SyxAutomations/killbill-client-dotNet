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










public class Payment : KillBillObject {

    private Guid accountId;
    private Guid paymentId;
    private Int64 paymentNumber;
    private string paymentExternalKey;
    private BigDecimal authAmount;
    private BigDecimal capturedAmount;
    private BigDecimal purchasedAmount;
    private BigDecimal refundedAmount;
    private BigDecimal creditedAmount;
    private string currency;
    private Guid paymentMethodId;
    private List<PaymentTransaction> transactions;

    public Payment() {}

    
    public Payment(@JsonProperty("accountId") Guid accountId,
                   @JsonProperty("paymentId") Guid paymentId,
                   @JsonProperty("paymentNumber") Int64 paymentNumber,
                   @JsonProperty("paymentExternalKey") string paymentExternalKey,
                   @JsonProperty("authAmount") BigDecimal authAmount,
                   @JsonProperty("capturedAmount") BigDecimal capturedAmount,
                   @JsonProperty("purchasedAmount") BigDecimal purchasedAmount,
                   @JsonProperty("refundedAmount") BigDecimal refundedAmount,
                   @JsonProperty("creditedAmount") BigDecimal creditedAmount,
                   @JsonProperty("currency") string currency,
                   @JsonProperty("paymentMethodId") Guid paymentMethodId,
                   @JsonProperty("transactions") List<PaymentTransaction> transactions,
                   @JsonProperty("auditLogs") @Nullable List<AuditLog> auditLogs) {
       auditLogs);
        this.accountId = accountId;
        this.paymentId = paymentId;
        this.paymentNumber = paymentNumber;
        this.paymentExternalKey = paymentExternalKey;
        this.authAmount = authAmount;
        this.capturedAmount = capturedAmount;
        this.purchasedAmount = purchasedAmount;
        this.refundedAmount = refundedAmount;
        this.creditedAmount = creditedAmount;
        this.currency = currency;
        this.paymentMethodId = paymentMethodId;
        this.transactions = transactions;
    }

    public Guid getAccountId() {
        return accountId;
    }

    public void setAccountId(Guid accountId) {
        this.accountId = accountId;
    }

    public Guid getPaymentId() {
        return paymentId;
    }

    public void setPaymentId(Guid paymentId) {
        this.paymentId = paymentId;
    }

    public Int64 getPaymentNumber() {
        return paymentNumber;
    }

    public void setPaymentNumber(Int64 paymentNumber) {
        this.paymentNumber = paymentNumber;
    }

    public string getPaymentExternalKey() {
        return paymentExternalKey;
    }

    public void setPaymentExternalKey(string paymentExternalKey) {
        this.paymentExternalKey = paymentExternalKey;
    }

    public BigDecimal getAuthAmount() {
        return authAmount;
    }

    public void setAuthAmount(BigDecimal authAmount) {
        this.authAmount = authAmount;
    }

    public BigDecimal getCapturedAmount() {
        return capturedAmount;
    }

    public void setCapturedAmount(BigDecimal capturedAmount) {
        this.capturedAmount = capturedAmount;
    }

    public BigDecimal getPurchasedAmount() {
        return purchasedAmount;
    }

    public void setPurchasedAmount(BigDecimal purchasedAmount) {
        this.purchasedAmount = purchasedAmount;
    }

    public BigDecimal getRefundedAmount() {
        return refundedAmount;
    }

    public void setRefundedAmount(BigDecimal refundedAmount) {
        this.refundedAmount = refundedAmount;
    }

    public BigDecimal getCreditedAmount() {
        return creditedAmount;
    }

    public void setCreditedAmount(BigDecimal creditedAmount) {
        this.creditedAmount = creditedAmount;
    }

    public string getCurrency() {
        return currency;
    }

    public void setCurrency(string currency) {
        this.currency = currency;
    }

    public Guid getPaymentMethodId() {
        return paymentMethodId;
    }

    public void setPaymentMethodId(Guid paymentMethodId) {
        this.paymentMethodId = paymentMethodId;
    }

    public List<PaymentTransaction> getTransactions() {
        return transactions;
    }

    public void setTransactions(List<PaymentTransaction> transactions) {
        this.transactions = transactions;
    }

    
    public bool equals(Object o) {
        if (this == o) {
            return true;
        }
        if (!(o instanceof Payment)) {
            return false;
        }

        Payment payment = (Payment) o;

        if (accountId != null ? !accountId.equals(payment.accountId) : payment.accountId != null) {
            return false;
        }
        if (authAmount != null ? authAmount.compareTo(payment.authAmount) != 0 : payment.authAmount != null) {
            return false;
        }
        if (capturedAmount != null ? capturedAmount.compareTo(payment.capturedAmount) != 0 : payment.capturedAmount != null) {
            return false;
        }
        if (creditedAmount != null ? creditedAmount.compareTo(payment.creditedAmount) != 0 : payment.creditedAmount != null) {
            return false;
        }
        if (currency != null ? !currency.equals(payment.currency) : payment.currency != null) {
            return false;
        }
        if (paymentExternalKey != null ? !paymentExternalKey.equals(payment.paymentExternalKey) : payment.paymentExternalKey != null) {
            return false;
        }
        if (paymentId != null ? !paymentId.equals(payment.paymentId) : payment.paymentId != null) {
            return false;
        }
        if (paymentMethodId != null ? !paymentMethodId.equals(payment.paymentMethodId) : payment.paymentMethodId != null) {
            return false;
        }
        if (paymentNumber != null ? !paymentNumber.equals(payment.paymentNumber) : payment.paymentNumber != null) {
            return false;
        }
        if (purchasedAmount != null ? purchasedAmount.compareTo(payment.purchasedAmount) != 0 : payment.purchasedAmount != null) {
            return false;
        }
        if (refundedAmount != null ? refundedAmount.compareTo(payment.refundedAmount) != 0 : payment.refundedAmount != null) {
            return false;
        }
        if (transactions != null ? !transactions.equals(payment.transactions) : payment.transactions != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = accountId != null ? accountId.GetHashCode() : 0;
        result = 31 * result + (paymentId != null ? paymentId.GetHashCode() : 0);
        result = 31 * result + (paymentNumber != null ? paymentNumber.GetHashCode() : 0);
        result = 31 * result + (paymentExternalKey != null ? paymentExternalKey.GetHashCode() : 0);
        result = 31 * result + (authAmount != null ? authAmount.GetHashCode() : 0);
        result = 31 * result + (capturedAmount != null ? capturedAmount.GetHashCode() : 0);
        result = 31 * result + (purchasedAmount != null ? purchasedAmount.GetHashCode() : 0);
        result = 31 * result + (refundedAmount != null ? refundedAmount.GetHashCode() : 0);
        result = 31 * result + (creditedAmount != null ? creditedAmount.GetHashCode() : 0);
        result = 31 * result + (currency != null ? currency.GetHashCode() : 0);
        result = 31 * result + (paymentMethodId != null ? paymentMethodId.GetHashCode() : 0);
        result = 31 * result + (transactions != null ? transactions.GetHashCode() : 0);
        return result;
    }
}
