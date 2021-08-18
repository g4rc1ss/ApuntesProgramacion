using System.ComponentModel.DataAnnotations.Schema;

namespace SqlServerEfCore.Database.Models {
    public class ModeloDosConClaveForanea {
        [ForeignKey("ID")]
        public ModelosParaBBDD UsuarioID { get; set; }
        public int IDMaterial { get; set; }
        public string Material { get; set; }
        public TipoMaterial TipoMaterial { get; set; }
    }

    public enum TipoMaterial {
        Coche,
        Moto,
        F1,
        Avion,
        Bicicleta
    }
}
