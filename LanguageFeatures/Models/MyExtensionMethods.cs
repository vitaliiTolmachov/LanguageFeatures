using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace LanguageFeatures.Models
{
	public static class MyExtensionMethods
	{
		public static decimal TotalCount(this ShoppingCart shoppingCart) {
			decimal totalCount = 0m;
			foreach (Product product in shoppingCart.Products) {
				totalCount += product.Price;
			}
			return totalCount;
		}

		public static decimal GetTotalPrices(this IEnumerable<Product> products) {
			decimal total = 0m;
			foreach (Product product in products) {
				total += product.Price;
			}
			return total;
		}
		public static IEnumerable<Product> FilerProductsByCatrgory(this IEnumerable<Product> products, string category) {
			foreach (Product product in products)
			{
				if (product.Category.ToLower().Equals(category.ToLower())) {
					yield return product; 
				}
			}
		}
		public static IEnumerable<Product> Filter(this IEnumerable<Product> products, Func<Product, bool> filterFunction) {
			foreach (Product product in products)
			{
				if (filterFunction.Invoke(product))
				{
					yield return product;
				}
			}
		}
		public static async Task<long?> GetlPageLength() {
			var client = new HttpClient();
			var res = await client.GetAsync("https://vk.com");
			return res.Content.Headers.ContentLength;
		} 
	}
}