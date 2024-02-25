using System.ComponentModel.DataAnnotations.Schema;

namespace SqlServerEfCore.Database.Entities;

public class Pueblo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Nombre { get; set; }

    public ICollection<Usuario>? Usuarios { get; set; }
}
