[assembly: WebActivator.PostApplicationStartMethod(typeof(MisOfertas.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace MisOfertas.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using MisOfertas.Cqrs.Infrastructure;
    using MisOfertas.Datos.Interfaces;
    using MisOfertas.Web.Infrastructure;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using SimpleInjector;
    using Negocio.Infrastructure;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            var assemblies = new[] {
                typeof(MisOfertas.Web.Startup).Assembly,
                typeof(MisOfertas.Cqrs.Startup).Assembly
            };

            container.Register(typeof(IQueryHandler<,>), assemblies);
            container.Register(typeof(ICommandHandler<>), assemblies);
            container.Register(typeof(IMediator), typeof(Mediator));
            container.Register(typeof(IUserContext), typeof(UserContext));
            container.Register(typeof(IMoContext), typeof(Negocio.Infrastructure.Context.MoContext));
        }
    }
}