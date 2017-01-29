using System;
using EssentialTools2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools2.Models;

namespace EssentialToolsUnitTest
{
	[TestClass]
	public class UnitTest1
	{
		private IDiscountHelper geDiscountHelper() {
			return new MinimumDiscountHelper();
		}

		[TestMethod]
		public void Discount_Above_100() {
			//Arrange (организация)
			IDiscountHelper target = this.geDiscountHelper();
			decimal total = 101m;

			//Act
			var result = target.ApplayDiscount(total);

			//Asseert
			Assert.AreEqual(total * 0.9m, result);


		}
		[TestMethod]
		public void Discount_Between_10_and_100() {
			//Arrange (организация)
			IDiscountHelper target = this.geDiscountHelper();

			//Act
			var tenDollarsDiscount = target.ApplayDiscount(10);
			var hundredDollarsDiscount = target.ApplayDiscount(100);
			var fiftyDollarsDiscount = target.ApplayDiscount(50);
			;

			//Asseert
			Assert.AreEqual(5, tenDollarsDiscount, "$10 discount si wrong");
			Assert.AreEqual(95, hundredDollarsDiscount, "$100 discount si wrong");
			Assert.AreEqual(45, fiftyDollarsDiscount, "$50 discount si wrong");
			

		}
		[TestMethod]
		public void Discount_Between_0_and_10() {
			//Arrange (организация)
			IDiscountHelper target = this.geDiscountHelper();

			//Act
			var fiveDollarsDiscount = target.ApplayDiscount(5);
			var zeroDollarsDiscount = target.ApplayDiscount(0);
			

			//Asseert
			Assert.AreEqual(5, fiveDollarsDiscount);
			Assert.AreEqual(0, zeroDollarsDiscount);


		}
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Discount_LessThan_0() {
			//Arrange (организация)
			IDiscountHelper target = this.geDiscountHelper();
			decimal total = -1;

			//Act
			var result = target.ApplayDiscount(-1);

		}
	}
}
