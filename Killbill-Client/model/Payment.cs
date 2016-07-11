
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Killbill_Client.model
{

    public class Payment : KillBillObject
    {

        private Guid accountId;
        private Guid paymentId;
        private Int64 paymentNumber;
        private string paymentExternalKey;
        private BigInteger authAmount;
        private BigInteger capturedAmount;
        private BigInteger purchasedAmount;
        private BigInteger refundedAmount;
        private BigInteger creditedAmount;
        private string currency;
        private Guid paymentMethodId;
        private List<PaymentTransaction> transactions;




        public bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (!(o is Payment))
            {
                return false;
            }

            Payment payment = (Payment) o;

            if (accountId != null ? !accountId.Equals(payment.accountId) : payment.accountId != null)
            {
                return false;
            }
            if (authAmount != null ? authAmount.CompareTo(payment.authAmount) != 0 : payment.authAmount != null)
            {
                return false;
            }
            if (capturedAmount != null
                ? capturedAmount.CompareTo(payment.capturedAmount) != 0
                : payment.capturedAmount != null)
            {
                return false;
            }
            if (creditedAmount != null
                ? creditedAmount.CompareTo(payment.creditedAmount) != 0
                : payment.creditedAmount != null)
            {
                return false;
            }
            if (currency != null ? !currency.Equals(payment.currency) : payment.currency != null)
            {
                return false;
            }
            if (paymentExternalKey != null
                ? !paymentExternalKey.Equals(payment.paymentExternalKey)
                : payment.paymentExternalKey != null)
            {
                return false;
            }
            if (paymentId != null ? !paymentId.Equals(payment.paymentId) : payment.paymentId != null)
            {
                return false;
            }
            if (paymentMethodId != null
                ? !paymentMethodId.Equals(payment.paymentMethodId)
                : payment.paymentMethodId != null)
            {
                return false;
            }
            if (paymentNumber != null ? !paymentNumber.Equals(payment.paymentNumber) : payment.paymentNumber != null)
            {
                return false;
            }
            if (purchasedAmount != null
                ? purchasedAmount.CompareTo(payment.purchasedAmount) != 0
                : payment.purchasedAmount != null)
            {
                return false;
            }
            if (refundedAmount != null
                ? refundedAmount.CompareTo(payment.refundedAmount) != 0
                : payment.refundedAmount != null)
            {
                return false;
            }
            if (transactions != null ? !transactions.Equals(payment.transactions) : payment.transactions != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = accountId != null ? accountId.GetHashCode() : 0;
            result = 31*result + (paymentId != null ? paymentId.GetHashCode() : 0);
            result = 31*result + (paymentNumber != null ? paymentNumber.GetHashCode() : 0);
            result = 31*result + (paymentExternalKey != null ? paymentExternalKey.GetHashCode() : 0);
            result = 31*result + (authAmount != null ? authAmount.GetHashCode() : 0);
            result = 31*result + (capturedAmount != null ? capturedAmount.GetHashCode() : 0);
            result = 31*result + (purchasedAmount != null ? purchasedAmount.GetHashCode() : 0);
            result = 31*result + (refundedAmount != null ? refundedAmount.GetHashCode() : 0);
            result = 31*result + (creditedAmount != null ? creditedAmount.GetHashCode() : 0);
            result = 31*result + (currency != null ? currency.GetHashCode() : 0);
            result = 31*result + (paymentMethodId != null ? paymentMethodId.GetHashCode() : 0);
            result = 31*result + (transactions != null ? transactions.GetHashCode() : 0);
            return result;
        }
    }
}
