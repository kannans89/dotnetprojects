using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;
using SCMProfitCore.SCMProfitRepository;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SCMProfit.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SCMProfit.App_Start.NinjectWebCommon), "Stop")]

namespace SCMProfit.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
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

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepository<Customer>>()
                  .To<CustomerDetailsRepository>();
            kernel.Bind<IRepository<CustomerLoginDetails>>()
                  .To<CustomerLoginDetailsRepository>();
            kernel.Bind<IRepository<CustomerSubscriptionDetails>>()
                .To<CustomerSubscriptionDetailsRepository>();
            kernel.Bind<IRepository<Partner>>()
                .To<PartnerRepository>();
            kernel.Bind<IRepository<Service>>()
                .To<ServicesRepository>();
            kernel.Bind<IRepository<Module>>()
              .To<ModuleRepository>();
        }
    }
}
