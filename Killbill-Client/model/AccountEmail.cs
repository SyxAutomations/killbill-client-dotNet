using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killbill_Client.model
{
    public class AccountEmail
    {
        private Guid accountId;
        private string email;

        public AccountEmail() { }
        
    public AccountEmail(Guid accountId,   string email) {
        this.accountId = accountId;
        this.email = email;
    }

    public Guid getAccountId()
    {
        return accountId;
    }

    public void setAccountId(Guid accountId)
    {
        this.accountId = accountId;
    }

    public string getEmail()
    {
        return email;
    }

    public void setEmail(string email)
    {
        this.email = email;
    }
    
    public override string ToString()
    {
         var sb = new StringBuilder("AccountEmail{");
        sb.Append("accountId='").Append(accountId).Append('\'');
        sb.Append(", email='").Append(email).Append('\'');
        sb.Append('}');
        return sb.ToString();
    }

    
    public override bool Equals(Object o)
    {
        if (this == o)
        {
            return true;
        }
        if (o == null || GetType() != o.GetType())
        {
            return false;
        }

         AccountEmail that = (AccountEmail)o;

        if (accountId != null ? !accountId.Equals(that.accountId) : that.accountId != null)
        {
            return false;
        }
        if (email != null ? !email.Equals(that.email) : that.email != null)
        {
            return false;
        }

        return true;
    }

   
    public override int GetHashCode()
    {
        int result = accountId != null ? accountId.GetHashCode() : 0;
        result = 31 * result + (email != null ? email.GetHashCode() : 0);
        return result;
    }
}
}
