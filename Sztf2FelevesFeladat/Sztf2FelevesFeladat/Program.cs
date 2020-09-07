using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sztf2FelevesFeladat
{
    class Program
    {
        static StoreManager manager = new StoreManager();
        static void Main(string[] args)
        {
            if (File.Exists("eladoLista.txt"))
            {
                UploadSellersFromFile(ref manager, "eladoLista.txt");
            }
            if (File.Exists("vevoLista.txt"))
            {
                UploadBuyersFromFile(ref manager, "vevoLista.txt");
            }
            if (File.Exists("termekLista.txt"))
            {
                UploadProductsFromFile(ref manager, "termekLista.txt");
            }
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Válassz az alábbiak közül:");
            Console.WriteLine("1) Vevő hozzáadása");
            Console.WriteLine("2) Eladó hozzáadása");
            Console.WriteLine("3) Vevők kiírása");
            Console.WriteLine("4) Eladók kiírása");
            Console.WriteLine("5) Vásárlás");
            Console.WriteLine("6) Ajándékosztás");
            Console.WriteLine("7) Exit");
            Console.Write("\r\nVálassz egy opciót: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Add meg milyen vevőt akarsz felvenni: 1)Magányszemély 2)Kft 3)Zrt");
                    string input = Console.ReadLine();
                    try
                    {
                        if (input == "1")
                        {
                            Console.WriteLine("Add meg az új Eladó Magánszemély adatait a következőképp: nev, adoszam");
                            string inputV = Console.ReadLine();
                            string[] strV = inputV.Split(',');
                            Buyer individual = new IndividualBuyer(strV[0].Trim(), strV[1].Trim());
                            manager.BuyerInsert(individual);
                        }
                        else if (input == "2")
                        {
                            Console.WriteLine("Add meg az új Eladó KFT adatait a következőképp: nev, adoszam, kontaktszemely, alapítás éve");
                            string inputV = Console.ReadLine();
                            string[] strV = inputV.Split(',');
                            Buyer kft = new KftBuyer(strV[0].Trim(), strV[1].Trim(), strV[2].Trim(), strV[3].Trim());
                            manager.BuyerInsert(kft);
                        }
                        else if (input == "3")
                        {
                            Console.WriteLine("Add meg az új Eladó ZRT adatait a következőképp: nev, adoszam, kontaktszemely, alapítás éve");
                            string inputV = Console.ReadLine();
                            string[] strV = inputV.Split(',');
                            Buyer zrt = new ZrtBuyer(strV[0].Trim(), strV[1].Trim(), strV[2].Trim(), strV[3].Trim());
                            manager.BuyerInsert(zrt);
                        }
                        else
                        {
                            throw new NoSuchNumber("Rossz számot írtál be!");
                        }
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Sikeres adatbevitel!");
                        Console.ReadKey();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Nem megfelelő formátumban írta be az adatokat!");
                        System.Threading.Thread.Sleep(2000);
                    }
                    return true;
                case "2":
                    Console.WriteLine("Add meg milyen eladót akarsz felvenni: 1)Magányszemély 2)Kft 3)Zrt");
                    string inp = Console.ReadLine();
                    
                    try
                    {
                        if (inp == "1")
                        {
                            Console.WriteLine("Add meg az új Eladó Magánszemély adatait a következőképp: nev, adoszam");
                            string inputE = Console.ReadLine();
                            string[] strE = inputE.Split(',');
                            Seller individual = new IndividualSeller(strE[0].Trim(), strE[1].Trim());
                            manager.SellerInsert(individual);
                        }
                        else if (inp == "2")
                        {
                            Console.WriteLine("Add meg az új Eladó KFT adatait a következőképp: nev, adoszam, kontaktszemely, alapítás éve");
                            string inputE = Console.ReadLine();
                            string[] strE = inputE.Split(',');
                            Seller kft = new KftSeller(strE[0].Trim(), strE[1].Trim(), strE[2].Trim(), strE[3].Trim());
                            manager.SellerInsert(kft);
                        }
                        else if (inp == "3")
                        {
                            Console.WriteLine("Add meg az új Eladó ZRT adatait a következőképp: nev, adoszam, kontaktszemely, alapítás éve");
                            string inputE = Console.ReadLine();
                            string[] strE = inputE.Split(',');
                            Seller zrt = new ZrtSeller(strE[0].Trim(), strE[1].Trim(), strE[2].Trim(), strE[3].Trim());
                            manager.SellerInsert(zrt);
                        }
                        else
                        {
                            throw new NoSuchNumber("Rossz számot írtál be!");
                        }
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Sikeres adatbevitel!");
                        Console.ReadKey();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Nem megfelelő formátumban írta be az adatokat!");
                        System.Threading.Thread.Sleep(2000);
                    }
                    return true;
                case "3":
                    manager.PrintBuyer();
                    Console.ReadKey();
                    return true;
                case "4":
                    manager.PrintSeller();
                    Console.ReadKey();
                    return true;
                case "5":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nVálasszon melyik Vevővel szeretne vásárolni, az adószámának beírásával:\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    manager.PrintBuyer();
                    string str = Console.ReadLine();
                    Buyer buyer = manager.FindBuyerByTaxNumber(str);
                    if (buyer == null)
                    {
                        Console.WriteLine("Sajnos nincsenek vásárlók feltöltve.");
                        System.Threading.Thread.Sleep(2000);
                        return true;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Válasszon az alábbi Eladók közül, az Eladó adószámának beírásával:\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    manager.PrintSeller();
                    string str1 = Console.ReadLine();
                    Seller seller = manager.FindSellerByTaxNumber(str1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nVálasszon az Eladó termékei közül, a termék nevének beírásával.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (seller == null)
                    {
                        Console.WriteLine("Sajnos nincsenek eladók feltöltve.");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine(seller.ProductList.IterateString());
                        string str2 = Console.ReadLine();
                        Product termek = manager.FindProductByProductName(str2);

                        manager.Buying(seller, buyer, termek);
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Sikeres vásárlás!");
                        System.Threading.Thread.Sleep(1000);
                    }
                    return true;
                case "6":
                    manager.Gifting(5);
                    return true;
                case "7":
                    return false;
                default:
                    return true;
            }
        }

        public static void UploadSellersFromFile(ref StoreManager manager, string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName, Encoding.Default);

                while (!reader.EndOfStream)
                {
                    string[] cut = reader.ReadLine().Split(';');
                    switch (cut[0])
                    {
                        case "0":
                            Seller individual = new IndividualSeller(cut[1], cut[2]);
                            manager.SellerInsert(individual);
                            break;

                        case "1":
                            Seller kft = new KftSeller(cut[1], cut[2], cut[3], cut[4]);
                            manager.SellerInsert(kft);
                            break;

                        case "2":
                            Seller zrt = new ZrtSeller(cut[1], cut[2], cut[3], cut[4]);
                            manager.SellerInsert(zrt);
                            break;
                    }
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Nem található a file!");
            }
        }

        public static void UploadBuyersFromFile(ref StoreManager manager, string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName, Encoding.Default);

                while (!reader.EndOfStream)
                {
                    string[] cut = reader.ReadLine().Split(';');
                    switch (cut[0])
                    {
                        case "0":
                            Buyer individual = new IndividualBuyer(cut[1], cut[2]);
                            manager.BuyerInsert(individual);
                            break;

                        case "1":
                            Buyer kft = new KftBuyer(cut[1], cut[2], cut[3], cut[4]);
                            manager.BuyerInsert(kft);
                            break;

                        case "2":
                            Buyer zrt = new ZrtBuyer(cut[1], cut[2], cut[3], cut[4]);
                            manager.BuyerInsert(zrt);
                            break;
                    }
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Nem található a file!");
            }
        }

        public static void UploadProductsFromFile(ref StoreManager manager, string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName, Encoding.Default);

                while (!reader.EndOfStream)
                {
                    string[] cut = reader.ReadLine().Split(';');
                    string sellerTaxNumber = cut[2];
                    Seller sellerOfProduct = manager.FindSellerByTaxNumber(sellerTaxNumber);

                    if (sellerOfProduct != null)
                    {
                        string name = cut[0];
                        int price = int.Parse(cut[1]);
                        int pcs = int.Parse(cut[2]);

                        Product product = new Product(cut[0], price, sellerOfProduct);
                        manager.ProductRegistration(product);
                    }
                }
            }
            else
            {
                Console.WriteLine("Nem található a file!");
            }
        }
    }

    class NoSuchNumber : Exception
    {
        public NoSuchNumber(string msg) : base(msg)
        {

        }
    }
}
