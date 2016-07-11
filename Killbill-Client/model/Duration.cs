
using System;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Killbill_Client.model {
    public class Duration
    {

        private DateTimeUnit unit;
        private int number;


        public Duration(DateTimeUnit unit, int number)
        {
            this.unit = unit;
            this.number = number;
        }

        public Duration(Duration duration)
        {
            //this(duration.getUnit(), duration.getNumber());
        }

        public DateTimeUnit getUnit()
        {
            return unit;
        }

        public int getNumber()
        {
            return number;
        }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder("DurationJson{");
            sb.Append("unit='").Append(unit).Append('\'');
            sb.Append(", number=").Append(number);
            sb.Append('}');
            return sb.ToString();
        }


        public bool equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            Duration that = (Duration) o;

            if (unit != null ? !unit.Equals(that.unit) : that.unit != null)
            {
                return false;
            }

            return number == that.number;

        }


        public int GetHashCode()
        {
            int result = unit != null ? unit.GetHashCode() : 0;
            result = 31*result + number;
            return result;
        }
    }

}
