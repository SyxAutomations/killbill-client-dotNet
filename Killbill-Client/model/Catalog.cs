
using System;
using System.Collections.Generic;
using System.Text;

namespace Killbill_Client.model {









    public class Catalog : KillBillObject
    {

        private string name;
        private DateTime effectiveDate;
        private List<Currency> currencies;
        private List<Product> products;
        private List<PriceList> priceLists;

        public Catalog()
        {
        }


        public Catalog(string name,
            DateTime effectiveDate,
            List<Currency> currencies,
            List<Product> products,
            List<PriceList> priceLists)
        {
            this.name = name;
            this.effectiveDate = effectiveDate;
            this.currencies = currencies;
            this.products = products;
            this.priceLists = priceLists;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public List<Product> getProducts()
        {
            return products;
        }

        public void setProducts(List<Product> products)
        {
            this.products = products;
        }

        public DateTime getEffectiveDate()
        {
            return effectiveDate;
        }

        public void setEffectiveDate(DateTime effectiveDate)
        {
            this.effectiveDate = effectiveDate;
        }

        public List<Currency> getCurrencies()
        {
            return currencies;
        }

        public void setCurrencies(List<Currency> currencies)
        {
            this.currencies = currencies;
        }

        public List<PriceList> getPriceLists()
        {
            return priceLists;
        }

        public void setPriceLists(List<PriceList> priceLists)
        {
            this.priceLists = priceLists;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Catalog{");
            sb.Append("name='").Append(name).Append('\'');
            sb.Append(", effectiveDate='").Append(effectiveDate).Append('\'');
            sb.Append(", currencies='").Append(currencies).Append('\'');
            sb.Append(", products=").Append(products);
            sb.Append(", priceLists=").Append(priceLists);
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

            Catalog catalog = (Catalog) o;

            if (name != null ? !name.Equals(catalog.name) : catalog.name != null)
            {
                return false;
            }
            if (effectiveDate != null
                ? effectiveDate.compareTo(catalog.effectiveDate) != 0
                : catalog.effectiveDate != null)
            {
                return false;
            }
            if (currencies != null ? !currencies.Equals(catalog.currencies) : catalog.currencies != null)
            {
                return false;
            }
            if (products != null ? !products.Equals(catalog.products) : catalog.products != null)
            {
                return false;
            }
            if (priceLists != null ? !priceLists.Equals(catalog.priceLists) : catalog.priceLists != null)
            {
                return false;
            }

            return true;
        }


        public override int GetHashCode()
        {
            int result = name != null ? name.GetHashCode() : 0;
            result = 31*result + (products != null ? products.GetHashCode() : 0);
            return result;
        }
    }
}
