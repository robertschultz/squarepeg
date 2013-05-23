namespace SquarePeg.ServiceInterface
{
    using ServiceStack.ServiceInterface;
    using SquarePeg.Core.Data;
    using SquarePeg.ServiceModel;

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
        /// Initializes a new instance of the <see cref="BoardsService"/> class.
        /// </summary>
        /// <param name="boardsRepository">The boards repository.</param>
        public BoardsService(IBoardsRepository boardsRepository)
        {
            this.boardsRepository = boardsRepository;
        }

        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Instance of a <see cref="BoardsResponse"/> class.</returns>
        public BoardsResponse Get(Boards request)
        {
            return new BoardsResponse() { Results = this.boardsRepository.Get() };
        }
    }
}
