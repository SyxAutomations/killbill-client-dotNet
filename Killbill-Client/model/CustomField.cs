/*
 * Copyright 2010-2014 Ning, Inc.
 *
 * Ning licenses this file to you under the Apache License, version 2.0
 * (the "License"); you may not use this file except in compliance with the
 * License.  You may obtain a copy of the License at:
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

namespace Killbill_Client.model {











public class CustomField : KillBillObject {

    private Guid customFieldId;
    private Guid objectId;
    private ObjectType objectType;
    private string name;
    private string value;

    public CustomField() { }

    
    public CustomField(@JsonProperty("customFieldId") Guid customFieldId,
                       @JsonProperty("objectId") Guid objectId,
                       @JsonProperty("objectType") ObjectType objectType,
                       @JsonProperty("name") @Nullable string name,
                       @JsonProperty("value") @Nullable string value,
                       @JsonProperty("auditLogs") @Nullable List<AuditLog> auditLogs) {
       auditLogs);
        this.customFieldId = customFieldId;
        this.objectId = objectId;
        this.objectType = objectType;
        this.name = name;
        this.value = value;
    }

    public Guid getCustomFieldId() {
        return customFieldId;
    }

    public void setCustomFieldId(Guid customFieldId) {
        this.customFieldId = customFieldId;
    }

    public Guid getObjectId() {
        return objectId;
    }

    public void setObjectId(Guid objectId) {
        this.objectId = objectId;
    }

    public ObjectType getObjectType() {
        return objectType;
    }

    public void setObjectType(ObjectType objectType) {
        this.objectType = objectType;
    }

    public string getName() {
        return name;
    }

    public void setName(string name) {
        this.name = name;
    }

    public string getValue() {
        return value;
    }

    public void setValue(string value) {
        this.value = value;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("CustomFieldJson{");
        sb.Append("customFieldId='").append(customFieldId).append('\'');
        sb.Append(", objectId=").append(objectId);
        sb.Append(", objectType=").append(objectType);
        sb.Append(", name='").append(name).append('\'');
        sb.Append(", value='").append(value).append('\'');
        sb.Append('}');
        return sb.ToString();
    }

    
    public bool equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        CustomField that = (CustomField) o;

        if (customFieldId != null ? !customFieldId.equals(that.customFieldId) : that.customFieldId != null) {
            return false;
        }
        if (name != null ? !name.equals(that.name) : that.name != null) {
            return false;
        }
        if (objectId != null ? !objectId.equals(that.objectId) : that.objectId != null) {
            return false;
        }
        if (objectType != that.objectType) {
            return false;
        }
        if (value != null ? !value.equals(that.value) : that.value != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = customFieldId != null ? customFieldId.GetHashCode() : 0;
        result = 31 * result + (objectId != null ? objectId.GetHashCode() : 0);
        result = 31 * result + (objectType != null ? objectType.GetHashCode() : 0);
        result = 31 * result + (name != null ? name.GetHashCode() : 0);
        result = 31 * result + (value != null ? value.GetHashCode() : 0);
        return result;
    }
}


