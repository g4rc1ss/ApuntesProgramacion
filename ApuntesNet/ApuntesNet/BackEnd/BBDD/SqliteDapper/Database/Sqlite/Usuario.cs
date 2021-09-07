using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDapper.Database.Sqlite {
    internal class Usuario {
        internal string IdUsuario { get; set; }
        internal string NombreUsuario { get; set; }

        internal Pueblo FKPueblo { get; set; }
    }
}
