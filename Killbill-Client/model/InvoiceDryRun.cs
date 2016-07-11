
using System;
using System.Collections.Generic;

namespace Killbill_Client.model {
    public class InvoiceDryRun
    {

        private DryRunType dryRunType;
        private SubscriptionEventType dryRunAction;
        private PhaseType phaseType;
        private string productName;
        private ProductCategory productCategory;
        private BillingPeriod billingPeriod;
        private string priceListName;
        private DateTime effectiveDate;
        private Guid subscriptionId;
        private Guid bundleId;
        private BillingActionPolicy billingPolicy;
        private List<PhasePriceOverride> priceOverrides;

    }
}
