using System.ComponentModel.DataAnnotations.Schema;

namespace SqliteEfCore.Database.DTO
{
    public class Pueblo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
