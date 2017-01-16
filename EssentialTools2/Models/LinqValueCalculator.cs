using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EssentialTools2.Models;

namespace EssentialTools2.Models
{
	public class LinqValueCalculator:IValueCalculator
	{
		private IDiscountHelper discouner;

		public LinqValueCalculator(IDiscountHelper discount)
		{
			this.discouner = discount;
		}
		public decimal ValueProducts(IEnumerable<Product> products)
		{
			return  discouner.ApplayDiscount(products.Sum(p => p.Price));
		}
	}
}