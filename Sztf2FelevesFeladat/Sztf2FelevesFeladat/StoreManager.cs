using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2FelevesFeladat
{
    class StoreManager
    {
        private ListNotSorted<Buyer> buyerList = new ListNotSorted<Buyer>();
        private ListNotSorted<Seller> sellerList = new ListNotSorted<Seller>();
        private ListNotSorted<Product> productsList = new ListNotSorted<Product>();

        public bool BuyerInsert(Buyer newBuyer)
        {
            var buyer = buyerList.Find(x => x.TaxNumber == newBuyer.TaxNumber);
            if (buyer == null)
            {
                buyerList.Insert(newBuyer);
                return true;
            }
            else
            {
                throw new BuyerExists(newBuyer as Buyer);
            }
        }

        public bool SellerInsert(Seller newSeller)
        {
            var seller = sellerList.Find(x => x.TaxNumber == newSeller.TaxNumber);
            if (seller == null)
            {
                sellerList.Insert(newSeller);
                return true;
            }
            else
            {
                throw new SellerExists(newSeller as Seller);
            }
        }

        public void ProductRegistration(Product productToRegister)
        {
            Seller soughtSeller = sellerList.Find(x => x.TaxNumber == productToRegister.SellerTaxNumber);
            if (soughtSeller != null)
            {
                soughtSeller.ProductList.Insert(productToRegister);
                productsList.Insert(productToRegister);
            }
        }

        public void PrintBuyer()
        {
            buyerList.Print();
        }

        public void PrintSeller()
        {
            sellerList.Print();
        }

        public void PrintProducts()
        {
            productsList.Print();
        }

        public Seller FindSellerByTaxNumber(string soughtTaxNumber)
        {
            Seller soughtSeller = sellerList.Find(x => x.TaxNumber == soughtTaxNumber);
            return soughtSeller;
        }

        public Buyer FindBuyerByTaxNumber(string soughtTaxNumber)
        {
            Buyer soughtBuyer = buyerList.Find(x => x.TaxNumber == soughtTaxNumber);
            return soughtBuyer;
        }

        public Product FindProductByProductName(string soughtProductName)
        {
            Product soughtProduct = productsList.Find(x=> x.productName == soughtProductName);
            return soughtProduct;
        }

        public void Buying(Seller seller, Buyer buyer, Product product) 
        {
            Product temp = seller.ProductList.Delete(product);
            productsList.Delete(product);
            buyer.ProductList.Insert(temp);
            buyer.ProductPcs++;
            buyer.Evaluation++;
        }

        public void Gifting(int maxGiftAmount)
        {
            var productsForSale = ProductsForSale();
            var buyers = buyerList.ToArray();
            Array.Sort(buyers, (o1,o2) => o2.ProductPcs.CompareTo(o1.ProductPcs));

            var giftsRemaining = maxGiftAmount;
            int i = 0;
            while (giftsRemaining > 0 && i < buyers.Length )
            {
                if (buyers[i].Evaluation >= giftsRemaining)
                {
                    GivingAwayProducts(buyers[i], giftsRemaining, productsForSale);
                    giftsRemaining = 0;
                }
                else
                {
                    GivingAwayProducts(buyers[i], buyers[i].Evaluation, productsForSale);
                    giftsRemaining -= buyers[i].Evaluation;
                }
                i++;
            }

            if (giftsRemaining > 0)
            {
                throw new UnallocatedProductLeftException("Nem sikerult mindent kiosztani");
            }
        }

        public void GivingAwayProducts(Buyer buyer, int giftAmount, ListNotSorted<(Seller, Product)>  productsForSale)
        {
            for (int i = 0; i < giftAmount; i++)
            {
                var gift = productsForSale.Pop();

                if (gift.Equals(null))
                {
                    return;
                }

                var seller = gift.Item1;
                var product = gift.Item2;

                if (seller == null || product == null)
                {
                    return;
                }

                Buying(seller, buyer, product);
            }
        }

        public ListNotSorted<(Seller, Product)> ProductsForSale() 
        {
            var productList = new ListNotSorted<(Seller, Product)>();
            sellerList.Foreach(seller => 
            {
                seller.ProductList.Foreach(product => productList.Insert((seller, product)));
            });
            return productList;
        }

        class SellerException : Exception
        {
            Seller defectiveSeller;

            public SellerException(Seller defectiveSeller)
            {
                this.defectiveSeller = (defectiveSeller as Seller);
            }

            public Seller DefectiveSeller { get => defectiveSeller; set => defectiveSeller = value; }
        }

        class SellerExists : SellerException
        {
            public SellerExists(Seller defectiveSeller) : base(defectiveSeller) { }
        }

        class BuyerException : Exception
        {
            Buyer defectiveBuyer;

            public BuyerException(Buyer defectiveBuyer)
            {
                this.defectiveBuyer = (defectiveBuyer as Buyer);
            }

            public Buyer DefectiveBuyer { get => defectiveBuyer; set => defectiveBuyer = value; }
        }

        class BuyerExists : BuyerException
        {
            public BuyerExists(Buyer defectiveBuyer) : base(defectiveBuyer) { }
        }

        class UnallocatedProductLeftException : Exception
        {
            public UnallocatedProductLeftException(string msg) : base(msg)
            {

            }
        }
    }
}
