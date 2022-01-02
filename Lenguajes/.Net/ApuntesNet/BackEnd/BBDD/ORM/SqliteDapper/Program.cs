using System.IO;
using System.Threading.Tasks;
using SqliteDapper.Dam;
using SqliteDapper.Database;

namespace SqliteDapper
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                if (!File.Exists(Helper.DATABASE_NAME))
                {
                    await new DapperExecute().CreateDatabase();
                }
                await InsertData.InsertDataQueryAsync();
                await UpdateData.UpdateDataQueryAsync();
                await DeleteData.DeleteDataQueryAsync();
                await SelectData.SelectDataQueryAsync();


            }
            finally
            {
                if (File.Exists(Helper.DATABASE_NAME))
                {
                    File.Delete(Helper.DATABASE_NAME);
                }
            }

        }
    }
}
