using System;
using System.Threading.Tasks;
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
        public async Task LoginOkAsync() {
            var resultado = await applicationUserManagerOk.LoginAsync("", "", false);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task CreateAccountOkAsync() {
            var resultado = await applicationUserManagerOk.CreateUserAccountAsync(It.IsAny<CreateAccountData>());

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task LogoutOkAsync() {
            var resultado = await applicationUserManagerOk.LogoutAsync();

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task LoginNullAsync() {
            var resultado = await applicationUserManagerNull.LoginAsync("", "", false);

            Assert.IsTrue(resultado == false);
        }

        [TestMethod]
        public async Task CreateAccountNullAsync() {
            var resultado = await applicationUserManagerNull.CreateUserAccountAsync(It.IsAny<CreateAccountData>());

            Assert.IsTrue(resultado == false);
        }

        [TestMethod]
        public async Task LogoutNullAsync() {
            var resultado = await applicationUserManagerNull.LogoutAsync();

            Assert.IsTrue(resultado == false);
        }
    }
}
