using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.SimulateDataForTesting;
using WebApi.SimulateDataForTesting.UserMocks;
using WebAPI.Backend.Business.BusinessManager.IdentityManager;
using WebAPI.Backend.Data.DataAccessManager.Interfaces;

namespace WebApi.Benchmarks.BenchmarkManager {
    internal class IdentityManagerBench {
        private ApplicationUserManager applicationUserManager;
        private readonly ILogger<ApplicationUserManager> logger = Mock.Of<ILogger<ApplicationUserManager>>();

        private Mock<IUserDam> MockUserDam => new UserDamMock(FakePossibilities.OK).MockUserDam;

        [GlobalSetup]
        internal void Inicializar() {
            applicationUserManager = new ApplicationUserManager(logger, MockUserDam.Object);
        }

        [Benchmark]
        internal void Login() {
            applicationUserManager.Login(string.Empty, string.Empty, false);
        }

        [Benchmark]
        internal void CreateUser() {
            applicationUserManager.CreateUserAccount(It.IsAny<CreateAccountData>());
        }

        [Benchmark]
        internal void Logout() {
            applicationUserManager.Logout();
        }
    }
}
