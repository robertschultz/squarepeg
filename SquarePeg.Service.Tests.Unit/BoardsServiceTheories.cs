namespace SquarePeg.Service.Tests.Unit
{
    using System;
    using ServiceStack.CacheAccess;
    using SquarePeg.Common.Test;
    using SquarePeg.ServiceInterface;
    using Xunit;
    using Xunit.Extensions;
    using SquarePeg.Repository;

    /// <summary>
    /// Theories related to the BoardsService class.
    /// </summary>
    public class BoardsServiceTheories
    {
        /// <summary>
        /// Test that when passing in a null repository to the service it throws an ArgumentNullException.
        /// </summary>
        /// <param name="cacheClient">The cache client.</param>
        [Theory, AutoMoqData]
        public void CtorNullBoardsRepositoryThrowsArgumentNullExceptoin(ICacheClient cacheClient)
        {
            Assert.Throws<ArgumentNullException>(() => new BoardsService(null, cacheClient));
        }

        /// <summary>
        /// Test that when passing in a null cache client to the service it throws an ArgumentNullException.
        /// </summary>
        /// <param name="cacheClient">The cache client.</param>
        [Theory, AutoMoqData]
        public void CtorNullCacheClientThrowsArgumentNullExceptoin(IBoardsRepository boardsRepository)
        {
            Assert.Throws<ArgumentNullException>(() => new BoardsService(boardsRepository, null));
        }
    }
}
