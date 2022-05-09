using System.ComponentModel.DataAnnotations.Schema;

namespace SqlServerEfCore.Database.DTO
{
    public class Pueblo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
