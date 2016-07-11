
using System;
using System.Text;

namespace Killbill_Client.model
{

    public class Tag : KillBillObject
    {
        private Guid tagId;
        private ObjectType objectType;
        private Guid objectId;
        private Guid tagDefinitionId;
        private string tagDefinitionName;



        public string ToString()
        {
            StringBuilder sb = new StringBuilder("Tag{");
            sb.Append("tagId=").Append(tagId);
            sb.Append(", objectType=").Append(objectType);
            sb.Append(", objectId=").Append(objectId);
            sb.Append(", tagDefinitionId=").Append(tagDefinitionId);
            sb.Append(", tagDefinitionName='").Append(tagDefinitionName).Append('\'');
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

            Tag tag = (Tag) o;

            if (objectType != tag.objectType)
            {
                return false;
            }
            if (tagDefinitionId != null ? !tagDefinitionId.Equals(tag.tagDefinitionId) : tag.tagDefinitionId != null)
            {
                return false;
            }
            if (tagDefinitionId != null ? !tagDefinitionId.Equals(tag.tagDefinitionId) : tag.tagDefinitionId != null)
            {
                return false;
            }
            if (objectId != null ? !objectId.Equals(tag.objectId) : tag.objectId != null)
            {
                return false;
            }
            if (tagId != null ? !tagId.Equals(tag.tagId) : tag.tagId != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = tagId != null ? tagId.GetHashCode() : 0;
            result = 31*result + (objectType != null ? objectType.GetHashCode() : 0);
            result = 31*result + (tagDefinitionId != null ? tagDefinitionId.GetHashCode() : 0);
            result = 31*result + (objectId != null ? objectId.GetHashCode() : 0);
            result = 31*result + (tagDefinitionName != null ? tagDefinitionName.GetHashCode() : 0);
            return result;
        }
    }
}