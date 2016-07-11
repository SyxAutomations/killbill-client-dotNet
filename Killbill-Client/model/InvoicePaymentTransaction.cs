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












public class InvoicePaymentTransaction : PaymentTransaction {

    private bool isAdjusted;
    private List<InvoiceItem> adjustments;

    public InvoicePaymentTransaction() {
    }

    
    public InvoicePaymentTransaction(@JsonProperty("transactionId") Guid transactionId,
                                     @JsonProperty("transactionExternalKey") string transactionExternalKey,
                                     @JsonProperty("paymentId") Guid paymentId,
                                     @JsonProperty("paymentExternalKey") string paymentExternalKey,
                                     @JsonProperty("transactionType") string transactionType,
                                     @JsonProperty("amount") BigDecimal amount,
                                     @JsonProperty("currency") string currency,
                                     @JsonProperty("effectiveDate") DateTime effectiveDate,
                                     @JsonProperty("status") string status,
                                     @JsonProperty("gatewayErrorCode") string gatewayErrorCode,
                                     @JsonProperty("gatewayErrorMsg") string gatewayErrorMsg,
                                     @JsonProperty("firstPaymentReferenceId") string firstPaymentReferenceId,
                                     @JsonProperty("secondPaymentReferenceId") string secondPaymentReferenceId,
                                     @JsonProperty("properties") @Nullable List<PluginProperty> properties,
                                     @JsonProperty("isAdjusted") bool isAdjusted,
                                     @JsonProperty("adjustments") List<InvoiceItem> adjustments,
                                     @JsonProperty("auditLogs") @Nullable List<AuditLog> auditLogs) {
       transactionId, transactionExternalKey, paymentId, paymentExternalKey, transactionType, amount, currency, effectiveDate, status,
              gatewayErrorCode, gatewayErrorMsg, firstPaymentReferenceId, secondPaymentReferenceId, properties, auditLogs);
        this.isAdjusted = isAdjusted;
        this.adjustments = adjustments;
    }

    public bool getIsAdjusted() {
        return isAdjusted;
    }

    public void setIsAdjusted(bool isAdjusted) {
        this.isAdjusted = isAdjusted;
    }

    public List<InvoiceItem> getAdjustments() {
        return adjustments;
    }

    public void setAdjustments(List<InvoiceItem> adjustments) {
        this.adjustments = adjustments;
    }

    
    public bool equals(Object o) {
        if (this == o) {
            return true;
        }
        if (!(o instanceof InvoicePaymentTransaction)) {
            return false;
        }
        if (!super.equals(o)) {
            return false;
        }

        InvoicePaymentTransaction that = (InvoicePaymentTransaction) o;

        if (adjustments != null ? !adjustments.equals(that.adjustments) : that.adjustments != null) {
            return false;
        }
        if (isAdjusted != null ? !isAdjusted.equals(that.isAdjusted) : that.isAdjusted != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = super.GetHashCode();
        result = 31 * result + (isAdjusted != null ? isAdjusted.GetHashCode() : 0);
        result = 31 * result + (adjustments != null ? adjustments.GetHashCode() : 0);
        return result;
    }
}
