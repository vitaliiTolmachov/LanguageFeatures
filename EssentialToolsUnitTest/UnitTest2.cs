using System;
using System.Linq;
using EssentialTools2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EssentialToolsUnitTest
{
	[TestClass]
	public class UnitTest2
	{
		private Product[] products = new Product[]
		{
			new Product {Name = "Kayak", Price = 275m, Category = "Watersports"},
			new Product {Name = "LifeJacket", Price = 48.49m, Category = "Watersports"},
			new Product {Name = "Soccer ball", Price = 19.50m, Category = "Soccer"},
			new Product {Name = "Corner flag", Price = 18, Category = "Soccer"}
		};
		[TestMethod]
		public void SummProductsCorretctly() {
			//Arrange
			Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
			mock.Setup(m => m.ApplayDiscount(It.IsAny<decimal>()))
				.Returns<decimal>(total => total);
			var target = new LinqValueCalculator(mock.Object);

			//Act
			decimal summ = target.ValueProducts(products);

			//Assert
			Assert.AreEqual(products.Sum(p => p.Price), summ);
		}
	}
}
