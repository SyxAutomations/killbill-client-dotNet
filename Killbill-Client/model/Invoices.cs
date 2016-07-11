namespace Killbill_Client.model {

    public class Invoices : KillBillObjects<Invoice>
    {
        public Invoices getNext()
        {
            return getNext(Invoices.class)
            ;
        }
    }
}
