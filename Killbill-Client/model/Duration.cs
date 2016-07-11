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







public class Duration {

    private TimeUnit unit;
    private int number;

    
    public Duration(@JsonProperty("unit") TimeUnit unit,
                        @JsonProperty("number") int number) {
        this.unit = unit;
        this.number = number;
    }

    public Duration(org.killbill.billing.catalog.api.Duration duration) throws CurrencyValueNull {
        this(duration.getUnit(), duration.getNumber());
    }

    public TimeUnit getUnit() {
        return unit;
    }

    public int getNumber() {
        return number;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("DurationJson{");
        sb.Append("unit='").append(unit).append('\'');
        sb.Append(", number=").append(number);
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

        Duration that = (Duration) o;

        if (unit != null ? !unit.equals(that.unit) : that.unit != null) {
            return false;
        }

        return number == that.number;

    }

    
    public int GetHashCode() {
        int result = unit != null ? unit.GetHashCode() : 0;
        result = 31 * result + number;
        return result;
    }

}
