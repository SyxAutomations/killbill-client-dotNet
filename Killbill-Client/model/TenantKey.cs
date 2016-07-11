using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model {

public class TenantKey : KillBillObject {

    private string key;
    private List<String> values;

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("TenantKey{");
        sb.Append("key='").Append(key).Append('\'');
        sb.Append(", values=").Append(values);
        sb.Append('}');
        return sb.ToString();
    }

    
    public bool Equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || GetType() != o.GetType()) {
            return false;
        }

        TenantKey tenantKey = (TenantKey) o;

        if (key != null ? !key.Equals(tenantKey.key) : tenantKey.key != null) {
            return false;
        }
        if (values != null ? !values.Equals(tenantKey.values) : tenantKey.values != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = key != null ? key.GetHashCode() : 0;
        result = 31 * result + (values != null ? values.GetHashCode() : 0);
        return result;
    }
}
