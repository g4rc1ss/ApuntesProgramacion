using System;

namespace ParallelQueries.Migrations.LocalDB.Database.Sqlite {
    public class Usuario {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime FechaHoy { get; set; } = DateTime.Now;
    }
}
