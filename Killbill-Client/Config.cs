using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killbill_Client
{
    public static class Config
    {
        public static readonly string API_PREFIX = "";
    public static readonly string API_VERSION = "/1.0";
    public static readonly string API_POSTFIX = "/kb";

    public static readonly string PREFIX = API_PREFIX + API_VERSION + API_POSTFIX;

    /*
     * Resource paths
     */
    public static readonly string ACCOUNTS = "accounts";
    public static readonly string ACCOUNTS_PATH = PREFIX + "/" + ACCOUNTS;
    public static readonly string BUNDLES = "bundles";
    public static readonly string BUNDLES_PATH = PREFIX + "/" + BUNDLES;
    public static readonly string CATALOG = "catalog";
    public static readonly string CATALOG_PATH = PREFIX + "/" + CATALOG;
    public static readonly string CHARGEBACKS = "chargebacks";
    public static readonly string CHARGES = "charges";
    public static readonly string CREDITS = "credits";
    public static readonly string CREDITS_PATH = PREFIX + "/" + CREDITS;
    public static readonly string CUSTOM_FIELDS = "customFields";
    public static readonly string CUSTOM_FIELDS_PATH = PREFIX + "/" + CUSTOM_FIELDS;
    public static readonly string EMAILS = "emails";
    public static readonly string EMAIL_NOTIFICATIONS = "emailNotifications";
    public static readonly string FORM = "form";
    public static readonly string HOSTED = "hosted";
    public static readonly string INVOICE_HTML = "html";
    public static readonly string INVOICES = "invoices";
    public static readonly string INVOICES_PATH = PREFIX + "/" + INVOICES;
    public static readonly string DRY_RUN = "dryRun";
    public static readonly string INVOICE_PAYMENTS = "invoicePayments";
    public static readonly string INVOICE_PAYMENTS_PATH = PREFIX + "/" + INVOICE_PAYMENTS;
    public static readonly string NOTIFICATION = "notification";
    public static readonly string OVERDUE = "overdue";
    public static readonly string OVERDUE_PATH = PREFIX + "/" + OVERDUE;
    public static readonly string PAGINATION = "pagination";
    public static readonly string PAYMENTS = "payments";
    public static readonly string PAYMENTS_PATH = PREFIX + "/" + PAYMENTS;
    public static readonly string PAYMENT_GATEWAYS = "paymentGateways";
    public static readonly string PAYMENT_GATEWAYS_PATH = PREFIX + "/" + PAYMENT_GATEWAYS;
    public static readonly string PAYMENT_METHODS = "paymentMethods";
    public static readonly string PAYMENT_METHODS_DEFAULT_PATH_POSTFIX = "setDefault";
    public static readonly string PAYMENT_METHODS_PATH = PREFIX + "/" + PAYMENT_METHODS;
    public static readonly string PLUGINS = "plugins";
    public static readonly string PLUGINS_PATH = "/" + PLUGINS;
    public static readonly string REFUNDS = "refunds";
    public static readonly string REGISTER_NOTIFICATION_CALLBACK = "registerNotificationCallback";
    public static readonly string UPLOAD_PLUGIN_CONFIG = "uploadPluginConfig";
    public static readonly string UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG = "uploadPluginPaymentStateMachineConfig";
    public static readonly string SEARCH = "search";
    public static readonly string SECURITY = "security";
    public static readonly string SECURITY_PATH = PREFIX + "/" + SECURITY;
    public static readonly string SUBSCRIPTIONS = "subscriptions";
    public static readonly string SUBSCRIPTIONS_PATH = PREFIX + "/" + SUBSCRIPTIONS;
    public static readonly string TAGS = "tags";
    public static readonly string ALL_TAGS = "allTags";
    public static readonly string TAGS_PATH = PREFIX + "/" + TAGS;
    public static readonly string TAG_DEFINITIONS = "tagDefinitions";
    public static readonly string TAG_DEFINITIONS_PATH = PREFIX + "/" + TAG_DEFINITIONS;
    public static readonly string TENANTS = "tenants";
    public static readonly string TENANTS_PATH = PREFIX + "/" + TENANTS;
    public static readonly string TIMELINE = "timeline";
    public static readonly string USAGES = "usages";
    public static readonly string USAGES_PATH = PREFIX + "/" + USAGES;
    public static readonly string COMBO = "combo";
    public static readonly string BLOCK = "block";

    /*
     * Multi-Tenancy headers
     */
    public static readonly string HDR_API_KEY = "X-Killbill-ApiKey";
    public static readonly string HDR_API_SECRET = "X-Killbill-ApiSecret";

    /*
     * Metadata Additional headers
     */
    public static readonly string HDR_CREATED_BY = "X-Killbill-CreatedBy";
    public static readonly string HDR_REASON = "X-Killbill-Reason";
    public static readonly string HDR_COMMENT = "X-Killbill-Comment";
    public static readonly string HDR_PAGINATION_CURRENT_OFFSET = "X-Killbill-Pagination-CurrentOffset";
    public static readonly string HDR_PAGINATION_NEXT_OFFSET = "X-Killbill-Pagination-NextOffset";
    public static readonly string HDR_PAGINATION_TOTAL_NB_RECORDS = "X-Killbill-Pagination-TotalNbRecords";
    public static readonly string HDR_PAGINATION_MAX_NB_RECORDS = "X-Killbill-Pagination-MaxNbRecords";
    public static readonly string HDR_PAGINATION_NEXT_PAGE_URI = "X-Killbill-Pagination-NextPageUri";
    public static readonly string HDR_REQUEST_ID = "X-Request-Id";

    /*
     * Query parameters
     */
    public static readonly string QUERY_ACCOUNT_ID = "accountId";
    public static readonly string QUERY_ACCOUNT_WITH_BALANCE = "accountWithBalance";
    public static readonly string QUERY_ACCOUNT_WITH_BALANCE_AND_CBA = "accountWithBalanceAndCBA";
    public static readonly string QUERY_AUDIT = "audit";
    public static readonly string QUERY_BILLING_POLICY = "billingPolicy";
    public static readonly string QUERY_CALL_COMPLETION = "callCompletion";
    public static readonly string QUERY_CALL_TIMEOUT = "callTimeoutSec";
    public static readonly string QUERY_CUSTOM_FIELDS = "customFieldList";
    public static readonly string QUERY_DELETE_DEFAULT_PM_WITH_AUTO_PAY_OFF = "deleteDefaultPmWithAutoPayOff";
    public static readonly string QUERY_DRY_RUN = "dryRun";
    public static readonly string QUERY_ENTITLEMENT_POLICY = "entitlementPolicy";
    public static readonly string QUERY_EXTERNAL_KEY = "externalKey";
    public static readonly string QUERY_INVOICE_WITH_ITEMS = "withItems";
    public static readonly string QUERY_NOTIFICATION_CALLBACK = "cb";
    public static readonly string QUERY_PAYMENT_EXTERNAL = "externalPayment";
    public static readonly string QUERY_PAYMENT_METHOD_ID = "paymentMethodId";
    public static readonly string QUERY_PAYMENT_METHOD_IS_DEFAULT = "isDefault";
    public static readonly string QUERY_PAYMENT_PLUGIN_NAME = "pluginName";
    public static readonly string QUERY_PAY_INVOICE = "payInvoice";
    public static readonly string QUERY_PLUGIN_PROPERTY = "pluginProperty";
    public static readonly string QUERY_REQUESTED_DT = "requestedDate";
    public static readonly string QUERY_SEARCH_LIMIT = "limit";
    public static readonly string QUERY_SEARCH_OFFSET = "offset";
    public static readonly string QUERY_TAGS = "tagList";
    public static readonly string QUERY_OBJECT_TYPE = "objectType";
    public static readonly string QUERY_TARGET_DATE = "targetDate";
    public static readonly string QUERY_UNPAID_INVOICES_ONLY = "unpaidInvoicesOnly";
    public static readonly string QUERY_PAYMENT_METHOD_PLUGIN_NAME = "pluginName";
    public static readonly string QUERY_WITH_PLUGIN_INFO = "withPluginInfo";
    public static readonly string UPCOMING_INVOICE_TARGET_DATE = "upcomingInvoiceTargetDate";
    public static readonly string QUERY_START_DATE = "startDate";
    public static readonly string QUERY_END_DATE = "endDate";
    public static readonly string QUERY_USE_REQUESTED_DATE_FOR_BILLING = "useRequestedDateForBilling";
    }
}
