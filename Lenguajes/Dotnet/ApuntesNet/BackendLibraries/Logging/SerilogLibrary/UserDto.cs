using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace SerilogLibrary
{
    public class UserDTO
    {
        public string Name { get;set; }
        public string SurName { get;set; }
        public string Email { get;set; }
    }
}
