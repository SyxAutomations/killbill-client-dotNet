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




public class StackTraceElement {

    private string className;
    private string fileName;
    private Int64 lineNumber;
    private string methodName;
    private bool nativeMethod;

    
    public StackTraceElement(@JsonProperty("className") string className,
                             @JsonProperty("fileName") string fileName,
                             @JsonProperty("lineNumber") Int64 lineNumber,
                             @JsonProperty("methodName") string methodName,
                             @JsonProperty("nativeMethod") bool nativeMethod) {
        this.className = className;
        this.fileName = fileName;
        this.lineNumber = lineNumber;
        this.methodName = methodName;
        this.nativeMethod = nativeMethod;
    }

    public string getClassName() {
        return className;
    }

    public void setClassName(string className) {
        this.className = className;
    }

    public string getFileName() {
        return fileName;
    }

    public void setFileName(string fileName) {
        this.fileName = fileName;
    }

    public Int64 getLineNumber() {
        return lineNumber;
    }

    public void setLineNumber(Int64 lineNumber) {
        this.lineNumber = lineNumber;
    }

    public string getMethodName() {
        return methodName;
    }

    public void setMethodName(string methodName) {
        this.methodName = methodName;
    }

    public bool getNativeMethod() {
        return nativeMethod;
    }

    public void setNativeMethod(bool nativeMethod) {
        this.nativeMethod = nativeMethod;
    }

    
    public string ToString() {
        StringBuilder sb = new StringBuilder("StackTraceElement{");
        sb.Append("className='").append(className).append('\'');
        sb.Append(", fileName='").append(fileName).append('\'');
        sb.Append(", lineNumber=").append(lineNumber);
        sb.Append(", methodName='").append(methodName).append('\'');
        sb.Append(", nativeMethod=").append(nativeMethod);
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

        StackTraceElement that = (StackTraceElement) o;

        if (className != null ? !className.equals(that.className) : that.className != null) {
            return false;
        }
        if (fileName != null ? !fileName.equals(that.fileName) : that.fileName != null) {
            return false;
        }
        if (lineNumber != null ? !lineNumber.equals(that.lineNumber) : that.lineNumber != null) {
            return false;
        }
        if (methodName != null ? !methodName.equals(that.methodName) : that.methodName != null) {
            return false;
        }
        if (nativeMethod != null ? !nativeMethod.equals(that.nativeMethod) : that.nativeMethod != null) {
            return false;
        }

        return true;
    }

    
    public int GetHashCode() {
        int result = className != null ? className.GetHashCode() : 0;
        result = 31 * result + (fileName != null ? fileName.GetHashCode() : 0);
        result = 31 * result + (lineNumber != null ? lineNumber.GetHashCode() : 0);
        result = 31 * result + (methodName != null ? methodName.GetHashCode() : 0);
        result = 31 * result + (nativeMethod != null ? nativeMethod.GetHashCode() : 0);
        return result;
    }
}
