namespace Killbill_Client.model
{
    public class Tags : KillBillObjects<Tag>
    {
        public Tags getNext()
        {
            return getNext<Tags>(typeof(Tags));
            ;
        }
    }
}