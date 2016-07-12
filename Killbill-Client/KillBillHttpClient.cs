using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Killbill_Client.model;
using Ninject.Infrastructure;

namespace Killbill_Client
{
    public class KillBillHttpClient
    {
        public static int DEFAULT_HTTP_TIMEOUT_SEC = 10;

        public static Multimap<String, String> DEFAULT_EMPTY_QUERY = new Multimap<string, string>();
        public static String AUDIT_OPTION_CREATED_BY = "__AUDIT_OPTION_CREATED_BY";
        public static String AUDIT_OPTION_REASON = "__AUDIT_OPTION_REASON";
        public static String AUDIT_OPTION_COMMENT = "__AUDIT_OPTION_COMMENT";
        public static String TENANT_OPTION_API_KEY = "__TENANT_OPTION_API_KEY";
        public static String TENANT_OPTION_API_SECRET = "__TENANT_OPTION_API_SECRET";
        public static String RBAC_OPTION_USERNAME = "__RBAC_OPTION_USERNAME";
        public static String RBAC_OPTION_PASSWORD = "__RBAC_OPTION_PASSWORD";

        public static String CONTROL_PLUGIN_NAME = "controlPluginName";

        public static String HTTP_HEADER_ACCEPT = "Accept";
        public static String HTTP_HEADER_CONTENT_TYPE = "Content-Type";

        public static String ACCEPT_HTML = "text/html";
        public static String ACCEPT_JSON = "application/json";
        public static String ACCEPT_XML = "application/xml";
        public static String CONTENT_TYPE_JSON = "application/json; charset=utf-8";
        public static String CONTENT_TYPE_XML = "application/xml; charset=utf-8";

        //private static Logger log = LoggerFactory.getLogger(KillBillHttpClient.class);
        private static String USER_AGENT = "KillBill-JavaClient/1.0";

        //private static Joiner CSV_JOINER = Joiner.on(",");

        //private bool DEBUG = Boolean.parseBoolean(System.getProperty("org.killbill.client.debug", "false"));

        private String kbServerUrl;
        private String username;
        private String password;
        private String apiKey;
        private String apiSecret;
        //private AsyncHttpClient httpClient;
        //private ObjectMapper mapper;

        private int requestTimeoutSec;
        public void close()
        {
            throw new NotImplementedException();
        }

        public HttpResponse doGet(string uri, object o)
        {
            throw new NotImplementedException();
        }
    }
}
