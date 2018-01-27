[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PostawNaMilionAzure.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PostawNaMilionAzure.App_Start.NinjectWebCommon), "Stop")]

namespace PostawNaMilionAzure.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Repository;
    using Models;
    using Utilties;

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
            kernel.Bind<IRepository<CategoryDict>>().To<CategoryDictRepository>();
            kernel.Bind<IRepository<KnowledgeArea>>().To<KnowledgeAreaRepository>();
            kernel.Bind<IRepository<Answer>>().To<AnswerRepository>();
            kernel.Bind<IExtendRepository<Question>>().To<QuestionRepository>();
            kernel.Bind<ITarget>().To<MapperAdapter>();
            kernel.Bind<ISessionManager>().To<SessionManager>();
            kernel.Bind<IExtendRepository<Game>>().To<GameRepository>();
            kernel.Bind<IRepository<StepAddSubTotalValue>>().To<StepAddSubTotalValueRepository>();

        }
    }
}
