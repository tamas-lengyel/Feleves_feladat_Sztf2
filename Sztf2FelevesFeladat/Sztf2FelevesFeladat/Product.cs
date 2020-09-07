using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2FelevesFeladat
{
    class Product : IComparable
    {
        public string productName { get; set; }
        public int productPrice { get; set; }
        public string SellerName { get; set; }
        public string SellerTaxNumber { get; set; }

        public Product(string name, int price, Seller seller)
        {
            productName = name;
            SellerName = seller.Name;
            SellerTaxNumber = seller.TaxNumber;

            if (price > 0)
            {
                productPrice = price;
            }
            else
            {
                productPrice = 0;
            }
        }

        public int CompareTo(object obj)
        {
            return this.productName.CompareTo(((Product)obj).productName);
        }

        public override string ToString()
        {
            return "\t Megnevevezés: " + this.productName + Environment.NewLine +
                   "\t Ár: " + productPrice + " Ft" + Environment.NewLine +
                   "\t Eladó: " + SellerName + Environment.NewLine;
        }
    }
}
