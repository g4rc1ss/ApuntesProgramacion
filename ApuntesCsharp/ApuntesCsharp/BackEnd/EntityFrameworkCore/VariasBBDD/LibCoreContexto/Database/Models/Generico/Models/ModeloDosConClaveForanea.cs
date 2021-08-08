﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apuntes.Back.Core.SQLite.ModelosBBDD {
    public class ModeloDosConClaveForanea {
        [ForeignKey("ID")]
        public ModelosParaBBDD UsuarioID { get; set; }
        [Key]
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