using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Killbill_Client.model
{
    public class Account
    {
        private Guid accountId;
        private string externalKey;
        private BigInteger accountCBA;
        private BigInteger accountBalance;
        private string name;
        private Int64 firstNameLength;
        private string email;
        private Int64 billCycleDayLocal;
        private string currency;
        private Guid paymentMethodId;
        private string timeZone;
        private string address1;
        private string address2;
        private string postalCode;
        private string company;
        private string city;
        private string state;
        private string country;
        private string locale;
        private string phone;
        private bool isMigrated;
        private bool isNotifiedForInvoices;

        public Account() { }

        public Account(Guid accountId, string name,
                    Int64 firstNameLength,
                    string externalKey,
                    string email,
                    Int64 billCycleDayLocal,
                    string currency,
                    Guid paymentMethodId,
                    string timeZone,
                    string address1,
                    string address2,
                    string postalCode,
                    string company,
                    string city,
                    string state,
                    string country,
                    string locale,
                    string phone,
                    bool isMigrated,
                    bool isNotifiedForInvoices,
                    BigInteger accountBalance,
                    BigInteger accountCBA)
        {

            this.accountBalance = accountBalance;
            this.externalKey = externalKey;
            this.accountId = accountId;
            this.name = name;
            this.firstNameLength = firstNameLength;
            this.email = email;
            this.billCycleDayLocal = billCycleDayLocal;
            this.currency = currency;
            this.paymentMethodId = paymentMethodId;
            this.timeZone = timeZone;
            this.address1 = address1;
            this.address2 = address2;
            this.postalCode = postalCode;
            this.company = company;
            this.city = city;
            this.state = state;
            this.country = country;
            this.locale = locale;
            this.phone = phone;
            this.isMigrated = isMigrated;
            this.isNotifiedForInvoices = isNotifiedForInvoices;
            this.accountCBA = accountCBA;
        }


        public Guid getAccountId()
        {
            return accountId;
        }

        public void setAccountId(Guid accountId)
        {
            this.accountId = accountId;
        }

        public string getExternalKey()
        {
            return externalKey;
        }

        public void setExternalKey(string externalKey)
        {
            this.externalKey = externalKey;
        }

        public BigInteger getAccountCBA()
        {
            return accountCBA;
        }

        public void setAccountCBA(BigInteger accountCBA)
        {
            this.accountCBA = accountCBA;
        }

        public BigInteger getAccountBalance()
        {
            return accountBalance;
        }

        public void setAccountBalance(BigInteger accountBalance)
        {
            this.accountBalance = accountBalance;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public Int64 getFirstNameLength()
        {
            return firstNameLength;
        }

        public void setFirstNameLength(Int64 firstNameLength)
        {
            this.firstNameLength = firstNameLength;
        }

        public string getEmail()
        {
            return email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public Int64 getBillCycleDayLocal()
        {
            return billCycleDayLocal;
        }

        public void setBillCycleDayLocal(Int64 billCycleDayLocal)
        {
            this.billCycleDayLocal = billCycleDayLocal;
        }

        public string getCurrency()
        {
            return currency;
        }

        public void setCurrency(string currency)
        {
            this.currency = currency;
        }

        public Guid getPaymentMethodId()
        {
            return paymentMethodId;
        }

        public void setPaymentMethodId(Guid paymentMethodId)
        {
            this.paymentMethodId = paymentMethodId;
        }

        public string getTimeZone()
        {
            return timeZone;
        }

        public void setTimeZone(string timeZone)
        {
            this.timeZone = timeZone;
        }

        public string getAddress1()
        {
            return address1;
        }

        public void setAddress1(string address1)
        {
            this.address1 = address1;
        }

        public string getAddress2()
        {
            return address2;
        }
        public void setAddress2(string address2)
        {
            this.address2 = address2;
        }

        public string getPostalCode()
        {
            return postalCode;
        }

        public void setPostalCode(string postalCode)
        {
            this.postalCode = postalCode;
        }

        public string getCompany()
        {
            return company;
        }

        public void setCompany(string company)
        {
            this.company = company;
        }

        public string getCity()
        {
            return city;
        }

        public void setCity(string city)
        {
            this.city = city;
        }

        public string getState()
        {
            return state;
        }

        public void setState(string state)
        {
            this.state = state;
        }

        public string getCountry()
        {
            return country;
        }

        public void setCountry(string country)
        {
            this.country = country;
        }

        public string getLocale()
        {
            return locale;
        }

        public void setLocale(string locale)
        {
            this.locale = locale;
        }

        public string getPhone()
        {
            return phone;
        }

        public void setPhone(string phone)
        {
            this.phone = phone;
        }

        public bool getIsMigrated()
        {
            return isMigrated;
        }

        public void setIsMigrated(bool isMigrated)
        {
            this.isMigrated = isMigrated;
        }

        public bool getIsNotifiedForInvoices()
        {
            return isNotifiedForInvoices;
        }

        public void setIsNotifiedForInvoices(bool isNotifiedForInvoices)
        {
            this.isNotifiedForInvoices = isNotifiedForInvoices;
        }



        public override string ToString()
        {
            var sb = new StringBuilder("Account{");
            sb.Append("accountId='").Append(accountId).Append('\'');
            sb.Append(", externalKey='").Append(externalKey).Append('\'');
            sb.Append(", accountCBA=").Append(accountCBA);
            sb.Append(", accountBalance=").Append(accountBalance);
            sb.Append(", name='").Append(name).Append('\'');
            sb.Append(", firstNameLength=").Append(firstNameLength);
            sb.Append(", email='").Append(email).Append('\'');
            sb.Append(", billCycleDayLocal=").Append(billCycleDayLocal);
            sb.Append(", currency='").Append(currency).Append('\'');
            sb.Append(", paymentMethodId='").Append(paymentMethodId).Append('\'');
            sb.Append(", timeZone='").Append(timeZone).Append('\'');
            sb.Append(", address1='").Append(address1).Append('\'');
            sb.Append(", address2='").Append(address2).Append('\'');
            sb.Append(", postalCode='").Append(postalCode).Append('\'');
            sb.Append(", company='").Append(company).Append('\'');
            sb.Append(", city='").Append(city).Append('\'');
            sb.Append(", state='").Append(state).Append('\'');
            sb.Append(", country='").Append(country).Append('\'');
            sb.Append(", locale='").Append(locale).Append('\'');
            sb.Append(", phone='").Append(phone).Append('\'');
            sb.Append(", isMigrated=").Append(isMigrated);
            sb.Append(", isNotifiedForInvoices=").Append(isNotifiedForInvoices);
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

            Account account = (Account)o;

            if (accountBalance != null ? accountBalance.CompareTo(account.accountBalance) != 0 : account.accountBalance != null)
            {
                return false;
            }
            if (accountCBA != null ? accountCBA.CompareTo(account.accountCBA) != 0 : account.accountCBA != null)
            {
                return false;
            }
            if (accountId != null ? !accountId.Equals(account.accountId) : account.accountId != null)
            {
                return false;
            }
            if (address1 != null ? !address1.Equals(account.address1) : account.address1 != null)
            {
                return false;
            }
            if (address2 != null ? !address2.Equals(account.address2) : account.address2 != null)
            {
                return false;
            }
            if (billCycleDayLocal != null ? !billCycleDayLocal.Equals(account.billCycleDayLocal) : account.billCycleDayLocal != null)
            {
                return false;
            }
            if (city != null ? !city.Equals(account.city) : account.city != null)
            {
                return false;
            }
            if (company != null ? !company.Equals(account.company) : account.company != null)
            {
                return false;
            }
            if (country != null ? !country.Equals(account.country) : account.country != null)
            {
                return false;
            }
            if (currency != null ? !currency.Equals(account.currency) : account.currency != null)
            {
                return false;
            }
            if (email != null ? !email.Equals(account.email) : account.email != null)
            {
                return false;
            }
            if (externalKey != null ? !externalKey.Equals(account.externalKey) : account.externalKey != null)
            {
                return false;
            }
            if (firstNameLength != null ? !firstNameLength.Equals(account.firstNameLength) : account.firstNameLength != null)
            {
                return false;
            }
            if (isMigrated != null ? !isMigrated.Equals(account.isMigrated) : account.isMigrated != null)
            {
                return false;
            }
            if (isNotifiedForInvoices != null ? !isNotifiedForInvoices.Equals(account.isNotifiedForInvoices) : account.isNotifiedForInvoices != null)
            {
                return false;
            }
            if (locale != null ? !locale.Equals(account.locale) : account.locale != null)
            {
                return false;
            }
            if (name != null ? !name.Equals(account.name) : account.name != null)
            {
                return false;
            }
            if (paymentMethodId != null ? !paymentMethodId.Equals(account.paymentMethodId) : account.paymentMethodId != null)
            {
                return false;
            }
            if (phone != null ? !phone.Equals(account.phone) : account.phone != null)
            {
                return false;
            }
            if (postalCode != null ? !postalCode.Equals(account.postalCode) : account.postalCode != null)
            {
                return false;
            }
            if (state != null ? !state.Equals(account.state) : account.state != null)
            {
                return false;
            }
            if (timeZone != null ? !timeZone.Equals(account.timeZone) : account.timeZone != null)
            {
                return false;
            }

            return true;
        }


        public override int GetHashCode()
        {
            int result = accountId != null ? accountId.GetHashCode() : 0;
            result = 31 * result + (externalKey?.GetHashCode() ?? 0);
            result = 31 * result + (accountCBA != null ? accountCBA.GetHashCode() : 0);
            result = 31 * result + (accountBalance.GetHashCode());
            result = 31 * result + (name != null ? name.GetHashCode() : 0);
            result = 31 * result + (firstNameLength != null ? firstNameLength.GetHashCode() : 0);
            result = 31 * result + (email != null ? email.GetHashCode() : 0);
            result = 31 * result + (billCycleDayLocal != null ? billCycleDayLocal.GetHashCode() : 0);
            result = 31 * result + (currency != null ? currency.GetHashCode() : 0);
            result = 31 * result + (paymentMethodId != null ? paymentMethodId.GetHashCode() : 0);
            result = 31 * result + (timeZone != null ? timeZone.GetHashCode() : 0);
            result = 31 * result + (address1 != null ? address1.GetHashCode() : 0);
            result = 31 * result + (address2 != null ? address2.GetHashCode() : 0);
            result = 31 * result + (postalCode != null ? postalCode.GetHashCode() : 0);
            result = 31 * result + (company != null ? company.GetHashCode() : 0);
            result = 31 * result + (city != null ? city.GetHashCode() : 0);
            result = 31 * result + (state != null ? state.GetHashCode() : 0);
            result = 31 * result + (country != null ? country.GetHashCode() : 0);
            result = 31 * result + (locale != null ? locale.GetHashCode() : 0);
            result = 31 * result + (phone != null ? phone.GetHashCode() : 0);
            result = 31 * result + (isMigrated != null ? isMigrated.GetHashCode() : 0);
            result = 31 * result + (isNotifiedForInvoices != null ? isNotifiedForInvoices.GetHashCode() : 0);
            return result;
        }
    }
}
