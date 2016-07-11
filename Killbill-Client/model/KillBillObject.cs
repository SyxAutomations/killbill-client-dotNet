using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killbill_Client.model
{
    public abstract class KillBillObject
    {
        protected List<AuditLog> auditLogs;

        protected KillBillObject(): this(null)
        {
            
        }

        protected KillBillObject(List<AuditLog> auditLogs = null)
        {
            this.auditLogs = auditLogs;
        }

        public List<AuditLog> getAuditLogs()
        {
            return auditLogs;
        }

        public void setAuditLogs(List<AuditLog> auditLogs)
        {
            this.auditLogs = auditLogs;
        }
    }
}
