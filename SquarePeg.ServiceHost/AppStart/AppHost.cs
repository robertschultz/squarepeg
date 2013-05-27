namespace SquarePeg.ServiceHost
{
    using System.Data;
    using System.Web.Configuration;
    using ServiceStack.CacheAccess;
    using ServiceStack.Logging;
    using ServiceStack.OrmLite;
    using ServiceStack.Redis;
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
        /// Configures the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public override void Configure(Funq.Container container)
        {
            // Create the connection factory for our database.
            var factory = new OrmLiteConnectionFactory(WebConfigurationManager.ConnectionStrings["SquarePeg"].ConnectionString, MySqlDialect.Provider);

            // Register database.
            container.Register(c => factory.OpenDbConnection());
            
            // Register logging.
            container.Register<ILog>(c => LogManager.GetLogger(GetType()));

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

            // Set the sharec container; this is used by other shared omponents such as aspects.
            SharedContainer.Container = container;
        }
    }
}