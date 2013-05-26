namespace SquarePeg.ServiceHost
{
    using System.Data;
    using System.Web.Configuration;
    using ServiceStack.CacheAccess;
    using ServiceStack.OrmLite;
    using ServiceStack.Redis;
    using ServiceStack.WebHost.Endpoints;
    using SquarePeg.Core.Repository;
    using SquarePeg.ServiceInterface;
    using ServiceStack.Logging;
    using Castle.DynamicProxy;
    using SquarePeg.Common.DependencyInjection;

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
        /// Configures the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public override void Configure(Funq.Container container)
        {
            // Create the connection factory for our database.
            var factory = new OrmLiteConnectionFactory(WebConfigurationManager.ConnectionStrings["SquarePeg"].ConnectionString, MySqlDialect.Provider);

            // Register database.
            container.Register(c => factory.OpenDbConnection());
            
            ProxyGenerator pg = new ProxyGenerator();

            // Register logging.
            container.Register<ILog>(c => LogManager.GetLogger(GetType()));

            // Register caching dependencies.
            container.Register<IRedisClientsManager>(c => new PooledRedisClientManager("localhost:6379"));
            container.Register<ICacheClient>(c =>
                (ICacheClient)c.Resolve<IRedisClientsManager>()
                .GetCacheClient())
                .ReusedWithin(Funq.ReuseScope.None);

            // Register repositories
            container.Register<IBoardsRepository>(c => pg.CreateClassProxyWithTarget(
                new BoardsRepository(container.Resolve<IDbConnection>()),
                new LoggingInterceptor()));
  
             container.Register<IBlah>(c => pg.CreateClassProxyWithTarget(
                new Blah(),
                new LoggingInterceptor()));

            // Register services.
            container.Register<IBoardsService>(c => pg.CreateClassProxyWithTarget(
                new BoardsService(container.Resolve<IBoardsRepository>(), container.Resolve<ICacheClient>()),
                new LoggingInterceptor()));

            SharedContainer.Container = container;
        }
    }
}