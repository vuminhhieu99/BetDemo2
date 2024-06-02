using Bet.Bussiness.Interfaces;
using Bet.Common;
using Bet.Common.Results;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetDemoTest.BussinessTest
{
    public class UserBussinessTest
    {
        private Mock<ISessionData> _sessionDataMock;
        private Mock<IUserBussiness> _userBussinessMock;

        [SetUp]
        public void Setup()
        {
            _sessionDataMock = new Mock<ISessionData>();
            _userBussinessMock = new Mock<IUserBussiness>();
        }

        [Test]
        public void Login_falese_null_balance()
        {
            //init
            string userName = "vmhieufalse";
            string password = "123456";
            //act
            //ServiceResult sv =  _userBussinessMock.Object.(userName, password);

            //result
            //Assert.IsNull(sv.Data);
        }
    }
}
