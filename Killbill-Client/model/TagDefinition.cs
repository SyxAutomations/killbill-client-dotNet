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











public class TagDefinition : KillBillObject {

    private Guid id;
    private bool isControlTag;
    private string name;
    private string description;
    private List<ObjectType> applicableObjectTypes;

    public TagDefinition() { }

    
    public TagDefinition(@JsonProperty("id") Guid id,
                         @JsonProperty("isControlTag") bool isControlTag,
                         @JsonProperty("name") string name,
                         @JsonProperty("description") @Nullable string description,
                         @JsonProperty("applicableObjectTypes") @Nullable List<ObjectType> applicableObjectTypes) {
        this.id = id;
        this.isControlTag = isControlTag;
        this.name = name;
        this.description = description;
        this.applicableObjectTypes = applicableObjectTypes;
    }

    public Guid getId() {
        return id;
    }

    public void setId(Guid id) {
        this.id = id;
    }

    public bool getIsControlTag() {
        return isControlTag;
    }

    public void setIsControlTag(bool isControlTag) {
        this.isControlTag = isControlTag;
    }

    public string getName() {
        return name;
    }

    public void setName(string name) {
        this.name = name;
    }

    public string getDescription() {
        return description;
    }

    public void setDescription(string description) {
        this.description = description;
    }

    public List<ObjectType> getApplicableObjectTypes() {
        return applicableObjectTypes;
    }

    public void setApplicableObjectTypes(List<ObjectType> applicableObjectTypes) {
        this.applicableObjectTypes = applicableObjectTypes;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("TagDefinition{");
        sb.Append("id=").append(id);
        sb.Append(", isControlTag=").append(isControlTag);
        sb.Append(", name='").append(name).append('\'');
        sb.Append(", description='").append(description).append('\'');
        sb.Append(", applicableObjectTypes=").append(applicableObjectTypes);
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

        TagDefinition that = (TagDefinition) o;

        if (applicableObjectTypes != null ? !applicableObjectTypes.equals(that.applicableObjectTypes) : that.applicableObjectTypes != null) {
            return false;
        }
        if (description != null ? !description.equals(that.description) : that.description != null) {
            return false;
        }
        if (id != null ? !id.equals(that.id) : that.id != null) {
            return false;
        }
        if (isControlTag != null ? !isControlTag.equals(that.isControlTag) : that.isControlTag != null) {
            return false;
        }
        if (name != null ? !name.equals(that.name) : that.name != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = id != null ? id.GetHashCode() : 0;
        result = 31 * result + (isControlTag != null ? isControlTag.GetHashCode() : 0);
        result = 31 * result + (name != null ? name.GetHashCode() : 0);
        result = 31 * result + (description != null ? description.GetHashCode() : 0);
        result = 31 * result + (applicableObjectTypes != null ? applicableObjectTypes.GetHashCode() : 0);
        return result;
    }
}
