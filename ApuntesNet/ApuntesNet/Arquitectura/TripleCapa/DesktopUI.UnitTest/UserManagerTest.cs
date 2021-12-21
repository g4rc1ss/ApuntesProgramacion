using System;
using System.Threading.Tasks;
using DesktopUI.Backend.Business.Manager;
using DesktopUI.Backend.Data.DataAccessManager.Interfaces;
using DesktopUI.SimulateDataForTesting;
using DesktopUI.SimulateDataForTesting.UserMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DesktopUI.UnitTest
{

    [TestClass]
    public class UserManagerTest
    {
        private static UserManager userManagerOk;
        private static UserManager userManagerNull;

        private static Mock<IUserDam> MockUserDamOK => new UserDamMock(FakePossibilities.OK).MockUserDam;
        private static Mock<IUserDam> MockUserDamNull => new UserDamMock(FakePossibilities.NullData).MockUserDam;

        [ClassInitialize]
        public static void Inicializar(TestContext testContext)
        {
            if (testContext is null)
            {
                throw new ArgumentNullException(nameof(testContext));
            }
            userManagerOk = new UserManager(MockUserDamOK.Object);
            userManagerNull = new UserManager(MockUserDamNull.Object);
        }

        [TestMethod]
        public async Task GetAllUsersOkAsync()
        {
            var resultado = await userManagerOk.GetListaUsuariosAsync();

            Assert.IsTrue(resultado.Count == 4);
        }

        [TestMethod]
        public async Task GetAllUsersNullAsync()
        {
            var resultado = await userManagerNull.GetListaUsuariosAsync();

            Assert.IsTrue(resultado is null || resultado.Count == 0);
        }
    }
}
