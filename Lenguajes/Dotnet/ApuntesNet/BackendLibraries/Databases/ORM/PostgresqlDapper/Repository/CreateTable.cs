﻿using System.Data;


using Dapper;

namespace PostgresqlDapper.Repository;

internal class CreateTable(IDbConnection dbConnection)
{
    private readonly IDbConnection _dbConnection = dbConnection;

    public async Task CreateTableAsync()
    {
        var createUsuario = @"CREATE TABLE Usuario(
                                        Id         SERIAL     NOT NULL,
                                        Nombre     TEXT    NOT NULL,
                                        IdPueblo   INT     NOT NULL,
                                        CONSTRAINT PK_Usuario PRIMARY KEY (Id),
                                        CONSTRAINT FK_pueblo FOREIGN KEY (IdPueblo)
                                        REFERENCES Pueblo(Id)
                                        ON DELETE CASCADE
                                        ON UPDATE CASCADE);";

        var createPueblo = @"CREATE TABLE Pueblo(
                                        Id         SERIAL     NOT NULL,
                                        Nombre     TEXT    NOT NULL,
                                        CONSTRAINT PK_Pueblo PRIMARY KEY (Id))";


        await _dbConnection.ExecuteAsync(createPueblo);
        await _dbConnection.ExecuteAsync(createUsuario);
    }
}
