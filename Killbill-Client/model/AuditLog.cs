using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killbill_Client.model
{
    public class AuditLog
    {
        private string changeType;
        private DateTime changeDate;
        private string changedBy;
        private string reasonCode;
        private string comments;
        private string userToken;

        public AuditLog() { }

        public AuditLog(string changeType,
                       DateTime changeDate,
                        string changedBy,
                        string reasonCode,
                        string comments,
                        string userToken)
        {
            this.changeType = changeType;
            this.changeDate = changeDate;
            this.changedBy = changedBy;
            this.reasonCode = reasonCode;
            this.comments = comments;
            this.userToken = userToken;
        }

        public string getChangeType()
        {
            return changeType;
        }

        public void setChangeType(String changeType)
        {
            this.changeType = changeType;
        }

        public DateTime getChangeDate()
        {
            return changeDate;
        }

        public void setChangeDate(DateTime changeDate)
        {
            this.changeDate = changeDate;
        }

        public string getChangedBy()
        {
            return changedBy;
        }

        public void setChangedBy(String changedBy)
        {
            this.changedBy = changedBy;
        }

        public string getReasonCode()
        {
            return reasonCode;
        }

        public void setReasonCode(String reasonCode)
        {
            this.reasonCode = reasonCode;
        }

        public string getComments()
        {
            return comments;
        }

        public void setComments(String comments)
        {
            this.comments = comments;
        }

        public string getUserToken()
        {
            return userToken;
        }

        public void setUserToken(String userToken)
        {
            this.userToken = userToken;
        }


        public override string ToString()
        {
            var sb = new StringBuilder("AuditLog{");
            sb.Append("changeType='").Append(changeType).Append('\'');
            sb.Append(", changeDate=").Append(changeDate);
            sb.Append(", changedBy='").Append(changedBy).Append('\'');
            sb.Append(", reasonCode='").Append(reasonCode).Append('\'');
            sb.Append(", comments='").Append(comments).Append('\'');
            sb.Append(", userToken='").Append(userToken).Append('\'');
            sb.Append('}');
            return sb.ToString();
        }


        public override bool Equals(Object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            AuditLog auditLog = (AuditLog)o;

            if (changeDate != null ? changeDate.CompareTo(auditLog.changeDate) != 0 : auditLog.changeDate != null)
            {
                return false;
            }
            if (changeType != null ? !changeType.Equals(auditLog.changeType) : auditLog.changeType != null)
            {
                return false;
            }
            if (changedBy != null ? !changedBy.Equals(auditLog.changedBy) : auditLog.changedBy != null)
            {
                return false;
            }
            if (comments != null ? !comments.Equals(auditLog.comments) : auditLog.comments != null)
            {
                return false;
            }
            if (reasonCode != null ? !reasonCode.Equals(auditLog.reasonCode) : auditLog.reasonCode != null)
            {
                return false;
            }
            if (userToken != null ? !userToken.Equals(auditLog.userToken) : auditLog.userToken != null)
            {
                return false;
            }

            return true;
        }


        public override int GetHashCode()
        {
            int result = changeType != null ? changeType.GetHashCode() : 0;
            result = 31 * result + (changeDate != null ? changeDate.GetHashCode() : 0);
            result = 31 * result + (changedBy != null ? changedBy.GetHashCode() : 0);
            result = 31 * result + (reasonCode != null ? reasonCode.GetHashCode() : 0);
            result = 31 * result + (comments != null ? comments.GetHashCode() : 0);
            result = 31 * result + (userToken != null ? userToken.GetHashCode() : 0);
            return result;
        }
    }
}
