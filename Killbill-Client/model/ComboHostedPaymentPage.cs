/*
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model {






    public class ComboHostedPaymentPage : ComboPayment
    {

        private HostedPaymentPageFields hostedPaymentPageFields;

        public ComboHostedPaymentPage()
        {
        }


        public ComboHostedPaymentPage(Account account,
            PaymentMethod paymentMethod,
            List<PluginProperty> paymentMethodPluginProperties,
            HostedPaymentPageFields hostedPaymentPageFields)
        {
            // todo: call to super
            this.hostedPaymentPageFields = hostedPaymentPageFields;
        }

        public HostedPaymentPageFields getHostedPaymentPageFields()
        {
            return hostedPaymentPageFields;
        }

        public void setHostedPaymentPageFields(HostedPaymentPageFields hostedPaymentPageFields)
        {
            this.hostedPaymentPageFields = hostedPaymentPageFields;
        }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("ComboHostedPaymentPage{");
            sb.Append("hostedPaymentPageFields=").Append(hostedPaymentPageFields);
            sb.Append('}');
            return sb.ToString();
        }


        public override bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }
            if (!base.Equals(o))
            {
                return false;
            }

            ComboHostedPaymentPage that = (ComboHostedPaymentPage) o;

            return
                !(hostedPaymentPageFields != null
                    ? !hostedPaymentPageFields.Equals(that.hostedPaymentPageFields)
                    : that.hostedPaymentPageFields != null);
        }


        public int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31*result + (hostedPaymentPageFields != null ? hostedPaymentPageFields.GetHashCode() : 0);
            return result;
        }
    }
}
