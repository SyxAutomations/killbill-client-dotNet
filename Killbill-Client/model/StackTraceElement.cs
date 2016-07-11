using System;
using System.Text;

namespace Killbill_Client.model
{




    public class StackTraceElement
    {

        private string className;
        private string fileName;
        private Int64 lineNumber;
        private string methodName;
        private bool nativeMethod;





        public string ToString()
        {
            StringBuilder sb = new StringBuilder("StackTraceElement{");
            sb.Append("className='").Append(className).Append('\'');
            sb.Append(", fileName='").Append(fileName).Append('\'');
            sb.Append(", lineNumber=").Append(lineNumber);
            sb.Append(", methodName='").Append(methodName).Append('\'');
            sb.Append(", nativeMethod=").Append(nativeMethod);
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

            StackTraceElement that = (StackTraceElement) o;

            if (className != null ? !className.Equals(that.className) : that.className != null)
            {
                return false;
            }
            if (fileName != null ? !fileName.Equals(that.fileName) : that.fileName != null)
            {
                return false;
            }
            if (lineNumber != null ? !lineNumber.Equals(that.lineNumber) : that.lineNumber != null)
            {
                return false;
            }
            if (methodName != null ? !methodName.Equals(that.methodName) : that.methodName != null)
            {
                return false;
            }
            if (nativeMethod != null ? !nativeMethod.Equals(that.nativeMethod) : that.nativeMethod != null)
            {
                return false;
            }

            return true;
        }


        public int GetHashCode()
        {
            int result = className != null ? className.GetHashCode() : 0;
            result = 31*result + (fileName != null ? fileName.GetHashCode() : 0);
            result = 31*result + (lineNumber != null ? lineNumber.GetHashCode() : 0);
            result = 31*result + (methodName != null ? methodName.GetHashCode() : 0);
            result = 31*result + (nativeMethod != null ? nativeMethod.GetHashCode() : 0);
            return result;
        }
    }
}