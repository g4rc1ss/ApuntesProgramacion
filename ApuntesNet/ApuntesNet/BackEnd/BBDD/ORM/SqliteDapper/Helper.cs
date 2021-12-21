using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SqliteDapper
{
    internal static class Helper
    {
        internal const string CONFIG_FILE = "appsettings.json";
        internal const string DATABASE_NAME = "BBDD_Local.db";
        internal const string KEY_DATABASE_STRING = "Database";

        internal static string DatabaseURL
        {
            get
            {
                var database = JObject.Parse(File.ReadAllText(CONFIG_FILE))?.Value<string>(KEY_DATABASE_STRING);
                if (string.IsNullOrEmpty(database))
                {
                    throw new ArgumentNullException(nameof(database));
                }
                return database;
            }
        }
    }
}
