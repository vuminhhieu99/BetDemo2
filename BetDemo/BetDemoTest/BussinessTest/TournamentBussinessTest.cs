using Bet.Common;
using Bet.Data.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetDemoTest.BussinessTest
{     
    public class TournamentBussinessTest
    {
        private Mock<ISessionData> _sessionDataMock;
        private Mock<ITournamentData>? _tournamentDataMock;
        [SetUp]
        public void Setup()
        {
            _sessionDataMock = new Mock<ISessionData>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
