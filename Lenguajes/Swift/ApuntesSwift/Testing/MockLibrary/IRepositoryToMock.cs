using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockLibrary
{
    public interface IRepositoryToMock
    {
        Task GetRepositoryAsync(string name);
        Task<IEnumerable<string>> GetRepositoriesAsync();
    }
}
