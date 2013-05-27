using SquarePeg.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SquarePeg.Service.Tests.Unit
{
    public class BoardsServiceFacts
    {
        public class Ctor
        {
            [Fact]
            public void NullBoardsRepositoryThrowsArgumentNullExceptoin()
            {
                Assert.Throws<ArgumentNullException>(() => new BoardsService(null, null));
            }
        }
    }
}
