
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqliteDapper.Dam;
using SqliteDapper.Database;

namespace SqliteDapper {
    internal class Program {
        private static async Task Main(string[] args) {
            try {
                if (!File.Exists(Helper.DATABASE_NAME)) {
                    await new DapperExecute().CreateDatabase();
                }
                SelectData.SelectDataQuery();
                InsertData.InsertDataQuery();
                UpdateData.UpdateDataQuery();
                DeleteData.DeleteDataQuery();


            } finally {
                if (File.Exists(Helper.DATABASE_NAME)) {
                    File.Delete(Helper.DATABASE_NAME);
                }
            }

        }
    }
}
