using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionToExtender.Database.DatabaseEntities
{
    public class Plugin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LocalDllPath { get; set; }
    }
}
