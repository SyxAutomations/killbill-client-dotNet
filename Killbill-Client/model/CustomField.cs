using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model {

    public class CustomField : KillBillObject
    {

        private Guid customFieldId;
        private Guid objectId;
        private ObjectType objectType;
        private string name;
        private string value;

        public CustomField()
        {
        }


        public CustomField(Guid customFieldId,
            Guid objectId,
            ObjectType objectType,
            string name,
            string value,
            List<AuditLog> auditLogs)
        {
            auditLogs)
            ;
            this.customFieldId = customFieldId;
            this.objectId = objectId;
            this.objectType = objectType;
            this.name = name;
            this.value = value;
        }

        public Guid getCustomFieldId()
        {
            return customFieldId;
        }

        public void setCustomFieldId(Guid customFieldId)
        {
            this.customFieldId = customFieldId;
        }

        public Guid getObjectId()
        {
            return objectId;
        }

        public void setObjectId(Guid objectId)
        {
            this.objectId = objectId;
        }

        public ObjectType getObjectType()
        {
            return objectType;
        }

        public void setObjectType(ObjectType objectType)
        {
            this.objectType = objectType;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getValue()
        {
            return value;
        }

        public void setValue(string value)
        {
            this.value = value;
        }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("CustomFieldJson{");
            sb.Append("customFieldId='").Append(customFieldId).Append('\'');
            sb.Append(", objectId=").Append(objectId);
            sb.Append(", objectType=").Append(objectType);
            sb.Append(", name='").Append(name).Append('\'');
            sb.Append(", value='").Append(value).Append('\'');
            sb.Append('}');
            return sb.ToString();
        }


        public bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            CustomField that = (CustomField) o;

            if (customFieldId != null ? !customFieldId.Equals(that.customFieldId) : that.customFieldId != null)
            {
                return false;
            }
            if (name != null ? !name.Equals(that.name) : that.name != null)
            {
                return false;
            }
            if (objectId != null ? !objectId.Equals(that.objectId) : that.objectId != null)
            {
                return false;
            }
            if (objectType != that.objectType)
            {
                return false;
            }
            if (value != null ? !value.Equals(that.value) : that.value != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = customFieldId != null ? customFieldId.GetHashCode() : 0;
            result = 31*result + (objectId != null ? objectId.GetHashCode() : 0);
            result = 31*result + (objectType != null ? objectType.GetHashCode() : 0);
            result = 31*result + (name != null ? name.GetHashCode() : 0);
            result = 31*result + (value != null ? value.GetHashCode() : 0);
            return result;
        }
    }
}


