using Ninject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killbill_Client
{
    public class RequestOptions
    {
        private readonly string requestId;

        private readonly string user;
        private readonly string password;

        private readonly string createdBy, reason, comment;

        private readonly string tenantApiKey, tenantApiSecret;

        private readonly ImmutableDictionary<string, string> headers;

        private readonly Multimap<string, string> queryParams;

        private readonly bool followLocation;

        private readonly Multimap<string, string> queryParamsForFollow;

        public RequestOptions(string requestId, string user, string password, string createdBy,
                              string reason, string comment, string tenantApiKey, string tenantApiSecret,
                              ImmutableDictionary<string, String> headers, Multimap<string, string> queryParams,
                              bool followLocation, Multimap<string, string> queryParamsForFollow)
        {
            this.requestId = requestId;
            this.user = user;
            this.password = password;
            this.createdBy = createdBy;
            this.reason = reason;
            this.comment = comment;
            this.tenantApiKey = tenantApiKey;
            this.tenantApiSecret = tenantApiSecret;
            /* todo: use copy of collectoins */
            this.headers = headers;
            this.queryParams = queryParams ?? new Multimap<string, string>();
            this.followLocation = followLocation;
            this.queryParamsForFollow = queryParamsForFollow;
        }

        public string getRequestId()
        {
            return requestId;
        }

        public string getUser()
        {
            return user;
        }

        public string getPassword()
        {
            return password;
        }

        public string getCreatedBy()
        {
            return createdBy;
        }

        public string getReason()
        {
            return reason;
        }

        public string getComment()
        {
            return comment;
        }

        public string getTenantApiKey()
        {
            return tenantApiKey;
        }

        public string getTenantApiSecret()
        {
            return tenantApiSecret;
        }

        public ImmutableDictionary<string, String> getHeaders()
        {
            return this.headers;
        }

        public Multimap<string, string> getQueryParams()
        {
            return queryParams;
        }

        public bool getFollowLocation()
        {
            return followLocation;
        }

        public bool shouldFollowLocation()
        {
            if (followLocation == null)
            {
                return false;
            }
            return followLocation;
        }

        public Multimap<string, string> getQueryParamsForFollow()
        {
            return queryParamsForFollow;
        }

        public RequestOptionsBuilder extend()
        {
            RequestOptionsBuilder builder = new RequestOptionsBuilder();
            this.headers.ToList().ForEach(x => builder.headers.Add(x.Key, x.Value));
            return builder
                    .withRequestId(requestId)
                    .withUser(user).withPassword(password)
                    .withCreatedBy(createdBy).withReason(reason).withComment(comment)
                    .withTenantApiKey(tenantApiKey).withTenantApiSecret(tenantApiSecret)
                    .withQueryParams(queryParams)
                    .withFollowLocation(followLocation).withQueryParamsForFollow(queryParamsForFollow);
        }

        /**
         * Helper method for creating a new builder
         * @return a new instance of RequestOptionsBuilder
         */
        public static RequestOptionsBuilder builder()
        {
            return new RequestOptionsBuilder();
        }

        /**
         * Helper method for creating an empty RequestOptions object.
         * @return an empty RequestOptions object.
         */
        public static RequestOptions empty()
        {
            return new RequestOptionsBuilder().build();
        }
    }
}
