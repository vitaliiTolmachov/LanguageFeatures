using System;
using System.Linq;
using EssentialTools2;
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
		private Product[] GetProductWithFixedPrice(decimal price) {
			return new[]
			{
				new Product {Price = price}
			};
		}
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
		[TestMethod]
		public void CalculateDiscount() {
			//Arrange
			var mock = new Mock<IDiscountHelper>();

			mock.Setup(myMock => myMock.ApplayDiscount(It.IsAny<decimal>()))
				.Returns<decimal>(total => total);
			
			mock.Setup(myMock => myMock.ApplayDiscount(It.Is<decimal>(v => v > 100)))
							.Returns<decimal>(total => total * 0.9m);

			mock.Setup(myMock => myMock.ApplayDiscount(It.Is<decimal>(v => v < 0)))
				.Throws<ArgumentOutOfRangeException>();

			mock.Setup(myMock => myMock.ApplayDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
				.Returns<decimal>(total => total - 5);


			var target = new LinqValueCalculator(mock.Object);
			//Act
			decimal discount5 = target.ValueProducts(this.GetProductWithFixedPrice(5));
			decimal discount10 = target.ValueProducts(this.GetProductWithFixedPrice(10));
			decimal discount50 = target.ValueProducts(this.GetProductWithFixedPrice(50));
			decimal discount100 = target.ValueProducts(this.GetProductWithFixedPrice(100));
			decimal discount500 = target.ValueProducts(this.GetProductWithFixedPrice(500));
			//Asset

			Assert.AreEqual(5, discount5);
			Assert.AreEqual(5, discount10);
			Assert.AreEqual(45, discount50);
			Assert.AreEqual(95, discount100);
			Assert.AreEqual(450, discount500);
		}
	}
}
