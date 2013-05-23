namespace SquarePeg.Core.Data
{
    using System.Collections.Generic;
    using SquarePeg.ServiceModel.Types;

    /// <summary>
    /// Repository to work with the Boards data source.
    /// </summary>
    public interface IBoardsRepository
    {
        /// <summary>
        /// Gets a list of boards.
        /// </summary>
        /// <returns>A list of <see cref="Board"/> objects.</returns>
        List<Board> Get();
    }
}
