using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using EssentialTools2.Models;

namespace EssentialTools2.Models
{
	public class LinqValueCalculator:IValueCalculator
	{
		private IDiscountHelper discouner;
		public static int counter = 0;

		public LinqValueCalculator(IDiscountHelper discount)
		{
			this.discouner = discount;
			Debug.WriteLine(string.Format("There was {0} instance created", counter++));
		}
		public decimal ValueProducts(IEnumerable<Product> products)
		{
			return  discouner.ApplayDiscount(products.Sum(p => p.Price));
		}
	}
}