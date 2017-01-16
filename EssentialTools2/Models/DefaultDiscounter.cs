using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools2.Models
{
	public interface IDiscountHelper
	{
		decimal ApplayDiscount(decimal total);
	}

	public class DefaultDiscounter : IDiscountHelper
	{
		public decimal DiscountSize { get; set; }

		public DefaultDiscounter(decimal discountParam)
		{
			this.DiscountSize = discountParam;
		}
		public decimal ApplayDiscount(decimal total)
		{
			return (total - (total/100* DiscountSize));
		}
	}
}