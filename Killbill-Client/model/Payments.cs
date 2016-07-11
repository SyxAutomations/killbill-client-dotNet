
namespace Killbill_Client.model
{
    public class Payments : KillBillObjects<Payment>
    {

        public Payments getNext()
        {
            return getNext(Payments.class)
            ;
        }
    }
}