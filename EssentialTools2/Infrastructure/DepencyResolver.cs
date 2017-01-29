using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;

namespace EssentialTools2.Models.Depencies
{
	public class DepencyResolver : IDependencyResolver
	{
		private IKernel kernel;

		public DepencyResolver(IKernel kernlParam) {
			this.kernel = kernlParam;
			this.AddBindings();
		}

		private void AddBindings()
		{
			//Всегда 1 обьект на запрос (оптимально)
			kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
			//kernel.Bind<IDiscountHelper>().To<DefaultDiscounter>().WithPropertyValue("DiscountSize", (object) 50m);
			kernel.Bind<IDiscountHelper>().To<DefaultDiscounter>().WithConstructorArgument("discountParam", (object)50m);
			//Использует более узкое условие привязки эсли это возможно
			kernel.Bind<IDiscountHelper>().To<FlexibleDiscounHelper>().WhenInjectedInto<LinqValueCalculator>();
		}

		public object GetService(Type serviceType) {
			return kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType) {
			return kernel.GetAll(serviceType);
		}
	}
}