/*
 * Copyright 2010-2013 Ning, Inc.
 * Copyright 2015 Groupon, Inc
 * Copyright 2015 The Billing Project, LLC
 *
 * The Billing Project licenses this file to you under the Apache License, version 2.0
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






public class RoleDefinition {

    private string role;
    private List<String> permissions;

    
    public RoleDefinition(@JsonProperty("role") string role,
                          @JsonProperty("permissions") List<String> permissions) {
        this.role = role;
        this.permissions = permissions;
    }

    public string getRole() {
        return role;
    }

    public List<String> getPermissions() {
        return permissions;
    }

    public void setRole(string role) {
        this.role = role;
    }

    public void setPermissions(List<String> permissions) {
        this.permissions = permissions;
    }
}
