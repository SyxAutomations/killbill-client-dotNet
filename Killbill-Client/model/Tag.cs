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











public class Tag : KillBillObject {

    private Guid tagId;
    private ObjectType objectType;
    private Guid objectId;
    private Guid tagDefinitionId;
    private string tagDefinitionName;

    public Tag() { }

    
    public Tag(@JsonProperty("tagId") Guid tagId,
               @JsonProperty("objectType") ObjectType objectType,
               @JsonProperty("objectId") Guid objectId,
               @JsonProperty("tagDefinitionId") Guid tagDefinitionId,
               @JsonProperty("tagDefinitionName") string tagDefinitionName,
               @JsonProperty("auditLogs") @Nullable List<AuditLog> auditLogs) {
       auditLogs);
        this.tagId = tagId;
        this.objectType = objectType;
        this.objectId = objectId;
        this.tagDefinitionId = tagDefinitionId;
        this.tagDefinitionName = tagDefinitionName;
    }

    public Guid getTagId() {
        return tagId;
    }

    public void setTagId(Guid tagId) {
        this.tagId = tagId;
    }

    public ObjectType getObjectType() {
        return objectType;
    }

    public void setObjectType(ObjectType objectType) {
        this.objectType = objectType;
    }

    public Guid getTagDefinitionId() {
        return tagDefinitionId;
    }

    public void setTagDefinitionId(Guid tagDefinitionId) {
        this.tagDefinitionId = tagDefinitionId;
    }

    public string getTagDefinitionName() {
        return tagDefinitionName;
    }

    public void setTagDefinitionName(string tagDefinitionName) {
        this.tagDefinitionName = tagDefinitionName;
    }

    public Guid getObjectId() {
        return objectId;
    }

    public void setObjectId(Guid objectId) {
        this.objectId = objectId;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("Tag{");
        sb.Append("tagId=").append(tagId);
        sb.Append(", objectType=").append(objectType);
        sb.Append(", objectId=").append(objectId);
        sb.Append(", tagDefinitionId=").append(tagDefinitionId);
        sb.Append(", tagDefinitionName='").append(tagDefinitionName).append('\'');
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

        Tag tag = (Tag) o;

        if (objectType != tag.objectType) {
            return false;
        }
        if (tagDefinitionId != null ? !tagDefinitionId.equals(tag.tagDefinitionId) : tag.tagDefinitionId != null) {
            return false;
        }
        if (tagDefinitionId != null ? !tagDefinitionId.equals(tag.tagDefinitionId) : tag.tagDefinitionId != null) {
            return false;
        }
        if (objectId != null ? !objectId.equals(tag.objectId) : tag.objectId != null) {
            return false;
        }
        if (tagId != null ? !tagId.equals(tag.tagId) : tag.tagId != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = tagId != null ? tagId.GetHashCode() : 0;
        result = 31 * result + (objectType != null ? objectType.GetHashCode() : 0);
        result = 31 * result + (tagDefinitionId != null ? tagDefinitionId.GetHashCode() : 0);
        result = 31 * result + (objectId != null ? objectId.GetHashCode() : 0);
        result = 31 * result + (tagDefinitionName != null ? tagDefinitionName.GetHashCode() : 0);
        return result;
    }
}
