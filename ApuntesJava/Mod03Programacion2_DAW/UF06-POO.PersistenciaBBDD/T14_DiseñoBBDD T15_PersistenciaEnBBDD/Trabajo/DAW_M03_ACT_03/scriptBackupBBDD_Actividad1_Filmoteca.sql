-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.4.11-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             10.2.0.5599
-- --------------------------------------------------------

-- Volcando estructura de base de datos para peliculas
CREATE DATABASE IF NOT EXISTS `peliculas` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `peliculas`;

-- Volcando estructura para tabla peliculas.pelicula
CREATE TABLE IF NOT EXISTS `pelicula` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(100) DEFAULT NULL,
  `Director` varchar(100) DEFAULT NULL,
  `Pais` varchar(100) DEFAULT NULL,
  `Duracion` decimal(10,0) DEFAULT NULL,
  `Genero` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla peliculas.pelicula: ~5 rows (aproximadamente)
INSERT INTO `pelicula` (`Id`, `Titulo`, `Director`, `Pais`, `Duracion`, `Genero`) VALUES
	(1, 'Harry potter: la orden del fenix', 'David Yates', 'UK', 2, 'fantasia'),
	(2, 'Vengadores: EndGame', 'Anthony Russo and Joe Russo', 'USA', 3, 'ciencia ficcion'),
	(3, 'El rey leon', 'Roger Alles', 'USA', 1, 'musical'),
	(4, 'Animales fantasticos: Los crimenes de Grindelwald', 'David Yates', 'USA', 2, 'fantasia'),
	(5, 'Jumaji 1995', 'Joe Johnson', 'USA', 1, 'Aventura');
