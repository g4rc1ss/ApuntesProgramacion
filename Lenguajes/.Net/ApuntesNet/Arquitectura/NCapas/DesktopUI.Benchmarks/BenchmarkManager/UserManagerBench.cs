using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using DesktopUI.Backend.Business.Manager;
using DesktopUI.Backend.Data.DataAccessManager.Interfaces;
using DesktopUI.SimulateDataForTesting;
using DesktopUI.SimulateDataForTesting.UserMocks;
using Moq;

namespace DesktopUI.Benchmarks.BenchmarkManager
{
    public class UserManagerBench
    {
        private UserManager UserManager;

        private Mock<IUserDam> MockUserDam => new UserDamMock(FakePossibilities.OK).MockUserDam;

        [GlobalSetup]
        public void Inicializar()
        {
            UserManager = new UserManager(MockUserDam.Object);
        }

        [Benchmark]
        public async Task GetListaUsuariosAsync()
        {
            await UserManager.GetListaUsuariosAsync();
        }
    }
}
