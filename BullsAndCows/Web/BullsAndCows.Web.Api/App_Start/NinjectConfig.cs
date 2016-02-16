namespace BullsAndCows.Web.Api
{
    using Data.Repositories;
    using Data;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;
    using Services.Data.Contracts;
    using Services.Data;
    using Common.Providers;

    public static class NinjectConfig
    {
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
            kernel.Bind<IBullsAndCowsDbContext>().To<BullsAndCowsDbContext>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            kernel.Bind<IRandomProvider>().To<RandomProvider>();

            kernel.Bind<IGamesService>().To<GamesService>();
        }
    } 
}