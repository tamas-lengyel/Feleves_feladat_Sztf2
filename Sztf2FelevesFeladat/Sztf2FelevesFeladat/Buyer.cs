using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2FelevesFeladat
{
    class Buyer : IInvolvedInTransaction
    {
        public string TaxNumber { get; set; }
        public string ContactPerson { get; set; }
        public int Evaluation { get; set; }
        public ListNotSorted<Product> ProductList { get; set; }
        public string Name { get; set; }
        public int ProductPcs { get; set; }

        public Buyer(string name, string taxnumber)
        {
            Name = name;
            TaxNumber = taxnumber;
            ContactPerson = name;
            Evaluation = ProductPcs;
            ProductList = new ListNotSorted<Product>();
        }

        public override string ToString()
        {
            string str = ProductList.IterateString();
            return "Nev: " + Name + Environment.NewLine +
                "Adoszam: " + TaxNumber + Environment.NewLine +
                "Kontaktszemély: " + ContactPerson + Environment.NewLine +
                "Termékek: \n" + str;
        }
    }
    class LegalEntityBuyer : Buyer
    {
        protected string yearOfFoundation;
        public LegalEntityBuyer(string buyerName, string buyerTaxNumber, string contactPerson, string yearOfFoundation) : base(buyerName, buyerTaxNumber)
        {
            this.yearOfFoundation = yearOfFoundation;
        }
    }

    class IndividualBuyer : Buyer
    {
        public IndividualBuyer(string buyerName, string buyerTaxNumber) : base(buyerName, buyerTaxNumber)
        {
            ContactPerson = buyerName;
        }
    }

    class KftBuyer : LegalEntityBuyer
    {
        public KftBuyer(string buyerName, string buyerTayNumber, string contactPerson, string yearOfFoundation) : base(buyerName, buyerTayNumber, contactPerson, yearOfFoundation)
        {
            ContactPerson = contactPerson;
        }
    }

    class ZrtBuyer : LegalEntityBuyer
    {
        public ZrtBuyer(string buyerName, string buyerTaxNumber, string contactPerson, string yearOfFoundation) : base(buyerName, buyerTaxNumber, contactPerson, yearOfFoundation)
        {
            ContactPerson = contactPerson;
        }
        public string YearOfFoundation { get => yearOfFoundation; set => yearOfFoundation = value; }
    }
}
