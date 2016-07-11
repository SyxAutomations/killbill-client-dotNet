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






public class Price : KillBillObject {

    private string currency;
    private BigDecimal value;

    
    public Price(@JsonProperty("currency") string currency,
                 @JsonProperty("value") BigDecimal value) {
        this.currency = currency;
        this.value = value;
    }

    public string getCurrency() {
        return currency;
    }

    public void setCurrency(string currency) {
        this.currency = currency;
    }

    public BigDecimal getValue() {
        return value;
    }

    public void setValue(BigDecimal value) {
        this.value = value;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("Price{");
        sb.Append("currency='").append(currency).append('\'');
        sb.Append(", value=").append(value);
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

        Price price = (Price) o;

        if (currency != null ? !currency.equals(price.currency) : price.currency != null) {
            return false;
        }
        if (value != null ? !value.equals(price.value) : price.value != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = currency != null ? currency.GetHashCode() : 0;
        result = 31 * result + (value != null ? value.GetHashCode() : 0);
        return result;
    }
}
