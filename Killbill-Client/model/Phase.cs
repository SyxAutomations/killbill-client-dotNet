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






public class Phase : KillBillObject {

    private string type;
    private List<Price> prices;
    private List<Price> fixedPrices;
    private Duration duration;

    
    public Phase(@JsonProperty("type") string type,
                 @JsonProperty("prices") List<Price> prices,
                 @JsonProperty("fixedPrices") List<Price> fixedPrices,
                 @JsonProperty("duration") Duration duration) {
        this.type = type;
        this.prices = prices;
        this.fixedPrices = fixedPrices;
        this.duration = duration;
    }

    public string getType() {
        return type;
    }

    public void setType(string type) {
        this.type = type;
    }

    public List<Price> getPrices() {
        return prices;
    }

    public void setPrices(List<Price> prices) {
        this.prices = prices;
    }

    public List<Price> getFixedPrices() {
        return fixedPrices;
    }

    public Duration getDuration() {
        return duration;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("Phase{");
        sb.Append("type='").append(type).append('\'');
        sb.Append(", prices=").append(prices);
        sb.Append(", fixedPrices=").append(fixedPrices);
        sb.Append(", duration=").append(duration);
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

        Phase phase = (Phase) o;

        if (prices != null ? !prices.equals(phase.prices) : phase.prices != null) {
            return false;
        }
        if (type != null ? !type.equals(phase.type) : phase.type != null) {
            return false;
        }
        if (fixedPrices != null ? !fixedPrices.equals(phase.fixedPrices) : phase.fixedPrices != null) {
            return false;
        }
        if (duration != null ? !duration.equals(phase.duration) : phase.duration != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = type != null ? type.GetHashCode() : 0;
        result = 31 * result + (prices != null ? prices.GetHashCode() : 0);
        result = 31 * result + (fixedPrices != null ? fixedPrices.GetHashCode() : 0);
        result = 31 * result + (duration != null ? duration.GetHashCode() : 0);
        return result;
    }
}
