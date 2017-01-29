using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools2.Models
{
	public class FlexibleDiscounHelper : IDiscountHelper
	{
		public decimal ApplayDiscount(decimal total) {
			var discount = total > 100 ? 70 : 25;
			return total - (total / 100 * discount);
		}
	}
}