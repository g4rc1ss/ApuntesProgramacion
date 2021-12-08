using MySqlDatabase.MySQL;

namespace MySqlDatabase {
    internal class Program {
        private const string CONNECTION_STRING = "server=localhost;user=root;database=apuntesnet;port=3306;password=123456";

        private static void Main() {
            _ = new CreateDatabaseAndTables(CONNECTION_STRING);
            _ = new InsertMysql(CONNECTION_STRING);
            _ = new UpdateMysql(CONNECTION_STRING);
            _ = new DeleteMysql(CONNECTION_STRING);
            _ = new SelectMysql(CONNECTION_STRING);
        }
    }
}
