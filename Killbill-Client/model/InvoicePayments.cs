
namespace Killbill_Client.model {

public class InvoicePayments : KillBillObjects<InvoicePayment> {

    
    public InvoicePayments getNext()  {
        return getNext(InvoicePayments.class);
    }

}
