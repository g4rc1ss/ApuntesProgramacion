using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlDatabase.MySQL
{
    internal class CreateDatabaseAndTables
    {
        public CreateDatabaseAndTables(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var sqlCreateDatabase = new StringBuilder("CREATE DATABASE IF NOT EXISTS `apuntesnet`").ToString();

                    var sqlCreateTable = new StringBuilder("CREATE TABLE IF NOT EXISTS `apuntesnet`.`Empleado` (")
                        .AppendLine("`ID`         INT NOT NULL AUTO_INCREMENT,")
                        .AppendLine("`Nombre`     VARCHAR(45)                 NULL,")
                        .AppendLine("`Apellidos`  VARCHAR(45)                 NULL,")
                        .AppendLine("`Salario`    DOUBLE NULL,")
                        .AppendLine("PRIMARY KEY(`ID`)")
                        .AppendLine(");").ToString();

                    var sqlInitializeData = new StringBuilder().AppendLine("INSERT INTO `apuntesnet`.`Empleado`(`Nombre`, `Apellidos`, `Salario`) VALUES")
                        .AppendLine("('David', 'Yates', 200000),")
                        .AppendLine("('Anthony', 'Russo', 50000000000),")
                        .AppendLine("('Roger', 'Alles', 2000000),")
                        .AppendLine("('Joe', 'Johson', 6000000);").ToString();

                    using (var executeCreateDatabase = new MySqlCommand(sqlCreateDatabase, connection))
                    {
                        executeCreateDatabase.ExecuteNonQuery();
                    }

                    using (var executeCreateTable = new MySqlCommand(sqlCreateTable, connection))
                    {
                        executeCreateTable.ExecuteNonQuery();
                    }

                    using (var executeInitializeData = new MySqlCommand(sqlInitializeData, connection))
                    {
                        executeInitializeData.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
