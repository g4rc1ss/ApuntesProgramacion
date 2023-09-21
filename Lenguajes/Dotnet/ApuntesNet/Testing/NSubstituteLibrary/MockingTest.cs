using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace NSubstituteLibrary;

public class MockingTest
{
    IRepositoryToMock _repository;

    public MockingTest()
    {
        _repository = new MockingRepositoryToMock().repositoryToMock;
    }

    [Fact]
    public async Task MockingDependencyAsync()
    {
        await _repository.GetRepositoryAsync(string.Empty);
        var repositories = await _repository.GetRepositoriesAsync();
        Assert.True(repositories.Count() == 1000);
    }
}
