using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2FelevesFeladat
{
    class Seller : IInvolvedInTransaction
    {
        public string TaxNumber { get; set; }
        public string ContactPerson { get; set; }
        public int Evaluation { get; set; }
        public ListNotSorted<Product> ProductList { get; set; }
        public string Name { get; set; }

        public Seller(string name, string taxnumber)
        {
            Name = name;
            TaxNumber = taxnumber;
            ContactPerson = name;
            ProductList = new ListNotSorted<Product>();
        }

        public override string ToString()
        {
            string str = ProductList.IterateString();
            return "Nev: " + Name + Environment.NewLine +
                "Adoszam: " + TaxNumber + Environment.NewLine + 
                "Kontaktszemély: " + ContactPerson + Environment.NewLine +
                "Termékek: \n" + str ;
        }
    }

    class LegalEntitySeller : Seller
    {
        protected string yearOfFoundation;
        public LegalEntitySeller(string sellerName, string sellerTaxNumber, string contactPerson, string yearOfFoundation) : base(sellerName, sellerTaxNumber)
        {
            this.yearOfFoundation = yearOfFoundation;
        }
    }

    class IndividualSeller : Seller
    {
        public IndividualSeller(string sellerName, string sellerTaxNumber) : base(sellerName, sellerTaxNumber)
        {
            ContactPerson = sellerName;
        }
    }

    class KftSeller : LegalEntitySeller
    {
        public KftSeller(string sellerName, string sellerTaxNumber, string contactPerson, string yearOfFoundation) : base(sellerName, sellerTaxNumber, contactPerson, yearOfFoundation)
        {
            ContactPerson = contactPerson;
        }
    }

    class ZrtSeller : LegalEntitySeller
    {
        public ZrtSeller(string sellerName, string sellerTaxNumber, string contactPerson, string yearOfFoundation) : base(sellerName, sellerTaxNumber, contactPerson, yearOfFoundation)
        {
            ContactPerson = contactPerson;
        }
        public string YearOfFoundation { get => yearOfFoundation; set => yearOfFoundation = value; }
    }
}
