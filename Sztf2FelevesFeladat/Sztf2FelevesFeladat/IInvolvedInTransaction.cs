using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2FelevesFeladat
{
    interface IInvolvedInTransaction
    {
        string TaxNumber { get; set; }
        string ContactPerson { get; set; }
        int Evaluation { get; set; }
        ListNotSorted<Product> ProductList { get; set; }
    }
}
