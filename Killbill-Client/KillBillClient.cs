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

            Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
            queryParams.Add(Config.QUERY_SEARCH_OFFSET, offset.ToString());
            queryParams.Add(Config.QUERY_SEARCH_LIMIT, limit.ToString());
            queryParams.Add(Config.QUERY_AUDIT, auditLevel.ToString());

            
            RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Accounts.class, requestOptions);
    }
    /*
    public Account getAccount(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
    {
        return getAccount(accountId, false, false, inputOptions);
    }

    public Account getAccount(UUID accountId, boolean withBalance, boolean withCBA, RequestOptions inputOptions) throws KillBillClientException
    {
        String uri = Config.ACCOUNTS_PATH + "/" + accountId;

        Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
        queryParams.put(Config.QUERY_ACCOUNT_WITH_BALANCE, withBalance ? "true" : "false");
        queryParams.put(Config.QUERY_ACCOUNT_WITH_BALANCE_AND_CBA, withCBA ? "true" : "false");

        RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Account.class, requestOptions);
    }

public Account getAccount(String externalKey, RequestOptions inputOptions) throws KillBillClientException
{
        return getAccount(externalKey, false, false, inputOptions);
}

public Account getAccount(String externalKey, boolean withBalance, boolean withCBA, RequestOptions inputOptions) throws KillBillClientException
{
    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_EXTERNAL_KEY, externalKey);
    queryParams.put(Config.QUERY_ACCOUNT_WITH_BALANCE, withBalance ? "true" : "false");
    queryParams.put(Config.QUERY_ACCOUNT_WITH_BALANCE_AND_CBA, withCBA ? "true" : "false");

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(Config.ACCOUNTS_PATH, Account.class, requestOptions);
    }

public Accounts searchAccounts(String key, RequestOptions inputOptions) throws KillBillClientException
{
        return searchAccounts(key, 0L, 100L, inputOptions);
}

public Accounts searchAccounts(String key, long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return searchAccounts(key, offset, limit, AuditLevel.NONE, RequestOptions.empty());
}

public Accounts searchAccounts(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Accounts.class, requestOptions);
    }

public AccountTimeline getAccountTimeline(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
        return getAccountTimeline(accountId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public AccountTimeline getAccountTimeline(UUID accountId, AuditLevel auditLevel) throws KillBillClientException
{
        return getAccountTimeline(accountId, auditLevel, RequestOptions.empty());
}

public AccountTimeline getAccountTimeline(UUID accountId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.TIMELINE;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, AccountTimeline.class, requestOptions);
    }

    @Deprecated
    public Account createAccount(Account account, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createAccount(account, RequestOptions.builder()
                                                    .withCreatedBy(createdBy)
                                                    .withReason(reason)
                                                    .withComment(comment).build());
}

public Account createAccount(Account account, RequestOptions inputOptions) throws KillBillClientException
{
    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();
        return httpClient.doPost(Config.ACCOUNTS_PATH, account, Account.class, requestOptions);
    }

    @Deprecated
    public Account updateAccount(Account account, String createdBy, String reason, String comment) throws KillBillClientException
{
        return updateAccount(account, RequestOptions.builder()
                                                    .withCreatedBy(createdBy)
                                                    .withReason(reason)
                                                    .withComment(comment).build());
}

public Account updateAccount(Account account, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(account.getAccountId(), "Account#accountId cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + account.getAccountId();

        return httpClient.doPut(uri, account, Account.class, inputOptions);
    }

    @Deprecated
    public AccountEmails getEmailsForAccount(UUID accountId) throws KillBillClientException
{
        return getEmailsForAccount(accountId, RequestOptions.empty());
}

public AccountEmails getEmailsForAccount(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.EMAILS;

        return httpClient.doGet(uri, AccountEmails.class, inputOptions);
    }

    @Deprecated
    public void addEmailToAccount(AccountEmail email, String createdBy, String reason, String comment) throws KillBillClientException
{
    addEmailToAccount(email, RequestOptions.builder()
                                               .withCreatedBy(createdBy)
                                               .withReason(reason)
                                               .withComment(comment).build());
}

public void addEmailToAccount(AccountEmail email, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(email.getAccountId(), "AccountEmail#accountId cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + email.getAccountId() + "/" + Config.EMAILS;

    httpClient.doPost(uri, email, inputOptions);
}

@Deprecated
    public void removeEmailFromAccount(AccountEmail email, String createdBy, String reason, String comment) throws KillBillClientException
{
    removeEmailFromAccount(email, RequestOptions.builder()
                                                    .withCreatedBy(createdBy)
                                                    .withReason(reason)
                                                    .withComment(comment).build());
}

public void removeEmailFromAccount(AccountEmail email, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(email.getAccountId(), "AccountEmail#accountId cannot be null");
    Preconditions.checkNotNull(email.getEmail(), "AccountEmail#email cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + email.getAccountId() + "/" + Config.EMAILS + "/" + UTF8UrlEncoder.encode(email.getEmail());

    httpClient.doDelete(uri, inputOptions);
}

@Deprecated
    public InvoiceEmail getEmailNotificationsForAccount(UUID accountId) throws KillBillClientException
{
        return getEmailNotificationsForAccount(accountId, RequestOptions.empty());
}

public InvoiceEmail getEmailNotificationsForAccount(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.EMAIL_NOTIFICATIONS;

        return httpClient.doGet(uri, InvoiceEmail.class, inputOptions);
    }

    @Deprecated
    public void updateEmailNotificationsForAccount(InvoiceEmail invoiceEmail, String createdBy, String reason, String comment) throws KillBillClientException
{
    updateEmailNotificationsForAccount(invoiceEmail, RequestOptions.builder()
                                                                       .withCreatedBy(createdBy)
                                                                       .withReason(reason)
                                                                       .withComment(comment).build());
}

public void updateEmailNotificationsForAccount(InvoiceEmail invoiceEmail, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(invoiceEmail.getAccountId(), "InvoiceEmail#accountId cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + invoiceEmail.getAccountId() + "/" + Config.EMAIL_NOTIFICATIONS;

    httpClient.doPut(uri, invoiceEmail, inputOptions);
}

// Bundles

@Deprecated
    public Bundle getBundle(UUID bundleId) throws KillBillClientException
{
        return getBundle(bundleId, RequestOptions.empty());
}

public Bundle getBundle(UUID bundleId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.BUNDLES_PATH + "/" + bundleId;

        return httpClient.doGet(uri, Bundle.class, inputOptions);
    }

    @Deprecated
    public Bundle getBundle(String externalKey) throws KillBillClientException
{
        return getBundle(externalKey, RequestOptions.empty());
}

public Bundle getBundle(String externalKey, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.BUNDLES_PATH;

    Multimap<String, String> queryParams = HashMultimap.create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_EXTERNAL_KEY, externalKey);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Bundle.class, requestOptions);
    }

    @Deprecated
    public Bundles getAccountBundles(UUID accountId) throws KillBillClientException
{
        return getAccountBundles(accountId, RequestOptions.empty());
}

public Bundles getAccountBundles(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.BUNDLES;

        return httpClient.doGet(uri, Bundles.class, inputOptions);
    }

    @Deprecated
    public Bundles getAccountBundles(UUID accountId, String externalKey) throws KillBillClientException
{
        return getAccountBundles(accountId, externalKey, RequestOptions.empty());
}

public Bundles getAccountBundles(UUID accountId, String externalKey, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.BUNDLES;

    Multimap<String, String> queryParams = HashMultimap.create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_EXTERNAL_KEY, externalKey);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Bundles.class, requestOptions);
    }

    @Deprecated
    public Bundles getBundles() throws KillBillClientException
{
        return getBundles(RequestOptions.empty());
}

public Bundles getBundles(RequestOptions inputOptions) throws KillBillClientException
{
        return getBundles(0L, 100L, inputOptions);
}

@Deprecated
    public Bundles getBundles(long offset, long limit) throws KillBillClientException
{
        return getBundles(offset, limit, RequestOptions.empty());
}

public Bundles getBundles(long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return getBundles(offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Bundles getBundles(long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return getBundles(offset, limit, auditLevel, RequestOptions.empty());
}

public Bundles getBundles(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.BUNDLES_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Bundles.class, requestOptions);
    }

    @Deprecated
    public Bundles searchBundles(String key) throws KillBillClientException
{
        return searchBundles(key, RequestOptions.empty());
}

public Bundles searchBundles(String key, RequestOptions inputOptions) throws KillBillClientException
{
        return searchBundles(key, 0L, 100L, inputOptions);
}

@Deprecated
    public Bundles searchBundles(String key, long offset, long limit) throws KillBillClientException
{
        return searchBundles(key, offset, limit, RequestOptions.empty());
}

public Bundles searchBundles(String key, long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return searchBundles(key, offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Bundles searchBundles(String key, long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return searchBundles(key, offset, limit, auditLevel, RequestOptions.empty());
}

public Bundles searchBundles(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.BUNDLES_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Bundles.class, requestOptions);
    }

    @Deprecated
    public Bundle transferBundle(Bundle bundle, String createdBy, String reason, String comment) throws KillBillClientException
{
        return transferBundle(bundle, RequestOptions.builder()
                                                    .withCreatedBy(createdBy)
                                                    .withReason(reason)
                                                    .withComment(comment).build());
}

public Bundle transferBundle(Bundle bundle, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(bundle.getBundleId(), "Bundle#bundleId cannot be null");
    Preconditions.checkNotNull(bundle.getAccountId(), "Bundle#accountId cannot be null");

    String uri = Config.BUNDLES_PATH + "/" + bundle.getBundleId();

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

        return httpClient.doPut(uri, bundle, Bundle.class, requestOptions);
    }

    @Deprecated
    public void setBlockingState(UUID bundleId, BlockingState blockingState, String createdBy, String reason, String comment) throws KillBillClientException
{
    setBlockingState(bundleId, blockingState, RequestOptions.builder()
                                                                .withCreatedBy(createdBy)
                                                                .withReason(reason)
                                                                .withComment(comment).build());
}

public void setBlockingState(UUID bundleId, BlockingState blockingState, RequestOptions inputOptions) throws KillBillClientException
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

@Deprecated
    public Subscription getSubscription(UUID subscriptionId) throws KillBillClientException
{
        return getSubscription(subscriptionId, RequestOptions.empty());
}

public Subscription getSubscription(UUID subscriptionId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.SUBSCRIPTIONS_PATH + "/" + subscriptionId;

        return httpClient.doGet(uri, Subscription.class, inputOptions);
    }

    @Deprecated
    public Subscription createSubscription(Subscription subscription, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createSubscription(subscription, RequestOptions.builder()
                                                              .withCreatedBy(createdBy)
                                                              .withReason(reason)
                                                              .withComment(comment).build());
}

public Subscription createSubscription(Subscription subscription, RequestOptions inputOptions) throws KillBillClientException
{
        return createSubscription(subscription, -1, inputOptions);
}

@Deprecated
    public Subscription createSubscription(Subscription subscription, int timeoutSec, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createSubscription(subscription, timeoutSec, RequestOptions.builder()
                                                                          .withCreatedBy(createdBy)
                                                                          .withReason(reason)
                                                                          .withComment(comment).build());
}

public Subscription createSubscription(Subscription subscription, int timeoutSec, RequestOptions inputOptions) throws KillBillClientException
{
        return createSubscription(subscription, null, timeoutSec, inputOptions);
}

@Deprecated
    public Subscription createSubscription(Subscription subscription, DateTime requestedDate, int timeoutSec, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createSubscription(subscription, requestedDate, timeoutSec, RequestOptions.builder()
                                                                                         .withCreatedBy(createdBy)
                                                                                         .withReason(reason)
                                                                                         .withComment(comment).build());
}

public Subscription createSubscription(Subscription subscription, DateTime requestedDate, int timeoutSec, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(subscription.getAccountId(), "Subscription#accountId cannot be null");
    Preconditions.checkNotNull(subscription.getProductName(), "Subscription#productName cannot be null");
    Preconditions.checkNotNull(subscription.getProductCategory(), "Subscription#productCategory cannot be null");
    Preconditions.checkNotNull(subscription.getBillingPeriod(), "Subscription#billingPeriod cannot be null");
    Preconditions.checkNotNull(subscription.getPriceList(), "Subscription#priceList cannot be null");
        if (subscription.getProductCategory() == ProductCategory.BASE) {
        Preconditions.checkNotNull(subscription.getAccountId(), "Account#accountId cannot be null");
    }

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_CALL_COMPLETION, timeoutSec > 0 ? "true" : "false");
    queryParams.put(Config.QUERY_CALL_TIMEOUT, String.valueOf(timeoutSec));
        if (requestedDate != null) {
        queryParams.put(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    }

    int httpTimeout = Math.max(DEFAULT_HTTP_TIMEOUT_SEC, timeoutSec);

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

        return httpClient.doPost(Config.SUBSCRIPTIONS_PATH, subscription, Subscription.class, requestOptions, httpTimeout);
    }

    @Deprecated
    public Bundle createSubscriptionWithAddOns(Iterable<Subscription> subscriptions, DateTime requestedDate, int timeoutSec, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createSubscriptionWithAddOns(subscriptions, requestedDate, timeoutSec, RequestOptions.builder()
                                                                                                    .withCreatedBy(createdBy)
                                                                                                    .withReason(reason)
                                                                                                    .withComment(comment).build());
}

public Bundle createSubscriptionWithAddOns(Iterable<Subscription> subscriptions, DateTime requestedDate, int timeoutSec, RequestOptions inputOptions) throws KillBillClientException
{
        for (Subscription subscription : subscriptions) {
        Preconditions.checkNotNull(subscription.getProductName(), "Subscription#productName cannot be null");
        Preconditions.checkNotNull(subscription.getProductCategory(), "Subscription#productCategory cannot be null");
        Preconditions.checkNotNull(subscription.getBillingPeriod(), "Subscription#billingPeriod cannot be null");
        Preconditions.checkNotNull(subscription.getPriceList(), "Subscription#priceList cannot be null");
        if (subscription.getProductCategory() == ProductCategory.BASE)
        {
            Preconditions.checkNotNull(subscription.getAccountId(), "Account#accountId cannot be null for base subscription");
        }
    }

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_CALL_COMPLETION, timeoutSec > 0 ? "true" : "false");
    queryParams.put(Config.QUERY_CALL_TIMEOUT, String.valueOf(timeoutSec));
        if (requestedDate != null) {
        queryParams.put(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    }

    int httpTimeout = Math.max(DEFAULT_HTTP_TIMEOUT_SEC, timeoutSec);

    String uri = Config.SUBSCRIPTIONS_PATH + "/createEntitlementWithAddOns";

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, subscriptions, Bundle.class, requestOptions, httpTimeout);
    }

    @Deprecated
    public Subscription updateSubscription(Subscription subscription, int timeoutSec, String createdBy, String reason, String comment) throws KillBillClientException
{
        return updateSubscription(subscription, timeoutSec, RequestOptions.builder()
                                                                          .withCreatedBy(createdBy)
                                                                          .withReason(reason)
                                                                          .withComment(comment).build());
}

public Subscription updateSubscription(Subscription subscription, int timeoutSec, RequestOptions inputOptions) throws KillBillClientException
{
        return updateSubscription(subscription, null, timeoutSec, inputOptions);
}

@Deprecated
    public Subscription updateSubscription(Subscription subscription, @Nullable BillingActionPolicy billingPolicy, int timeoutSec, String createdBy, String reason, String comment) throws KillBillClientException
{
        return updateSubscription(subscription, billingPolicy, timeoutSec, RequestOptions.builder()
                                                                                         .withCreatedBy(createdBy)
                                                                                         .withReason(reason)
                                                                                         .withComment(comment).build());
}

public Subscription updateSubscription(Subscription subscription, @Nullable BillingActionPolicy billingPolicy, int timeoutSec, RequestOptions inputOptions) throws KillBillClientException
{
        return updateSubscription(subscription, null, billingPolicy, timeoutSec, inputOptions);
}

@Deprecated
    public Subscription updateSubscription(Subscription subscription, @Nullable DateTime requestedDate, @Nullable BillingActionPolicy billingPolicy, int timeoutSec, String createdBy, String reason, String comment) throws KillBillClientException
{
        return updateSubscription(subscription, requestedDate, billingPolicy, timeoutSec, RequestOptions.builder()
                                                                                                        .withCreatedBy(createdBy)
                                                                                                        .withReason(reason)
                                                                                                        .withComment(comment).build());
}

public Subscription updateSubscription(Subscription subscription, @Nullable DateTime requestedDate, @Nullable BillingActionPolicy billingPolicy, int timeoutSec, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(subscription.getSubscriptionId(), "Subscription#subscriptionId cannot be null");
    Preconditions.checkNotNull(subscription.getProductName(), "Subscription#productName cannot be null");
    Preconditions.checkNotNull(subscription.getBillingPeriod(), "Subscription#billingPeriod cannot be null");
    Preconditions.checkNotNull(subscription.getPriceList(), "Subscription#priceList cannot be null");

    String uri = Config.SUBSCRIPTIONS_PATH + "/" + subscription.getSubscriptionId();

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_CALL_COMPLETION, timeoutSec > 0 ? "true" : "false");
    queryParams.put(Config.QUERY_CALL_TIMEOUT, String.valueOf(timeoutSec));
        if (requestedDate != null) {
        queryParams.put(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    }
        if (billingPolicy != null) {
        queryParams.put(Config.QUERY_BILLING_POLICY, billingPolicy.toString());
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doPut(uri, subscription, Subscription.class, inputOptions);
    }

    @Deprecated
    public void cancelSubscription(UUID subscriptionId, String createdBy, String reason, String comment) throws KillBillClientException
{
    cancelSubscription(subscriptionId, -1, RequestOptions.builder()
                                                             .withCreatedBy(createdBy)
                                                             .withReason(reason)
                                                             .withComment(comment).build());
}

public void cancelSubscription(UUID subscriptionId, RequestOptions inputOptions) throws KillBillClientException
{
    cancelSubscription(subscriptionId, -1, inputOptions);
}

@Deprecated
    public void cancelSubscription(UUID subscriptionId, int timeoutSec, String createdBy, String reason, String comment) throws KillBillClientException
{
    cancelSubscription(subscriptionId, timeoutSec, RequestOptions.builder()
                                                                     .withCreatedBy(createdBy)
                                                                     .withReason(reason)
                                                                     .withComment(comment).build());
}

public void cancelSubscription(UUID subscriptionId, int timeoutSec, RequestOptions inputOptions) throws KillBillClientException
{
    cancelSubscription(subscriptionId, null, null, timeoutSec, inputOptions);
}

@Deprecated
    public void cancelSubscription(UUID subscriptionId, @Nullable EntitlementActionPolicy entitlementPolicy, @Nullable BillingActionPolicy billingPolicy,
                                   int timeoutSec, String createdBy, String reason, String comment) throws KillBillClientException
{
    cancelSubscription(subscriptionId, entitlementPolicy, billingPolicy, timeoutSec, RequestOptions.builder()
                                                                                                       .withCreatedBy(createdBy)
                                                                                                       .withReason(reason)
                                                                                                       .withComment(comment).build());
}

public void cancelSubscription(UUID subscriptionId, @Nullable EntitlementActionPolicy entitlementPolicy, @Nullable BillingActionPolicy billingPolicy,
                               int timeoutSec, RequestOptions inputOptions) throws KillBillClientException
{
    cancelSubscription(subscriptionId, null, entitlementPolicy, billingPolicy, timeoutSec, inputOptions);
}

@Deprecated
    public void cancelSubscription(UUID subscriptionId, @Nullable DateTime requestedDate, @Nullable EntitlementActionPolicy entitlementPolicy, @Nullable BillingActionPolicy billingPolicy,
                                   int timeoutSec, String createdBy, String reason, String comment) throws KillBillClientException
{
    cancelSubscription(subscriptionId, requestedDate, entitlementPolicy, billingPolicy, timeoutSec, RequestOptions.builder()
                                                                                                                      .withCreatedBy(createdBy)
                                                                                                                      .withReason(reason)
                                                                                                                      .withComment(comment).build());
}

public void cancelSubscription(UUID subscriptionId, @Nullable DateTime requestedDate, @Nullable EntitlementActionPolicy entitlementPolicy, @Nullable BillingActionPolicy billingPolicy,
                               int timeoutSec, RequestOptions inputOptions) throws KillBillClientException
{
    cancelSubscription(subscriptionId, requestedDate, null, entitlementPolicy, billingPolicy, timeoutSec, inputOptions);
}

@Deprecated
    public void cancelSubscription(UUID subscriptionId, @Nullable DateTime requestedDate, @Nullable Boolean useRequestedDateForBilling, @Nullable EntitlementActionPolicy entitlementPolicy,
                                   @Nullable BillingActionPolicy billingPolicy, int timeoutSec, String createdBy, String reason, String comment) throws KillBillClientException
{
    cancelSubscription(subscriptionId, requestedDate, useRequestedDateForBilling, entitlementPolicy, billingPolicy, timeoutSec, RequestOptions.builder()
                                                                                                                                                  .withCreatedBy(createdBy)
                                                                                                                                                  .withReason(reason)
                                                                                                                                                  .withComment(comment).build());
}

public void cancelSubscription(UUID subscriptionId, @Nullable DateTime requestedDate, @Nullable Boolean useRequestedDateForBilling, @Nullable EntitlementActionPolicy entitlementPolicy,
                               @Nullable BillingActionPolicy billingPolicy, int timeoutSec, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.SUBSCRIPTIONS_PATH + "/" + subscriptionId;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_CALL_COMPLETION, timeoutSec > 0 ? "true" : "false");
    queryParams.put(Config.QUERY_CALL_TIMEOUT, String.valueOf(timeoutSec));
        if (requestedDate != null) {
        queryParams.put(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    }
        if (entitlementPolicy != null) {
        queryParams.put(Config.QUERY_ENTITLEMENT_POLICY, entitlementPolicy.toString());
    }
        if (billingPolicy != null) {
        queryParams.put(Config.QUERY_BILLING_POLICY, billingPolicy.toString());
    }
        if (useRequestedDateForBilling != null) {
        queryParams.put(Config.QUERY_USE_REQUESTED_DATE_FOR_BILLING, useRequestedDateForBilling.toString());
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doDelete(uri, requestOptions);
}

@Deprecated
    public void uncancelSubscription(UUID subscriptionId, String createdBy, String reason, String comment) throws KillBillClientException
{
    uncancelSubscription(subscriptionId, RequestOptions.builder()
                                                           .withCreatedBy(createdBy)
                                                           .withReason(reason)
                                                           .withComment(comment).build());
}

public void uncancelSubscription(UUID subscriptionId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.SUBSCRIPTIONS_PATH + "/" + subscriptionId + "/uncancel";

    httpClient.doPut(uri, null, inputOptions);
}

@Deprecated
    public void createSubscriptionUsageRecord(SubscriptionUsageRecord subscriptionUsageRecord, String createdBy, String reason, String comment) throws KillBillClientException
{
    createSubscriptionUsageRecord(subscriptionUsageRecord, RequestOptions.builder()
                                                                             .withCreatedBy(createdBy)
                                                                             .withReason(reason)
                                                                             .withComment(comment).build());
}

public void createSubscriptionUsageRecord(SubscriptionUsageRecord subscriptionUsageRecord, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(subscriptionUsageRecord.getSubscriptionId(), "SubscriptionUsageRecord#subscriptionId cannot be null");
    Preconditions.checkNotNull(subscriptionUsageRecord.getUnitUsageRecords(), "SubscriptionUsageRecord#unitUsageRecords cannot be null");
    Preconditions.checkArgument(!subscriptionUsageRecord.getUnitUsageRecords().isEmpty(), "SubscriptionUsageRecord#unitUsageRecords cannot be empty");

    String uri = Config.USAGES_PATH;

    httpClient.doPost(uri, subscriptionUsageRecord, inputOptions);
}

@Deprecated
    public RolledUpUsage getRolledUpUsage(UUID subscriptionId, @Nullable String unitType, LocalDate startDate, LocalDate endDate) throws KillBillClientException
{
        return getRolledUpUsage(subscriptionId, unitType, startDate, endDate, RequestOptions.empty());
}

public RolledUpUsage getRolledUpUsage(UUID subscriptionId, @Nullable String unitType, LocalDate startDate, LocalDate endDate, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.USAGES_PATH + "/" + subscriptionId;

        if (unitType != null && !unitType.trim().isEmpty()) {
        uri = uri.concat("/").concat(unitType);
    }

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_START_DATE, startDate.toString());
    queryParams.put(Config.QUERY_END_DATE, endDate.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, RolledUpUsage.class, requestOptions);
    }

    // Invoices

    @Deprecated
    public Invoices getInvoices() throws KillBillClientException
{
        return getInvoices(RequestOptions.empty());
}

public Invoices getInvoices(RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoices(0L, 100L, inputOptions);
}

@Deprecated
    public Invoices getInvoices(long offset, long limit) throws KillBillClientException
{
        return getInvoices(offset, limit, RequestOptions.empty());
}

public Invoices getInvoices(long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoices(true, offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Invoices getInvoices(long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return getInvoices(true, offset, limit, auditLevel, RequestOptions.empty());
}

public Invoices getInvoices(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoices(true, offset, limit, auditLevel, inputOptions);
}

@Deprecated
    public Invoices getInvoices(boolean withItems, long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return getInvoices(withItems, offset, limit, auditLevel, RequestOptions.empty());
}

public Invoices getInvoices(boolean withItems, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_INVOICE_WITH_ITEMS, String.valueOf(withItems));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Invoices.class, requestOptions);
    }

    @Deprecated
    public Invoice getInvoice(UUID invoiceId) throws KillBillClientException
{
        return getInvoice(invoiceId, RequestOptions.empty());
}

public Invoice getInvoice(UUID invoiceId, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoice(invoiceId, true, inputOptions);
}

@Deprecated
    public Invoice getInvoice(UUID invoiceId, boolean withItems) throws KillBillClientException
{
        return getInvoice(invoiceId, withItems, RequestOptions.empty());
}

public Invoice getInvoice(UUID invoiceId, boolean withItems, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoice(invoiceId, withItems, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Invoice getInvoice(UUID invoiceId, boolean withItems, AuditLevel auditLevel) throws KillBillClientException
{
        return getInvoice(invoiceId, withItems, auditLevel, RequestOptions.empty());
}

public Invoice getInvoice(UUID invoiceId, boolean withItems, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoiceByIdOrNumber(invoiceId.toString(), withItems, auditLevel, inputOptions);
}

@Deprecated
    public Invoice getInvoice(Integer invoiceNumber) throws KillBillClientException
{
        return getInvoice(invoiceNumber, RequestOptions.empty());
}

public Invoice getInvoice(Integer invoiceNumber, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoice(invoiceNumber, true, inputOptions);
}

@Deprecated
    public Invoice getInvoice(Integer invoiceNumber, boolean withItems) throws KillBillClientException
{
        return getInvoice(invoiceNumber, withItems, RequestOptions.empty());
}

public Invoice getInvoice(Integer invoiceNumber, boolean withItems, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoice(invoiceNumber, withItems, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Invoice getInvoice(Integer invoiceNumber, boolean withItems, AuditLevel auditLevel) throws KillBillClientException
{
        return getInvoice(invoiceNumber, withItems, auditLevel, RequestOptions.empty());
}

public Invoice getInvoice(Integer invoiceNumber, boolean withItems, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoiceByIdOrNumber(invoiceNumber.toString(), withItems, auditLevel, inputOptions);
}

@Deprecated
    public Invoice getInvoiceByIdOrNumber(String invoiceIdOrNumber, boolean withItems, AuditLevel auditLevel) throws KillBillClientException
{
        return getInvoiceByIdOrNumber(invoiceIdOrNumber, withItems, auditLevel, RequestOptions.empty());
}

public Invoice getInvoiceByIdOrNumber(String invoiceIdOrNumber, boolean withItems, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES_PATH + "/" + invoiceIdOrNumber;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_INVOICE_WITH_ITEMS, String.valueOf(withItems));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Invoice.class, requestOptions);
    }

    @Deprecated
    public String getInvoiceAsHtml(UUID invoiceId) throws KillBillClientException
{
        return getInvoiceAsHtml(invoiceId, RequestOptions.empty());
}

public String getInvoiceAsHtml(UUID invoiceId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES_PATH + "/" + invoiceId + "/" + Config.INVOICE_HTML;
        return getResourceFile(uri, KillBillHttpClient.ACCEPT_HTML, inputOptions);
}

@Deprecated
    public Invoices getInvoicesForAccount(UUID accountId) throws KillBillClientException
{
        return getInvoicesForAccount(accountId, RequestOptions.empty());
}

public Invoices getInvoicesForAccount(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoicesForAccount(accountId, true, inputOptions);
}

@Deprecated
    public Invoices getInvoicesForAccount(UUID accountId, boolean withItems) throws KillBillClientException
{
        return getInvoicesForAccount(accountId, withItems, RequestOptions.empty());
}

public Invoices getInvoicesForAccount(UUID accountId, boolean withItems, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoicesForAccount(accountId, withItems, false, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Invoices getInvoicesForAccount(UUID accountId, boolean withItems, boolean unpaidOnly) throws KillBillClientException
{
        return getInvoicesForAccount(accountId, withItems, unpaidOnly, RequestOptions.empty());
}

public Invoices getInvoicesForAccount(UUID accountId, boolean withItems, boolean unpaidOnly, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoicesForAccount(accountId, withItems, unpaidOnly, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Invoices getInvoicesForAccount(UUID accountId, boolean withItems, boolean unpaidOnly, AuditLevel auditLevel) throws KillBillClientException
{
        return getInvoicesForAccount(accountId, withItems, unpaidOnly, auditLevel, RequestOptions.empty());
}

public Invoices getInvoicesForAccount(UUID accountId, boolean withItems, boolean unpaidOnly, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.INVOICES;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_INVOICE_WITH_ITEMS, String.valueOf(withItems));
    queryParams.put(Config.QUERY_UNPAID_INVOICES_ONLY, String.valueOf(unpaidOnly));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Invoices.class, requestOptions);
    }

    @Deprecated
    public Invoices searchInvoices(String key) throws KillBillClientException
{
        return searchInvoices(key, RequestOptions.empty());
}

public Invoices searchInvoices(String key, RequestOptions inputOptions) throws KillBillClientException
{
        return searchInvoices(key, 0L, 100L, inputOptions);
}

@Deprecated
    public Invoices searchInvoices(String key, long offset, long limit) throws KillBillClientException
{
        return searchInvoices(key, offset, limit, RequestOptions.empty());
}

public Invoices searchInvoices(String key, long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return searchInvoices(key, offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Invoices searchInvoices(String key, long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return searchInvoices(key, offset, limit, auditLevel, RequestOptions.empty());
}

public Invoices searchInvoices(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Invoices.class, requestOptions);
    }

    @Deprecated
    public Invoice createDryRunInvoice(UUID accountId, @Nullable LocalDate futureDate, InvoiceDryRun dryRunInfo, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createDryRunInvoice(accountId, futureDate, dryRunInfo, RequestOptions.builder()
                                                                                    .withCreatedBy(createdBy)
                                                                                    .withReason(reason)
                                                                                    .withComment(comment).build());
}

public Invoice createDryRunInvoice(UUID accountId, @Nullable LocalDate futureDate, InvoiceDryRun dryRunInfo, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES_PATH + "/" + Config.DRY_RUN;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());

    String futureDateOrUpcomingNextInvoice = (futureDate != null) ? futureDate.toString() : null;
        if (futureDateOrUpcomingNextInvoice != null) {
        queryParams.put(Config.QUERY_ACCOUNT_ID, accountId.toString());
        queryParams.put(Config.QUERY_TARGET_DATE, futureDateOrUpcomingNextInvoice);
        queryParams.put(Config.QUERY_DRY_RUN, "true");
    } else {
        queryParams.put(Config.QUERY_ACCOUNT_ID, accountId.toString());
        queryParams.put(Config.QUERY_DRY_RUN, "true");
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doPost(uri, dryRunInfo, Invoice.class, requestOptions);
    }

    @Deprecated
    public Invoice createInvoice(UUID accountId, LocalDate futureDate, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createInvoice(accountId, futureDate, RequestOptions.builder()
                                                                  .withCreatedBy(createdBy)
                                                                  .withReason(reason)
                                                                  .withComment(comment).build());
}

public Invoice createInvoice(UUID accountId, LocalDate futureDate, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES_PATH;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_ACCOUNT_ID, accountId.toString());
    queryParams.put(Config.QUERY_TARGET_DATE, futureDate.toString());

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, null, Invoice.class, requestOptions);
    }

    @Deprecated
    public Invoice adjustInvoiceItem(InvoiceItem invoiceItem, String createdBy, String reason, String comment) throws KillBillClientException
{
        return adjustInvoiceItem(invoiceItem, RequestOptions.builder()
                                                            .withCreatedBy(createdBy)
                                                            .withReason(reason)
                                                            .withComment(comment).build());
}

public Invoice adjustInvoiceItem(InvoiceItem invoiceItem, RequestOptions inputOptions) throws KillBillClientException
{
        return adjustInvoiceItem(invoiceItem, new DateTime(DateTimeZone.UTC), inputOptions);
    }

    @Deprecated
    public Invoice adjustInvoiceItem(InvoiceItem invoiceItem, DateTime requestedDate, String createdBy, String reason, String comment) throws KillBillClientException
{
        return adjustInvoiceItem(invoiceItem, requestedDate, RequestOptions.builder()
                                                                           .withCreatedBy(createdBy)
                                                                           .withReason(reason)
                                                                           .withComment(comment).build());
}

public Invoice adjustInvoiceItem(InvoiceItem invoiceItem, DateTime requestedDate, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(invoiceItem.getAccountId(), "InvoiceItem#accountId cannot be null");
    Preconditions.checkNotNull(invoiceItem.getInvoiceId(), "InvoiceItem#invoiceId cannot be null");
    Preconditions.checkNotNull(invoiceItem.getInvoiceItemId(), "InvoiceItem#invoiceItemId cannot be null");

    String uri = Config.INVOICES_PATH + "/" + invoiceItem.getInvoiceId();

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, invoiceItem, Invoice.class, requestOptions);
    }

    @Deprecated
    public InvoiceItem createExternalCharge(InvoiceItem externalCharge, DateTime requestedDate, Boolean autoPay, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createExternalCharge(externalCharge, requestedDate, autoPay, RequestOptions.builder()
                                                                                          .withCreatedBy(createdBy)
                                                                                          .withReason(reason)
                                                                                          .withComment(comment).build());
}

public InvoiceItem createExternalCharge(InvoiceItem externalCharge, DateTime requestedDate, Boolean autoPay, RequestOptions inputOptions) throws KillBillClientException
{
    List<InvoiceItem> externalCharges = createExternalCharges(ImmutableList.<InvoiceItem>of(externalCharge), requestedDate, autoPay, inputOptions);
        return externalCharges.isEmpty() ? null : externalCharges.get(0);
    }

    @Deprecated
    public List<InvoiceItem> createExternalCharges(Iterable<InvoiceItem> externalCharges, DateTime requestedDate, Boolean autoPay, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createExternalCharges(externalCharges, requestedDate, autoPay, RequestOptions.builder()
                                                                                            .withCreatedBy(createdBy)
                                                                                            .withReason(reason)
                                                                                            .withComment(comment).build());
}

public List<InvoiceItem> createExternalCharges(Iterable<InvoiceItem> externalCharges, DateTime requestedDate, Boolean autoPay, RequestOptions inputOptions) throws KillBillClientException
{
    Map<UUID, Collection<InvoiceItem>> externalChargesPerAccount = new HashMap<UUID, Collection<InvoiceItem>>();
        for (InvoiceItem externalCharge : externalCharges) {
            Preconditions.checkNotNull(externalCharge.getAccountId(), "InvoiceItem#accountId cannot be null");
            Preconditions.checkNotNull(externalCharge.getAmount(), "InvoiceItem#amount cannot be null");
            // We allow the currency to be null and in this case will default to account currency
            //Preconditions.checkNotNull(externalCharge.getCurrency(), "InvoiceItem#currency cannot be null");

            if (externalChargesPerAccount.get(externalCharge.getAccountId()) == null) {
                externalChargesPerAccount.put(externalCharge.getAccountId(), new LinkedList<InvoiceItem>());
            }
            externalChargesPerAccount.get(externalCharge.getAccountId()).add(externalCharge);
        }

        List<InvoiceItem> createdExternalCharges = new LinkedList<InvoiceItem>();
        for (UUID accountId : externalChargesPerAccount.keySet()) {
            List<InvoiceItem> invoiceItems = createExternalCharges(accountId, externalChargesPerAccount.get(accountId), requestedDate, autoPay, inputOptions);
createdExternalCharges.addAll(invoiceItems);
        }

        return createdExternalCharges;
    }

    private List<InvoiceItem> createExternalCharges(UUID accountId, Iterable<InvoiceItem> externalCharges, DateTime requestedDate, Boolean autoPay, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES_PATH + "/" + Config.CHARGES + "/" + accountId;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    queryParams.put(Config.QUERY_PAY_INVOICE, autoPay.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doPost(uri, externalCharges, InvoiceItems.class, requestOptions);
    }

    @Deprecated
    public void triggerInvoiceNotification(UUID invoiceId, String createdBy, String reason, String comment) throws KillBillClientException
{
    triggerInvoiceNotification(invoiceId, RequestOptions.builder()
                                                            .withCreatedBy(createdBy)
                                                            .withReason(reason)
                                                            .withComment(comment).build());
}

public void triggerInvoiceNotification(UUID invoiceId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES_PATH + "/" + invoiceId.toString() + "/" + Config.EMAIL_NOTIFICATIONS;

    httpClient.doPost(uri, null, inputOptions);
}

@Deprecated
    public void uploadInvoiceTemplate(String invoiceTemplateFilePath, boolean manualPay, String createdBy, String reason, String comment) throws KillBillClientException
{
    uploadInvoiceTemplate(invoiceTemplateFilePath, manualPay, RequestOptions.builder()
                                                                                .withCreatedBy(createdBy)
                                                                                .withReason(reason)
                                                                                .withComment(comment).build());
}

public void uploadInvoiceTemplate(String invoiceTemplateFilePath, boolean manualPay, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES + (manualPay ? "/manualPayTemplate" : "/template");
    uploadFile(invoiceTemplateFilePath, uri, "text/html", inputOptions, null);
}

@Deprecated
    public void uploadInvoiceTemplate(InputStream invoiceTemplateInputStream, boolean manualPay, String createdBy, String reason, String comment) throws KillBillClientException
{
    uploadInvoiceTemplate(invoiceTemplateInputStream, manualPay, RequestOptions.builder()
                                                                                   .withCreatedBy(createdBy)
                                                                                   .withReason(reason)
                                                                                   .withComment(comment).build());
}

public void uploadInvoiceTemplate(InputStream invoiceTemplateInputStream, boolean manualPay, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES + (manualPay ? "/manualPayTemplate" : "/template");
    uploadFile(invoiceTemplateInputStream, uri, "text/html", inputOptions, null);
}

@Deprecated
    public String getInvoiceTemplate(boolean manualPay) throws KillBillClientException
{
        return getInvoiceTemplate(manualPay, RequestOptions.empty());
}

public String getInvoiceTemplate(boolean manualPay, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES + (manualPay ? "/manualPayTemplate" : "/template");
        return getResourceFile(uri, "text/html", inputOptions);
}

@Deprecated
    public void uploadInvoiceTranslation(String invoiceTranslationFilePath, String locale, String createdBy, String reason, String comment) throws KillBillClientException
{
    uploadInvoiceTranslation(invoiceTranslationFilePath, locale, RequestOptions.builder()
                                                                                   .withCreatedBy(createdBy)
                                                                                   .withReason(reason)
                                                                                   .withComment(comment).build());
}

public void uploadInvoiceTranslation(String invoiceTranslationFilePath, String locale, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES + "/translation/" + locale;
    uploadFile(invoiceTranslationFilePath, uri, "text/plain", inputOptions, null);
}

@Deprecated
    public void uploadInvoiceTranslation(InputStream invoiceTranslationInputStream, String locale, String createdBy, String reason, String comment) throws KillBillClientException
{
    uploadInvoiceTranslation(invoiceTranslationInputStream, locale, RequestOptions.builder()
                                                                                      .withCreatedBy(createdBy)
                                                                                      .withReason(reason)
                                                                                      .withComment(comment).build());
}

public void uploadInvoiceTranslation(InputStream invoiceTranslationInputStream, String locale, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES + "/translation/" + locale;
    uploadFile(invoiceTranslationInputStream, uri, "text/plain", inputOptions, null);
}

@Deprecated
    public String getInvoiceTranslation(String locale) throws KillBillClientException
{
        return getInvoiceTranslation(locale, RequestOptions.empty());
}

public String getInvoiceTranslation(String locale, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES + "/translation/" + locale;
        return getResourceFile(uri, "text/plain", inputOptions);
}

@Deprecated
    public void uploadCatalogTranslation(String catalogTranslationFilePath, String locale, String createdBy, String reason, String comment) throws KillBillClientException
{
    uploadCatalogTranslation(catalogTranslationFilePath, locale, RequestOptions.builder()
                                                                                   .withCreatedBy(createdBy)
                                                                                   .withReason(reason)
                                                                                   .withComment(comment).build());
}

public void uploadCatalogTranslation(String catalogTranslationFilePath, String locale, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES + "/catalogTranslation/" + locale;
    uploadFile(catalogTranslationFilePath, uri, "text/plain", inputOptions, null);
}

@Deprecated
    public void uploadCatalogTranslation(InputStream catalogTranslationInputStream, String locale, String createdBy, String reason, String comment) throws KillBillClientException
{
    uploadCatalogTranslation(catalogTranslationInputStream, locale, RequestOptions.builder()
                                                                                      .withCreatedBy(createdBy)
                                                                                      .withReason(reason)
                                                                                      .withComment(comment).build());
}

public void uploadCatalogTranslation(InputStream catalogTranslationInputStream, String locale, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES + "/catalogTranslation/" + locale;
    uploadFile(catalogTranslationInputStream, uri, "text/plain", inputOptions, null);
}

@Deprecated
    public String getCatalogTranslation(String locale) throws KillBillClientException
{
        return getCatalogTranslation(locale, RequestOptions.empty());
}

public String getCatalogTranslation(String locale, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES + "/catalogTranslation/" + locale;
        return getResourceFile(uri, "text/plain", inputOptions);
}

// Credits

@Deprecated
    public Credit getCredit(UUID creditId) throws KillBillClientException
{
        return getCredit(creditId, RequestOptions.empty());
}

public Credit getCredit(UUID creditId, RequestOptions inputOptions) throws KillBillClientException
{
        return getCredit(creditId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Credit getCredit(UUID creditId, AuditLevel auditLevel) throws KillBillClientException
{
        return getCredit(creditId, auditLevel, RequestOptions.empty());
}

public Credit getCredit(UUID creditId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.CREDITS_PATH + "/" + creditId;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Credit.class, requestOptions);
    }

    @Deprecated
    public Credit createCredit(Credit credit, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createCredit(credit, RequestOptions.builder()
                                                  .withCreatedBy(createdBy)
                                                  .withReason(reason)
                                                  .withComment(comment).build());
}

public Credit createCredit(Credit credit, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(credit.getAccountId(), "Credt#accountId cannot be null");
    Preconditions.checkNotNull(credit.getCreditAmount(), "Credt#creditAmount cannot be null");

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

        return httpClient.doPost(Config.CREDITS_PATH, credit, Credit.class, requestOptions);
    }

    @Deprecated
    public Payments searchPayments(String key) throws KillBillClientException
{
        return searchPayments(key, RequestOptions.empty());
}

public Payments searchPayments(String key, RequestOptions inputOptions) throws KillBillClientException
{
        return searchPayments(key, 0L, 100L, inputOptions);
}

@Deprecated
    public Payments searchPayments(String key, long offset, long limit) throws KillBillClientException
{
        return searchPayments(key, offset, limit, RequestOptions.empty());
}

public Payments searchPayments(String key, long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return searchPayments(key, offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Payments searchPayments(String key, long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return searchPayments(key, offset, limit, auditLevel, RequestOptions.empty());
}

public Payments searchPayments(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENTS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Payments.class, requestOptions);
    }

    @Deprecated
    public InvoicePayments getInvoicePaymentsForAccount(UUID accountId) throws KillBillClientException
{
        return getInvoicePaymentsForAccount(accountId, RequestOptions.empty());
}

public InvoicePayments getInvoicePaymentsForAccount(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoicePaymentsForAccount(accountId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public InvoicePayments getInvoicePaymentsForAccount(UUID accountId, AuditLevel auditLevel) throws KillBillClientException
{
        return getInvoicePaymentsForAccount(accountId, auditLevel, RequestOptions.empty());
}

public InvoicePayments getInvoicePaymentsForAccount(UUID accountId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.INVOICE_PAYMENTS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, InvoicePayments.class, requestOptions);
    }

    @Deprecated
    public InvoicePayments getInvoicePayment(UUID invoiceId) throws KillBillClientException
{
        return getInvoicePayment(invoiceId, RequestOptions.empty());
}

public InvoicePayments getInvoicePayment(UUID invoiceId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.INVOICES_PATH + "/" + invoiceId + "/" + Config.PAYMENTS;

        return httpClient.doGet(uri, InvoicePayments.class, inputOptions);
    }

    @Deprecated
    public void payAllInvoices(UUID accountId, boolean externalPayment, BigDecimal paymentAmount, String createdBy, String reason, String comment) throws KillBillClientException
{
    payAllInvoices(accountId, externalPayment, paymentAmount, RequestOptions.builder()
                                                                                .withCreatedBy(createdBy)
                                                                                .withReason(reason)
                                                                                .withComment(comment).build());
}

public void payAllInvoices(UUID accountId, boolean externalPayment, BigDecimal paymentAmount, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.INVOICE_PAYMENTS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_PAYMENT_EXTERNAL, String.valueOf(externalPayment));
        if (paymentAmount != null) {
        queryParams.put("paymentAmount", String.valueOf(paymentAmount));
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doPost(uri, null, requestOptions);
}

@Deprecated
    public InvoicePayment createInvoicePayment(InvoicePayment payment, boolean isExternal, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createInvoicePayment(payment, isExternal, RequestOptions.builder()
                                                                       .withCreatedBy(createdBy)
                                                                       .withReason(reason)
                                                                       .withComment(comment).build());
}

public InvoicePayment createInvoicePayment(InvoicePayment payment, boolean isExternal, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(payment.getAccountId(), "InvoiceItem#accountId cannot be null");
    Preconditions.checkNotNull(payment.getTargetInvoiceId(), "InvoiceItem#invoiceId cannot be null");
    Preconditions.checkNotNull(payment.getPurchasedAmount(), "InvoiceItem#amount cannot be null");

    String uri = Config.INVOICES_PATH + "/" + payment.getTargetInvoiceId() + "/" + Config.PAYMENTS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put("externalPayment", String.valueOf(isExternal));

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, payment, InvoicePayment.class, requestOptions);
    }

    @Deprecated
    public Payments getPayments() throws KillBillClientException
{
        return getPayments(RequestOptions.empty());
}

public Payments getPayments(RequestOptions inputOptions) throws KillBillClientException
{
        return getPayments(0L, 100L, inputOptions);
}

@Deprecated
    public Payments getPayments(long offset, long limit) throws KillBillClientException
{
        return getPayments(offset, limit, RequestOptions.empty());
}

public Payments getPayments(long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return getPayments(offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Payments getPayments(long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return getPayments(offset, limit, auditLevel, RequestOptions.empty());
}

public Payments getPayments(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getPayments(offset, limit, null, ImmutableMap.<String, String>of(), auditLevel, inputOptions);
}

@Deprecated
    public Payments getPayments(long offset, long limit, @Nullable String pluginName, Map<String, String> pluginProperties, AuditLevel auditLevel) throws KillBillClientException
{
        return getPayments(offset, limit, pluginName, pluginProperties, auditLevel, RequestOptions.empty());
}

public Payments getPayments(long offset, long limit, @Nullable String pluginName, Map<String, String> pluginProperties, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENTS_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
        if (pluginName != null) {
        queryParams.put(Config.QUERY_PAYMENT_PLUGIN_NAME, pluginName);
    }
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Payments.class, requestOptions);
    }

    @Deprecated
    public Payment getPayment(UUID paymentId) throws KillBillClientException
{
        return getPayment(paymentId, RequestOptions.empty());
}

public Payment getPayment(UUID paymentId, RequestOptions inputOptions) throws KillBillClientException
{
        return getPayment(paymentId, true, inputOptions);
}

@Deprecated
    public Payment getPayment(UUID paymentId, boolean withPluginInfo) throws KillBillClientException
{
        return getPayment(paymentId, withPluginInfo, RequestOptions.empty());
}

public Payment getPayment(UUID paymentId, boolean withPluginInfo, RequestOptions inputOptions) throws KillBillClientException
{
        return getPayment(paymentId, withPluginInfo, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Payment getPayment(UUID paymentId, boolean withPluginInfo, AuditLevel auditLevel) throws KillBillClientException
{
        return getPayment(paymentId, withPluginInfo, auditLevel, RequestOptions.empty());
}

public Payment getPayment(UUID paymentId, boolean withPluginInfo, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getPayment(paymentId, withPluginInfo, ImmutableMap.<String, String>of(), auditLevel, inputOptions);
}

@Deprecated
    public Payment getPayment(UUID paymentId, boolean withPluginInfo, Map<String, String> pluginProperties, AuditLevel auditLevel) throws KillBillClientException
{
        return getPayment(paymentId, withPluginInfo, pluginProperties, auditLevel, RequestOptions.empty());
}

public Payment getPayment(UUID paymentId, boolean withPluginInfo, Map<String, String> pluginProperties, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENTS_PATH + "/" + paymentId;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Payment.class, requestOptions);
    }

    @Deprecated
    public Payment getPaymentByExternalKey(String externalKey) throws KillBillClientException
{
        return getPaymentByExternalKey(externalKey, RequestOptions.empty());
}

public Payment getPaymentByExternalKey(String externalKey, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentByExternalKey(externalKey, true, inputOptions);
}

@Deprecated
    public Payment getPaymentByExternalKey(String externalKey, boolean withPluginInfo) throws KillBillClientException
{
        return getPaymentByExternalKey(externalKey, withPluginInfo, RequestOptions.empty());
}

public Payment getPaymentByExternalKey(String externalKey, boolean withPluginInfo, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentByExternalKey(externalKey, withPluginInfo, AuditLevel.NONE);
}

@Deprecated
    public Payment getPaymentByExternalKey(String externalKey, boolean withPluginInfo, AuditLevel auditLevel) throws KillBillClientException
{
        return getPaymentByExternalKey(externalKey, withPluginInfo, auditLevel, RequestOptions.empty());
}

public Payment getPaymentByExternalKey(String externalKey, boolean withPluginInfo, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentByExternalKey(externalKey, withPluginInfo, ImmutableMap.<String, String>of(), auditLevel, inputOptions);
}

@Deprecated
    public Payment getPaymentByExternalKey(String externalKey, boolean withPluginInfo, Map<String, String> pluginProperties, AuditLevel auditLevel) throws KillBillClientException
{
        return getPaymentByExternalKey(externalKey, withPluginInfo, pluginProperties, auditLevel, RequestOptions.empty());
}

public Payment getPaymentByExternalKey(String externalKey, boolean withPluginInfo, Map<String, String> pluginProperties, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENTS_PATH;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_EXTERNAL_KEY, externalKey);
    queryParams.put(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Payment.class, requestOptions);
    }

    @Deprecated
    public Payments getPaymentsForAccount(UUID accountId) throws KillBillClientException
{
        return getPaymentsForAccount(accountId, RequestOptions.empty());
}

public Payments getPaymentsForAccount(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentsForAccount(accountId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Payments getPaymentsForAccount(UUID accountId, AuditLevel auditLevel) throws KillBillClientException
{
        return getPaymentsForAccount(accountId, auditLevel, RequestOptions.empty());
}

public Payments getPaymentsForAccount(UUID accountId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENTS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Payments.class, requestOptions);
    }

    @Deprecated
    public Payment createPayment(ComboPaymentTransaction comboPaymentTransaction, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return this.createPayment(comboPaymentTransaction, pluginProperties, RequestOptions.builder()
                                                                                           .withCreatedBy(createdBy)
                                                                                           .withReason(reason)
                                                                                           .withComment(comment).build());
}

public Payment createPayment(ComboPaymentTransaction comboPaymentTransaction, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
        return this.createPayment(comboPaymentTransaction, null, pluginProperties, inputOptions);
}

@Deprecated
    public Payment createPayment(ComboPaymentTransaction comboPaymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createPayment(comboPaymentTransaction, controlPluginNames, pluginProperties, RequestOptions.builder()
                                                                                                          .withCreatedBy(createdBy)
                                                                                                          .withReason(reason)
                                                                                                          .withComment(comment).build());
}

public Payment createPayment(ComboPaymentTransaction comboPaymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENTS_PATH + "/" + Config.COMBO;

    Multimap<String, String> queryParams = HashMultimap.create(inputOptions.getQueryParams());
        if (controlPluginNames != null) {
        queryParams.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(queryParams)
                                                          .withFollowLocation(followLocation).build();
        return httpClient.doPost(uri, comboPaymentTransaction, Payment.class, requestOptions);
    }

    @Deprecated
    public Payment createPayment(UUID accountId, PaymentTransaction paymentTransaction, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createPayment(accountId, paymentTransaction, RequestOptions.builder()
                                                                          .withCreatedBy(createdBy)
                                                                          .withReason(reason)
                                                                          .withComment(comment).build());
}

public Payment createPayment(UUID accountId, PaymentTransaction paymentTransaction, RequestOptions inputOptions) throws KillBillClientException
{
        return createPayment(accountId, null, paymentTransaction, null, ImmutableMap.<String, String>of(), inputOptions);
}

@Deprecated
    public Payment createPayment(UUID accountId, PaymentTransaction paymentTransaction, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createPayment(accountId, paymentTransaction, pluginProperties, RequestOptions.builder()
                                                                                            .withCreatedBy(createdBy)
                                                                                            .withReason(reason)
                                                                                            .withComment(comment).build());
}

public Payment createPayment(UUID accountId, PaymentTransaction paymentTransaction, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
        return createPayment(accountId, null, paymentTransaction, null, pluginProperties, inputOptions);
}

@Deprecated
    public Payment createPayment(UUID accountId, @Nullable UUID paymentMethodId, PaymentTransaction paymentTransaction, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createPayment(accountId, paymentMethodId, paymentTransaction, RequestOptions.builder()
                                                                                           .withCreatedBy(createdBy)
                                                                                           .withReason(reason)
                                                                                           .withComment(comment).build());
}

public Payment createPayment(UUID accountId, @Nullable UUID paymentMethodId, PaymentTransaction paymentTransaction, RequestOptions inputOptions) throws KillBillClientException
{
        return createPayment(accountId, paymentMethodId, paymentTransaction, null, ImmutableMap.<String, String>of(), inputOptions);
}

@Deprecated
    public Payment createPayment(UUID accountId, @Nullable UUID paymentMethodId, PaymentTransaction paymentTransaction, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createPayment(accountId, paymentMethodId, paymentTransaction, pluginProperties, RequestOptions.builder()
                                                                                                             .withCreatedBy(createdBy)
                                                                                                             .withReason(reason)
                                                                                                             .withComment(comment)
                                                                                                             .build());
}

public Payment createPayment(UUID accountId, @Nullable UUID paymentMethodId, PaymentTransaction paymentTransaction, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
        return createPayment(accountId, paymentMethodId, paymentTransaction, null, pluginProperties, inputOptions);
}

public Payment createPayment(UUID accountId, @Nullable UUID paymentMethodId, PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
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

    Multimap<String, String> params = HashMultimap.create(inputOptions.getQueryParams());
        if (paymentMethodId != null) {
            params.put("paymentMethodId", paymentMethodId.toString());
    }
        if (controlPluginNames != null) {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }
    storePluginPropertiesAsParams(pluginProperties, params);

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();
        return httpClient.doPost(uri, paymentTransaction, Payment.class, requestOptions);
    }

    @Deprecated
    public Payment completePayment(PaymentTransaction paymentTransaction, String createdBy, String reason, String comment) throws KillBillClientException
{
        return completePayment(paymentTransaction, RequestOptions.builder()
                                                                 .withCreatedBy(createdBy)
                                                                 .withReason(reason)
                                                                 .withComment(comment)
                                                                 .build());
}

public Payment completePayment(PaymentTransaction paymentTransaction, RequestOptions requestOptions) throws KillBillClientException
{
        return completePayment(paymentTransaction, ImmutableMap.<String, String>of(), requestOptions);
}

@Deprecated
    public Payment completePayment(PaymentTransaction paymentTransaction, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return completePayment(paymentTransaction, pluginProperties, RequestOptions.builder()
                                                                                   .withCreatedBy(createdBy)
                                                                                   .withReason(reason)
                                                                                   .withComment(comment)
                                                                                   .build());
}

public Payment completePayment(PaymentTransaction paymentTransaction, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkState(paymentTransaction.getPaymentId() != null || paymentTransaction.getPaymentExternalKey() != null, "PaymentTransaction#paymentId or PaymentTransaction#paymentExternalKey cannot be null");

    String uri = (paymentTransaction.getPaymentId() != null) ?
                           Config.PAYMENTS_PATH + "/" + paymentTransaction.getPaymentId() :
                           Config.PAYMENTS_PATH;

    Multimap<String, String> params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();

        return httpClient.doPut(uri, paymentTransaction, Payment.class, requestOptions);
    }

    @Deprecated
    public Payment captureAuthorization(PaymentTransaction paymentTransaction, String createdBy, String reason, String comment) throws KillBillClientException
{
        return captureAuthorization(paymentTransaction, RequestOptions.builder()
                                                                      .withCreatedBy(createdBy)
                                                                      .withReason(reason)
                                                                      .withComment(comment)
                                                                      .build());
}

public Payment captureAuthorization(PaymentTransaction paymentTransaction, RequestOptions inputOptions) throws KillBillClientException
{
        return captureAuthorization(paymentTransaction, null, ImmutableMap.<String, String>of(), inputOptions);
}

@Deprecated
    public Payment captureAuthorization(PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return captureAuthorization(paymentTransaction, controlPluginNames, pluginProperties, RequestOptions.builder()
                                                                                                            .withCreatedBy(createdBy)
                                                                                                            .withReason(reason)
                                                                                                            .withComment(comment)
                                                                                                            .build());
}

public Payment captureAuthorization(PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkState(paymentTransaction.getPaymentId() != null || paymentTransaction.getPaymentExternalKey() != null, "PaymentTransaction#paymentId or PaymentTransaction#paymentExternalKey cannot be null");
    Preconditions.checkNotNull(paymentTransaction.getAmount(), "PaymentTransaction#amount cannot be null");

    String uri = (paymentTransaction.getPaymentId() != null) ?
                           Config.PAYMENTS_PATH + "/" + paymentTransaction.getPaymentId() :
                           Config.PAYMENTS_PATH;

    Multimap<String, String> params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
        if (controlPluginNames != null) {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, paymentTransaction, Payment.class, requestOptions);
    }

    @Deprecated
    public Payment refundPayment(PaymentTransaction paymentTransaction, String createdBy, String reason, String comment) throws KillBillClientException
{
        return refundPayment(paymentTransaction, RequestOptions.builder()
                                                               .withCreatedBy(createdBy)
                                                               .withReason(reason)
                                                               .withComment(comment)
                                                               .build());
}

public Payment refundPayment(PaymentTransaction paymentTransaction, RequestOptions inputOptions) throws KillBillClientException
{
        return refundPayment(paymentTransaction, null, ImmutableMap.<String, String>of(), inputOptions);
}

@Deprecated
    public Payment refundPayment(PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return refundPayment(paymentTransaction, controlPluginNames, pluginProperties, RequestOptions.builder()
                                                                                                     .withCreatedBy(createdBy)
                                                                                                     .withReason(reason)
                                                                                                     .withComment(comment)
                                                                                                     .build());
}

public Payment refundPayment(PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkState(paymentTransaction.getPaymentId() != null || paymentTransaction.getPaymentExternalKey() != null, "PaymentTransaction#paymentId or PaymentTransaction#paymentExternalKey cannot be null");
    Preconditions.checkNotNull(paymentTransaction.getAmount(), "PaymentTransaction#amount cannot be null");

    String uri = (paymentTransaction.getPaymentId() != null) ?
                           Config.PAYMENTS_PATH + "/" + paymentTransaction.getPaymentId() + "/" + Config.REFUNDS :
                           Config.PAYMENTS_PATH + "/" + Config.REFUNDS;

    Multimap<String, String> params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
        if (controlPluginNames != null) {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, paymentTransaction, Payment.class, requestOptions);
    }

    @Deprecated
    public Payment chargebackPayment(PaymentTransaction paymentTransaction, String createdBy, String reason, String comment) throws KillBillClientException
{
        return chargebackPayment(paymentTransaction, RequestOptions.builder()
                                                                   .withCreatedBy(createdBy)
                                                                   .withReason(reason)
                                                                   .withComment(comment)
                                                                   .build());
}

public Payment chargebackPayment(PaymentTransaction paymentTransaction, RequestOptions requestOptions) throws KillBillClientException
{
        return chargebackPayment(paymentTransaction, null, ImmutableMap.<String, String>of(), requestOptions);
}

@Deprecated
    public Payment chargebackPayment(PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return chargebackPayment(paymentTransaction, controlPluginNames, pluginProperties, RequestOptions.builder()
                                                                                                         .withCreatedBy(createdBy)
                                                                                                         .withReason(reason)
                                                                                                         .withComment(comment)
                                                                                                         .build());
}

public Payment chargebackPayment(PaymentTransaction paymentTransaction, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkState(paymentTransaction.getPaymentId() != null || paymentTransaction.getPaymentExternalKey() != null, "PaymentTransaction#paymentId or PaymentTransaction#paymentExternalKey cannot be null");
    Preconditions.checkNotNull(paymentTransaction.getAmount(), "PaymentTransaction#amount cannot be null");

    String uri = (paymentTransaction.getPaymentId() != null) ?
                           Config.PAYMENTS_PATH + "/" + paymentTransaction.getPaymentId() + "/" + Config.CHARGEBACKS :
                           Config.PAYMENTS_PATH + "/" + Config.CHARGEBACKS;

    Multimap<String, String> params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
        if (controlPluginNames != null) {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }
    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, paymentTransaction, Payment.class, requestOptions);
    }

    @Deprecated
    public Payment voidPayment(UUID paymentId, String transactionExternalKey, String createdBy, String reason, String comment) throws KillBillClientException
{
        return voidPayment(paymentId, transactionExternalKey, RequestOptions.builder()
                                                                            .withCreatedBy(createdBy)
                                                                            .withReason(reason)
                                                                            .withComment(comment)
                                                                            .build());
}

public Payment voidPayment(UUID paymentId, String transactionExternalKey, RequestOptions inputOptions) throws KillBillClientException
{
        return voidPayment(paymentId, null, transactionExternalKey, null, ImmutableMap.<String, String>of(), inputOptions);
}

@Deprecated
    public Payment voidPayment(UUID paymentId, String paymentExternalKey, String transactionExternalKey, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return voidPayment(paymentId, paymentExternalKey, transactionExternalKey, controlPluginNames, pluginProperties, RequestOptions.builder()
                                                                                                                                      .withCreatedBy(createdBy)
                                                                                                                                      .withReason(reason)
                                                                                                                                      .withComment(comment)
                                                                                                                                      .build());
}

public Payment voidPayment(UUID paymentId, String paymentExternalKey, String transactionExternalKey, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{

    Preconditions.checkState(paymentId != null || paymentExternalKey != null, "PaymentTransaction#paymentId or PaymentTransaction#paymentExternalKey cannot be null");
    String uri = (paymentId != null) ?
                           Config.PAYMENTS_PATH + "/" + paymentId :
                           Config.PAYMENTS_PATH;

    PaymentTransaction paymentTransaction = new PaymentTransaction();
        if (paymentExternalKey != null) {
            paymentTransaction.setPaymentExternalKey(paymentExternalKey);
        }
        paymentTransaction.setTransactionExternalKey(transactionExternalKey);

        Multimap<String, String> params = HashMultimap.create(inputOptions.getQueryParams());
        storePluginPropertiesAsParams(pluginProperties, params);
        if (controlPluginNames != null) {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
        }

        Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
        RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(followLocation).build();
        return httpClient.doDelete(uri, paymentTransaction, Payment.class, requestOptions);
    }

    // Hosted payment pages
    @Deprecated
    public HostedPaymentPageFormDescriptor buildFormDescriptor(HostedPaymentPageFields fields, UUID kbAccountId, @Nullable UUID kbPaymentMethodId, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return buildFormDescriptor(fields, kbAccountId, kbPaymentMethodId, pluginProperties, RequestOptions.builder()
                                                                                                           .withCreatedBy(createdBy)
                                                                                                           .withReason(reason)
                                                                                                           .withComment(comment)
                                                                                                           .build());
}

public HostedPaymentPageFormDescriptor buildFormDescriptor(HostedPaymentPageFields fields, UUID kbAccountId, @Nullable UUID kbPaymentMethodId, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
        return buildFormDescriptor(fields, kbAccountId, kbPaymentMethodId, null, pluginProperties, inputOptions);
}

public HostedPaymentPageFormDescriptor buildFormDescriptor(HostedPaymentPageFields fields, UUID kbAccountId, @Nullable UUID kbPaymentMethodId, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_GATEWAYS_PATH + "/" + Config.HOSTED + "/" + Config.FORM + "/" + kbAccountId;

    Multimap<String, String> params = HashMultimap.create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);
        if (controlPluginNames != null) {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }
        if (kbPaymentMethodId != null) {
            params.put(Config.QUERY_PAYMENT_METHOD_ID, kbPaymentMethodId.toString());
    }

    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(false).build();

        return httpClient.doPost(uri, fields, HostedPaymentPageFormDescriptor.class, requestOptions);
    }

    @Deprecated
    public HostedPaymentPageFormDescriptor buildFormDescriptor(ComboHostedPaymentPage comboHostedPaymentPage, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return buildFormDescriptor(comboHostedPaymentPage, pluginProperties, RequestOptions.builder()
                                                                                           .withCreatedBy(createdBy)
                                                                                           .withReason(reason)
                                                                                           .withComment(comment)
                                                                                           .build());
}

public HostedPaymentPageFormDescriptor buildFormDescriptor(ComboHostedPaymentPage comboHostedPaymentPage, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
        return buildFormDescriptor(comboHostedPaymentPage, null, pluginProperties, inputOptions);
}

@Deprecated
    public HostedPaymentPageFormDescriptor buildFormDescriptor(ComboHostedPaymentPage comboHostedPaymentPage, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return buildFormDescriptor(comboHostedPaymentPage, controlPluginNames, pluginProperties, RequestOptions.builder()
                                                                                                 .withCreatedBy(createdBy)
                                                                                                 .withReason(reason)
                                                                                                 .withComment(comment)
                                                                                                 .build());
}

public HostedPaymentPageFormDescriptor buildFormDescriptor(ComboHostedPaymentPage comboHostedPaymentPage, @Nullable List<String> controlPluginNames, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_GATEWAYS_PATH + "/" + Config.HOSTED + "/" + Config.FORM;

    Multimap<String, String> params = HashMultimap.create(inputOptions.getQueryParams());
        if (controlPluginNames != null) {
            params.putAll(KillBillHttpClient.CONTROL_PLUGIN_NAME, controlPluginNames);
    }
    storePluginPropertiesAsParams(pluginProperties, params);

    RequestOptions requestOptions = inputOptions.extend()
                                                          .withQueryParams(params)
                                                          .withFollowLocation(false).build();

        return httpClient.doPost(uri, comboHostedPaymentPage, HostedPaymentPageFormDescriptor.class, requestOptions);
    }

    @Deprecated
    public Response processNotification(String notification, String pluginName, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
        return processNotification(notification, pluginName, pluginProperties, RequestOptions.builder()
                                                                                             .withCreatedBy(createdBy)
                                                                                             .withReason(reason)
                                                                                             .withComment(comment)
                                                                                             .build());
}

public Response processNotification(String notification, String pluginName, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_GATEWAYS_PATH + "/" + Config.NOTIFICATION + "/" + pluginName;

    Multimap<String, String> params = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    storePluginPropertiesAsParams(pluginProperties, params);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(params).build();

        return httpClient.doPost(uri, notification, requestOptions);
}

@Deprecated
    public InvoicePayment createInvoicePaymentRefund(InvoicePaymentTransaction refundTransaction, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createInvoicePaymentRefund(refundTransaction, RequestOptions.builder()
                                                                           .withCreatedBy(createdBy)
                                                                           .withReason(reason)
                                                                           .withComment(comment)
                                                                           .build());
}

public InvoicePayment createInvoicePaymentRefund(InvoicePaymentTransaction refundTransaction, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(refundTransaction.getPaymentId(), "InvoicePaymentTransaction#paymentId cannot be null");

        // Specify isAdjusted for invoice adjustment and invoice item adjustment
        // Specify adjustments for invoice item adjustments only
        if (refundTransaction.getAdjustments() != null) {
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

    @Deprecated
    public InvoicePayment createInvoicePaymentChargeback(InvoicePaymentTransaction chargebackTransaction, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createInvoicePaymentChargeback(chargebackTransaction, RequestOptions.builder()
                                                                                   .withCreatedBy(createdBy)
                                                                                   .withReason(reason)
                                                                                   .withComment(comment)
                                                                                   .build());
}

public InvoicePayment createInvoicePaymentChargeback(InvoicePaymentTransaction chargebackTransaction, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(chargebackTransaction.getPaymentId(), "InvoicePaymentTransaction#paymentId cannot be null");

    String uri = Config.INVOICE_PAYMENTS_PATH + "/" + chargebackTransaction.getPaymentId() + "/" + Config.CHARGEBACKS;

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, chargebackTransaction, InvoicePayment.class, requestOptions);
    }

    // Payment methods

    @Deprecated
    public PaymentMethods getPaymentMethods() throws KillBillClientException
{
        return getPaymentMethods(RequestOptions.empty());
}

public PaymentMethods getPaymentMethods(RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentMethods(0L, 100L, inputOptions);
}

@Deprecated
    public PaymentMethods getPaymentMethods(long offset, long limit) throws KillBillClientException
{
        return getPaymentMethods(offset, limit, RequestOptions.empty());
}

public PaymentMethods getPaymentMethods(long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentMethods(offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public PaymentMethods getPaymentMethods(long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return getPaymentMethods(offset, limit, auditLevel, RequestOptions.empty());
}

public PaymentMethods getPaymentMethods(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, PaymentMethods.class, requestOptions);
    }

    @Deprecated
    public PaymentMethods searchPaymentMethods(String key) throws KillBillClientException
{
        return searchPaymentMethods(key, RequestOptions.empty());
}

public PaymentMethods searchPaymentMethods(String key, RequestOptions inputOptions) throws KillBillClientException
{
        return searchPaymentMethods(key, 0L, 100L, inputOptions);
}

@Deprecated
    public PaymentMethods searchPaymentMethods(String key, long offset, long limit) throws KillBillClientException
{
        return searchPaymentMethods(key, offset, limit, RequestOptions.empty());
}

public PaymentMethods searchPaymentMethods(String key, long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return searchPaymentMethods(key, offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public PaymentMethods searchPaymentMethods(String key, long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return searchPaymentMethods(key, offset, limit, auditLevel, RequestOptions.empty());
}

public PaymentMethods searchPaymentMethods(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, PaymentMethods.class, requestOptions);
    }

    @Deprecated
    public PaymentMethod getPaymentMethod(UUID paymentMethodId) throws KillBillClientException
{
        return getPaymentMethod(paymentMethodId, RequestOptions.empty());
}

public PaymentMethod getPaymentMethod(UUID paymentMethodId, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentMethod(paymentMethodId, false, inputOptions);
}

@Deprecated
    public PaymentMethod getPaymentMethod(UUID paymentMethodId, boolean withPluginInfo) throws KillBillClientException
{
        return getPaymentMethod(paymentMethodId, withPluginInfo, RequestOptions.empty());
}

public PaymentMethod getPaymentMethod(UUID paymentMethodId, boolean withPluginInfo, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentMethod(paymentMethodId, withPluginInfo, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public PaymentMethod getPaymentMethod(UUID paymentMethodId, boolean withPluginInfo, AuditLevel auditLevel) throws KillBillClientException
{
        return getPaymentMethod(paymentMethodId, withPluginInfo, auditLevel, RequestOptions.empty());
}

public PaymentMethod getPaymentMethod(UUID paymentMethodId, boolean withPluginInfo, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + paymentMethodId;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, PaymentMethod.class, requestOptions);
    }

    @Deprecated
    public PaymentMethod getPaymentMethodByKey(String externalKey) throws KillBillClientException
{
        return getPaymentMethodByKey(externalKey, RequestOptions.empty());
}

public PaymentMethod getPaymentMethodByKey(String externalKey, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentMethodByKey(externalKey, false, inputOptions);
}

@Deprecated
    public PaymentMethod getPaymentMethodByKey(String externalKey, boolean withPluginInfo) throws KillBillClientException
{
        return getPaymentMethodByKey(externalKey, withPluginInfo, RequestOptions.empty());
}

public PaymentMethod getPaymentMethodByKey(String externalKey, boolean withPluginInfo, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentMethodByKey(externalKey, withPluginInfo, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public PaymentMethod getPaymentMethodByKey(String externalKey, boolean withPluginInfo, AuditLevel auditLevel) throws KillBillClientException
{
        return getPaymentMethodByKey(externalKey, withPluginInfo, auditLevel, RequestOptions.empty());
}

public PaymentMethod getPaymentMethodByKey(String externalKey, boolean withPluginInfo, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_METHODS_PATH;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_EXTERNAL_KEY, externalKey);
    queryParams.put(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, PaymentMethod.class, requestOptions);
    }

    @Deprecated
    public PaymentMethods getPaymentMethodsForAccount(UUID accountId) throws KillBillClientException
{
        return getPaymentMethodsForAccount(accountId, RequestOptions.empty());
}

public PaymentMethods getPaymentMethodsForAccount(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENT_METHODS;
        return httpClient.doGet(uri, PaymentMethods.class, inputOptions);
    }

    @Deprecated
    public PaymentMethods getPaymentMethodsForAccount(UUID accountId, Map<String, String> pluginProperties, boolean withPluginInfo, AuditLevel auditLevel) throws KillBillClientException
{
        return getPaymentMethodsForAccount(accountId, pluginProperties, withPluginInfo, auditLevel, RequestOptions.empty());
}

public PaymentMethods getPaymentMethodsForAccount(UUID accountId, Map<String, String> pluginProperties, boolean withPluginInfo, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENT_METHODS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, PaymentMethods.class, requestOptions);
    }

    @Deprecated
    public PaymentMethods searchPaymentMethodsByKey(String key) throws KillBillClientException
{
        return searchPaymentMethodsByKey(key, RequestOptions.empty());
}

public PaymentMethods searchPaymentMethodsByKey(String key, RequestOptions inputOptions) throws KillBillClientException
{
        return searchPaymentMethodsByKeyAndPlugin(key, null, inputOptions);
}

@Deprecated
    public PaymentMethods searchPaymentMethodsByKey(String key, boolean withPluginInfo) throws KillBillClientException
{
        return searchPaymentMethodsByKey(key, withPluginInfo, RequestOptions.empty());
}

public PaymentMethods searchPaymentMethodsByKey(String key, boolean withPluginInfo, RequestOptions inputOptions) throws KillBillClientException
{
        return searchPaymentMethodsByKeyAndPlugin(key, withPluginInfo, null, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public PaymentMethods searchPaymentMethodsByKeyAndPlugin(String key, @Nullable String pluginName) throws KillBillClientException
{
        return searchPaymentMethodsByKeyAndPlugin(key, pluginName, AuditLevel.NONE, RequestOptions.empty());
}

public PaymentMethods searchPaymentMethodsByKeyAndPlugin(String key, @Nullable String pluginName, RequestOptions inputOptions) throws KillBillClientException
{
        return searchPaymentMethodsByKeyAndPlugin(key, pluginName, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public PaymentMethods searchPaymentMethodsByKeyAndPlugin(String key, @Nullable String pluginName, AuditLevel auditLevel) throws KillBillClientException
{
        return searchPaymentMethodsByKeyAndPlugin(key, pluginName, auditLevel, RequestOptions.empty());
}

public PaymentMethods searchPaymentMethodsByKeyAndPlugin(String key, @Nullable String pluginName, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return searchPaymentMethodsByKeyAndPlugin(key, pluginName != null, pluginName, auditLevel, inputOptions);
}

@Deprecated
    public PaymentMethods searchPaymentMethodsByKeyAndPlugin(String key, boolean withPluginInfo, @Nullable String pluginName, AuditLevel auditLevel) throws KillBillClientException
{
        return searchPaymentMethodsByKeyAndPlugin(key, withPluginInfo, pluginName, auditLevel, RequestOptions.empty());
}

public PaymentMethods searchPaymentMethodsByKeyAndPlugin(String key, boolean withPluginInfo, @Nullable String pluginName, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_PAYMENT_METHOD_PLUGIN_NAME, Strings.nullToEmpty(pluginName));
    queryParams.put(Config.QUERY_WITH_PLUGIN_INFO, String.valueOf(withPluginInfo));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, PaymentMethods.class, requestOptions);
    }

    @Deprecated
    public PaymentMethod createPaymentMethod(PaymentMethod paymentMethod, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createPaymentMethod(paymentMethod, RequestOptions.builder()
                                                                .withCreatedBy(createdBy)
                                                                .withReason(reason)
                                                                .withComment(comment)
                                                                .build());
}

public PaymentMethod createPaymentMethod(PaymentMethod paymentMethod, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(paymentMethod.getAccountId(), "PaymentMethod#accountId cannot be null");
    Preconditions.checkNotNull(paymentMethod.getPluginName(), "PaymentMethod#pluginName cannot be null");

    String uri = Config.ACCOUNTS_PATH + "/" + paymentMethod.getAccountId() + "/" + Config.PAYMENT_METHODS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_PAYMENT_METHOD_IS_DEFAULT, paymentMethod.getIsDefault() ? "true" : "false");

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, paymentMethod, PaymentMethod.class, requestOptions);
    }

    @Deprecated
    public void updateDefaultPaymentMethod(UUID accountId, UUID paymentMethodId, String createdBy, String reason, String comment) throws KillBillClientException
{
    updateDefaultPaymentMethod(accountId, paymentMethodId, RequestOptions.builder()
                                                                             .withCreatedBy(createdBy)
                                                                             .withReason(reason)
                                                                             .withComment(comment)
                                                                             .build());
}

public void updateDefaultPaymentMethod(UUID accountId, UUID paymentMethodId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENT_METHODS + "/" + paymentMethodId + "/" + Config.PAYMENT_METHODS_DEFAULT_PATH_POSTFIX;

    httpClient.doPut(uri, null, inputOptions);
}

@Deprecated
    public void deletePaymentMethod(UUID paymentMethodId, Boolean deleteDefault, String createdBy, String reason, String comment) throws KillBillClientException
{
    deletePaymentMethod(paymentMethodId, deleteDefault, RequestOptions.builder()
                                                                          .withCreatedBy(createdBy)
                                                                          .withReason(reason)
                                                                          .withComment(comment)
                                                                          .build());
}

public void deletePaymentMethod(UUID paymentMethodId, Boolean deleteDefault, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + paymentMethodId;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_DELETE_DEFAULT_PM_WITH_AUTO_PAY_OFF, deleteDefault.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doDelete(uri, requestOptions);
}

@Deprecated
    public void refreshPaymentMethods(UUID accountId, String pluginName, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
    refreshPaymentMethods(accountId, pluginName, pluginProperties, RequestOptions.builder()
                                                                                     .withCreatedBy(createdBy)
                                                                                     .withReason(reason)
                                                                                     .withComment(comment)
                                                                                     .build());
}

public void refreshPaymentMethods(UUID accountId, String pluginName, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.PAYMENT_METHODS + "/refresh";

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
        if (pluginName != null) {
        queryParams.put(Config.QUERY_PAYMENT_METHOD_PLUGIN_NAME, pluginName);
    }
    storePluginPropertiesAsParams(pluginProperties, queryParams);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doPost(uri, null, requestOptions);
}

@Deprecated
    public void refreshPaymentMethods(UUID accountId, Map<String, String> pluginProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
    refreshPaymentMethods(accountId, pluginProperties, RequestOptions.builder()
                                                                         .withCreatedBy(createdBy)
                                                                         .withReason(reason)
                                                                         .withComment(comment)
                                                                         .build());
}

public void refreshPaymentMethods(UUID accountId, Map<String, String> pluginProperties, RequestOptions inputOptions) throws KillBillClientException
{
    refreshPaymentMethods(accountId, null, pluginProperties, inputOptions);
}

// Overdue

@Deprecated
    public void uploadXMLOverdueConfig(String overdueConfigFilePath, String createdBy, String reason, String comment) throws KillBillClientException
{
    uploadXMLOverdueConfig(overdueConfigFilePath, RequestOptions.builder()
                                                                    .withCreatedBy(createdBy)
                                                                    .withReason(reason)
                                                                    .withComment(comment)
                                                                    .build());
}

public void uploadXMLOverdueConfig(String overdueConfigFilePath, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.OVERDUE_PATH;
    uploadFile(overdueConfigFilePath, uri, "application/xml", inputOptions, null);
}

@Deprecated
    public void uploadXMLOverdueConfig(InputStream overdueConfigInputStream, String createdBy, String reason, String comment) throws KillBillClientException
{
    uploadXMLOverdueConfig(overdueConfigInputStream, RequestOptions.builder()
                                                                       .withCreatedBy(createdBy)
                                                                       .withReason(reason)
                                                                       .withComment(comment)
                                                                       .build());
}

public void uploadXMLOverdueConfig(InputStream overdueConfigInputStream, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.OVERDUE_PATH;
    uploadFile(overdueConfigInputStream, uri, "application/xml", inputOptions, null);
}

@Deprecated
    public String getXMLOverdueConfig() throws KillBillClientException
{
        return getXMLOverdueConfig(RequestOptions.empty());
}

public String getXMLOverdueConfig(RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.OVERDUE_PATH;
        return getResourceFile(uri, "application/xml", inputOptions);
}

@Deprecated
    public OverdueState getOverdueStateForAccount(UUID accountId) throws KillBillClientException
{
        return getOverdueStateForAccount(accountId, RequestOptions.empty());
}

public OverdueState getOverdueStateForAccount(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.OVERDUE;

        return httpClient.doGet(uri, OverdueState.class, inputOptions);
    }

    // Tag definitions

    @Deprecated
    public TagDefinitions getTagDefinitions() throws KillBillClientException
{
        return getTagDefinitions(RequestOptions.empty());
}

public TagDefinitions getTagDefinitions(RequestOptions inputOptions) throws KillBillClientException
{
        return httpClient.doGet(Config.TAG_DEFINITIONS_PATH, TagDefinitions.class, inputOptions);
    }

    @Deprecated
    public TagDefinition getTagDefinition(UUID tagDefinitionId) throws KillBillClientException
{
        return getTagDefinition(tagDefinitionId, RequestOptions.empty());
}

public TagDefinition getTagDefinition(UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TAG_DEFINITIONS_PATH + "/" + tagDefinitionId;

        return httpClient.doGet(uri, TagDefinition.class, inputOptions);
    }

    @Deprecated
    public TagDefinition createTagDefinition(TagDefinition tagDefinition, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createTagDefinition(tagDefinition, RequestOptions.builder()
                                                                .withCreatedBy(createdBy)
                                                                .withReason(reason)
                                                                .withComment(comment)
                                                                .build());
}

public TagDefinition createTagDefinition(TagDefinition tagDefinition, RequestOptions inputOptions) throws KillBillClientException
{
    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

        return httpClient.doPost(Config.TAG_DEFINITIONS_PATH, tagDefinition, TagDefinition.class, requestOptions);
    }

    @Deprecated
    public void deleteTagDefinition(UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
    deleteTagDefinition(tagDefinitionId, RequestOptions.builder()
                                                           .withCreatedBy(createdBy)
                                                           .withReason(reason)
                                                           .withComment(comment)
                                                           .build());
}

public void deleteTagDefinition(UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TAG_DEFINITIONS_PATH + "/" + tagDefinitionId;

    httpClient.doDelete(uri, inputOptions);
}

// Tags

@Deprecated
    public Tags getTags() throws KillBillClientException
{
        return getTags(RequestOptions.empty());
}

public Tags getTags(RequestOptions inputOptions) throws KillBillClientException
{
        return getTags(0L, 100L, inputOptions);
}

@Deprecated
    public Tags getTags(long offset, long limit) throws KillBillClientException
{
        return getTags(offset, limit, RequestOptions.empty());
}

public Tags getTags(long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return getTags(offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Tags getTags(long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return getTags(offset, limit, auditLevel, RequestOptions.empty());
}

public Tags getTags(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TAGS_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Tags.class, requestOptions);
    }

    @Deprecated
    public Tags searchTags(String key) throws KillBillClientException
{
        return searchTags(key, RequestOptions.empty());
}

public Tags searchTags(String key, RequestOptions inputOptions) throws KillBillClientException
{
        return searchTags(key, 0L, 100L, inputOptions);
}

@Deprecated
    public Tags searchTags(String key, long offset, long limit) throws KillBillClientException
{
        return searchTags(key, offset, limit, RequestOptions.empty());
}

public Tags searchTags(String key, long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return searchTags(key, offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Tags searchTags(String key, long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return searchTags(key, offset, limit, auditLevel, RequestOptions.empty());
}

public Tags searchTags(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TAGS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Tags.class, requestOptions);
    }

    @Deprecated
    public Tags getAllAccountTags(UUID accountId, String objectType) throws KillBillClientException
{
        return getAllAccountTags(accountId, objectType, RequestOptions.empty());
}

public Tags getAllAccountTags(UUID accountId, String objectType, RequestOptions inputOptions) throws KillBillClientException
{
        return getAllAccountTags(accountId, objectType, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Tags getAllAccountTags(UUID accountId, @Nullable String objectType, AuditLevel auditLevel) throws KillBillClientException
{
        return getAllAccountTags(accountId, objectType, auditLevel, RequestOptions.empty());
}

public Tags getAllAccountTags(UUID accountId, @Nullable String objectType, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.ALL_TAGS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());
        if (objectType != null) {
        queryParams.put(Config.QUERY_OBJECT_TYPE, objectType);
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();
        return httpClient.doGet(uri, Tags.class, requestOptions);
    }

    @Deprecated
    public Tags getAccountTags(UUID accountId) throws KillBillClientException
{
        return getAccountTags(accountId, RequestOptions.empty());
}

public Tags getAccountTags(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
        return getAccountTags(accountId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Tags getAccountTags(UUID accountId, AuditLevel auditLevel) throws KillBillClientException
{
        return getAccountTags(accountId, auditLevel, RequestOptions.empty());
}

public Tags getAccountTags(UUID accountId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getObjectTags(accountId, Config.ACCOUNTS_PATH, auditLevel, inputOptions);
}

@Deprecated
    public Tags createAccountTag(UUID accountId, UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createAccountTag(accountId, tagDefinitionId, RequestOptions.builder()
                                                                          .withCreatedBy(createdBy)
                                                                          .withReason(reason)
                                                                          .withComment(comment)
                                                                          .build());
}

public Tags createAccountTag(UUID accountId, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
        return createObjectTag(accountId, Config.ACCOUNTS_PATH, tagDefinitionId, inputOptions);
}

@Deprecated
    public void deleteAccountTag(UUID accountId, UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
    deleteAccountTag(accountId, tagDefinitionId, RequestOptions.builder()
                                                                   .withCreatedBy(createdBy)
                                                                   .withReason(reason)
                                                                   .withComment(comment)
                                                                   .build());
}

public void deleteAccountTag(UUID accountId, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
    deleteObjectTag(accountId, Config.ACCOUNTS_PATH, tagDefinitionId, inputOptions);
}

@Deprecated
    public Tags getBundleTags(UUID bundleId) throws KillBillClientException
{
        return getBundleTags(bundleId, RequestOptions.empty());
}

public Tags getBundleTags(UUID bundleId, RequestOptions inputOptions) throws KillBillClientException
{
        return getBundleTags(bundleId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Tags getBundleTags(UUID bundleId, AuditLevel auditLevel) throws KillBillClientException
{
        return getBundleTags(bundleId, auditLevel, RequestOptions.empty());
}

public Tags getBundleTags(UUID bundleId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getObjectTags(bundleId, Config.BUNDLES_PATH, auditLevel, inputOptions);
}

@Deprecated
    public Tags createBundleTag(UUID bundleId, UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createBundleTag(bundleId, tagDefinitionId, RequestOptions.builder()
                                                                        .withCreatedBy(createdBy)
                                                                        .withReason(reason)
                                                                        .withComment(comment)
                                                                        .build());
}

public Tags createBundleTag(UUID bundleId, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
        return createObjectTag(bundleId, Config.BUNDLES_PATH, tagDefinitionId, inputOptions);
}

@Deprecated
    public void deleteBundleTag(UUID bundleId, UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
    deleteBundleTag(bundleId, tagDefinitionId, RequestOptions.builder()
                                                                 .withCreatedBy(createdBy)
                                                                 .withReason(reason)
                                                                 .withComment(comment)
                                                                 .build());
}

public void deleteBundleTag(UUID bundleId, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
    deleteObjectTag(bundleId, Config.BUNDLES_PATH, tagDefinitionId, inputOptions);
}

@Deprecated
    public Tags getSubscriptionTags(UUID subscriptionId) throws KillBillClientException
{
        return getSubscriptionTags(subscriptionId, RequestOptions.empty());
}

public Tags getSubscriptionTags(UUID subscriptionId, RequestOptions inputOptions) throws KillBillClientException
{
        return getSubscriptionTags(subscriptionId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Tags getSubscriptionTags(UUID subscriptionId, AuditLevel auditLevel) throws KillBillClientException
{
        return getSubscriptionTags(subscriptionId, auditLevel, RequestOptions.empty());
}

public Tags getSubscriptionTags(UUID subscriptionId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getObjectTags(subscriptionId, Config.SUBSCRIPTIONS_PATH, auditLevel, inputOptions);
}

@Deprecated
    public Tags createSubscriptionTag(UUID subscriptionId, UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createSubscriptionTag(subscriptionId, tagDefinitionId, RequestOptions.builder()
                                                                                    .withCreatedBy(createdBy)
                                                                                    .withReason(reason)
                                                                                    .withComment(comment)
                                                                                    .build());
}

public Tags createSubscriptionTag(UUID subscriptionId, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
        return createObjectTag(subscriptionId, Config.SUBSCRIPTIONS_PATH, tagDefinitionId, inputOptions);
}

@Deprecated
    public void deleteSubscriptionTag(UUID subscriptionId, UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
    deleteSubscriptionTag(subscriptionId, tagDefinitionId, RequestOptions.builder()
                                                                             .withCreatedBy(createdBy)
                                                                             .withReason(reason)
                                                                             .withComment(comment)
                                                                             .build());
}

public void deleteSubscriptionTag(UUID subscriptionId, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
    deleteObjectTag(subscriptionId, Config.SUBSCRIPTIONS_PATH, tagDefinitionId, inputOptions);
}

@Deprecated
    public Tags getInvoiceTags(UUID invoiceId) throws KillBillClientException
{
        return getInvoiceTags(invoiceId, RequestOptions.empty());
}

public Tags getInvoiceTags(UUID invoiceId, RequestOptions inputOptions) throws KillBillClientException
{
        return getInvoiceTags(invoiceId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Tags getInvoiceTags(UUID invoiceId, AuditLevel auditLevel) throws KillBillClientException
{
        return getInvoiceTags(invoiceId, auditLevel, RequestOptions.empty());
}

public Tags getInvoiceTags(UUID invoiceId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getObjectTags(invoiceId, Config.INVOICES_PATH, auditLevel, inputOptions);
}

@Deprecated
    public Tags createInvoiceTag(UUID invoiceId, UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createInvoiceTag(invoiceId, tagDefinitionId, RequestOptions.builder()
                                                                          .withCreatedBy(createdBy)
                                                                          .withReason(reason)
                                                                          .withComment(comment)
                                                                          .build());
}

public Tags createInvoiceTag(UUID invoiceId, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
        return createObjectTag(invoiceId, Config.INVOICES_PATH, tagDefinitionId, inputOptions);
}

@Deprecated
    public void deleteInvoiceTag(UUID invoiceId, UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
    deleteInvoiceTag(invoiceId, tagDefinitionId, RequestOptions.builder()
                                                                   .withCreatedBy(createdBy)
                                                                   .withReason(reason)
                                                                   .withComment(comment)
                                                                   .build());
}

public void deleteInvoiceTag(UUID invoiceId, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
    deleteObjectTag(invoiceId, Config.INVOICES_PATH, tagDefinitionId, inputOptions);
}

@Deprecated
    public Tags getPaymentTags(UUID paymentId) throws KillBillClientException
{
        return getPaymentTags(paymentId, RequestOptions.empty());
}

public Tags getPaymentTags(UUID paymentId, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentTags(paymentId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public Tags getPaymentTags(UUID paymentId, AuditLevel auditLevel) throws KillBillClientException
{
        return getPaymentTags(paymentId, auditLevel, RequestOptions.empty());
}

public Tags getPaymentTags(UUID paymentId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
        return getObjectTags(paymentId, Config.PAYMENTS_PATH, auditLevel, inputOptions);
}

@Deprecated
    public Tags createPaymentTag(UUID paymentId, UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createPaymentTag(paymentId, tagDefinitionId, RequestOptions.builder()
                                                                          .withCreatedBy(createdBy)
                                                                          .withReason(reason)
                                                                          .withComment(comment)
                                                                          .build());
}

public Tags createPaymentTag(UUID paymentId, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
        return createObjectTag(paymentId, Config.PAYMENTS_PATH, tagDefinitionId, inputOptions);
}

@Deprecated
    public void deletePaymentTag(UUID paymentId, UUID tagDefinitionId, String createdBy, String reason, String comment) throws KillBillClientException
{
    deletePaymentTag(paymentId, tagDefinitionId, RequestOptions.builder()
                                                                   .withCreatedBy(createdBy)
                                                                   .withReason(reason)
                                                                   .withComment(comment)
                                                                   .build());
}

public void deletePaymentTag(UUID paymentId, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
    deleteObjectTag(paymentId, Config.PAYMENTS_PATH, tagDefinitionId, inputOptions);
}

private Tags getObjectTags(UUID objectId, String resourcePathPrefix, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = resourcePathPrefix + "/" + objectId + "/" + Config.TAGS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, Tags.class, requestOptions);
    }

    private Tags createObjectTag(UUID objectId, String resourcePathPrefix, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = resourcePathPrefix + "/" + objectId + "/" + Config.TAGS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_TAGS, tagDefinitionId.toString());

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, null, Tags.class, requestOptions);
    }

    private void deleteObjectTag(UUID objectId, String resourcePathPrefix, UUID tagDefinitionId, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = resourcePathPrefix + "/" + objectId + "/" + Config.TAGS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_TAGS, tagDefinitionId.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doDelete(uri, requestOptions);
}

// Custom fields

@Deprecated
    public CustomFields getCustomFields() throws KillBillClientException
{
        return getCustomFields(RequestOptions.empty());
}

public CustomFields getCustomFields(RequestOptions inputOptions) throws KillBillClientException
{
        return getCustomFields(0L, 100L, inputOptions);
}

@Deprecated
    public CustomFields getCustomFields(long offset, long limit) throws KillBillClientException
{
        return getCustomFields(offset, limit, RequestOptions.empty());
}

public CustomFields getCustomFields(long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return getCustomFields(offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public CustomFields getCustomFields(long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return getCustomFields(offset, limit, auditLevel, RequestOptions.empty());
}

public CustomFields getCustomFields(long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.CUSTOM_FIELDS_PATH + "/" + Config.PAGINATION;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, CustomFields.class, requestOptions);
    }

    @Deprecated
    public CustomFields searchCustomFields(String key) throws KillBillClientException
{
        return searchCustomFields(key, RequestOptions.empty());
}

public CustomFields searchCustomFields(String key, RequestOptions inputOptions) throws KillBillClientException
{
        return searchCustomFields(key, 0L, 100L, inputOptions);
}

@Deprecated
    public CustomFields searchCustomFields(String key, long offset, long limit) throws KillBillClientException
{
        return searchCustomFields(key, offset, limit, RequestOptions.empty());
}

public CustomFields searchCustomFields(String key, long offset, long limit, RequestOptions inputOptions) throws KillBillClientException
{
        return searchCustomFields(key, offset, limit, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public CustomFields searchCustomFields(String key, long offset, long limit, AuditLevel auditLevel) throws KillBillClientException
{
        return searchCustomFields(key, offset, limit, auditLevel, RequestOptions.empty());
}

public CustomFields searchCustomFields(String key, long offset, long limit, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.CUSTOM_FIELDS_PATH + "/" + Config.SEARCH + "/" + UTF8UrlEncoder.encode(key);

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_SEARCH_OFFSET, String.valueOf(offset));
    queryParams.put(Config.QUERY_SEARCH_LIMIT, String.valueOf(limit));
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, CustomFields.class, requestOptions);
    }

    @Deprecated
    public CustomFields getAccountCustomFields(UUID accountId) throws KillBillClientException
{
        return getAccountCustomFields(accountId, RequestOptions.empty());
}

public CustomFields getAccountCustomFields(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
        return getAccountCustomFields(accountId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public CustomFields getAccountCustomFields(UUID accountId, AuditLevel auditLevel) throws KillBillClientException
{
        return getAccountCustomFields(accountId, auditLevel, RequestOptions.empty());
}

public CustomFields getAccountCustomFields(UUID accountId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.CUSTOM_FIELDS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, CustomFields.class, requestOptions);
    }

    @Deprecated
    public CustomFields createAccountCustomField(UUID accountId, CustomField customField, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createAccountCustomField(accountId, customField, RequestOptions.builder()
                                                                              .withCreatedBy(createdBy)
                                                                              .withReason(reason)
                                                                              .withComment(comment)
                                                                              .build());
}

public CustomFields createAccountCustomField(UUID accountId, CustomField customField, RequestOptions inputOptions) throws KillBillClientException
{
        return createAccountCustomFields(accountId, ImmutableList.<CustomField>of(customField), inputOptions);
}

@Deprecated
    public CustomFields createAccountCustomFields(UUID accountId, Iterable<CustomField> customFields, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createAccountCustomFields(accountId, customFields, RequestOptions.builder()
                                                                                .withCreatedBy(createdBy)
                                                                                .withReason(reason)
                                                                                .withComment(comment)
                                                                                .build());
}

public CustomFields createAccountCustomFields(UUID accountId, Iterable<CustomField> customFields, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.CUSTOM_FIELDS;

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, customFields, CustomFields.class, requestOptions);
    }

    @Deprecated
    public void deleteAccountCustomField(UUID accountId, UUID customFieldId, String createdBy, String reason, String comment) throws KillBillClientException
{
    deleteAccountCustomField(accountId, customFieldId, RequestOptions.builder()
                                                                         .withCreatedBy(createdBy)
                                                                         .withReason(reason)
                                                                         .withComment(comment)
                                                                         .build());
}

public void deleteAccountCustomField(UUID accountId, UUID customFieldId, RequestOptions inputOptions) throws KillBillClientException
{
    deleteAccountCustomFields(accountId, ImmutableList.<UUID>of(customFieldId), inputOptions);
}

@Deprecated
    public void deleteAccountCustomFields(UUID accountId, String createdBy, String reason, String comment) throws KillBillClientException
{
    deleteAccountCustomFields(accountId, RequestOptions.builder()
                                                           .withCreatedBy(createdBy)
                                                           .withReason(reason)
                                                           .withComment(comment)
                                                           .build());
}

public void deleteAccountCustomFields(UUID accountId, RequestOptions inputOptions) throws KillBillClientException
{
    deleteAccountCustomFields(accountId, null, inputOptions);
}

@Deprecated
    public void deleteAccountCustomFields(UUID accountId, @Nullable Iterable<UUID> customFieldIds, String createdBy, String reason, String comment) throws KillBillClientException
{
    deleteAccountCustomFields(accountId, customFieldIds, RequestOptions.builder()
                                                                           .withCreatedBy(createdBy)
                                                                           .withReason(reason)
                                                                           .withComment(comment)
                                                                           .build());
}

public void deleteAccountCustomFields(UUID accountId, @Nullable Iterable<UUID> customFieldIds, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.ACCOUNTS_PATH + "/" + accountId + "/" + Config.CUSTOM_FIELDS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
        if (customFieldIds != null) {
        queryParams.put(Config.QUERY_CUSTOM_FIELDS, Joiner.on(",").join(customFieldIds));
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doDelete(uri, requestOptions);
}

@Deprecated
    public CustomFields getPaymentMethodCustomFields(UUID paymentMethodId) throws KillBillClientException
{
        return getPaymentMethodCustomFields(paymentMethodId, RequestOptions.empty());
}

public CustomFields getPaymentMethodCustomFields(UUID paymentMethodId, RequestOptions inputOptions) throws KillBillClientException
{
        return getPaymentMethodCustomFields(paymentMethodId, AuditLevel.NONE, inputOptions);
}

@Deprecated
    public CustomFields getPaymentMethodCustomFields(UUID paymentMethodId, AuditLevel auditLevel) throws KillBillClientException
{
        return getPaymentMethodCustomFields(paymentMethodId, auditLevel, RequestOptions.empty());
}

public CustomFields getPaymentMethodCustomFields(UUID paymentMethodId, AuditLevel auditLevel, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + paymentMethodId + "/" + Config.CUSTOM_FIELDS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_AUDIT, auditLevel.toString());

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, CustomFields.class, requestOptions);
    }

    @Deprecated
    public CustomFields createPaymentMethodCustomField(UUID paymentMethodId, CustomField customField, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createPaymentMethodCustomField(paymentMethodId, customField, RequestOptions.builder()
                                                                                          .withCreatedBy(createdBy)
                                                                                          .withReason(reason)
                                                                                          .withComment(comment)
                                                                                          .build());
}

public CustomFields createPaymentMethodCustomField(UUID paymentMethodId, CustomField customField, RequestOptions inputOptions) throws KillBillClientException
{
        return createPaymentMethodCustomFields(paymentMethodId, ImmutableList.of(customField), inputOptions);
}

@Deprecated
    public CustomFields createPaymentMethodCustomFields(UUID paymentMethodId, Iterable<CustomField> customFields, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createPaymentMethodCustomFields(paymentMethodId, customFields, RequestOptions.builder()
                                                                                            .withCreatedBy(createdBy)
                                                                                            .withReason(reason)
                                                                                            .withComment(comment)
                                                                                            .build());
}

public CustomFields createPaymentMethodCustomFields(UUID paymentMethodId, Iterable<CustomField> customFields, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + paymentMethodId + "/" + Config.CUSTOM_FIELDS;

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, customFields, CustomFields.class, requestOptions);
    }

    @Deprecated
    public void deletePaymentMethodCustomFields(UUID paymentMethodId, String createdBy, String reason, String comment) throws KillBillClientException
{
    deletePaymentMethodCustomFields(paymentMethodId, RequestOptions.builder()
                                                                       .withCreatedBy(createdBy)
                                                                       .withReason(reason)
                                                                       .withComment(comment)
                                                                       .build());
}

public void deletePaymentMethodCustomFields(UUID paymentMethodId, RequestOptions inputOptions) throws KillBillClientException
{
    deletePaymentMethodCustomFields(paymentMethodId, null, inputOptions);
}

@Deprecated
    public void deletePaymentMethodCustomFields(UUID paymentMethodId, @Nullable Iterable<UUID> customFieldIds, String createdBy, String reason, String comment) throws KillBillClientException
{
    deletePaymentMethodCustomFields(paymentMethodId, customFieldIds, RequestOptions.builder()
                                                                                       .withCreatedBy(createdBy)
                                                                                       .withReason(reason)
                                                                                       .withComment(comment)
                                                                                       .build());
}

public void deletePaymentMethodCustomFields(UUID paymentMethodId, @Nullable Iterable<UUID> customFieldIds, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.PAYMENT_METHODS_PATH + "/" + paymentMethodId + "/" + Config.CUSTOM_FIELDS;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
        if (customFieldIds != null) {
        queryParams.put(Config.QUERY_CUSTOM_FIELDS, Joiner.on(",").join(customFieldIds));
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    httpClient.doDelete(uri, requestOptions);
}

// Catalog

@Deprecated
    public List<PlanDetail> getAvailableAddons(String baseProductName) throws KillBillClientException
{
        return getAvailableAddons(baseProductName, RequestOptions.empty());
}

public List<PlanDetail> getAvailableAddons(String baseProductName, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.CATALOG_PATH + "/availableAddons";

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put("baseProductName", baseProductName);

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

        return httpClient.doGet(uri, PlanDetails.class, requestOptions);
    }

    @Deprecated
    public List<PlanDetail> getBasePlans() throws KillBillClientException
{
        return getBasePlans(RequestOptions.empty());
}

public List<PlanDetail> getBasePlans(RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.CATALOG_PATH + "/availableBasePlans";

        return httpClient.doGet(uri, PlanDetails.class, inputOptions);
    }

    @Deprecated
    public void uploadXMLCatalog(String catalogFilePath, String createdBy, String reason, String comment) throws KillBillClientException
{
    uploadXMLCatalog(catalogFilePath, RequestOptions.builder()
                                                        .withCreatedBy(createdBy)
                                                        .withReason(reason)
                                                        .withComment(comment)
                                                        .build());
}

public void uploadXMLCatalog(String catalogFilePath, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.CATALOG_PATH;
    uploadFile(catalogFilePath, uri, CONTENT_TYPE_XML, inputOptions, null);
}

@Deprecated
    public void uploadXMLCatalog(InputStream catalogInputStream, String createdBy, String reason, String comment) throws KillBillClientException
{
    uploadXMLCatalog(catalogInputStream, RequestOptions.builder()
                                                           .withCreatedBy(createdBy)
                                                           .withReason(reason)
                                                           .withComment(comment)
                                                           .build());
}

public void uploadXMLCatalog(InputStream catalogInputStream, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.CATALOG_PATH;
    uploadFile(catalogInputStream, uri, CONTENT_TYPE_XML, inputOptions, null);
}

@Deprecated
    public Catalog getJSONCatalog() throws KillBillClientException
{
        return getJSONCatalog(RequestOptions.empty());
}

public Catalog getJSONCatalog(RequestOptions inputOptions) throws KillBillClientException
{
        return this.getJSONCatalog(null, inputOptions);
}

@Deprecated
    public Catalog getJSONCatalog(DateTime requestedDate) throws KillBillClientException
{
        return getJSONCatalog(requestedDate, RequestOptions.empty());
}

public Catalog getJSONCatalog(DateTime requestedDate, RequestOptions inputOptions) throws KillBillClientException
{
    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
        if (requestedDate != null) {
        queryParams.put(Config.QUERY_REQUESTED_DT, requestedDate.toDateTimeISO().toString());
    }

    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).build();

    String uri = Config.CATALOG_PATH;
        return httpClient.doGet(uri, Catalog.class, requestOptions);
    }

    @Deprecated
    public String getXMLCatalog() throws KillBillClientException
{
        return getXMLCatalog(RequestOptions.empty());
}

public String getXMLCatalog(RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.CATALOG_PATH;
        return getResourceFile(uri, ACCEPT_XML, inputOptions);
}

// Tenants

@Deprecated
    public Tenant createTenant(Tenant tenant, String createdBy, String reason, String comment) throws KillBillClientException
{
        return createTenant(tenant, RequestOptions.builder()
                                                  .withCreatedBy(createdBy)
                                                  .withReason(reason)
                                                  .withComment(comment)
                                                  .build());
}

public Tenant createTenant(Tenant tenant, RequestOptions inputOptions) throws KillBillClientException
{
    Preconditions.checkNotNull(tenant.getApiKey(), "Tenant#apiKey cannot be null");
    Preconditions.checkNotNull(tenant.getApiSecret(), "Tenant#apiSecret cannot be null");

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withFollowLocation(followLocation).build();

        return httpClient.doPost(Config.TENANTS_PATH, tenant, Tenant.class, requestOptions);
    }

    @Deprecated
    public TenantKey registerCallbackNotificationForTenant(String callback, String createdBy, String reason, String comment) throws KillBillClientException
{
        return registerCallbackNotificationForTenant(callback, RequestOptions.builder()
                                                                             .withCreatedBy(createdBy)
                                                                             .withReason(reason)
                                                                             .withComment(comment)
                                                                             .build());
}

public TenantKey registerCallbackNotificationForTenant(String callback, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.REGISTER_NOTIFICATION_CALLBACK;

    Multimap<String, String> queryParams = HashMultimap.<String, String>create(inputOptions.getQueryParams());
    queryParams.put(Config.QUERY_NOTIFICATION_CALLBACK, callback);

    Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
    RequestOptions requestOptions = inputOptions.extend().withQueryParams(queryParams).withFollowLocation(followLocation).build();

        return httpClient.doPost(uri, null, TenantKey.class, requestOptions);
    }

    @Deprecated
    public TenantKey getCallbackNotificationForTenant() throws KillBillClientException
{
        return getCallbackNotificationForTenant(RequestOptions.empty());
}

public TenantKey getCallbackNotificationForTenant(RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.REGISTER_NOTIFICATION_CALLBACK;
        return httpClient.doGet(uri, TenantKey.class, inputOptions);
    }

    @Deprecated
    public void unregisterCallbackNotificationForTenant(String createdBy, String reason, String comment) throws KillBillClientException
{
    unregisterCallbackNotificationForTenant(RequestOptions.builder()
                                                              .withCreatedBy(createdBy)
                                                              .withReason(reason)
                                                              .withComment(comment)
                                                              .build());
}

public void unregisterCallbackNotificationForTenant(RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.REGISTER_NOTIFICATION_CALLBACK;

    httpClient.doDelete(uri, inputOptions);
}

@Deprecated
    public TenantKey registerPluginConfigurationForTenant(String pluginName, String pluginConfigFilePath, String createdBy, String reason, String comment) throws KillBillClientException
{
        return registerPluginConfigurationForTenant(pluginName, pluginConfigFilePath, RequestOptions.builder()
                                                                                                    .withCreatedBy(createdBy)
                                                                                                    .withReason(reason)
                                                                                                    .withComment(comment)
                                                                                                    .build());
}

public TenantKey registerPluginConfigurationForTenant(String pluginName, String pluginConfigFilePath, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_CONFIG + "/" + pluginName;
        return uploadFile(pluginConfigFilePath, uri, "text/plain", inputOptions, TenantKey.class);
    }

    @Deprecated
    public TenantKey registerPluginConfigurationForTenant(String pluginName, InputStream pluginConfigInputStream, String createdBy, String reason, String comment) throws KillBillClientException
{
        return registerPluginConfigurationForTenant(pluginName, pluginConfigInputStream, RequestOptions.builder()
                                                                                                       .withCreatedBy(createdBy)
                                                                                                       .withReason(reason)
                                                                                                       .withComment(comment)
                                                                                                       .build());
}

public TenantKey registerPluginConfigurationForTenant(String pluginName, InputStream pluginConfigInputStream, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_CONFIG + "/" + pluginName;
        return uploadFile(pluginConfigInputStream, uri, "text/plain", inputOptions, TenantKey.class);
    }

    @Deprecated
    public TenantKey postPluginConfigurationPropertiesForTenant(String pluginName, String pluginConfigProperties, String createdBy, String reason, String comment) throws KillBillClientException
{
    RequestOptions options = RequestOptions.builder()
                                                     .withCreatedBy(createdBy)
                                                     .withReason(reason)
                                                     .withComment(comment)
                                                     .build();
        return postPluginConfigurationPropertiesForTenant(pluginName, pluginConfigProperties, options);
}

public TenantKey postPluginConfigurationPropertiesForTenant(String pluginName, String pluginConfigProperties, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_CONFIG + "/" + pluginName;

    RequestOptions options = inputOptions.extend()
                                                   .withFollowLocation(true)
                                                   .withHeader(KillBillHttpClient.HTTP_HEADER_CONTENT_TYPE, "text/plain")
                                                   .build();
        return httpClient.doPost(uri, pluginConfigProperties, TenantKey.class, options);
    }

    @Deprecated
    public TenantKey getPluginConfigurationForTenant(String pluginName) throws KillBillClientException
{
        return getPluginConfigurationForTenant(pluginName, RequestOptions.empty());
}

public TenantKey getPluginConfigurationForTenant(String pluginName, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_CONFIG + "/" + pluginName;
        return httpClient.doGet(uri, TenantKey.class, inputOptions);
    }

    @Deprecated
    public void unregisterPluginConfigurationForTenant(String pluginName, String createdBy, String reason, String comment) throws KillBillClientException
{
    unregisterPluginConfigurationForTenant(pluginName, RequestOptions.builder()
                                                                         .withCreatedBy(createdBy)
                                                                         .withReason(reason)
                                                                         .withComment(comment)
                                                                         .build());
}

public void unregisterPluginConfigurationForTenant(String pluginName, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_CONFIG + "/" + pluginName;
    httpClient.doDelete(uri, inputOptions);
}

public TenantKey registerPluginPaymentStateMachineConfigurationForTenant(String pluginName, String pluginPaymentStateMachineConfigFilePath, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG + "/" + pluginName;
        return uploadFile(pluginPaymentStateMachineConfigFilePath, uri, "text/plain", inputOptions, TenantKey.class);
    }

    public TenantKey registerPluginPaymentStateMachineConfigurationForTenant(String pluginName, InputStream pluginPaymentStateMachineConfigInputStream, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG + "/" + pluginName;
        return uploadFile(pluginPaymentStateMachineConfigInputStream, uri, "text/plain", inputOptions, TenantKey.class);
    }

    public TenantKey postPluginPaymentStateMachineConfigurationXMLForTenant(String pluginName, String pluginPaymentStateMachineConfigXML, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG + "/" + pluginName;

    RequestOptions options = inputOptions.extend()
                                                   .withFollowLocation(true)
                                                   .withHeader(KillBillHttpClient.HTTP_HEADER_CONTENT_TYPE, "text/plain")
                                                   .build();
        return httpClient.doPost(uri, pluginPaymentStateMachineConfigXML, TenantKey.class, options);
    }

    public TenantKey getPluginPaymentStateMachineConfigurationForTenant(String pluginName, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG + "/" + pluginName;
        return httpClient.doGet(uri, TenantKey.class, inputOptions);
    }

    public void unregisterPluginPaymentStateMachineConfigurationForTenant(String pluginName, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.TENANTS_PATH + "/" + Config.UPLOAD_PLUGIN_PAYMENT_STATE_MACHINE_CONFIG + "/" + pluginName;
    httpClient.doDelete(uri, inputOptions);
}

@Deprecated
    public Permissions getPermissions() throws KillBillClientException
{
        return getPermissions(RequestOptions.empty());
}

public Permissions getPermissions(RequestOptions inputOptions) throws KillBillClientException
{
        return httpClient.doGet(Config.SECURITY_PATH + "/permissions", Permissions.class, inputOptions);
    }

    @Deprecated
    public Response addUserRoles(UserRoles userRoles, String createdBy, String reason, String comment) throws KillBillClientException
{
        return addUserRoles(userRoles, RequestOptions.builder()
                                                     .withCreatedBy(createdBy)
                                                     .withReason(reason)
                                                     .withComment(comment)
                                                     .build());
}

public Response addUserRoles(UserRoles userRoles, RequestOptions inputOptions) throws KillBillClientException
{
        return httpClient.doPost(Config.SECURITY_PATH + "/users", userRoles, inputOptions);
}

@Deprecated
    public Response updateUserPassword(String username, String newPassword, String createdBy, String reason, String comment) throws KillBillClientException
{
        return updateUserPassword(username, newPassword, RequestOptions.builder()
                                                                       .withCreatedBy(createdBy)
                                                                       .withReason(reason)
                                                                       .withComment(comment)
                                                                       .build());
}

public Response updateUserPassword(String username, String newPassword, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.SECURITY_PATH + "/users/" + username + "/password";
    UserRoles userRoles = new UserRoles(username, newPassword, ImmutableList.<String>of());
        return httpClient.doPut(uri, userRoles, inputOptions);
    }

    @Deprecated
    public Response updateUserRoles(String username, List<String> newRoles, String createdBy, String reason, String comment) throws KillBillClientException
{
        return updateUserRoles(username, newRoles, RequestOptions.builder()
                                                                 .withCreatedBy(createdBy)
                                                                 .withReason(reason)
                                                                 .withComment(comment)
                                                                 .build());
}

public Response updateUserRoles(String username, List<String> newRoles, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.SECURITY_PATH + "/users/" + username + "/roles";
    UserRoles userRoles = new UserRoles(username, null, newRoles);
        return httpClient.doPut(uri, userRoles, inputOptions);
    }

    @Deprecated
    public Response invalidateUser(String username, String createdBy, String reason, String comment) throws KillBillClientException
{
        return invalidateUser(username, RequestOptions.builder()
                                                      .withCreatedBy(createdBy)
                                                      .withReason(reason)
                                                      .withComment(comment)
                                                      .build());
}

public Response invalidateUser(String username, RequestOptions inputOptions) throws KillBillClientException
{
    String uri = Config.SECURITY_PATH + "/users/" + username;
        return httpClient.doDelete(uri, inputOptions);
}

@Deprecated
    public Response addRoleDefinition(RoleDefinition roleDefinition, String createdBy, String reason, String comment) throws KillBillClientException
{
        return addRoleDefinition(roleDefinition, RequestOptions.builder()
                                                               .withCreatedBy(createdBy)
                                                               .withReason(reason)
                                                               .withComment(comment)
                                                               .build());
}

public Response addRoleDefinition(RoleDefinition roleDefinition, RequestOptions inputOptions) throws KillBillClientException
{
        return httpClient.doPost(Config.SECURITY_PATH + "/roles", roleDefinition, inputOptions);
}

// Plugin endpoints

@Deprecated
    public Response pluginGET(String uri) throws Exception
{
        return pluginGET(uri, RequestOptions.empty());
}

@Deprecated
    public Response pluginGET(String uri, Multimap<String, String> queryParams) throws Exception
{
        return pluginGET(uri, RequestOptions.builder().withQueryParams(queryParams).build());
}

public Response pluginGET(String uri, RequestOptions inputOptions) throws Exception
{
        return httpClient.doGet(Config.PLUGINS_PATH + "/" + uri, inputOptions);
}

@Deprecated
    public Response pluginHEAD(String uri) throws Exception
{
        return pluginHEAD(uri, RequestOptions.empty());
}

@Deprecated
    public Response pluginHEAD(String uri, Multimap<String, String> queryParams) throws Exception
{
        return pluginHEAD(uri, RequestOptions.builder().withQueryParams(queryParams).build());
}

public Response pluginHEAD(String uri, RequestOptions inputOptions) throws Exception
{
        return httpClient.doHead(Config.PLUGINS_PATH + "/" + uri, inputOptions);
}

@Deprecated
    public Response pluginPOST(String uri, @Nullable String body) throws Exception
{
        return pluginPOST(uri, body, RequestOptions.empty());
}

@Deprecated
    public Response pluginPOST(String uri, @Nullable String body, Multimap<String, String> queryParams) throws Exception
{
        return pluginPOST(uri, body, RequestOptions.builder().withQueryParams(queryParams).build());
}

public Response pluginPOST(String uri, @Nullable String body, RequestOptions inputOptions) throws Exception
{
        return httpClient.doPost(Config.PLUGINS_PATH + "/" + uri, body, inputOptions);
}

@Deprecated
    public Response pluginPUT(String uri, @Nullable String body) throws Exception
{
        return pluginPUT(uri, body, RequestOptions.empty());
}

@Deprecated
    public Response pluginPUT(String uri, @Nullable String body, Multimap<String, String> queryParams) throws Exception
{
        return pluginPUT(uri, body, RequestOptions.builder().withQueryParams(queryParams).build());
}

public Response pluginPUT(String uri, @Nullable String body, RequestOptions inputOptions) throws Exception
{
        return httpClient.doPut(Config.PLUGINS_PATH + "/" + uri, body, inputOptions);
}

@Deprecated
    public Response pluginDELETE(String uri) throws Exception
{
        return pluginDELETE(uri, RequestOptions.empty());
}

@Deprecated
    public Response pluginDELETE(String uri, Multimap<String, String> queryParams) throws Exception
{
        return pluginDELETE(uri, RequestOptions.builder().withQueryParams(queryParams).build());
}

public Response pluginDELETE(String uri, RequestOptions inputOptions) throws Exception
{
        return httpClient.doDelete(Config.PLUGINS_PATH + "/" + uri, inputOptions);
}

@Deprecated
    public Response pluginOPTIONS(String uri) throws Exception
{
        return pluginOPTIONS(uri, RequestOptions.empty());
}

@Deprecated
    public Response pluginOPTIONS(String uri, Multimap<String, String> queryParams) throws Exception
{
        return pluginOPTIONS(uri, RequestOptions.builder().withQueryParams(queryParams).build());
}

public Response pluginOPTIONS(String uri, RequestOptions inputOptions) throws Exception
{
        return httpClient.doOptions(Config.PLUGINS_PATH + "/" + uri, inputOptions);
}

// Utilities

private String getResourceFile(String uri, String contentType, RequestOptions inputOptions) throws KillBillClientException
{
    RequestOptions requestOptions = inputOptions.extend().withHeader(KillBillHttpClient.HTTP_HEADER_ACCEPT, contentType).build();
    Response response = httpClient.doGet(uri, requestOptions);
        try {
        return response.getResponseBody("UTF-8");
    } catch (IOException e) {
        throw new KillBillClientException(e);
    }
}

private <ReturnType> ReturnType uploadFile(String fileToUpload, String uri, String contentType, RequestOptions inputOptions, Class<ReturnType> followUpClass) throws KillBillClientException
{
    Preconditions.checkNotNull(fileToUpload, "fileToUpload cannot be null");
    File catalogFile = new File(fileToUpload);
Preconditions.checkArgument(catalogFile.exists() && catalogFile.isFile() && catalogFile.canRead(), "file to upload needs to be a valid file");
        try {
            String body = Files.toString(catalogFile, Charset.forName("UTF-8"));
            return doUploadFile(body, uri, contentType, inputOptions, followUpClass);
        } catch (IOException e) {
            throw new KillBillClientException(e);
        }
    }

    private <ReturnType> ReturnType uploadFile(InputStream fileToUpload, String uri, String contentType, RequestOptions inputOptions, Class<ReturnType> followUpClass) throws KillBillClientException
{
    Preconditions.checkNotNull(fileToUpload, "fileToUpload cannot be null");
        try {
        Readable reader = new InputStreamReader(fileToUpload, Charset.forName("UTF-8"));
        String body = CharStreams.toString(reader);
        return doUploadFile(body, uri, contentType, inputOptions, followUpClass);
    } catch (IOException e) {
        throw new KillBillClientException(e);
    }
}

private <ReturnType> ReturnType doUploadFile(String body, String uri, String contentType, RequestOptions inputOptions, Class<ReturnType> followUpClass) throws KillBillClientException
{
    RequestOptionsBuilder requestOptionsBuilder = inputOptions.extend().withHeader(KillBillHttpClient.HTTP_HEADER_CONTENT_TYPE, contentType);

        if (followUpClass != null) {
        Boolean followLocation = MoreObjects.firstNonNull(inputOptions.getFollowLocation(), Boolean.TRUE);
        RequestOptions requestOptions = requestOptionsBuilder.withFollowLocation(followLocation).build();
        return httpClient.doPost(uri, body, followUpClass, requestOptions);
    } else {
        RequestOptions requestOptions = requestOptionsBuilder.build();
        httpClient.doPost(uri, body, requestOptions);
        return null;
    }
}

private void storePluginPropertiesAsParams(Map<String, String> pluginProperties, Multimap<String, String> params)
{
    for (String key : pluginProperties.keySet())
    {
            params.put(Config.QUERY_PLUGIN_PROPERTY, String.format("%s=%s", UTF8UrlEncoder.encode(key), UTF8UrlEncoder.encode(pluginProperties.get(key))));
    }
}
*/
    }
}
