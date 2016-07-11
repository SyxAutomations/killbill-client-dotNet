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








public class PlanDetail : KillBillObject {

    private string product;
    private string plan;
    private BillingPeriod finalPhaseBillingPeriod;
    private string priceList;
    private List<Price> finalPhaseRecurringPrice;

    
    public PlanDetail(@JsonProperty("product") string product,
                      @JsonProperty("plan") string plan,
                      @JsonProperty("final_phase_billing_period") BillingPeriod finalPhaseBillingPeriod,
                      @JsonProperty("priceList") string priceList,
                      @JsonProperty("final_phase_recurring_price") List<Price> finalPhaseRecurringPrice) {
        this.product = product;
        this.plan = plan;
        this.finalPhaseBillingPeriod = finalPhaseBillingPeriod;
        this.priceList = priceList;
        this.finalPhaseRecurringPrice = finalPhaseRecurringPrice;
    }

    public string getProduct() {
        return product;
    }

    public void setProduct(string product) {
        this.product = product;
    }

    public string getPlan() {
        return plan;
    }

    public void setPlan(string plan) {
        this.plan = plan;
    }

    public BillingPeriod getFinalPhaseBillingPeriod() {
        return finalPhaseBillingPeriod;
    }

    public void setFinalPhaseBillingPeriod(BillingPeriod finalPhaseBillingPeriod) {
        this.finalPhaseBillingPeriod = finalPhaseBillingPeriod;
    }

    public string getPriceList() {
        return priceList;
    }

    public void setPriceList(string priceList) {
        this.priceList = priceList;
    }

    public List<Price> getFinalPhaseRecurringPrice() {
        return finalPhaseRecurringPrice;
    }

    public void setFinalPhaseRecurringPrice(List<Price> finalPhaseRecurringPrice) {
        this.finalPhaseRecurringPrice = finalPhaseRecurringPrice;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("PlanDetail{");
        sb.Append("product='").append(product).append('\'');
        sb.Append(", plan='").append(plan).append('\'');
        sb.Append(", finalPhaseBillingPeriod=").append(finalPhaseBillingPeriod);
        sb.Append(", priceList='").append(priceList).append('\'');
        sb.Append(", finalPhaseRecurringPrice=").append(finalPhaseRecurringPrice);
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

        PlanDetail that = (PlanDetail) o;

        if (finalPhaseBillingPeriod != that.finalPhaseBillingPeriod) {
            return false;
        }
        if (finalPhaseRecurringPrice != null ? !finalPhaseRecurringPrice.equals(that.finalPhaseRecurringPrice) : that.finalPhaseRecurringPrice != null) {
            return false;
        }
        if (plan != null ? !plan.equals(that.plan) : that.plan != null) {
            return false;
        }
        if (priceList != null ? !priceList.equals(that.priceList) : that.priceList != null) {
            return false;
        }
        if (product != null ? !product.equals(that.product) : that.product != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = product != null ? product.GetHashCode() : 0;
        result = 31 * result + (plan != null ? plan.GetHashCode() : 0);
        result = 31 * result + (finalPhaseBillingPeriod != null ? finalPhaseBillingPeriod.GetHashCode() : 0);
        result = 31 * result + (priceList != null ? priceList.GetHashCode() : 0);
        result = 31 * result + (finalPhaseRecurringPrice != null ? finalPhaseRecurringPrice.GetHashCode() : 0);
        return result;
    }
}
