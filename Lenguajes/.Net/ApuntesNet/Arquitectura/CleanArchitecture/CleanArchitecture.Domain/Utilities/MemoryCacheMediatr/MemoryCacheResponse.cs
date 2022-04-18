using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Utilities.MemoryCacheMediatr
{
    public class MemoryCacheResponse
    {
        public object Value { get; set; }
        public bool Succeed { get; set; }
    }
}
