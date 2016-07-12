namespace Killbill_Client.model
{
    public class BillingPeriod
    {
        public static int MONTHLY = 1;
        public static int QUARTERLY = 3;
        public static int BIANNUAL = 6;
        public static int ANNUAL = 12;
        public static int BIENNIAL = 24;
        public static int NO_BILLING_PERIOD = 0;

        public int numberOfMonths { get; set; }

    }
}