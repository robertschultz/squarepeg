namespace SquarePeg.WebHost
{
    using System.Data;
    using System.Web.Configuration;
    using System.Web.Mvc;

    using ServiceStack.CacheAccess;
    using ServiceStack.Logging;
    using ServiceStack.Mvc;
    using ServiceStack.OrmLite;
    using ServiceStack.Redis;
    using ServiceStack.ServiceInterface;
    using ServiceStack.ServiceInterface.Auth;
    using ServiceStack.WebHost.Endpoints;

    using SquarePeg.Common.DependencyInjection;
    using SquarePeg.Repository;
    using SquarePeg.ServiceInterface;

    /// <summary>
    /// Application host used to wire up the service stack components.
    /// </summary>
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppHost"/> class.
        /// </summary>
        public AppHost()
            : base("SquarePeg Services", typeof(BoardsService).Assembly)
        {
        }

        /// <summary>
        /// Configures the application host.
        /// </summary>
        /// <param name="container">The container.</param>
        public override void Configure(Funq.Container container)
        {
            // Set JSON web services to return idiomatic JSON camelCase properties
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            // Create the connection factory for our database.
            var factory = new OrmLiteConnectionFactory(WebConfigurationManager.ConnectionStrings["SquarePeg"].ConnectionString, MySqlDialect.Provider);

            // Register database.
            container.Register(c => factory.OpenDbConnection());

            // Register logging.
            container.Register<ILog>(c => LogManager.GetLogger(this.GetType()));

            // Register caching dependencies.
            container.Register<IRedisClientsManager>(c => new PooledRedisClientManager("localhost:6379"));
            container.Register<ICacheClient>(c =>
                (ICacheClient)c.Resolve<IRedisClientsManager>()
                .GetCacheClient())
                .ReusedWithin(Funq.ReuseScope.None);

            // Register repositories
            container.Register<IBoardsRepository>(c => new BoardsRepository(container.Resolve<IDbConnection>()));

            // Register services.
            container.Register<IBoardsService>(
                c => new BoardsService(container.Resolve<IBoardsRepository>(), container.Resolve<ICacheClient>()));

            // Configure the authentiation.
            this.ConfigureAuth(container, factory);

            // Set the sharec container; this is used by other shared omponents such as aspects.
            SharedContainer.Container = container;

            // Set MVC to use the same Funq IOC as ServiceStack
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
        }

        /// <summary>
        /// Configures the authentication.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="factory">The factory.</param>
        public void ConfigureAuth(Funq.Container container, OrmLiteConnectionFactory factory)
        {
            // Instantiate the authentication repository with the configured OrmLiteConnectionFactory.
            var authRepository = new OrmLiteAuthRepository(factory);

            // Create the missing tables if they are not yet configured.
            authRepository.CreateMissingTables();

            // Register the authentication repository.
            container.Register<IUserAuthRepository>(c => authRepository);

            // Register all Authentication methods needed.
            Plugins.Add(
                new AuthFeature(
                    () => new AuthUserSession(),
                    new IAuthProvider[] { new CredentialsAuthProvider(), new BasicAuthProvider() }));

            // HtmlRedirect = null --^

            // Provide service for new users to register so they can login with supplied credentials.
            Plugins.Add(new RegistrationFeature());

        }
    }
}