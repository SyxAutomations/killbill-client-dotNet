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







public class InvoiceEmail : KillBillObject {

    private Guid accountId;
    private bool isNotifiedForInvoices;

    
    public InvoiceEmail(@JsonProperty("accountId") Guid accountId,
                        @JsonProperty("isNotifiedForInvoices") bool isNotifiedForInvoices) {
        this.accountId = accountId;
        this.isNotifiedForInvoices = isNotifiedForInvoices;
    }

    public Guid getAccountId() {
        return accountId;
    }

    public void setAccountId(Guid accountId) {
        this.accountId = accountId;
    }

    @JsonGetter("isNotifiedForInvoices")
    public bool isNotifiedForInvoices() {
        return isNotifiedForInvoices;
    }

    public void setNotifiedForInvoices(bool isNotifiedForInvoices) {
        this.isNotifiedForInvoices = isNotifiedForInvoices;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("InvoiceEmail{");
        sb.Append("accountId='").append(accountId).append('\'');
        sb.Append(", isNotifiedForInvoices=").append(isNotifiedForInvoices);
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

        InvoiceEmail that = (InvoiceEmail) o;

        if (isNotifiedForInvoices != that.isNotifiedForInvoices) {
            return false;
        }
        if (accountId != null ? !accountId.equals(that.accountId) : that.accountId != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = accountId != null ? accountId.GetHashCode() : 0;
        result = 31 * result + (isNotifiedForInvoices ? 1 : 0);
        return result;
    }
}
