namespace Killbill_Client.model
{
    public class Bundles : KillBillObjects<Bundle>
    {
        public Bundles getNext()
        {
            return getNext<Bundles>(typeof(Bundles));
        }
    }
}
