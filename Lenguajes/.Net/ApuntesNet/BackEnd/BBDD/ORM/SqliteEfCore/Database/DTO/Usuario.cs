using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqliteEfCore.Database.DTO
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PuebloId { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime FechaHoy { get; set; } = DateTime.Now;

        public Pueblo PuebloIdNavigation { get; set; }
    }
}
