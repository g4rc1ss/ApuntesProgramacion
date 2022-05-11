using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeferredExecutionYield.ExplicitEnumerator.AsyncEnumerableClass
{
    internal class ExplicitAsyncEnumerable : IAsyncEnumerable<int>
    {
        public IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new ExplicitAsyncEnumerator();
        }
    }
}
