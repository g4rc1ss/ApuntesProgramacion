using System;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.SimulateDataForTesting;
using WebApi.SimulateDataForTesting.UserMocks;
using WebAPI.Backend.Business.BusinessManager.IdentityManager;
using WebAPI.Backend.Data.DataAccessManager.Interfaces;

namespace WebApi.UnitTest {

    [TestClass]
    public class IdentityManagerTest {
        private static ApplicationUserManager applicationUserManagerOk;
        private static ApplicationUserManager applicationUserManagerNull;
        private static readonly ILogger<ApplicationUserManager> logger = Mock.Of<ILogger<ApplicationUserManager>>();

        private static Mock<IUserDam> MockUserDamOK => new UserDamMock(FakePossibilities.OK).MockUserDam;
        private static Mock<IUserDam> MockUserDamNull => new UserDamMock(FakePossibilities.NullData).MockUserDam;

        [ClassInitialize]
        public static void Inicializar(TestContext testContext) {
            if (testContext is null) {
                throw new ArgumentNullException(nameof(testContext));
            }
            applicationUserManagerOk = new ApplicationUserManager(logger, MockUserDamOK.Object);
            applicationUserManagerNull = new ApplicationUserManager(logger, MockUserDamNull.Object);
        }

        [TestMethod]
        public void LoginOk() {
            var resultado = applicationUserManagerOk.Login("", "", false);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void CreateAccountOk() {
            var resultado = applicationUserManagerOk.CreateUserAccount(It.IsAny<CreateAccountData>());

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void LogoutOk() {
            var resultado = applicationUserManagerOk.Logout();

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void LoginNull() {
            var resultado = applicationUserManagerNull.Login("", "", false);

            Assert.IsTrue(resultado == false);
        }

        [TestMethod]
        public void CreateAccountNull() {
            var resultado = applicationUserManagerNull.CreateUserAccount(It.IsAny<CreateAccountData>());

            Assert.IsTrue(resultado == false);
        }

        [TestMethod]
        public void LogoutNull() {
            var resultado = applicationUserManagerNull.Logout();

            Assert.IsTrue(resultado == false);
        }
    }
}
