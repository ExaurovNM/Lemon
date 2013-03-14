 [assembly: WebActivator.PreApplicationStartMethod(typeof(Lemon.WebApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Lemon.WebApp.App_Start.NinjectWebCommon), "Stop")]

namespace Lemon.WebApp.App_Start
{
    using System;
    using System.Web;

    using Lemon.Common;
    using Lemon.DataAccess.Repositories;
    using Lemon.WebApp.Services;

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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<IAuthService>().To<AuthService>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<ICriptoProvider>().To<CriptoProvider>();
            kernel.Bind<IOrderCommentRepository>().To<OrderCommentRepository>();
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IMessageService>().To<MessageService>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<IRatingRepository>().To<RatingRepository>();
            kernel.Bind<IRatingService>().To<RatingService>();
            kernel.Bind<IUserEventsRepository>().To<UserEventsRepository>();
            kernel.Bind<IUserEventsService>().To<UserEventsService>();
        }
    }
}
