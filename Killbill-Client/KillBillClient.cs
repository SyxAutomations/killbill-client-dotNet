using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Killbill_Client;
using Killbill_Client.model;
using Ninject.Infrastructure;

namespace Killbill_Client
{
    public class KillBillClient
    {
        private readonly KillBillHttpClient httpClient;

        public KillBillClient() : this(new KillBillHttpClient())
        {
        }

        public KillBillClient(KillBillHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }



        public void close()
        {
            httpClient.close();
        }

        // Accounts


        public Accounts getAccounts(RequestOptions inputOptions)
        {
            return getAccounts(0L, 100L, inputOptions);
        }

        public Accounts getAccounts(long offset, long limit, RequestOptions inputOptions)
        {
            return getAccounts(offset, limit, AuditLevel.None, inputOptions);
        }


        public Accounts getAccounts(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
        {
            String uri = Config.ACCOUNTS_PATH + "/" + Config.PAGINATION;

            Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
            queryParams.Add(Config.QUERY_SEARCH_OFFSET, offset.ToString());
            queryParams.Add(Config.QUERY_SEARCH_LIMIT, limit.ToString());
            queryParams.Add(Config.QUERY_AUDIT, auditLevel.ToString());


            RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

            return httpClient.doGet(uri, Accounts.class, requestOptions);
    }

    public Account getAccount(Guid accountId, RequestOptions inputOptions)
    {
        return getAccount(accountId, false, false, inputOptions);
    }

    public Account getAccount(Guid accountId, bool withBalance, bool withCBA, RequestOptions inputOptions)
    {
        String uri = Config.ACCOUNTS_PATH + "/" + accountId;

        Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
        queryParams.Add(Config.QUERY_ACCOUNT_WITH_BALANCE, withBalance ? "true" : "false");
        queryParams.Add(Config.QUERY_ACCOUNT_WITH_BALANCE_AND_CBA, withCBA ? "true" : "false");

        RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Account.class, requestOptions);
    }

public Account getAccount(String externalKey, RequestOptions inputOptions)
{
    return getAccount(externalKey, false, false, inputOptions);
}

public Account getAccount(String externalKey, bool withBalance, bool withCBA, RequestOptions inputOptions)
{
    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_EXTERNAL_KEY, externalKey);
    queryParams.Add(Config.QUERY_ACCOUNT_WITH_BALANCE, withBalance ? "true" : "false");
    queryParams.Add(Config.QUERY_ACCOUNT_WITH_BALANCE_AND_CBA, withCBA ? "true" : "false");

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(Config.ACCOUNTS_PATH, Account.class, requestOptions);
    }

public Accounts searchAccounts(String key, RequestOptions inputOptions)
{
    return searchAccounts(key, 0L, 100L, inputOptions);
}

public Accounts searchAccounts(String key, long offset, long limit, RequestOptions inputOptions)
{
    return searchAccounts(key, offset, limit, AuditLevel.None, RequestOptions.empty());
}

public Accounts searchAccounts(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Accounts.class, requestOptions);
    }

public AccountTimeline getAccountTimeline(Guid accountId, RequestOptions inputOptions)
{
    return getAccountTimeline(accountId, AuditLevel.NONE, inputOptions);
}


public AccountTimeline getAccountTimeline(Guid accountId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.TIMELINE;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, AccountTimeline.class, requestOptions);
    }

public Account createAccount(Account account, RequestOptions inputOptions)
{
    bool followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), true);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();
    return httpClient.doPost(Config.ACCOUNTS_PATH, account, Account.class, requestOptions);
    }



public Account updateAccount(Account account, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(account.getAccountId(), "Account#accountId cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + account.getAccountId();

    return httpClient.doPut(uri, account, Account.class, inputOptions);
    }

public AccountEmails getEmailsForAccount(Guid accountId, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.EMAILS;

    return httpClient.doGet(uri, AccountEmails.class, inputOptions);
    }
    

public void addEmailToAccount(AccountEmail email, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(email.getAccountId(), "AccountEmail#accountId cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + email.getAccountId() + "/" + Config.EMAILS;

    httpClient.doPost(uri, email, inputOptions);
}


public void removeEmailFromAccount(AccountEmail email, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(email.getAccountId(), "AccountEmail#accountId cannot be null");
    Preconditions.checkNotNull(email.getEmail(), "AccountEmail#email cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + email.getAccountId() + "/" + Config.EMAILS + "/" + UTF8UrlEncoder.encode(email.getEmail());

    httpClient.doDelete(uri, inputOptions);
}


public InvoiceEmail getEmailNotificationsForAccount(Guid accountId, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.EMAIL_NOTIFICATIONS;

    return httpClient.doGet(uri, InvoiceEmail.class, inputOptions);
    }


public void updateEmailNotificationsForAccount(InvoiceEmail invoiceEmail, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(invoiceEmail.getAccountId(), "InvoiceEmail#accountId cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + invoiceEmail.getAccountId() + "/" + Config.EMAIL_NOTIFICATIONS;

    httpClient.doPut(uri, invoiceEmail, inputOptions);
}

// Bundles


public Bundle getBundle(Guid bundleId, RequestOptions inputOptions)
{
    String uri = Config.BUNDLES_PATH + "/" + bundleId;

    return httpClient.doGet(uri, Bundle.class, inputOptions);
    }
    
public Bundle getBundle(String externalKey, RequestOptions inputOptions)
{
    String uri = Config.BUNDLES_PATH;

    Multimap<String, String> queryParams = HashMultimap.create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_EXTERNAL_KEY, externalKey);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Bundle.class, requestOptions);
    }


public Bundles getAccountBundles(Guid accountId, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.BUNDLES;

    return httpClient.doGet(uri, Bundles.class, inputOptions);
    }

public Bundles getAccountBundles(Guid accountId, String externalKey, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.BUNDLES;

    Multimap<String, String> queryParams = HashMultimap.create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_EXTERNAL_KEY, externalKey);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Bundles.class, requestOptions);
    }



public Bundles getBundles(RequestOptions inputOptions)
{
    return getBundles(0L, 100L, inputOptions);
}



public Bundles getBundles(long offset, long limit, RequestOptions inputOptions)
{
    return getBundles(offset, limit, AuditLevel.NONE, inputOptions);
}



public Bundles getBundles(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.BUNDLES_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Bundles.class, requestOptions);
    }



public Bundles searchBundles(String key, RequestOptions inputOptions)
{
    return searchBundles(key, 0L, 100L, inputOptions);
}



public Bundles searchBundles(String key, long offset, long limit, RequestOptions inputOptions)
{
    return searchBundles(key, offset, limit, AuditLevel.NONE, inputOptions);
}



public Bundles searchBundles(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.BUNDLES_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Bundles.class, requestOptions);
    }



public Bundle transferBundle(Bundle bundle, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(bundle.getBundleId(), "Bundle#bundleId cannot be null");
    Preconditions.checkNotNull(bundle.getAccountId(), "Bundle#accountId cannot be null");

    String uri = Config.BUNDLES_PATH + "/" + bundle.getBundleId();

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

    return httpClient.doPut(uri, bundle, Bundle.class, requestOptions);
    }

 
public void setBlockingState(Guid bundleId, BlockingState blockingState, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(bundleId, "bundleId cannot be null");
    Preconditions.checkNotNull(blockingState.getService(), "Bundle#service cannot be null");
    Preconditions.checkNotNull(blockingState.getStateName(), "Bundle#stateName cannot be null");
    Preconditions.checkNotNull(blockingState.getEffectiveDate(), "Bundle#effectiveDate cannot be null");
    Preconditions.checkNotNull(blockingState.getType(), "Bundle#type cannot be null");

    String uri = Config.BUNDLES_PATH + "/" + bundleId + "/" + Config.BLOCK;

    httpClient.doPut(uri, blockingState, inputOptions);
}

// Subscriptions and entitlements


public Subscription getSubscription(Guid subscriptionId, RequestOptions inputOptions)
{
    String uri = Config.SUBSCRIPTIONS_PATH + "/" + subscriptionId;

    return httpClient.doGet(uri, Subscription.class, inputOptions);
    }



public Subscription createSubscription(Subscription subscription, RequestOptions inputOptions)
{
    return createSubscription(subscription, -1, inputOptions);
}


public Subscription createSubscription(Subscription subscription, int timeoutSec, RequestOptions inputOptions)
{
    return createSubscription(subscription, null, timeoutSec, inputOptions);
}


public Subscription createSubscription(Subscription subscription, DateTime requestedDate, int timeoutSec, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(subscription.getAccountId(), "Subscription#accountId cannot be null");
    Preconditions.checkNotNull(subscription.getProductName(), "Subscription#productName cannot be null");
    Preconditions.checkNotNull(subscription.getProductCategory(), "Subscription#productCategory cannot be null");
    Preconditions.checkNotNull(subscription.getBillingPeriod(), "Subscription#billingPeriod cannot be null");
    Preconditions.checkNotNull(subscription.getPriceList(), "Subscription#priceList cannot be null");
    if (subscription.getProductCategory() == ProductCategory.BASE)
    {
        Preconditions.checkNotNull(subscription.getAccountId(), "Account#accountId cannot be null");
    }

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_CALL_COMPLETION, timeoutSec > 0 ? "true" : "false");
    queryParams.Add(Config.QUERY_CALL_TIMEOUT, String.valueOf(timeoutSec));
    if (requestedDate != null)
    {
        queryParams.Add(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    }

    int httpTimeout = Math.max(DEFAULT_HTTP_TIMEOUT_SEC, timeoutSec);

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

    return httpClient.doPost(Config.SUBSCRIPTIONS_PATH, subscription, Subscription.class, requestOptions, httpTimeout);
    }


public Bundle createSubscriptionWithAddOns(Iterable<Subscription> subscriptions, DateTime requestedDate, int timeoutSec, RequestOptions inputOptions)
{
    for (Subscription subscription : subscriptions)
    {
        Preconditions.checkNotNull(subscription.getProductName(), "Subscription#productName cannot be null");
        Preconditions.checkNotNull(subscription.getProductCategory(), "Subscription#productCategory cannot be null");
        Preconditions.checkNotNull(subscription.getBillingPeriod(), "Subscription#billingPeriod cannot be null");
        Preconditions.checkNotNull(subscription.getPriceList(), "Subscription#priceList cannot be null");
        if (subscription.getProductCategory() == ProductCategory.BASE)
        {
            Preconditions.checkNotNull(subscription.getAccountId(), "Account#accountId cannot be null for base subscription");
        }
    }

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_CALL_COMPLETION, timeoutSec > 0 ? "true" : "false");
    queryParams.Add(Config.QUERY_CALL_TIMEOUT, String.valueOf(timeoutSec));
    if (requestedDate != null)
    {
        queryParams.Add(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    }

    int httpTimeout = Math.max(DEFAULT_HTTP_TIMEOUT_SEC, timeoutSec);

    String uri = Config.SUBSCRIPTIONS_PATH + "/createEntitlementWithAddOns";

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, subscriptions, Bundle.class, requestOptions, httpTimeout);
    }

   

public Subscription updateSubscription(Subscription subscription, int timeoutSec, RequestOptions inputOptions)
{
    return updateSubscription(subscription, null, timeoutSec, inputOptions);
}


public Subscription updateSubscription(Subscription subscription, @Nullable BillingActionPolicy billingPolicy, int timeoutSec, RequestOptions inputOptions)
{
    return updateSubscription(subscription, null, billingPolicy, timeoutSec, inputOptions);
}



public Subscription updateSubscription(Subscription subscription, @Nullable DateTime requestedDate, @Nullable BillingActionPolicy billingPolicy, int timeoutSec, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(subscription.getSubscriptionId(), "Subscription#subscriptionId cannot be null");
    Preconditions.checkNotNull(subscription.getProductName(), "Subscription#productName cannot be null");
    Preconditions.checkNotNull(subscription.getBillingPeriod(), "Subscription#billingPeriod cannot be null");
    Preconditions.checkNotNull(subscription.getPriceList(), "Subscription#priceList cannot be null");

    String uri = Config.SUBSCRIPTIONS_PATH + "/" + subscription.getSubscriptionId();

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_CALL_COMPLETION, timeoutSec > 0 ? "true" : "false");
    queryParams.Add(Config.QUERY_CALL_TIMEOUT, String.valueOf(timeoutSec));
    if (requestedDate != null)
    {
        queryParams.Add(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    }
    if (billingPolicy != null)
    {
        queryParams.Add(Config.QUERY_BILLING_POLICY, billingPolicy.toString());
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doPut(uri, subscription, Subscription.class, inputOptions);
    }

   
public void cancelSubscription(Guid subscriptionId, RequestOptions inputOptions)
{
    cancelSubscription(subscriptionId, -1, inputOptions);
}


public void cancelSubscription(Guid subscriptionId, int timeoutSec, RequestOptions inputOptions)
{
    cancelSubscription(subscriptionId, null, null, timeoutSec, inputOptions);
}


public void cancelSubscription(Guid subscriptionId, @Nullable EntitlementActionPolicy entitlementPolicy, @Nullable BillingActionPolicy billingPolicy,
                               int timeoutSec, RequestOptions inputOptions)
{
    cancelSubscription(subscriptionId, null, entitlementPolicy, billingPolicy, timeoutSec, inputOptions);
}



public void cancelSubscription(Guid subscriptionId, @Nullable DateTime requestedDate, @Nullable EntitlementActionPolicy entitlementPolicy, @Nullable BillingActionPolicy billingPolicy,
                               int timeoutSec, RequestOptions inputOptions)
{
    cancelSubscription(subscriptionId, requestedDate, null, entitlementPolicy, billingPolicy, timeoutSec, inputOptions);
}



public void cancelSubscription(Guid subscriptionId, @Nullable DateTime requestedDate, @Nullable Boolean useRequestedDateForBilling, @Nullable EntitlementActionPolicy entitlementPolicy,
                               @Nullable BillingActionPolicy billingPolicy, int timeoutSec, RequestOptions inputOptions)
{
    String uri = Config.SUBSCRIPTIONS_PATH + "/" + subscriptionId;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_CALL_COMPLETION, timeoutSec > 0 ? "true" : "false");
    queryParams.Add(Config.QUERY_CALL_TIMEOUT, String.valueOf(timeoutSec));
    if (requestedDate != null)
    {
        queryParams.Add(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    }
    if (entitlementPolicy != null)
    {
        queryParams.Add(Config.QUERY_ENTITLEMENT_POLICY, entitlementPolicy.toString());
    }
    if (billingPolicy != null)
    {
        queryParams.Add(Config.QUERY_BILLING_POLICY, billingPolicy.toString());
    }
    if (useRequestedDateForBilling != null)
    {
        queryParams.Add(Config.QUERY_USE_REQUESTED_DATE_FOR_BILLING, useRequestedDateForBilling.toString());
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doDelete(uri, requestOptions);
}



public void uncancelSubscription(Guid subscriptionId, RequestOptions inputOptions)
{
    String uri = Config.SUBSCRIPTIONS_PATH + "/" + subscriptionId + "/uncancel";

    httpClient.doPut(uri, null, inputOptions);
}



public void createSubscriptionUsageRecord(SubscriptionUsageRecord subscriptionUsageRecord, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(subscriptionUsageRecord.getSubscriptionId(), "SubscriptionUsageRecord#subscriptionId cannot be null");
    Preconditions.checkNotNull(subscriptionUsageRecord.getUnitUsageRecords(), "SubscriptionUsageRecord#unitUsageRecords cannot be null");
    Preconditions.checkArgument(!subscriptionUsageRecord.getUnitUsageRecords().isEmpty(), "SubscriptionUsageRecord#unitUsageRecords cannot be empty");

    String uri = Config.USAGES_PATH;

    httpClient.doPost(uri, subscriptionUsageRecord, inputOptions);
}



public RolledUpUsage getRolledUpUsage(Guid subscriptionId, @Nullable String unitType, LocalDate startDate, LocalDate endDate, RequestOptions inputOptions)
{
    String uri = Config.USAGES_PATH + "/" + subscriptionId;

    if (unitType != null && !unitType.trim().isEmpty())
    {
        uri = uri.concat("/").concat(unitType);
    }

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_START_DATE, startDate.toString());
    queryParams.Add(Config.QUERY_END_DATE, endDate.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, RolledUpUsage.class, requestOptions);
    }

    // Invoices

   
public Invoices getInvoices(RequestOptions inputOptions)
{
    return getInvoices(0L, 100L, inputOptions);
}


public Invoices getInvoices(long offset, long limit, RequestOptions inputOptions)
{
    return getInvoices(true, offset, limit, AuditLevel.NONE, inputOptions);
}


public Invoices getInvoices(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getInvoices(true, offset, limit, auditLevel, inputOptions);
}


public Invoices getInvoices(bool withItems, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.INVOICES_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_INVOICE_WITH_ITEMS, String.valueOf(withItems));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Invoices.class, requestOptions);
    }


public Invoice getInvoice(Guid invoiceId, RequestOptions inputOptions)
{
    return getInvoice(invoiceId, true, inputOptions);
}


public Invoice getInvoice(Guid invoiceId, bool withItems, RequestOptions inputOptions)
{
    return getInvoice(invoiceId, withItems, AuditLevel.NONE, inputOptions);
}


public Invoice getInvoice(Guid invoiceId, bool withItems, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getInvoiceByIdOrNumber(invoiceId.toString(), withItems, auditLevel, inputOptions);
}


public Invoice getInvoice(Integer invoiceNumber, RequestOptions inputOptions)
{
    return getInvoice(invoiceNumber, true, inputOptions);
}


public Invoice getInvoice(Integer invoiceNumber, bool withItems, RequestOptions inputOptions)
{
    return getInvoice(invoiceNumber, withItems, AuditLevel.NONE, inputOptions);
}

public Invoice getInvoice(Integer invoiceNumber, bool withItems, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getInvoiceByIdOrNumber(invoiceNumber.toString(), withItems, auditLevel, inputOptions);
}

public Invoice getInvoiceByIdOrNumber(String invoiceIdOrNumber, bool withItems, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.INVOICES_PATH + "/" + invoiceIdOrNumber;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_INVOICE_WITH_ITEMS, String.valueOf(withItems));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Invoice.class, requestOptions);
    }

   
public String getInvoiceAsHtml(Guid invoiceId, RequestOptions inputOptions)
{
    String uri = Config.INVOICES_PATH + "/" + invoiceId + "/" + Config.INVOICE_HTML;
    return getResourceFile(uri, KillBillHttpClient.ACCEPT_HTML, inputOptions);
}


public Invoices getInvoicesForAccount(Guid accountId, RequestOptions inputOptions)
{
    return getInvoicesForAccount(accountId, true, inputOptions);
}


public Invoices getInvoicesForAccount(Guid accountId, bool withItems, RequestOptions inputOptions)
{
    return getInvoicesForAccount(accountId, withItems, false, AuditLevel.NONE, inputOptions);
}


public Invoices getInvoicesForAccount(Guid accountId, bool withItems, bool unpaidOnly, RequestOptions inputOptions)
{
    return getInvoicesForAccount(accountId, withItems, unpaidOnly, AuditLevel.NONE, inputOptions);
}


public Invoices getInvoicesForAccount(Guid accountId, bool withItems, bool unpaidOnly, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.INVOICES;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_INVOICE_WITH_ITEMS, String.valueOf(withItems));
    queryParams.Add(Config.QUERY_UNPAID_INVOICES_ONLY, String.valueOf(unpaidOnly));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Invoices.class, requestOptions);
    }

    

public Invoices searchInvoices(String key, RequestOptions inputOptions)
{
    return searchInvoices(key, 0L, 100L, inputOptions);
}

public Invoices searchInvoices(String key, long offset, long limit, RequestOptions inputOptions)
{
    return searchInvoices(key, offset, limit, AuditLevel.NONE, inputOptions);
}

public Invoices searchInvoices(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.INVOICES_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Invoices.class, requestOptions);
    }

  

public Invoice createDryRunInvoice(Guid accountId, @Nullable LocalDate futureDate, InvoiceDryRun dryRunInfo, RequestOptions inputOptions)
{
    String uri = Config.INVOICES_PATH + "/" + Config.DRY_RUN;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());

    String futureDateOrUpcomingNextInvoice = (futureDate != null) ? futureDate.toString() : null;
    if (futureDateOrUpcomingNextInvoice != null)
    {
        queryParams.Add(Config.QUERY_ACCOUNT_ID, accountId.toString());
        queryParams.Add(Config.QUERY_TARGET_DATE, futureDateOrUpcomingNextInvoice);
        queryParams.Add(Config.QUERY_DRY_RUN, "true");
    }
    else
    {
        queryParams.Add(Config.QUERY_ACCOUNT_ID, accountId.toString());
        queryParams.Add(Config.QUERY_DRY_RUN, "true");
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doPost(uri, dryRunInfo, Invoice.class, requestOptions);
    }

  

public Invoice createInvoice(Guid accountId, LocalDate futureDate, RequestOptions inputOptions)
{
    String uri = Config.INVOICES_PATH;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_ACCOUNT_ID, accountId.toString());
    queryParams.Add(Config.QUERY_TARGET_DATE, futureDate.toString());

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, null, Invoice.class, requestOptions);
    }

   
public Invoice adjustInvoiceItem(InvoiceItem invoiceItem, RequestOptions inputOptions)
{
    return adjustInvoiceItem(invoiceItem, new DateTime(DateTimeZone.UTC), inputOptions);
}



public Invoice adjustInvoiceItem(InvoiceItem invoiceItem, DateTime requestedDate, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(invoiceItem.getAccountId(), "InvoiceItem#accountId cannot be null");
    Preconditions.checkNotNull(invoiceItem.getInvoiceId(), "InvoiceItem#invoiceId cannot be null");
    Preconditions.checkNotNull(invoiceItem.getInvoiceItemId(), "InvoiceItem#invoiceItemId cannot be null");

    String uri = Config.INVOICES_PATH + "/" + invoiceItem.getInvoiceId();

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, invoiceItem, Invoice.class, requestOptions);
    }

   

public InvoiceItem createExternalCharge(InvoiceItem externalCharge, DateTime requestedDate, Boolean autoPay, RequestOptions inputOptions)
{
    List<InvoiceItem> externalCharges = createExternalCharges(ImmutableList.< InvoiceItem > of(externalCharge), requestedDate, autoPay, inputOptions);
    return externalCharges.isEmpty() ? null : externalCharges.get(0);
}


public List<InvoiceItem> createExternalCharges(Iterable<InvoiceItem> externalCharges, DateTime requestedDate, Boolean autoPay, RequestOptions inputOptions)
{
    Map<Guid, Collection<InvoiceItem>> externalChargesPerAccount = new HashMap<Guid, Collection<InvoiceItem>>();
    for (InvoiceItem externalCharge : externalCharges)
    {
        Preconditions.checkNotNull(externalCharge.getAccountId(), "InvoiceItem#accountId cannot be null");
        Preconditions.checkNotNull(externalCharge.getAmount(), "InvoiceItem#amount cannot be null");
        // We allow the currency to be null and in this case will default to account currency
        //Preconditions.checkNotNull(externalCharge.getCurrency(), "InvoiceItem#currency cannot be null");

        if (externalChargesPerAccount.get(externalCharge.getAccountId()) == null)
        {
            externalChargesPerAccount.Add(externalCharge.getAccountId(), new LinkedList<InvoiceItem>());
        }
        externalChargesPerAccount.get(externalCharge.getAccountId()).add(externalCharge);
    }

    List<InvoiceItem> createdExternalCharges = new LinkedList<InvoiceItem>();
    for (Guid accountId : externalChargesPerAccount.keySet())
    {
        List<InvoiceItem> invoiceItems = createExternalCharges(accountId, externalChargesPerAccount.get(accountId), requestedDate, autoPay, inputOptions);
        createdExternalCharges.addAll(invoiceItems);
    }

    return createdExternalCharges;
}

private List<InvoiceItem> createExternalCharges(Guid accountId, Iterable<InvoiceItem> externalCharges, DateTime requestedDate, Boolean autoPay, RequestOptions inputOptions)
{
    String uri = Config.INVOICES_PATH + "/" + Config.CHARGES + "/" + accountId;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    queryParams.Add(Config.QUERY_PAY_INVOICE, autoPay.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doPost(uri, externalCharges, InvoiceItems.class, requestOptions);
    }

   

public void triggerInvoiceNotification(Guid invoiceId, RequestOptions inputOptions)
{
    String uri = Config.INVOICES_PATH + "/" + invoiceId.toString() + "/" + Config.EMAIL_NOTIFICATIONS;

    httpClient.doPost(uri, null, inputOptions);
}


public void uploadInvoiceTemplate(String invoiceTemplateFilePath, bool manualPay, RequestOptions inputOptions)
{
    String uri = Config.INVOICES + (manualPay ? "/manualPayTemplate" : "/template");
    uploadFile(invoiceTemplateFilePath, uri, "text/html", inputOptions, null);
}


public void uploadInvoiceTemplate(InputStream invoiceTemplateInputStream, bool manualPay, RequestOptions inputOptions)
{
    String uri = Config.INVOICES + (manualPay ? "/manualPayTemplate" : "/template");
    uploadFile(invoiceTemplateInputStream, uri, "text/html", inputOptions, null);
}


public String getInvoiceTemplate(bool manualPay, RequestOptions inputOptions)
{
    String uri = Config.INVOICES + (manualPay ? "/manualPayTemplate" : "/template");
    return getResourceFile(uri, "text/html", inputOptions);
}


public void uploadInvoiceTranslation(String invoiceTranslationFilePath, String locale, RequestOptions inputOptions)
{
    String uri = Config.INVOICES + "/translation/" + locale;
    uploadFile(invoiceTranslationFilePath, uri, "text/plain", inputOptions, null);
}

public void uploadInvoiceTranslation(InputStream invoiceTranslationInputStream, String locale, RequestOptions inputOptions)
{
    String uri = Config.INVOICES + "/translation/" + locale;
    uploadFile(invoiceTranslationInputStream, uri, "text/plain", inputOptions, null);
}


public String getInvoiceTranslation(String locale, RequestOptions inputOptions)
{
    String uri = Config.INVOICES + "/translation/" + locale;
    return getResourceFile(uri, "text/plain", inputOptions);
}

public void uploadCatalogTranslation(String catalogTranslationFilePath, String locale, RequestOptions inputOptions)
{
    String uri = Config.INVOICES + "/catalogTranslation/" + locale;
    uploadFile(catalogTranslationFilePath, uri, "text/plain", inputOptions, null);
}

public void uploadCatalogTranslation(InputStream catalogTranslationInputStream, String locale, RequestOptions inputOptions)
{
    String uri = Config.INVOICES + "/catalogTranslation/" + locale;
    uploadFile(catalogTranslationInputStream, uri, "text/plain", inputOptions, null);
}


public String getCatalogTranslation(String locale, RequestOptions inputOptions)
{
    String uri = Config.INVOICES + "/catalogTranslation/" + locale;
    return getResourceFile(uri, "text/plain", inputOptions);
}

// Credits

public Credit getCredit(Guid creditId, RequestOptions inputOptions)
{
    return getCredit(creditId, AuditLevel.NONE, inputOptions);
}

public Credit getCredit(Guid creditId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.CREDITS_PATH + "/" + creditId;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Credit.class, requestOptions);
    }

  
public Credit createCredit(Credit credit, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(credit.getAccountId(), "Credt#accountId cannot be null");
    Preconditions.checkNotNull(credit.getCreditAmount(), "Credt#creditAmount cannot be null");

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

    return httpClient.doPost(Config.CREDITS_PATH, credit, Credit.class, requestOptions);
    }

   
public Payments searchPayments(String key, RequestOptions inputOptions)
{
    return searchPayments(key, 0L, 100L, inputOptions);
}

public Payments searchPayments(String key, long offset, long limit, RequestOptions inputOptions)
{
    return searchPayments(key, offset, limit, AuditLevel.NONE, inputOptions);
}


public Payments searchPayments(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.PAYMENTS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Payments.class, requestOptions);
    }

   

public InvoicePayments getInvoicePaymentsForAccount(Guid accountId, RequestOptions inputOptions)
{
    return getInvoicePaymentsForAccount(accountId, AuditLevel.NONE, inputOptions);
}


public InvoicePayments getInvoicePaymentsForAccount(Guid accountId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.INVOICE_PAYMENTS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, InvoicePayments.class, requestOptions);
    }

  

public InvoicePayments getInvoicePayment(Guid invoiceId, RequestOptions inputOptions)
{
    String uri = Config.INVOICES_PATH + "/" + invoiceId + "/" + Config.PAYMENTS;

    return httpClient.doGet(uri, InvoicePayments.class, inputOptions);
    }

  

public void payAllInvoices(Guid accountId, bool externalPayment, BigDecimal paymentAmount, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.INVOICE_PAYMENTS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_PAYMENT_EXTERNAL, String.valueOf(externalPayment));
    if (paymentAmount != null)
    {
        queryParams.Add("paymentAmount", String.valueOf(paymentAmount));
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doPost(uri, null, requestOptions);
}


public InvoicePayment createInvoicePayment(InvoicePayment payment, bool isExternal, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(payment.getAccountId(), "InvoiceItem#accountId cannot be null");
    Preconditions.checkNotNull(payment.getTargetInvoiceId(), "InvoiceItem#invoiceId cannot be null");
    Preconditions.checkNotNull(payment.getPurchasedAmount(), "InvoiceItem#amount cannot be null");

    String uri = Config.INVOICES_PATH + "/" + payment.getTargetInvoiceId() + "/" + Config.PAYMENTS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add("externalPayment", String.valueOf(isExternal));

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, payment, InvoicePayment.class, requestOptions);
    }

   
public Payments getPayments(RequestOptions inputOptions)
{
    return getPayments(0L, 100L, inputOptions);
}

public Payments getPayments(long offset, long limit, RequestOptions inputOptions)
{
    return getPayments(offset, limit, AuditLevel.NONE, inputOptions);
}


public Payments getPayments(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getPayments(offset, limit, null, ImmutableMap.< String, String > of(), auditLevel, inputOptions);
}


public Payments getPayments(long offset, long limit, @Nullable String pluginName, Map<String, String> pluginProperties, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.PAYMENTS_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    if (pluginName != null)
    {
        queryParams.Add(Config.QUERY_PAYMENT_PLUGIN_NAME, pluginName);
    }
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Payments.class, requestOptions);
    }

   

public Payment getPayment(Guid paymentId, RequestOptions inputOptions)
{
    return getPayment(paymentId, true, inputOptions);
}

public Payment getPayment(Guid paymentId, bool withPluginInfo, RequestOptions inputOptions)
{
    return getPayment(paymentId, withPluginInfo, AuditLevel.NONE, inputOptions);
}

public Payment getPayment(Guid paymentId, bool withPluginInfo, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getPayment(paymentId, withPluginInfo, ImmutableMap.< String, String > of(), auditLevel, inputOptions);
}


public Payment getPayment(Guid paymentId, bool withPluginInfo, Map<String, String> pluginProperties, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.PAYMENTS_PATH + "/" + paymentId;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Payment.class, requestOptions);
    }

public Payment getPaymentByExternalKey(String externalKey, RequestOptions inputOptions)
{
    return getPaymentByExternalKey(externalKey, true, inputOptions);
}

public Payment getPaymentByExternalKey(String externalKey, bool withPluginInfo, RequestOptions inputOptions)
{
    return getPaymentByExternalKey(externalKey, withPluginInfo, AuditLevel.NONE);
}

public Payment getPaymentByExternalKey(String externalKey, bool withPluginInfo, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getPaymentByExternalKey(externalKey, withPluginInfo, ImmutableMap.< String, String > of(), auditLevel, inputOptions);
}

public Payment getPaymentByExternalKey(String externalKey, bool withPluginInfo, Map<String, String> pluginProperties, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.PAYMENTS_PATH;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_EXTERNAL_KEY, externalKey);
    queryParams.Add(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Payment.class, requestOptions);
    }

public Payments getPaymentsForAccount(Guid accountId, RequestOptions inputOptions)
{
    return getPaymentsForAccount(accountId, AuditLevel.NONE, inputOptions);
}

public Payments getPaymentsForAccount(Guid accountId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENTS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Payments.class, requestOptions);
    }
    

public Payment createPayment(ComboPaymentTransaction comboPaymentTransaction, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    return this.createPayment(comboPaymentTransaction, null, pluginProperties, inputOptions);
}

public Payment createPayment(ComboPaymentTransaction comboPaymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    String uri = Config.PAYMENTS_PATH + "/" + Config.COMBO;

    Multimap<String, String> queryParams = HashMultimap.create(inputOptions.getQueryParams());
    if (controlPluginNames != null)
    {
        queryParams.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(queryParams)
                                                          .withFollowLocation(followLocation).build();
    return httpClient.doPost(uri, comboPaymentTransaction, Payment.class, requestOptions);
    }


public Payment createPayment(Guid accountId, PaymentTransaction paymentTransaction, RequestOptions inputOptions)
{
    return createPayment(accountId, null, paymentTransaction, null, ImmutableMap.< String, String > of(), inputOptions);
}

public Payment createPayment(Guid accountId, PaymentTransaction paymentTransaction, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    return createPayment(accountId, null, paymentTransaction, null, pluginProperties, inputOptions);
}



public Payment createPayment(Guid accountId, @Nullable Guid paymentMethodId, PaymentTransaction paymentTransaction, RequestOptions inputOptions)
{
    return createPayment(accountId, paymentMethodId, paymentTransaction, null, ImmutableMap.< String, String > of(), inputOptions);
}


public Payment createPayment(Guid accountId, @Nullable Guid paymentMethodId, PaymentTransaction paymentTransaction, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    return createPayment(accountId, paymentMethodId, paymentTransaction, null, pluginProperties, inputOptions);
}

public Payment createPayment(Guid accountId, @Nullable Guid paymentMethodId, PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(accountId, "accountId cannot be null");
    Preconditions.checkNotNull(paymentTransaction.getTransactionType(), "PaymentTransaction#transactionType cannot be null");
    Preconditions.checkArgument("AUTHORIZE".equals(paymentTransaction.getTransactionType()) ||
                                    "CREDIT".equals(paymentTransaction.getTransactionType()) ||
                                    "PURCHASE".equals(paymentTransaction.getTransactionType()),
                                    "Invalid paymentTransaction type " + paymentTransaction.getTransactionType()
                                   );
    Preconditions.checkNotNull(paymentTransaction.getAmount(), "PaymentTransaction#amount cannot be null");
    Preconditions.checkNotNull(paymentTransaction.getCurrency(), "PaymentTransaction#currency cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENTS;

    Multimap < String, String > params = HashMultimap.create(inputOptions.getQueryParams());
    if (paymentMethodId != null)
    {
            params.Add("paymentMethodId", paymentMethodId.toString());
    }
    if (controlPluginNames != null)
    {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }
    storePluginPropertiesAsParams(pluginProperties, params);

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();
    return httpClient.doPost(uri, paymentTransaction, Payment.class, requestOptions);
    }

  

public Payment completePayment(PaymentTransaction paymentTransaction, RequestOptions requestOptions)
{
    return completePayment(paymentTransaction, ImmutableMap.< String, String > of(), requestOptions);
}


public Payment completePayment(PaymentTransaction paymentTransaction, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    Preconditions.checkState(paymentTransaction.getPaymentId() != null || paymentTransaction.getPaymentExternalKey() != null, "PaymentTransaction#paymentId or PaymentTransaction#paymentExternalKey cannot be null");

    String uri = (paymentTransaction.getPaymentId() != null) ?
                           Config.PAYMENTS_PATH + "/" + paymentTransaction.getPaymentId() :
                           Config.PAYMENTS_PATH;

    Multimap < String, String > params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();

    return httpClient.doPut(uri, paymentTransaction, Payment.class, requestOptions);
    }

   

public Payment captureAuthorization(PaymentTransaction paymentTransaction, RequestOptions inputOptions)
{
    return captureAuthorization(paymentTransaction, null, ImmutableMap.< String, String > of(), inputOptions);
}


public Payment captureAuthorization(PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    Preconditions.checkState(paymentTransaction.getPaymentId() != null || paymentTransaction.getPaymentExternalKey() != null, "PaymentTransaction#paymentId or PaymentTransaction#paymentExternalKey cannot be null");
    Preconditions.checkNotNull(paymentTransaction.getAmount(), "PaymentTransaction#amount cannot be null");

    String uri = (paymentTransaction.getPaymentId() != null) ?
                           Config.PAYMENTS_PATH + "/" + paymentTransaction.getPaymentId() :
                           Config.PAYMENTS_PATH;

    Multimap < String, String > params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
    if (controlPluginNames != null)
    {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, paymentTransaction, Payment.class, requestOptions);
    }


public Payment refundPayment(PaymentTransaction paymentTransaction, RequestOptions inputOptions)
{
    return refundPayment(paymentTransaction, null, ImmutableMap.< String, String > of(), inputOptions);
}


public Payment refundPayment(PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    Preconditions.checkState(paymentTransaction.getPaymentId() != null || paymentTransaction.getPaymentExternalKey() != null, "PaymentTransaction#paymentId or PaymentTransaction#paymentExternalKey cannot be null");
    Preconditions.checkNotNull(paymentTransaction.getAmount(), "PaymentTransaction#amount cannot be null");

    String uri = (paymentTransaction.getPaymentId() != null) ?
                           Config.PAYMENTS_PATH + "/" + paymentTransaction.getPaymentId() + "/" + Config.REFUNDS :
                           Config.PAYMENTS_PATH + "/" + Config.REFUNDS;

    Multimap < String, String > params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
    if (controlPluginNames != null)
    {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, paymentTransaction, Payment.class, requestOptions);
    }
    
public Payment chargebackPayment(PaymentTransaction paymentTransaction, RequestOptions requestOptions)
{
    return chargebackPayment(paymentTransaction, null, ImmutableMap.< String, String > of(), requestOptions);
}


public Payment chargebackPayment(PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    Preconditions.checkState(paymentTransaction.getPaymentId() != null || paymentTransaction.getPaymentExternalKey() != null, "PaymentTransaction#paymentId or PaymentTransaction#paymentExternalKey cannot be null");
    Preconditions.checkNotNull(paymentTransaction.getAmount(), "PaymentTransaction#amount cannot be null");

    String uri = (paymentTransaction.getPaymentId() != null) ?
                           Config.PAYMENTS_PATH + "/" + paymentTransaction.getPaymentId() + "/" + Config.CHARGEBACKS :
                           Config.PAYMENTS_PATH + "/" + Config.CHARGEBACKS;

    Multimap < String, String > params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
    if (controlPluginNames != null)
    {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }
    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, paymentTransaction, Payment.class, requestOptions);
    }


public Payment voidPayment(Guid paymentId, String transactionExternalKey, RequestOptions inputOptions)
{
    return voidPayment(paymentId, null, transactionExternalKey, null, ImmutableMap.< String, String > of(), inputOptions);
}


public Payment voidPayment(Guid paymentId, String paymentExternalKey, String transactionExternalKey, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions)
{

    Preconditions.checkState(paymentId != null || paymentExternalKey != null, "PaymentTransaction#paymentId or PaymentTransaction#paymentExternalKey cannot be null");
    String uri = (paymentId != null) ?
                           Config.PAYMENTS_PATH + "/" + paymentId :
                           Config.PAYMENTS_PATH;

    PaymentTransaction paymentTransaction = new PaymentTransaction();
    if (paymentExternalKey != null)
    {
        paymentTransaction.setPaymentExternalKey(paymentExternalKey);
    }
    paymentTransaction.setTransactionExternalKey(transactionExternalKey);

    Multimap < String, String > params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
    if (controlPluginNames != null)
    {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                      .withQueryParams(params)
                                                      .withFollowLocation(followLocation).build();
    return httpClient.doDelete(uri, paymentTransaction, Payment.class, requestOptions);
    }

    // Hosted payment pages
   

public HostedPaymentPageFormDescriptor buildFormDescriptor(HostedPaymentPageFields fields, Guid kbAccountId, @Nullable Guid kbPaymentMethodId, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    return buildFormDescriptor(fields, kbAccountId, kbPaymentMethodId, null, pluginProperties, inputOptions);
}

public HostedPaymentPageFormDescriptor buildFormDescriptor(HostedPaymentPageFields fields, Guid kbAccountId, @Nullable Guid kbPaymentMethodId, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_GATEWAYS_PATH + "/" + Config.HOSTED + "/" + Config.FORM + "/" + kbAccountId;

    Multimap < String, String > params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
    if (controlPluginNames != null)
    {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }
    if (kbPaymentMethodId != null)
    {
            params.Add(Config.QUERY_PAYMENT_METHOD_ID, kbPaymentMethodId.toString());
    }

    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(false).build();

    return httpClient.doPost(uri, fields, HostedPaymentPageFormDescriptor.class, requestOptions);
    }

   

public HostedPaymentPageFormDescriptor buildFormDescriptor(ComboHostedPaymentPage comboHostedPaymentPage, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    return buildFormDescriptor(comboHostedPaymentPage, null, pluginProperties, inputOptions);
}


public HostedPaymentPageFormDescriptor buildFormDescriptor(ComboHostedPaymentPage comboHostedPaymentPage, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_GATEWAYS_PATH + "/" + Config.HOSTED + "/" + Config.FORM;

    Multimap < String, String > params = HashMultimap.create(inputOptions.getQueryParams());
    if (controlPluginNames != null)
    {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }
    storePluginPropertiesAsParams(pluginProperties, params);

    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(false).build();

    return httpClient.doPost(uri, comboHostedPaymentPage, HostedPaymentPageFormDescriptor.class, requestOptions);
    }


public Response processNotification(String notification, String pluginName, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_GATEWAYS_PATH + "/" + Config.NOTIFICATION + "/" + pluginName;

    Multimap < String, String > params = HashMultimap.< String, String > create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(params).build();

    return httpClient.doPost(uri, notification, requestOptions);
}


public InvoicePayment createInvoicePaymentRefund(InvoicePaymentTransaction refundTransaction, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(refundTransaction.getPaymentId(), "InvoicePaymentTransaction#paymentId cannot be null");

    // Specify isAdjusted for invoice adjustment and invoice item adjustment
    // Specify adjustments for invoice item adjustments only
    if (refundTransaction.getAdjustments() != null)
    {
        for (InvoiceItem invoiceItem : refundTransaction.getAdjustments())
        {
            Preconditions.checkNotNull(invoiceItem.getInvoiceItemId(), "InvoiceItem#invoiceItemId cannot be null");
        }
    }

    String uri = Config.INVOICE_PAYMENTS_PATH + "/" + refundTransaction.getPaymentId() + "/" + Config.REFUNDS;

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, refundTransaction, InvoicePayment.class, requestOptions);
    }

    // Chargebacks

   

public InvoicePayment createInvoicePaymentChargeback(InvoicePaymentTransaction chargebackTransaction, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(chargebackTransaction.getPaymentId(), "InvoicePaymentTransaction#paymentId cannot be null");

    String uri = Config.INVOICE_PAYMENTS_PATH + "/" + chargebackTransaction.getPaymentId() + "/" + Config.CHARGEBACKS;

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, chargebackTransaction, InvoicePayment.class, requestOptions);
    }

    // Payment methods

   

public PaymentMethods getPaymentMethods(RequestOptions inputOptions)
{
    return getPaymentMethods(0L, 100L, inputOptions);
}


public PaymentMethods getPaymentMethods(long offset, long limit, RequestOptions inputOptions)
{
    return getPaymentMethods(offset, limit, AuditLevel.NONE, inputOptions);
}

public PaymentMethods getPaymentMethods(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, PaymentMethods.class, requestOptions);
    }

   
public PaymentMethods searchPaymentMethods(String key, RequestOptions inputOptions)
{
    return searchPaymentMethods(key, 0L, 100L, inputOptions);
}


public PaymentMethods searchPaymentMethods(String key, long offset, long limit, RequestOptions inputOptions)
{
    return searchPaymentMethods(key, offset, limit, AuditLevel.NONE, inputOptions);
}


public PaymentMethods searchPaymentMethods(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, PaymentMethods.class, requestOptions);
    }

   

public PaymentMethod getPaymentMethod(Guid paymentMethodId, RequestOptions inputOptions)
{
    return getPaymentMethod(paymentMethodId, false, inputOptions);
}

public PaymentMethod getPaymentMethod(Guid paymentMethodId, bool withPluginInfo, RequestOptions inputOptions)
{
    return getPaymentMethod(paymentMethodId, withPluginInfo, AuditLevel.NONE, inputOptions);
}


public PaymentMethod getPaymentMethod(Guid paymentMethodId, bool withPluginInfo, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + paymentMethodId;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, PaymentMethod.class, requestOptions);
    }

  

public PaymentMethod getPaymentMethodByKey(String externalKey, RequestOptions inputOptions)
{
    return getPaymentMethodByKey(externalKey, false, inputOptions);
}

public PaymentMethod getPaymentMethodByKey(String externalKey, bool withPluginInfo, RequestOptions inputOptions)
{
    return getPaymentMethodByKey(externalKey, withPluginInfo, AuditLevel.NONE, inputOptions);
}


public PaymentMethod getPaymentMethodByKey(String externalKey, bool withPluginInfo, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_METHODS_PATH;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_EXTERNAL_KEY, externalKey);
    queryParams.Add(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, PaymentMethod.class, requestOptions);
    }


public PaymentMethods getPaymentMethodsForAccount(Guid accountId, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENT_METHODS;
    return httpClient.doGet(uri, PaymentMethods.class, inputOptions);
    }

   

public PaymentMethods getPaymentMethodsForAccount(Guid accountId, Map<String, String> pluginProperties, bool withPluginInfo, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENT_METHODS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, PaymentMethods.class, requestOptions);
    }

  
public PaymentMethods searchPaymentMethodsByKey(String key, RequestOptions inputOptions)
{
    return searchPaymentMethodsByKeyAndPlugin(key, null, inputOptions);
}


public PaymentMethods searchPaymentMethodsByKey(String key, bool withPluginInfo, RequestOptions inputOptions)
{
    return searchPaymentMethodsByKeyAndPlugin(key, withPluginInfo, null, AuditLevel.NONE, inputOptions);
}

public PaymentMethods searchPaymentMethodsByKeyAndPlugin(String key, @Nullable String pluginName, RequestOptions inputOptions)
{
    return searchPaymentMethodsByKeyAndPlugin(key, pluginName, AuditLevel.NONE, inputOptions);
}


public PaymentMethods searchPaymentMethodsByKeyAndPlugin(String key, @Nullable String pluginName, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return searchPaymentMethodsByKeyAndPlugin(key, pluginName != null, pluginName, auditLevel, inputOptions);
}


public PaymentMethods searchPaymentMethodsByKeyAndPlugin(String key, bool withPluginInfo, @Nullable String pluginName, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_PAYMENT_METHOD_PLUGIN_NAME, Strings.nullToEmpty(pluginName));
    queryParams.Add(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, PaymentMethods.class, requestOptions);
    }

    

public PaymentMethod createPaymentMethod(PaymentMethod paymentMethod, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(paymentMethod.getAccountId(), "PaymentMethod#accountId cannot be null");
    Preconditions.checkNotNull(paymentMethod.getPluginName(), "PaymentMethod#pluginName cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + paymentMethod.getAccountId() + "/" + Config.PAYMENT_METHODS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_PAYMENT_METHOD_IS_DEFAULT, paymentMethod.getIsDefault() ? "true" : "false");

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, paymentMethod, PaymentMethod.class, requestOptions);
    }

   

public void updateDefaultPaymentMethod(Guid accountId, Guid paymentMethodId, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENT_METHODS + "/" + paymentMethodId + "/" + Config.PAYMENT_METHODS_DEFAULT_PATH_POSTFIX;

    httpClient.doPut(uri, null, inputOptions);
}


public void deletePaymentMethod(Guid paymentMethodId, Boolean deleteDefault, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + paymentMethodId;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_DELETE_DEFAULT_PM_WITH_AUTO_PAY_OFF, deleteDefault.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doDelete(uri, requestOptions);
}

public void refreshPaymentMethods(Guid accountId, String pluginName, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENT_METHODS + "/refresh";

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    if (pluginName != null)
    {
        queryParams.Add(Config.QUERY_PAYMENT_METHOD_PLUGIN_NAME, pluginName);
    }
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doPost(uri, null, requestOptions);
}

public void refreshPaymentMethods(Guid accountId, Map<String, String> pluginProperties, RequestOptions inputOptions)
{
    refreshPaymentMethods(accountId, null, pluginProperties, inputOptions);
}

// Overdue


public void uploadXMLOverdueConfig(String overdueConfigFilePath, RequestOptions inputOptions)
{
    String uri = Config.OVERDUE_PATH;
    uploadFile(overdueConfigFilePath, uri, "application/xml", inputOptions, null);
}



public void uploadXMLOverdueConfig(InputStream overdueConfigInputStream, RequestOptions inputOptions)
{
    String uri = Config.OVERDUE_PATH;
    uploadFile(overdueConfigInputStream, uri, "application/xml", inputOptions, null);
}

public String getXMLOverdueConfig(RequestOptions inputOptions)
{
    String uri = Config.OVERDUE_PATH;
    return getResourceFile(uri, "application/xml", inputOptions);
}

public OverdueState getOverdueStateForAccount(Guid accountId, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.OVERDUE;

    return httpClient.doGet(uri, OverdueState.class, inputOptions);
    }

    // Tag definitions

  

public TagDefinitions getTagDefinitions(RequestOptions inputOptions)
{
    return httpClient.doGet(Config.TAG_DEFINITIONS_PATH, TagDefinitions.class, inputOptions);
    }

 
public TagDefinition getTagDefinition(Guid tagDefinitionId, RequestOptions inputOptions)
{
    String uri = Config.TAG_DEFINITIONS_PATH + "/" + tagDefinitionId;

    return httpClient.doGet(uri, TagDefinition.class, inputOptions);
    }

   
public TagDefinition createTagDefinition(TagDefinition tagDefinition, RequestOptions inputOptions)
{
    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

    return httpClient.doPost(Config.TAG_DEFINITIONS_PATH, tagDefinition, TagDefinition.class, requestOptions);
    }

   

public void deleteTagDefinition(Guid tagDefinitionId, RequestOptions inputOptions)
{
    String uri = Config.TAG_DEFINITIONS_PATH + "/" + tagDefinitionId;

    httpClient.doDelete(uri, inputOptions);
}

// Tags


public Tags getTags(RequestOptions inputOptions)
{
    return getTags(0L, 100L, inputOptions);
}

public Tags getTags(long offset, long limit, RequestOptions inputOptions)
{
    return getTags(offset, limit, AuditLevel.NONE, inputOptions);
}


public Tags getTags(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.TAGS_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Tags.class, requestOptions);
    }

   

public Tags searchTags(String key, RequestOptions inputOptions)
{
    return searchTags(key, 0L, 100L, inputOptions);
}


public Tags searchTags(String key, long offset, long limit, RequestOptions inputOptions)
{
    return searchTags(key, offset, limit, AuditLevel.NONE, inputOptions);
}


public Tags searchTags(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.TAGS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Tags.class, requestOptions);
    }

   

public Tags getAllAccountTags(Guid accountId, String objectType, RequestOptions inputOptions)
{
    return getAllAccountTags(accountId, objectType, AuditLevel.NONE, inputOptions);
}


public Tags getAllAccountTags(Guid accountId, @Nullable String objectType, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.ALL_TAGS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());
    if (objectType != null)
    {
        queryParams.Add(Config.QUERY_OBJECT_TYPE, objectType);
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();
    return httpClient.doGet(uri, Tags.class, requestOptions);
    }

   
public Tags getAccountTags(Guid accountId, RequestOptions inputOptions)
{
    return getAccountTags(accountId, AuditLevel.NONE, inputOptions);
}


public Tags getAccountTags(Guid accountId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getObjectTags(accountId, Config.ACCOUNTS_PATH, auditLevel, inputOptions);
}


public Tags createAccountTag(Guid accountId, Guid tagDefinitionId, RequestOptions inputOptions)
{
    return createObjectTag(accountId, Config.ACCOUNTS_PATH, tagDefinitionId, inputOptions);
}


public void deleteAccountTag(Guid accountId, Guid tagDefinitionId, RequestOptions inputOptions)
{
    deleteObjectTag(accountId, Config.ACCOUNTS_PATH, tagDefinitionId, inputOptions);
}


public Tags getBundleTags(Guid bundleId, RequestOptions inputOptions)
{
    return getBundleTags(bundleId, AuditLevel.NONE, inputOptions);
}


public Tags getBundleTags(Guid bundleId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getObjectTags(bundleId, Config.BUNDLES_PATH, auditLevel, inputOptions);
}

public Tags createBundleTag(Guid bundleId, Guid tagDefinitionId, RequestOptions inputOptions)
{
    return createObjectTag(bundleId, Config.BUNDLES_PATH, tagDefinitionId, inputOptions);
}


public void deleteBundleTag(Guid bundleId, Guid tagDefinitionId, RequestOptions inputOptions)
{
    deleteObjectTag(bundleId, Config.BUNDLES_PATH, tagDefinitionId, inputOptions);
}



public Tags getSubscriptionTags(Guid subscriptionId, RequestOptions inputOptions)
{
    return getSubscriptionTags(subscriptionId, AuditLevel.NONE, inputOptions);
}



public Tags getSubscriptionTags(Guid subscriptionId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getObjectTags(subscriptionId, Config.SUBSCRIPTIONS_PATH, auditLevel, inputOptions);
}


public Tags createSubscriptionTag(Guid subscriptionId, Guid tagDefinitionId, RequestOptions inputOptions)
{
    return createObjectTag(subscriptionId, Config.SUBSCRIPTIONS_PATH, tagDefinitionId, inputOptions);
}


public void deleteSubscriptionTag(Guid subscriptionId, Guid tagDefinitionId, RequestOptions inputOptions)
{
    deleteObjectTag(subscriptionId, Config.SUBSCRIPTIONS_PATH, tagDefinitionId, inputOptions);
}


public Tags getInvoiceTags(Guid invoiceId, RequestOptions inputOptions)
{
    return getInvoiceTags(invoiceId, AuditLevel.NONE, inputOptions);
}


public Tags getInvoiceTags(Guid invoiceId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getObjectTags(invoiceId, Config.INVOICES_PATH, auditLevel, inputOptions);
}


public Tags createInvoiceTag(Guid invoiceId, Guid tagDefinitionId, RequestOptions inputOptions)
{
    return createObjectTag(invoiceId, Config.INVOICES_PATH, tagDefinitionId, inputOptions);
}


public void deleteInvoiceTag(Guid invoiceId, Guid tagDefinitionId, RequestOptions inputOptions)
{
    deleteObjectTag(invoiceId, Config.INVOICES_PATH, tagDefinitionId, inputOptions);
}


public Tags getPaymentTags(Guid paymentId, RequestOptions inputOptions)
{
    return getPaymentTags(paymentId, AuditLevel.NONE, inputOptions);
}


public Tags getPaymentTags(Guid paymentId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    return getObjectTags(paymentId, Config.PAYMENTS_PATH, auditLevel, inputOptions);
}


public Tags createPaymentTag(Guid paymentId, Guid tagDefinitionId, RequestOptions inputOptions)
{
    return createObjectTag(paymentId, Config.PAYMENTS_PATH, tagDefinitionId, inputOptions);
}

public void deletePaymentTag(Guid paymentId, Guid tagDefinitionId, RequestOptions inputOptions)
{
    deleteObjectTag(paymentId, Config.PAYMENTS_PATH, tagDefinitionId, inputOptions);
}

private Tags getObjectTags(Guid objectId, String resourcePathPrefix, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = resourcePathPrefix + "/" + objectId + "/" + Config.TAGS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, Tags.class, requestOptions);
    }

    private Tags createObjectTag(Guid objectId, String resourcePathPrefix, Guid tagDefinitionId, RequestOptions inputOptions)
{
    String uri = resourcePathPrefix + "/" + objectId + "/" + Config.TAGS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_TAGS, tagDefinitionId.toString());

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, null, Tags.class, requestOptions);
    }

    private void deleteObjectTag(Guid objectId, String resourcePathPrefix, Guid tagDefinitionId, RequestOptions inputOptions)
{
    String uri = resourcePathPrefix + "/" + objectId + "/" + Config.TAGS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_TAGS, tagDefinitionId.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doDelete(uri, requestOptions);
}

// Custom fields


public CustomFields getCustomFields(RequestOptions inputOptions)
{
    return getCustomFields(0L, 100L, inputOptions);
}
public CustomFields getCustomFields(long offset, long limit, RequestOptions inputOptions)
{
    return getCustomFields(offset, limit, AuditLevel.NONE, inputOptions);
}


public CustomFields getCustomFields(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.CUSTOM_FIELDS_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, CustomFields.class, requestOptions);
    }

   

public CustomFields searchCustomFields(String key, RequestOptions inputOptions)
{
    return searchCustomFields(key, 0L, 100L, inputOptions);
}


public CustomFields searchCustomFields(String key, long offset, long limit, RequestOptions inputOptions)
{
    return searchCustomFields(key, offset, limit, AuditLevel.NONE, inputOptions);
}


public CustomFields searchCustomFields(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.CUSTOM_FIELDS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.Add(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, CustomFields.class, requestOptions);
    }

   
public CustomFields getAccountCustomFields(Guid accountId, RequestOptions inputOptions)
{
    return getAccountCustomFields(accountId, AuditLevel.NONE, inputOptions);
}


public CustomFields getAccountCustomFields(Guid accountId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.CUSTOM_FIELDS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, CustomFields.class, requestOptions);
    }

   

public CustomFields createAccountCustomField(Guid accountId, CustomField customField, RequestOptions inputOptions)
{
    return createAccountCustomFields(accountId, ImmutableList.< CustomField > of(customField), inputOptions);
}

public CustomFields createAccountCustomFields(Guid accountId, Iterable<CustomField> customFields, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.CUSTOM_FIELDS;

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, customFields, CustomFields.class, requestOptions);
    }

  
public void deleteAccountCustomField(Guid accountId, Guid customFieldId, RequestOptions inputOptions)
{
    deleteAccountCustomFields(accountId, ImmutableList.< Guid > of(customFieldId), inputOptions);
}


public void deleteAccountCustomFields(Guid accountId, RequestOptions inputOptions)
{
    deleteAccountCustomFields(accountId, null, inputOptions);
}


public void deleteAccountCustomFields(Guid accountId, @Nullable Iterable<Guid> customFieldIds, RequestOptions inputOptions)
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.CUSTOM_FIELDS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    if (customFieldIds != null)
    {
        queryParams.Add(Config.QUERY_CUSTOM_FIELDS, Joiner.on(",").join(customFieldIds));
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doDelete(uri, requestOptions);
}


public CustomFields getPaymentMethodCustomFields(Guid paymentMethodId, RequestOptions inputOptions)
{
    return getPaymentMethodCustomFields(paymentMethodId, AuditLevel.NONE, inputOptions);
}

public CustomFields getPaymentMethodCustomFields(Guid paymentMethodId, AuditLevel auditLevel, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + paymentMethodId + "/" + Config.CUSTOM_FIELDS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, CustomFields.class, requestOptions);
    }

   
public CustomFields createPaymentMethodCustomField(Guid paymentMethodId, CustomField customField, RequestOptions inputOptions)
{
    return createPaymentMethodCustomFields(paymentMethodId, ImmutableList.of(customField), inputOptions);
}


public CustomFields createPaymentMethodCustomFields(Guid paymentMethodId, Iterable<CustomField> customFields, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + paymentMethodId + "/" + Config.CUSTOM_FIELDS;

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, customFields, CustomFields.class, requestOptions);
    }

  
public void deletePaymentMethodCustomFields(Guid paymentMethodId, RequestOptions inputOptions)
{
    deletePaymentMethodCustomFields(paymentMethodId, null, inputOptions);
}

public void deletePaymentMethodCustomFields(Guid paymentMethodId, @Nullable Iterable<Guid> customFieldIds, RequestOptions inputOptions)
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + paymentMethodId + "/" + Config.CUSTOM_FIELDS;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    if (customFieldIds != null)
    {
        queryParams.Add(Config.QUERY_CUSTOM_FIELDS, Joiner.on(",").join(customFieldIds));
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doDelete(uri, requestOptions);
}

// Catalog


public List<PlanDetail> getAvailableAddons(String baseProductName, RequestOptions inputOptions)
{
    String uri = Config.CATALOG_PATH + "/availableAddons";

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add("baseProductName", baseProductName);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    return httpClient.doGet(uri, PlanDetails.class, requestOptions);
    }

    
public List<PlanDetail> getBasePlans(RequestOptions inputOptions)
{
    String uri = Config.CATALOG_PATH + "/availableBasePlans";

    return httpClient.doGet(uri, PlanDetails.class, inputOptions);
    }

   
public void uploadXMLCatalog(String catalogFilePath, RequestOptions inputOptions)
{
    String uri = Config.CATALOG_PATH;
    uploadFile(catalogFilePath, uri, CONTENT_TYPE_XML, inputOptions, null);
}



public void uploadXMLCatalog(InputStream catalogInputStream, RequestOptions inputOptions)
{
    String uri = Config.CATALOG_PATH;
    uploadFile(catalogInputStream, uri, CONTENT_TYPE_XML, inputOptions, null);
}


public Catalog getJSONCatalog(RequestOptions inputOptions)
{
    return this.getJSONCatalog(null, inputOptions);
}


public Catalog getJSONCatalog(DateTime requestedDate, RequestOptions inputOptions)
{
    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    if (requestedDate != null)
    {
        queryParams.Add(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    String uri = Config.CATALOG_PATH;
    return httpClient.doGet(uri, Catalog.class, requestOptions);
    }


public String getXMLCatalog(RequestOptions inputOptions)
{
    String uri = Config.CATALOG_PATH;
    return getResourceFile(uri, ACCEPT_XML, inputOptions);
}

// Tenants



public Tenant createTenant(Tenant tenant, RequestOptions inputOptions)
{
    Preconditions.checkNotNull(tenant.getApiKey(), "Tenant#apiKey cannot be null");
    Preconditions.checkNotNull(tenant.getApiSecret(), "Tenant#apiSecret cannot be null");

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

    return httpClient.doPost(Config.TENANTS_PATH, tenant, Tenant.class, requestOptions);
    }

   

public TenantKey registerCallbackNotificationForTenant(String callback, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.REGISTER_NOTIFICATION_CALLBACK;

    Multimap<String, String> queryParams = HashMultimap.< String, String> create(inputOptions.getQueryParams());
    queryParams.Add(Config.QUERY_NOTIFICATION_CALLBACK, callback);

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

    return httpClient.doPost(uri, null, TenantKey.class, requestOptions);
    }

   

public TenantKey getCallbackNotificationForTenant(RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.REGISTER_NOTIFICATION_CALLBACK;
    return httpClient.doGet(uri, TenantKey.class, inputOptions);
    }

   

public void unregisterCallbackNotificationForTenant(RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.REGISTER_NOTIFICATION_CALLBACK;

    httpClient.doDelete(uri, inputOptions);
}



public TenantKey registerPluginConfigurationForTenant(String pluginName, String pluginConfigFilePath, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_CONFIG + "/" + pluginName;
    return uploadFile(pluginConfigFilePath, uri, "text/plain", inputOptions, TenantKey.class);
    }

   

public TenantKey registerPluginConfigurationForTenant(String pluginName, InputStream pluginConfigInputStream, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_CONFIG + "/" + pluginName;
    return uploadFile(pluginConfigInputStream, uri, "text/plain", inputOptions, TenantKey.class);
    }

    

public TenantKey postPluginConfigurationPropertiesForTenant(String pluginName, String pluginConfigProperties, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_CONFIG + "/" + pluginName;

    RequestOptions options = inputOptions.extend()
                                                   .withFollowLocation(true)
                                                   .withHeader(KillBillHttpClient.HTTP_HEADER_CONTENT_TYPE, "text/plain")
                                                   .build();
    return httpClient.doPost(uri, pluginConfigProperties, TenantKey.class, options);
    }

   
public TenantKey getPluginConfigurationForTenant(String pluginName, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_CONFIG + "/" + pluginName;
    return httpClient.doGet(uri, TenantKey.class, inputOptions);
    }

   

public void unregisterPluginConfigurationForTenant(String pluginName, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_CONFIG + "/" + pluginName;
    httpClient.doDelete(uri, inputOptions);
}

public TenantKey registerPluginPaymentStateMachineConfigurationForTenant(String pluginName, String pluginPaymentStateMachineConfigFilePath, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG + "/" + pluginName;
    return uploadFile(pluginPaymentStateMachineConfigFilePath, uri, "text/plain", inputOptions, TenantKey.class);
    }

    public TenantKey registerPluginPaymentStateMachineConfigurationForTenant(String pluginName, InputStream pluginPaymentStateMachineConfigInputStream, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG + "/" + pluginName;
    return uploadFile(pluginPaymentStateMachineConfigInputStream, uri, "text/plain", inputOptions, TenantKey.class);
    }

    public TenantKey postPluginPaymentStateMachineConfigurationXMLForTenant(String pluginName, String pluginPaymentStateMachineConfigXML, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG + "/" + pluginName;

    RequestOptions options = inputOptions.extend()
                                                   .withFollowLocation(true)
                                                   .withHeader(KillBillHttpClient.HTTP_HEADER_CONTENT_TYPE, "text/plain")
                                                   .build();
    return httpClient.doPost(uri, pluginPaymentStateMachineConfigXML, TenantKey.class, options);
    }

    public TenantKey getPluginPaymentStateMachineConfigurationForTenant(String pluginName, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG + "/" + pluginName;
    return httpClient.doGet(uri, TenantKey.class, inputOptions);
    }

    public void unregisterPluginPaymentStateMachineConfigurationForTenant(String pluginName, RequestOptions inputOptions)
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG + "/" + pluginName;
    httpClient.doDelete(uri, inputOptions);
}

public Permissions getPermissions(RequestOptions inputOptions)
{
    return httpClient.doGet(Config.SECURITY_PATH + "/permissions", Permissions.class, inputOptions);
    }

   

public Response addUserRoles(UserRoles userRoles, RequestOptions inputOptions)
{
    return httpClient.doPost(Config.SECURITY_PATH + "/users", userRoles, inputOptions);
}


public Response updateUserPassword(String username, String newPassword, RequestOptions inputOptions)
{
    String uri = Config.SECURITY_PATH + "/users/" + username + "/password";
    UserRoles userRoles = new UserRoles(username, newPassword, ImmutableList.< String > of());
    return httpClient.doPut(uri, userRoles, inputOptions);
}



public Response updateUserRoles(String username, List<String> newRoles, RequestOptions inputOptions)
{
    String uri = Config.SECURITY_PATH + "/users/" + username + "/roles";
    UserRoles userRoles = new UserRoles(username, null, newRoles);
    return httpClient.doPut(uri, userRoles, inputOptions);
}


public Response invalidateUser(String username, RequestOptions inputOptions)
{
    String uri = Config.SECURITY_PATH + "/users/" + username;
    return httpClient.doDelete(uri, inputOptions);
}


public Response addRoleDefinition(RoleDefinition roleDefinition, RequestOptions inputOptions)
{
    return httpClient.doPost(Config.SECURITY_PATH + "/roles", roleDefinition, inputOptions);
}

// Plugin endpoints


public Response pluginGET(String uri, RequestOptions inputOptions) throws Exception
{
        return httpClient.doGet(Config.PLUGINS_PATH + "/" + uri, inputOptions);
}

public Response pluginHEAD(String uri, RequestOptions inputOptions) throws Exception
{
        return httpClient.doHead(Config.PLUGINS_PATH + "/" + uri, inputOptions);
}

public Response pluginPOST(String uri, @Nullable String body, RequestOptions inputOptions) throws Exception
{
        return httpClient.doPost(Config.PLUGINS_PATH + "/" + uri, body, inputOptions);
}

public Response pluginPUT(String uri, @Nullable String body, RequestOptions inputOptions) throws Exception
{
        return httpClient.doPut(Config.PLUGINS_PATH + "/" + uri, body, inputOptions);
}

public Response pluginDELETE(String uri, RequestOptions inputOptions) throws Exception
{
        return httpClient.doDelete(Config.PLUGINS_PATH + "/" + uri, inputOptions);
}

public Response pluginOPTIONS(String uri, RequestOptions inputOptions) throws Exception
{
        return httpClient.doOptions(Config.PLUGINS_PATH + "/" + uri, inputOptions);
}

// Utilities

private String getResourceFile(String uri, String contentType, RequestOptions inputOptions)
{
    RequestOptions requestOptions = inputOptions.extend().withHeader(KillBillHttpClient.HTTP_HEADER_ACCEPT, contentType).build();
    Response response = httpClient.doGet(uri, requestOptions);
    try
    {
        return response.getResponseBody("UTF-8");
    }
    catch (IOException e)
    {
        throw new KillBillClientException(e);
    }
}

private <ReturnType> ReturnType uploadFile(String fileToUpload, String uri, String contentType, RequestOptions inputOptions, Class<ReturnType> followUpClass)
{
    Preconditions.checkNotNull(fileToUpload, "fileToUpload cannot be null");
    File catalogFile = new File(fileToUpload);
    Preconditions.checkArgument(catalogFile.exists() && catalogFile.isFile() && catalogFile.canRead(), "file to upload needs to be a valid file");
    try
    {
        String body = Files.toString(catalogFile, Charset.forName("UTF-8"));
        return doUploadFile(body, uri, contentType, inputOptions, followUpClass);
    }
    catch (IOException e)
    {
        throw new KillBillClientException(e);
    }
}

private <ReturnType> ReturnType uploadFile(InputStream fileToUpload, String uri, String contentType, RequestOptions inputOptions, Class<ReturnType> followUpClass)
{
    Preconditions.checkNotNull(fileToUpload, "fileToUpload cannot be null");
    try
    {
        Readable reader = new InputStreamReader(fileToUpload, Charset.forName("UTF-8"));
        String body = CharStreams.toString(reader);
        return doUploadFile(body, uri, contentType, inputOptions, followUpClass);
    }
    catch (IOException e)
    {
        throw new KillBillClientException(e);
    }
}

private <ReturnType> ReturnType doUploadFile(String body, String uri, String contentType, RequestOptions inputOptions, Class<ReturnType> followUpClass)
{
    RequestOptionsBuilder requestOptionsBuilder = inputOptions.extend().withHeader(KillBillHttpClient.HTTP_HEADER_CONTENT_TYPE, contentType);

    if (followUpClass != null)
    {
        Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
        RequestOptions requestOptions = requestOptionsBuilder.withFollowLocation(followLocation).build();
        return httpClient.doPost(uri, body, followUpClass, requestOptions);
    }
    else
    {
        RequestOptions requestOptions = requestOptionsBuilder.build();
        httpClient.doPost(uri, body, requestOptions);
        return null;
    }
}

private void storePluginPropertiesAsParams(Map<String, String> pluginProperties, Multimap<String, String> params)
{
    for (String key : pluginProperties.keySet())
    {
            params.Add(Config.QUERY_PLUGIN_PROPERTY, String.format("%s=%s", UTF8UrlEncoder.encode(key), UTF8UrlEncoder.encode(pluginProperties.get(key))));
    }
}
    }
}
