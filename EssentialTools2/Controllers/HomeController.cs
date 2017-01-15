using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools2.Models;
using Ninject;

namespace EssentialTools2.Controllers
{
	public class HomeController : Controller
	{
		private Product[] products = new Product[]
		{
			new Product {Name = "Kayak", Price = 275m, Category = "Watersports"},
			new Product {Name = "LifeJacket", Price = 48.49m, Category = "Watersports"},
			new Product {Name = "Soccer ball", Price = 19.50m, Category = "Soccer"},
			new Product {Name = "Corner flag", Price = 18, Category = "Soccer"}
		};

		// GET: Home
		public ActionResult Index()
		{
			IKernel ninjectKernel = new StandardKernel();
			ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
			var calc = ninjectKernel.Get<IValueCalculator>();
			var shoppingCart = new ShoppingCart(calc)
			{
				Products = products
			};
			return View(shoppingCart.CalculateTotalProducts());
		}
	}
}