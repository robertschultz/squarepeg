namespace SquarePeg.ServiceInterface
{
    using SquarePeg.ServiceModel;

    /// <summary>
    /// Boards service that executes the service logic from the repository and performs any other business logic.
    /// </summary>
    public interface IBoardsService
    {
        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Instance of a <see cref="BoardsResponse"/> class.</returns>
        BoardsResponse Get(Boards request);
    }
}
