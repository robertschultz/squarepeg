namespace SquarePeg.ServiceHost
{
    using System.Data;
    using System.Web.Configuration;

    using ServiceStack.OrmLite;
    using ServiceStack.WebHost.Endpoints;
    using SquarePeg.Core.Data;
    using SquarePeg.ServiceInterface;

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
            var factory = new OrmLiteConnectionFactory(WebConfigurationManager.ConnectionStrings["SquarePeg"].ConnectionString, MySqlDialect.Provider);

            container.Register(c => factory.OpenDbConnection());
            container.Register<IBoardsRepository>(new BoardsRepository(container.Resolve<IDbConnection>()));
            container.Register<IBoardsService>(new BoardsService(container.Resolve<IBoardsRepository>()));
        }
    }
}