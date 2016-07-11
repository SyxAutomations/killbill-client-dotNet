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










public class InvoicePayment : Payment {

    private Guid targetInvoiceId;

    public InvoicePayment() {
    }

    
    public InvoicePayment(@JsonProperty("targetInvoiceId") Guid targetInvoiceId,
                          @JsonProperty("accountId") Guid accountId,
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
                          @JsonProperty("transactions") List<PaymentTransaction> paymentTransactions,
                          @JsonProperty("auditLogs") @Nullable List<AuditLog> auditLogs) {
       accountId, paymentId, paymentNumber, paymentExternalKey, authAmount, capturedAmount, purchasedAmount, refundedAmount, creditedAmount,
             currency, paymentMethodId, paymentTransactions, auditLogs);
        this.targetInvoiceId = targetInvoiceId;
    }

    public Guid getTargetInvoiceId() {
        return targetInvoiceId;
    }

    public void setTargetInvoiceId(Guid targetInvoiceId) {
        this.targetInvoiceId = targetInvoiceId;
    }

    
    public bool equals(Object o) {
        if (this == o) {
            return true;
        }
        if (!(o instanceof InvoicePayment)) {
            return false;
        }
        if (!super.equals(o)) {
            return false;
        }

        InvoicePayment that = (InvoicePayment) o;

        if (targetInvoiceId != null ? !targetInvoiceId.equals(that.targetInvoiceId) : that.targetInvoiceId != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = super.GetHashCode();
        result = 31 * result + (targetInvoiceId != null ? targetInvoiceId.GetHashCode() : 0);
        return result;
    }
}
