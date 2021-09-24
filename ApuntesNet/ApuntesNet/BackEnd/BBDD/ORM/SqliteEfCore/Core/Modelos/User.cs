namespace SqliteEfCore.Core.Modelos {
    public class User {
        public string Name { get; set; }
        public int Edad { get; set; }
        public Pueblo Pueblo { get; set; }
    }
}
