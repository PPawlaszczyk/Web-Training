using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeControler
        public string Index()
        {
            return "Przejscie do adresu URL pokazujacego przyklad";
        }

        public ViewResult AutoProperty()
        {
            Produkt myproduct = new Produkt();
            myproduct.Name = "Kajak";
            string productName = myproduct.Name;
            return View("Result", (object)String.Format("Nazwa produktu: {0} ", productName));
        }
        public ViewResult CreateProduct()
        {
            Produkt myproduct = new Produkt
            { ProductID = 100, Name = "Kajak", Description = "łodka jedonosobowa", Price = 275M, Category = "sporty wodne" };
            return View("Result", (object)String.Format("Kategoria: {0} ", myproduct.Category));
        }
        public ViewResult CreateCollection()
        {
            string[] stringArray = { "jabłko", "pomarańcza", "gruszka" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int>
            {
                {"jabłko",10 },{"pomarancza",20},{"gruszka",30}
            };
            return View("Result", (object)Convert.ToString(myDict.FirstOrDefault(pair => pair.Key == "jabłko").Value));

        }

        public ViewResult CreateCollection2()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Produkt> {
                new Produkt { Name = "kajak", Price = 275M },
                new Produkt { Name = "kamizelka", Price = 49.89M },
                new Produkt { Name = "pilka", Price = 19.50M },
                new Produkt { Name = "flaga", Price = 34.95M }
            }
            };
            decimal cartTotal = cart.TotalPrices();
            return View("Result", (object)String.Format("Razem: {0:c}", cartTotal));

        }

        public ViewResult CreateCollection_enum()
        {
            ShoppingCart_enum cart2 = new ShoppingCart_enum
            {
                Products = new List<Produkt> {
                new Produkt { Name = "kajak", Price = 275M },
                new Produkt { Name = "kamizelka", Price = 49.89M },
                new Produkt { Name = "pilka", Price = 19.50M },
                new Produkt { Name = "flaga", Price = 34.95M }
            }
            };
            decimal cartTotal = cart2.TotalPrices_enum();
            return View("Result", (object)String.Format("Razem: {0:c}", cartTotal));

        }

        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Produkt> produkts = new ShoppingCart_enum
            {
                Products = new List<Produkt>
                {
                new Produkt { Name = "kajakowo_1", Price = 275M },
                new Produkt { Name = "kamizelka_1", Price = 49.89M },
                new Produkt { Name = "pilka_1", Price = 19.50M },
                new Produkt { Name = "flaga_1", Price = 34.95M }
                }
            };

            Produkt[] productArray =
            {

                new Produkt { Name = "kajakowo_1", Price = 275M },
                new Produkt { Name = "kamizelka_1", Price = 49.89M },
                new Produkt { Name = "pilka_1", Price = 19.50M },
                new Produkt { Name = "flaga_1", Price = 34.95M }
            };
            decimal cartTotal = produkts.TotalPrices_enum();
            decimal arrayTotal = produkts.TotalPrices_enum();
            return View("Result", (object)String.Format("Razem koszyk: {0}, Razem tablica: {1}", cartTotal, arrayTotal));

        }

        public ViewResult UseExtensionEnumerable_Filter()
        {
            IEnumerable<Produkt> produkts = new ShoppingCart_enum
            {
                Products = new List<Produkt>
                {
                    new Produkt { Name = "kajakowo_1", Price = 275M, Category = "sport" },
                    new Produkt { Name = "kamizelka_1", Price = 49.89M, Category = "sport" },
                    new Produkt { Name = "pilka_1", Price = 19.50M, Category = "sklep" },
                    new Produkt { Name = "flaga_1", Price = 34.95M, Category = "sport" }
                }
            };
            decimal total = 0;
            foreach (Produkt prod in produkts.FilterByCategory("sklep"))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Razem koszyk: {0}", total));
        }

        public ViewResult UseExtensionEnumerable_Filter_lambda()
        {
            IEnumerable<Produkt> produkts = new ShoppingCart_enum
            {
                Products = new List<Produkt>
                {
                    new Produkt { Name = "kajakowo_1", Price = 275M, Category = "sport", Description= "jasiek" },
                    new Produkt { Name = "kamizelka_1", Price = 49.89M, Category = "sport", Description= "niejasiek" },
                    new Produkt { Name = "pilka_1", Price = 19.50M, Category = "sklep" , Description= "niejasiek"},
                    new Produkt { Name = "flaga_1", Price = 34.95M, Category = "sport", Description= "jasiek" }
                }
            };
            // Func<Produkt, bool> Categoryfilter =prod=>prod.Category == "sklep";
            decimal total = 0;
            //  foreach (Produkt prod in produkts.Filter_Lamda(Categoryfilter))
            foreach (Produkt prod in produkts.Filter_Lamda(prod => prod.Name == "jasiek"))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Razem koszyk: {0}", total));
        }
        public ViewResult CreateAnonArray()
        {
            var OddsAndEnds = new[]
            {
                new { name = "MVC", Category = "Wzorzec" },
                new { name = "Kapelusz", Category = "Odzież" },
                new { name = "Jabłko", Category = "Owoc" },
            };
            StringBuilder result = new StringBuilder();
            foreach (var item in OddsAndEnds)
            {
                result.Append(item.name).Append(" ");
            }
            return View("Result", (object)result.ToString());
        }
        public ViewResult FindProduct()
        {
            Produkt[] products =
                {
                    new Produkt { Name = "kajakowo_1", Price = 275M, Category = "sport", Description= "jasiek" },
                    new Produkt { Name = "kamizelka_1", Price = 49.89M, Category = "sport", Description= "niejasiek" },
                    new Produkt { Name = "pilka_1", Price = 19.50M, Category = "sklep" , Description= "niejasiek"},
                    new Produkt { Name = "flaga_1", Price = 34.95M, Category = "sport", Description= "jasiek" }
                };
            var FoundProducts = from match in products
                                orderby match.Price descending
                                select new
                                { match.Name, match.Price };
            int count = 0;
            StringBuilder result = new StringBuilder();
            foreach (var p in FoundProducts)
            {
                result.AppendFormat("Cena: {0} ", p.Price);
                if (++count == 3) { break; }
            }
            return View("Result", (object)result.ToString());
        }

        public ViewResult FindProduct_LINQ2()
        {
            Produkt[] products =
                {
                    new Produkt { Name = "kajakowo_1", Price = 275M, Category = "sport", Description= "jasiek" },
                    new Produkt { Name = "kamizelka_1", Price = 49.89M, Category = "sport", Description= "niejasiek" },
                    new Produkt { Name = "pilka_1", Price = 19.50M, Category = "sklep" , Description= "niejasiek"},
                    new Produkt { Name = "flaga_1", Price = 34.95M, Category = "sport", Description= "jasiek" }
                };
            var FoundProducts = products.OrderByDescending(e => e.Price).Take(3).Select(e => new { e.Name, e.Price });
            
            StringBuilder result = new StringBuilder();
            foreach (var p in FoundProducts)
            {
                result.AppendFormat("Cena: {0} ", p.Price);
            }
            return View("Result", (object)result.ToString());
        }

    }
}