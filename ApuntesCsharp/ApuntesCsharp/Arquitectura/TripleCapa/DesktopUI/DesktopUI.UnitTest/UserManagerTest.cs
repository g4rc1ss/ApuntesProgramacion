using System;
using DesktopUI.Backend.Business.Manager;
using DesktopUI.Backend.Data.DataAccessManager.Interfaces;
using DesktopUI.SimulateDataForTesting;
using DesktopUI.SimulateDataForTesting.UserMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DesktopUI.UnitTest {

    [TestClass]
    public class UserManagerTest {
        private static UserManager userManagerOk;
        private static UserManager userManagerNull;

        private static Mock<IUserDam> MockUserDamOK => new UserDamMock(FakePossibilities.OK).MockUserDam;
        private static Mock<IUserDam> MockUserDamNull => new UserDamMock(FakePossibilities.NullData).MockUserDam;

        [ClassInitialize]
        public static void Inicializar(TestContext testContext) {
            if (testContext is null) {
                throw new ArgumentNullException(nameof(testContext));
            }
            userManagerOk = new UserManager(MockUserDamOK.Object);
            userManagerNull = new UserManager(MockUserDamNull.Object);
        }

        [TestMethod]
        public void GetAllUsersOk() {
            var resultado = userManagerOk.GetListaUsuarios();

            Assert.IsTrue(resultado.Count == 4);
        }

        [TestMethod]
        public void GetAllUsersNull() {
            var resultado = userManagerNull.GetListaUsuarios();

            Assert.IsTrue(resultado is null || resultado.Count == 0);
        }
    }
}
