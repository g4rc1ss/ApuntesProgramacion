using System;
using System.Collections.Generic;

namespace Apuntes.Back.Core.SQLite.ModelosBBDD {
    public class ModelosParaBBDD {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime FechaHoy { get; set; } = DateTime.Now;
        public string Direccion { get; set; }
        public IEnumerable<ModeloDosConClaveForanea> Material { get; set; }
    }
}
