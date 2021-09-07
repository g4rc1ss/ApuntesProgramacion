﻿using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using SqliteDapper.Database.Sqlite;

namespace SqliteDapper.Database {
    internal class DapperExecute {
        internal static IDbConnection GetConnection() {
            return new SqliteConnection(Helper.DatabaseURL);
        }

        internal async Task CreateDatabase() {
            File.WriteAllBytes(Helper.DATABASE_NAME, Array.Empty<byte>());
            using (var connection = GetConnection()) {
                var createUsuario = @"CREATE TABLE Usuario(
                                        Id         TEXT     NOT NULL,
                                        Nombre     TEXT    NOT NULL,
                                        IdPueblo   TEXT     NOT NULL,
                                        CONSTRAINT PK_Usuario PRIMARY KEY (Id),
                                        CONSTRAINT FK_pueblo FOREIGN KEY (IdPueblo)
                                        REFERENCES Pueblo(Id)
                                        ON DELETE CASCADE
                                        ON UPDATE CASCADE);";

                var createPueblo = @"CREATE TABLE Pueblo(
                                        Id         TEXT     NOT NULL,
                                        Nombre     TEXT    NOT NULL,
                                        CONSTRAINT PK_Pueblo PRIMARY KEY (Id))";


                await connection.ExecuteAsync(createPueblo);
                await connection.ExecuteAsync(createUsuario);

                foreach (var item in Enumerable.Range(1, 5)) {
                    var insertIntoPueblo = new StringBuilder();
                    var insertIntoUsuario = new StringBuilder();

                    insertIntoPueblo.AppendLine($"INSERT INTO {nameof(Pueblo)} (Id, Nombre)");
                    insertIntoPueblo.AppendLine($"VALUES ('IdPueblo{item}', 'pueblo{item}')");

                    insertIntoUsuario.AppendLine($"INSERT INTO {nameof(Usuario)} (Id, Nombre, IdPueblo)");
                    insertIntoUsuario.AppendLine($"VALUES ('IdUsuario{item}', 'usuario{item}', 'IdPueblo{item}')");

                    var result = await connection.ExecuteAsync(insertIntoPueblo.ToString());
                    await connection.ExecuteAsync(insertIntoUsuario.ToString());
                }
            }
        }
    }
}
