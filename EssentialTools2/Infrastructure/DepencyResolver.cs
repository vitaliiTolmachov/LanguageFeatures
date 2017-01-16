using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace EssentialTools2.Models.Depencies
{
	public class DepencyResolver:IDependencyResolver
	{
		private IKernel kernel;

		public DepencyResolver(IKernel kernlParam)
		{
			this.kernel = kernlParam;
			this.AddBindings();
		}

		private void AddBindings()
		{
			kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
		}

		public object GetService(Type serviceType)
		{
			return kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return kernel.GetAll(serviceType);
		}
	}
}