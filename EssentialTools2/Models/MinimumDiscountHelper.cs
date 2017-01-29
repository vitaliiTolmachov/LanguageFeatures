using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EssentialTools2.Models;

namespace EssentialTools2
{
	public class MinimumDiscountHelper : IDiscountHelper
	{
		public decimal ApplayDiscount(decimal total) {

			if (total < 0) {
				throw new ArgumentOutOfRangeException();
			} else if (total > 100) {
				return Math.Round(total - (total / 100 * 10), 2);
			} else if (total >= 10 && total <= 100) {
				return total - 5;
			} else {
				return total;
			}
		}
	}
}