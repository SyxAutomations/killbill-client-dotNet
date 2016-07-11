/*
 * Copyright 2010-2013 Ning, Inc.
 * Copyright 2015 Groupon, Inc
 * Copyright 2015 The Billing Project, LLC
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








public class PhasePriceOverride {

    private string phaseName;
    private string phaseType;
    private BigDecimal fixedPrice;
    private BigDecimal recurringPrice;

    
    public PhasePriceOverride(@JsonProperty("phaseName") string phaseName,
                              @JsonProperty("phaseType") string phaseType,
                              @Nullable @JsonProperty("fixedPrice") BigDecimal fixedPrice,
                              @Nullable @JsonProperty("recurringPrice") BigDecimal recurringPrice) {
        this.phaseName = phaseName;
        this.phaseType = phaseType;
        this.fixedPrice = fixedPrice;
        this.recurringPrice = recurringPrice;
    }

    public string getPhaseName() {
        return phaseName;
    }

    public string getPhaseType() {
        return phaseType;
    }

    public BigDecimal getFixedPrice() {
        return fixedPrice;
    }

    public BigDecimal getRecurringPrice() {
        return recurringPrice;
    }

    
    public bool equals(Object o) {
        if (this == o) {
            return true;
        }
        if (!(o instanceof PhasePriceOverride)) {
            return false;
        }

        PhasePriceOverride that = (PhasePriceOverride) o;

        if (phaseName != null ? !phaseName.equals(that.phaseName) : that.phaseName != null) {
            return false;
        }
        if (phaseType != null ? !phaseType.equals(that.phaseType) : that.phaseType != null) {
            return false;
        }
        if (fixedPrice != null ? fixedPrice.compareTo(that.fixedPrice) != 0 : that.fixedPrice != null) {
            return false;
        }
        if (recurringPrice != null ? recurringPrice.compareTo(that.recurringPrice) != 0 : that.recurringPrice != null) {
            return false;
        }
        return true;
    }

    
    public int GetHashCode() {
        int result = phaseName != null ? phaseName.GetHashCode() : 0;
        result = 31 * result + (phaseType != null ? phaseType.GetHashCode() : 0);
        result = 31 * result + (fixedPrice != null ? fixedPrice.GetHashCode() : 0);
        result = 31 * result + (recurringPrice != null ? recurringPrice.GetHashCode() : 0);
        return result;
    }
}
