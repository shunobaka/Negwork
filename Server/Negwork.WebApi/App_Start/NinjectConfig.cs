namespace Negwork.WebApi
{
    using System;
    using System.Web;
    using Common.Constants;
    using Data;
    using Data.Repositories;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    public static class NinjectConfig
    {
        private static Action<IKernel> dependenciesRegistration = kernel =>
        {
            kernel.Bind<NegworkDbContext>().To<NegworkDbContext>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
        };

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            dependenciesRegistration(kernel);
            
            kernel.Bind(b => b
                .From(Assemblies.DataServices)
                .SelectAllClasses()
                .BindDefaultInterface());
        }
    }
}