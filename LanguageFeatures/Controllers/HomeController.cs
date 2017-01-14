using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index() {
			var product = new Product {
				Name = "Kayak",
				ProductId = 100,
				Category = "Watersports",
				Description = "A boat for one person",
				Price = 275m
			};
			ViewBag.Count = 1;
			ViewBag.Supplier = null;
			ViewBag.isExpressShip = true;
			ViewBag.isDiscount = false;
			return View(product);
		}
		public ActionResult GetArray() {
			Product[] arr =
			{
				new Product {Name = "Kayak", Price = 275m, Category = "Watersports"},
				new Product {Name = "LifeJacket", Price = 48.49m, Category = "Watersports"},
				new Product {Name = "Soccer ball", Price = 19.50m, Category = "Soccer"},
				new Product {Name = "Corner flag", Price = 18m, Category = "Soccer"}
			};
			return View(arr);
		}
		public ViewResult AutoPropertyViewResult() {
			var product = new Product();
			product.Name = "Kayak";
			return View("Result", (object)string.Format("Product name: {0}", product.Name));
		}
		public ViewResult GetProductCategory() {
			var product = new Product {
				Name = "Kayak",
				ProductId = 100,
				Category = "Watersports",
				Description = "A boat for one person",
				Price = 275m
			};
			return View("Result", (object)string.Format("Product name: {0}", product.Category));
		}

		public ViewResult GetCollection() {
			string[] fruits = new[] { "apple", "banana", "peach" };
			List<int> intList = new List<int> { 10, 20, 30 };
			Dictionary<int, string> dict = new Dictionary<int, string>
			{
				{ 10, "apple" },
				{ 20, "banana" },
				{ 30, "peach" }
			};
			return View("Result", (object)string.Format("Product name: {0}", fruits[1]));
		}
		public ViewResult GetTotalCount() {
			var shopingCart = new ShoppingCart() {
				Products = new List<Product>
				{
					new Product {Name = "Kayak", Price = 275m},
					new Product {Name = "LifeJacket", Price = 48.49m},
					new Product {Name = "Soccer ball", Price = 19.50m},
					new Product {Name = "Corner flag", Price = 18}
				}
			};
			decimal total = shopingCart.TotalCount();
			return View("Result", (object)string.Format(new CultureInfo("En-us"), "Total shopping cart: {0:C}", total));
		}
		public ViewResult GetTotalPrices() {
			var shopingCart = new ShoppingCart() {
				Products = new List<Product>
				{
					new Product {Name = "Kayak", Price = 275m},
					new Product {Name = "LifeJacket", Price = 48.49m},
					new Product {Name = "Soccer ball", Price = 19.50m},
					new Product {Name = "Corner flag", Price = 18}
				}
			};
			var products = new Product[]
			{
					new Product {Name = "Kayak", Price = 275m},
					new Product {Name = "LifeJacket", Price = 48.49m},
					new Product {Name = "Soccer ball", Price = 19.50m},
					new Product {Name = "Corner flag", Price = 18}
			};
			decimal shoppingCartTotal = shopingCart.TotalCount();
			decimal productsTotal = products.GetTotalPrices();
			return View("Result", (object)string.Format(new CultureInfo("En-us"),
				"Total shopping cart: {0:c0};\nTotal prices: {1:c0}", shoppingCartTotal, productsTotal));
		}
		public ViewResult GetFilterByCategory() {
			var products = new Product[]
			{
					new Product {Name = "Kayak", Price = 275m,Category = "Watersports"},
					new Product {Name = "LifeJacket", Price = 48.49m, Category = "Watersports"},
					new Product {Name = "Soccer ball", Price = 19.50m, Category = "Soccer"},
					new Product {Name = "Corner flag", Price = 18, Category = "Soccer"}
			};
			var socerCollection = products.FilerProductsByCatrgory("Watersports");
			var soccerTotal = socerCollection.GetTotalPrices();
			return View("Result", (object)string.Format(new CultureInfo("En-us"),
				"Total Watersports in shoppingcart: {0:c0}", soccerTotal));
		}
		public ViewResult Filter() {
			var products = new Product[]
			{
					new Product {Name = "Kayak", Price = 275m,Category = "Watersports"},
					new Product {Name = "LifeJacket", Price = 48.49m, Category = "Watersports"},
					new Product {Name = "Soccer ball", Price = 19.50m, Category = "Soccer"},
					new Product {Name = "Corner flag", Price = 18, Category = "Soccer"}
			};
			var socerCollection = products.Filter(product => product.Category.ToLower().Equals("soccer"));
			var soccerTotal = socerCollection.GetTotalPrices();
			return View("Result", (object)string.Format(new CultureInfo("En-us"),
				"Total Soccer in shoppingcart: {0:c0}", soccerTotal));
		}
		public ViewResult CreateAnonimusResult() {
			var shopingCart = new ShoppingCart() {
				Products = new List<Product>
				{
					new Product {Name = "Kayak", Price = 275m},
					new Product {Name = "LifeJacket", Price = 48.49m},
					new Product {Name = "Soccer ball", Price = 19.50m},
					new Product {Name = "Corner flag", Price = 18}
				}
			};

			var sb = new StringBuilder();
			foreach (Product product in shopingCart.Products) {

				sb.Append("Name: ").Append(product.Name).Append(" Categoty: ").Append(product.Category).Append(" Price: ").Append(product.Price);
			}
			sb.Append("\nTotal Price: " + shopingCart.GetTotalPrices());
			return View("Result", (object)sb.ToString());
		}
		public ViewResult Top3Product() {
			var products = new Product[]
			{
					new Product {Name = "Kayak", Price = 275m,Category = "Watersports"},
					new Product {Name = "LifeJacket", Price = 48.49m, Category = "Watersports"},
					new Product {Name = "Soccer ball", Price = 19.50m, Category = "Soccer"},
					new Product {Name = "Corner flag", Price = 18m, Category = "Soccer"}
			};
			var topCollection = products.OrderByDescending(p => p.Price).Take(3);
			var sb = new StringBuilder();
			foreach (Product product in topCollection) {

				sb.Append("Name: ").Append(product.Name).Append(" Categoty: ").Append(product.Category).Append(" Price: ").Append(product.Price);
			}
			sb.Append("\nTotal Price: " + topCollection.GetTotalPrices());
			return View("Result", (object)sb.ToString());
		}
	}
}