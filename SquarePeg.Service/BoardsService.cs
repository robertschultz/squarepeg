#if DEBUG
#define SkipPostSharp
#endif

namespace SquarePeg.ServiceInterface
{
    using System;
    using System.Collections.Generic;

    using ServiceStack.CacheAccess;
    using ServiceStack.ServiceInterface;
    using SquarePeg.Repository;
    using SquarePeg.ServiceModel;
    using ServiceStack.Common;
    using SquarePeg.Common.Caching;

    /// <summary>
    /// Boards service that executes the service logic from the repository and performs any other business logic.
    /// </summary>
    public class BoardsService : Service, IBoardsService
    {
        /// <summary>
        /// The boards repository.
        /// </summary>
        private readonly IBoardsRepository boardsRepository = null;

        /// <summary>
        /// The cache client.
        /// </summary>
        private readonly ICacheClient cacheClient = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardsService"/> class.
        /// </summary>
        /// <param name="boardsRepository">
        /// The boards repository.
        /// </param>
        /// <param name="cacheClient">
        /// The cache Client.
        /// </param>
        public BoardsService(IBoardsRepository boardsRepository, ICacheClient cacheClient)
        {
            if (boardsRepository == null)
            {
                throw new ArgumentNullException("boardsRepository", "Boards repository is required.");
            }

            if (cacheClient == null)
            {
                throw new ArgumentNullException("cacheClient", "Cache client is required.");
            }

            this.boardsRepository = boardsRepository;
            this.cacheClient = cacheClient;
        }

        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Instance of a <see cref="BoardsResponse"/> class.</returns>
        public virtual BoardsResponse Get(Boards request)
        {
            var boards = this.cacheClient.Get<List<Model.Types.Board>>(Keys.BOARDS_GET);

            if (boards == null)
            {
                boards = this.boardsRepository.Get();
                this.cacheClient.Add(Keys.BOARDS_GET, boards);
            }

            var result = boards.ConvertAll(x => x.TranslateTo<ServiceModel.Types.Board>());

            return new BoardsResponse { Results = result };
        }
    }
}
