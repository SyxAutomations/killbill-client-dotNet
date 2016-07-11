/*
 * Copyright 2014 Groupon, Inc
 *
 * Groupon licenses this file to you under the Apache License, version 2.0
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













public class PaymentTransaction : KillBillObject {

    private Guid transactionId;
    private string transactionExternalKey;
    private Guid paymentId;
    private string paymentExternalKey;
    private string transactionType;
    private DateTime effectiveDate;
    private string status;
    private BigDecimal amount;
    private string currency;
    private string gatewayErrorCode;
    private string gatewayErrorMsg;
    // Plugin specific fields
    private string firstPaymentReferenceId;
    private string secondPaymentReferenceId;
    // Avoid null iterable field
    private List<PluginProperty> properties = ImmutableList.<PluginProperty>of();

    public PaymentTransaction() {
    }

    
    public PaymentTransaction(@JsonProperty("transactionId") Guid transactionId,
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
                              @JsonProperty("auditLogs") @Nullable List<AuditLog> auditLogs) {
       auditLogs);
        this.transactionId = transactionId;
        this.transactionExternalKey = transactionExternalKey;
        this.paymentId = paymentId;
        this.paymentExternalKey = paymentExternalKey;
        this.transactionType = transactionType;
        this.effectiveDate = effectiveDate;
        this.status = status;
        this.amount = amount;
        this.currency = currency;
        this.gatewayErrorCode = gatewayErrorCode;
        this.gatewayErrorMsg = gatewayErrorMsg;
        this.firstPaymentReferenceId = firstPaymentReferenceId;
        this.secondPaymentReferenceId = secondPaymentReferenceId;
        setProperties(properties);
    }

    public Guid getTransactionId() {
        return transactionId;
    }

    public void setTransactionId(Guid transactionId) {
        this.transactionId = transactionId;
    }

    public string getTransactionExternalKey() {
        return transactionExternalKey;
    }

    public void setTransactionExternalKey(string transactionExternalKey) {
        this.transactionExternalKey = transactionExternalKey;
    }

    public Guid getPaymentId() {
        return paymentId;
    }

    public void setPaymentId(Guid paymentId) {
        this.paymentId = paymentId;
    }

    public string getPaymentExternalKey() {
        return paymentExternalKey;
    }

    public void setPaymentExternalKey(string paymentExternalKey) {
        this.paymentExternalKey = paymentExternalKey;
    }

    public string getTransactionType() {
        return transactionType;
    }

    public void setTransactionType(string transactionType) {
        this.transactionType = transactionType;
    }

    public DateTime getEffectiveDate() {
        return effectiveDate;
    }

    public void setEffectiveDate(DateTime effectiveDate) {
        this.effectiveDate = effectiveDate;
    }

    public string getStatus() {
        return status;
    }

    public void setStatus(string status) {
        this.status = status;
    }

    public BigDecimal getAmount() {
        return amount;
    }

    public void setAmount(BigDecimal amount) {
        this.amount = amount;
    }

    public string getCurrency() {
        return currency;
    }

    public void setCurrency(string currency) {
        this.currency = currency;
    }

    public string getGatewayErrorCode() {
        return gatewayErrorCode;
    }

    public void setGatewayErrorCode(string gatewayErrorCode) {
        this.gatewayErrorCode = gatewayErrorCode;
    }

    public string getGatewayErrorMsg() {
        return gatewayErrorMsg;
    }

    public void setGatewayErrorMsg(string gatewayErrorMsg) {
        this.gatewayErrorMsg = gatewayErrorMsg;
    }

    public string getFirstPaymentReferenceId() {
        return firstPaymentReferenceId;
    }

    public void setFirstPaymentReferenceId(string firstPaymentReferenceId) {
        this.firstPaymentReferenceId = firstPaymentReferenceId;
    }

    public string getSecondPaymentReferenceId() {
        return secondPaymentReferenceId;
    }

    public void setSecondPaymentReferenceId(string secondPaymentReferenceId) {
        this.secondPaymentReferenceId = secondPaymentReferenceId;
    }

    public List<PluginProperty> getProperties() {
        return properties;
    }

    public void setProperties(List<PluginProperty> properties) {
        if (properties != null) {
            this.properties = properties;
        }
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("PaymentTransaction{");
        sb.Append("transactionId=").append(transactionId);
        sb.Append(", transactionExternalKey='").append(transactionExternalKey).append('\'');
        sb.Append(", paymentId=").append(paymentId);
        sb.Append(", paymentExternalKey='").append(paymentExternalKey).append('\'');
        sb.Append(", transactionType='").append(transactionType).append('\'');
        sb.Append(", effectiveDate=").append(effectiveDate);
        sb.Append(", status='").append(status).append('\'');
        sb.Append(", amount=").append(amount);
        sb.Append(", currency='").append(currency).append('\'');
        sb.Append(", gatewayErrorCode='").append(gatewayErrorCode).append('\'');
        sb.Append(", gatewayErrorMsg='").append(gatewayErrorMsg).append('\'');
        sb.Append(", firstPaymentReferenceId='").append(firstPaymentReferenceId).append('\'');
        sb.Append(", secondPaymentReferenceId='").append(secondPaymentReferenceId).append('\'');
        sb.Append(", properties=").append(properties);
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

        PaymentTransaction that = (PaymentTransaction) o;

        if (amount != null ? amount.compareTo(that.amount) != 0 : that.amount != null) {
            return false;
        }
        if (currency != null ? !currency.equals(that.currency) : that.currency != null) {
            return false;
        }
        if (paymentExternalKey != null ? !paymentExternalKey.equals(that.paymentExternalKey) : that.paymentExternalKey != null) {
            return false;
        }
        if (paymentId != null ? !paymentId.equals(that.paymentId) : that.paymentId != null) {
            return false;
        }
        if (transactionExternalKey != null ? !transactionExternalKey.equals(that.transactionExternalKey) : that.transactionExternalKey != null) {
            return false;
        }
        if (transactionId != null ? !transactionId.equals(that.transactionId) : that.transactionId != null) {
            return false;
        }
        if (effectiveDate != null ? effectiveDate.compareTo(that.effectiveDate) != 0 : that.effectiveDate != null) {
            return false;
        }
        if (firstPaymentReferenceId != null ? !firstPaymentReferenceId.equals(that.firstPaymentReferenceId) : that.firstPaymentReferenceId != null) {
            return false;
        }
        if (gatewayErrorCode != null ? !gatewayErrorCode.equals(that.gatewayErrorCode) : that.gatewayErrorCode != null) {
            return false;
        }
        if (gatewayErrorMsg != null ? !gatewayErrorMsg.equals(that.gatewayErrorMsg) : that.gatewayErrorMsg != null) {
            return false;
        }
        if (properties != null ? !properties.equals(that.properties) : that.properties != null) {
            return false;
        }
        if (secondPaymentReferenceId != null ? !secondPaymentReferenceId.equals(that.secondPaymentReferenceId) : that.secondPaymentReferenceId != null) {
            return false;
        }
        if (status != null ? !status.equals(that.status) : that.status != null) {
            return false;
        }
        if (transactionType != null ? !transactionType.equals(that.transactionType) : that.transactionType != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = transactionId != null ? transactionId.GetHashCode() : 0;
        result = 31 * result + (transactionExternalKey != null ? transactionExternalKey.GetHashCode() : 0);
        result = 31 * result + (paymentId != null ? paymentId.GetHashCode() : 0);
        result = 31 * result + (paymentExternalKey != null ? paymentExternalKey.GetHashCode() : 0);
        result = 31 * result + (transactionType != null ? transactionType.GetHashCode() : 0);
        result = 31 * result + (effectiveDate != null ? effectiveDate.GetHashCode() : 0);
        result = 31 * result + (status != null ? status.GetHashCode() : 0);
        result = 31 * result + (amount != null ? amount.GetHashCode() : 0);
        result = 31 * result + (currency != null ? currency.GetHashCode() : 0);
        result = 31 * result + (gatewayErrorCode != null ? gatewayErrorCode.GetHashCode() : 0);
        result = 31 * result + (gatewayErrorMsg != null ? gatewayErrorMsg.GetHashCode() : 0);
        result = 31 * result + (firstPaymentReferenceId != null ? firstPaymentReferenceId.GetHashCode() : 0);
        result = 31 * result + (secondPaymentReferenceId != null ? secondPaymentReferenceId.GetHashCode() : 0);
        result = 31 * result + (properties != null ? properties.GetHashCode() : 0);
        return result;
    }
}
