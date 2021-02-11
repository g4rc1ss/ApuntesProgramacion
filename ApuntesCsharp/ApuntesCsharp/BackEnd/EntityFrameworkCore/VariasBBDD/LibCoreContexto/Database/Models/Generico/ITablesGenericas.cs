using Apuntes.Back.Core.SQLite.ModelosBBDD;
using Microsoft.EntityFrameworkCore;

namespace Apuntes.Back.Core.Database.Models.Generico {
    internal interface ITablesGenericas {
        public DbSet<ModelosParaBBDD> Usuario { get; set; }
        public DbSet<ModeloDosConClaveForanea> Material { get; set; }
    }
}
