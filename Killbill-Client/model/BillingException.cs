using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killbill_Client.model
{
    public class BillingException
    {
        private string className;
        private Int64 code;
        private string message;
        private string causeClassName;
        private string causeMessage;
        private List<StackTraceElement> stackTrace;
        // TODO add getSuppressed() from 1.7?

        
    public BillingException( string className,
                             Int64? code,
                             string message,
                             string causeClassName,
                             string causeMessage,
                             List < StackTraceElement > stackTrace) {
        this.className = className;
        this.code = (long) code;
        this.message = message;
        this.causeClassName = causeClassName;
        this.causeMessage = causeMessage;
        this.stackTrace = stackTrace;
    }

    public string getClassName()
    {
        return className;
    }

    public void setClassName(string className)
    {
        this.className = className;
    }

    public Int64 getCode()
    {
        return code;
    }

    public void setCode(Int64 code)
    {
        this.code = code;
    }

    public string getMessage()
    {
        return message;
    }

    public void setMessage(string message)
    {
        this.message = message;
    }

    public string getCauseClassName()
    {
        return causeClassName;
    }

    public void setCauseClassName(string causeClassName)
    {
        this.causeClassName = causeClassName;
    }

    public string getCauseMessage()
    {
        return causeMessage;
    }

    public void setCauseMessage(string causeMessage)
    {
        this.causeMessage = causeMessage;
    }

    public List<StackTraceElement> getStackTrace()
    {
        return stackTrace;
    }

    public void setStackTrace(List<StackTraceElement> stackTrace)
    {
        this.stackTrace = stackTrace;
    }

    
    public override string ToString()
    {
        var sb = new StringBuilder("BillingException{");
        sb.Append("className='").Append(className).Append('\'');
        sb.Append(", code=").Append(code);
        sb.Append(", message='").Append(message).Append('\'');
        sb.Append(", causeClassName='").Append(causeClassName).Append('\'');
        sb.Append(", causeMessage='").Append(causeMessage).Append('\'');
        sb.Append(", stackTrace=").Append(stackTrace);
        sb.Append('}');
        return sb.ToString();
    }
}
}
