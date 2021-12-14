using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.SimulateDataForTesting;
using WebApi.SimulateDataForTesting.UserMocks;
using WebAPI.Backend.Business.BusinessManager.IdentityManager;
using WebAPI.Backend.Data.DataAccessManager.Interfaces;

namespace WebApi.Benchmarks.BenchmarkManager {
    public class IdentityManagerBench {
        private ApplicationUserManager applicationUserManager;
        private readonly ILogger<ApplicationUserManager> logger = Mock.Of<ILogger<ApplicationUserManager>>();

        private Mock<IUserDam> MockUserDam => new UserDamMock(FakePossibilities.OK).MockUserDam;

        [GlobalSetup]
        public void Inicializar() {
            applicationUserManager = new ApplicationUserManager(logger, MockUserDam.Object);
        }

        [Benchmark]
        public async Task LoginAsync() {
            await applicationUserManager.LoginAsync(string.Empty, string.Empty, false);
        }

        [Benchmark]
        public async Task CreateUserAsync() {
            await applicationUserManager.CreateUserAccountAsync(It.IsAny<CreateAccountData>());
        }

        [Benchmark]
        public async Task LogoutAsync() {
            await applicationUserManager.LogoutAsync();
        }
    }
}
