
namespace Killbill_Client.model {

    public class CustomFields : KillBillObjects<CustomField>
    {


        public CustomFields getNext()
        {
            return getNext(CustomFields.class)
            ;
        }
    }
}
