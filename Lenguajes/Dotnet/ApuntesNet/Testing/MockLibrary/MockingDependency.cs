using System.Linq;
using System.Threading.Tasks;
using Moq;

namespace MockLibrary
{
    internal class MockingDependency
    {
        public Mock<IRepositoryToMock> MockingRepository { get; set; }

        public MockingDependency()
        {
            MockingRepository = new Mock<IRepositoryToMock>();
            Initialize();
        }

        private void Initialize()
        {
            MockingRepository.Setup(x => x.GetRepositoryAsync(It.IsAny<string>()));
            MockingRepository.Setup(x => x.GetRepositoriesAsync()).ReturnsAsync(Enumerable.Range(0, 1000).Select(x => $"{x}"));
        }
    }
}
