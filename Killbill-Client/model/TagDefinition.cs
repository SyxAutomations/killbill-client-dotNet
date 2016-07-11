
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model
{

    public class TagDefinition : KillBillObject
    {

        private Guid id;
        private bool isControlTag;
        private string name;
        private string description;
        private List<ObjectType> applicableObjectTypes;


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("TagDefinition{");
            sb.Append("id=").Append(id);
            sb.Append(", isControlTag=").Append(isControlTag);
            sb.Append(", name='").Append(name).Append('\'');
            sb.Append(", description='").Append(description).Append('\'');
            sb.Append(", applicableObjectTypes=").Append(applicableObjectTypes);
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

            TagDefinition that = (TagDefinition) o;

            if (applicableObjectTypes != null
                ? !applicableObjectTypes.Equals(that.applicableObjectTypes)
                : that.applicableObjectTypes != null)
            {
                return false;
            }
            if (description != null ? !description.Equals(that.description) : that.description != null)
            {
                return false;
            }
            if (id != null ? !id.Equals(that.id) : that.id != null)
            {
                return false;
            }
            if (isControlTag != null ? !isControlTag.Equals(that.isControlTag) : that.isControlTag != null)
            {
                return false;
            }
            if (name != null ? !name.Equals(that.name) : that.name != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = id != null ? id.GetHashCode() : 0;
            result = 31*result + (isControlTag != null ? isControlTag.GetHashCode() : 0);
            result = 31*result + (name != null ? name.GetHashCode() : 0);
            result = 31*result + (description != null ? description.GetHashCode() : 0);
            result = 31*result + (applicableObjectTypes != null ? applicableObjectTypes.GetHashCode() : 0);
            return result;
        }
    }
}