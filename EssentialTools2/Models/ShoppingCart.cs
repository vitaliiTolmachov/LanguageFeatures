using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EssentialTools2.Models;

namespace EssentialTools2.Models
{
	public class ShoppingCart
	{
		private IValueCalculator calc;
		public IEnumerable<Product> Products { get; set; }

		public ShoppingCart(IValueCalculator calcParams)
		{
			calc = calcParams;
		}
		public decimal CalculateTotalProducts()
		{
			return this.calc.ValueProducts(Products);
		}
	}
}