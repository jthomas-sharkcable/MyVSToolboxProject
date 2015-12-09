using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Shop.Abstract;
using Shop.Entities;
using Shop.Concrete;
namespace Shop.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // put bindings here

            kernel.Bind<IEquipmentRepository>().To<EFEquipmentRepository>();
            
        }
    }
}
