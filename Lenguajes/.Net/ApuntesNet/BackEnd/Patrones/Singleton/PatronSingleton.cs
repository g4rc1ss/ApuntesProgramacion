namespace Singleton
{
    public class PatronSingleton
    {
        private static PatronSingleton _singleton;

        public string Nombre { get; set; }

        private PatronSingleton()
        {

        }

        public static PatronSingleton GetInstance()
        {
            if (_singleton == null)
            {
                _singleton = new PatronSingleton();
            }

            return _singleton;
        }
    }
}
