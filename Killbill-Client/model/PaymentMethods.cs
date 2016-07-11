
namespace Killbill_Client.model
{
    public class PaymentMethods : KillBillObjects<PaymentMethod>
    {


        public PaymentMethods getNext()
        {
            return getNext(PaymentMethods.class);
        }
    }
}