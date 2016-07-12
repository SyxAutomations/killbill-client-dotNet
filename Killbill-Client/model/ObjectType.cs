using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killbill_Client.model
{
    public enum ObjectType
    {
        ACCOUNT,
        ACCOUNT_EMAIL,
        BLOCKING_STATES,
        BUNDLE,
        CUSTOM_FIELD,
        INVOICE,
        PAYMENT,
        TRANSACTION,
        INVOICE_ITEM,
        INVOICE_PAYMENT,
        SUBSCRIPTION,
        SUBSCRIPTION_EVENT,
        SERVICE_BROADCAST,
        PAYMENT_ATTEMPT,
        PAYMENT_METHOD,
        REFUND,
        TAG,
        TAG_DEFINITION,
        TENANT,
        TENANT_KVS
    }
}
