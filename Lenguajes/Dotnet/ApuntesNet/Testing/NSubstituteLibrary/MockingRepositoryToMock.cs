using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Extensions;

namespace NSubstituteLibrary;

public class MockingRepositoryToMock
{
    public IRepositoryToMock repositoryToMock { get; set; }

    public MockingRepositoryToMock()
    {
        repositoryToMock = Substitute.For<IRepositoryToMock>();
        Initialize();
    }

    private async void Initialize()
    {
        repositoryToMock.GetRepositoryAsync(Arg.Any<string>()).Returns(Task.CompletedTask);
        repositoryToMock.GetRepositoriesAsync().Returns(Enumerable.Range(0, 1000).Select(x => $"{x}"));
    }
}
