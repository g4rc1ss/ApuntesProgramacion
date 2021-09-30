using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExample.Database.DTO {
    public class UserDatabase {
        public Guid UserID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
