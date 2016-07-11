/*
 * Copyright 2014-2016 Groupon, Inc
 * Copyright 2014-2016 The Billing Project, LLC
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




public class RolledUpUnit {

    private string unitType;
    private Long amount;

    public RolledUpUnit() {}

    
    public RolledUpUnit(@JsonProperty("unitType") string unitType,
                        @JsonProperty("amount") Long amount) {
        this.unitType = unitType;
        this.amount = amount;
    }

    public string getUnitType() {
        return unitType;
    }

    public void setUnitType(string unitType) {
        this.unitType = unitType;
    }

    public Long getAmount() {
        return amount;
    }

    public void setAmount(Long amount) {
        this.amount = amount;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("RolledUpUnit{");
        sb.Append("unitType=").append(unitType);
        sb.Append(", amount=").append(amount);
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

        RolledUpUnit that = (RolledUpUnit) o;

        if (unitType != null ? !unitType.equals(that.unitType) : that.unitType != null) {
            return false;
        }
        return amount != null ? amount.equals(that.amount) : that.amount == null;

    }

    
    public int GetHashCode() {
        int result = unitType != null ? unitType.GetHashCode() : 0;
        result = 31 * result + (amount != null ? amount.GetHashCode() : 0);
        return result;
    }
}
