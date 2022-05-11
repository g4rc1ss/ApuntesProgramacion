namespace Prototype
{
    public class ClasePrototype : ICloneable
    {
        private readonly string _password;
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public ClasePrototype(string password)
        {
            _password = password;
        }

        public object Clone()
        {
            return new ClasePrototype(_password)
            {
                Name = Name,
                Description = Description,
                Age = Age,
                FechaNacimiento = FechaNacimiento,
            };
        }

        public override string ToString()
        {
            return $"{Name} - {Description} - {Age} - {_password}";
        }
    }
}
