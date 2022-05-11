using System.Threading.Tasks;
using Xunit;

namespace MockLibrary
{
    public class MockingTest
    {
        IRepositoryToMock _repository;

        public MockingTest()
        {
            _repository = new MockingDependency().MockingRepository.Object;
        }

        [Fact]
        public async Task MockingDependencyAsync()
        {
            await _repository.GetRepositoryAsync("Ejemplo");
            var repositories = await _repository.GetRepositoriesAsync();
        }
    }
}
