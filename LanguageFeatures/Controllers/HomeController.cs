using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index() {
            return "Navigate to URL to show an example";
        }
        public ViewResult AutoPropertyViewResult() {
            var product = new Product();
            product.Name = "Kayak";
            return View("Result", (object)string.Format("Product name: {0}", product.Name));
        }
        public ViewResult GetProductCategory() {
            var product = new Product {
                Name = "Kayak",
                ProductID = 100,
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
            return View("Result", (object) string.Format("Product name: {0}", fruits[1]));
        }
    }
}