CREATE DATABASE PruebasConceptoWebApuntesNet;

GO

CREATE TABLE [PruebasConceptoWebApuntesNet].[dbo].[USUARIO](
	UserID	UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	Nombre varchar(20),
	Apellidos varchar(100)
);

INSERT INTO [PruebasConceptoWebApuntesNet].dbo.USUARIO(Nombre, Apellidos) VALUES ('Nombre 1', 'Apellido 1');
INSERT INTO [PruebasConceptoWebApuntesNet].dbo.USUARIO(Nombre, Apellidos) VALUES ('Nombre 2', 'Apellido 2');
INSERT INTO [PruebasConceptoWebApuntesNet].dbo.USUARIO(Nombre, Apellidos) VALUES ('Nombre 3', 'Apellido 3');
INSERT INTO [PruebasConceptoWebApuntesNet].dbo.USUARIO(Nombre, Apellidos) VALUES ('Nombre 4', 'Apellido 4');
INSERT INTO [PruebasConceptoWebApuntesNet].dbo.USUARIO(Nombre, Apellidos) VALUES ('Nombre 5', 'Apellido 5');
INSERT INTO [PruebasConceptoWebApuntesNet].dbo.USUARIO(Nombre, Apellidos) VALUES ('Nombre 6', 'Apellido 6');
INSERT INTO [PruebasConceptoWebApuntesNet].dbo.USUARIO(Nombre, Apellidos) VALUES ('Nombre 7', 'Apellido 7');