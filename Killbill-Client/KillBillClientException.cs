using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Killbill_Client.model;

namespace Killbill_Client
{
    public class KillBillClientException : Exception
    {
        private readonly HttpResponse _response;
        private readonly BillingException _billingException;

        public KillBillClientException(Exception cause)
        {
            this._response = null;
            _billingException = null;
        }

        public KillBillClientException(Exception cause, HttpResponse response)
        {
            this._response = response;
            _billingException = null;
        }

        public KillBillClientException(BillingException exception, HttpResponse response)
        {
            this._response = response;
            this._billingException = exception;
        }

        public HttpResponse getResponse()
        {
            return _response;
        }

        public BillingException getBillingException()
        {
            return _billingException;
        }
    }
}
