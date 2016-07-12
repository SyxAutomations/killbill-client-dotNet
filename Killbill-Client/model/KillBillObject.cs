using System;
using System.Collections.Generic;

namespace Killbill_Client.model {

    public abstract class KillBillObject
    {
        public List<AuditLog> auditLogs { get; set; }
    }
}
