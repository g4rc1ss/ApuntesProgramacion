-- Se podria hacer un ALTER TABLE, pero considero que es mejor borrar la base de datos
-- y crearla de nuevo con las modificaciones
DROP DATABASE IF EXISTS `apuntesjava`;
CREATE DATABASE IF NOT EXISTS `apuntesjava`;

-- Crear table de los directores

CREATE TABLE IF NOT EXISTS `apuntesjava`.`director`(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	Nombre VARCHAR(50),
	Apellidos VARCHAR(50)
);
-- Crear table si no existe de peliculas
CREATE TABLE IF NOT EXISTS `apuntesjava`.`pelicula`(
	Id INT AUTO_INCREMENT,
	Titulo VARCHAR(100),
	DirectorId INT,
	Pais VARCHAR(100),
	Duracion DECIMAL,
	Genero VARCHAR(50),
	FOREIGN KEY(DirectorId) REFERENCES director(Id) ON DELETE CASCADE,
	PRIMARY KEY(Id)
);
-- Insertar datos los datos de prueba de director
INSERT INTO `apuntesjava`.`director`(`Nombre`, `Apellidos`) VALUES
	('David', 'Yates'),
	('Anthony', 'Russo'),
	('Roger', 'Alles'),
	('Joe', 'Johson');
-- Insertar datos de peliculas relacionando con la clave foranea al director
INSERT INTO `apuntesjava`.`pelicula` (`Id`, `Titulo`, `DirectorId`, `Pais`, `Duracion`, `Genero`) VALUES
	(1, 'Harry potter: la orden del fenix', 1, 'UK', 2, 'fantasia'),
	(2, 'Vengadores: EndGame', 2, 'USA', 3, 'ciencia ficcion'),
	(3, 'El rey leon', 3, 'USA', 1, 'musical'),
	(4, 'Animales fantasticos: Los crimenes de Grindelwald', 1, 'USA', 2, 'fantasia'),
	(5, 'Jumaji 1995', 4, 'USA', 1, 'Aventura');
