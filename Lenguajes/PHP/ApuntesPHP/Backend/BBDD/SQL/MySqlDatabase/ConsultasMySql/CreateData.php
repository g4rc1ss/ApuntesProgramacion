<?php

class CreateData
{
    public function __construct($connection)
    {
        $sqlQuery = "";
        $sqlQuery = "-- Se podria hacer un ALTER TABLE, pero considero que es mejor borrar la base de datos\n";
        $sqlQuery = "-- y crearla de nuevo con las modificaciones\n";
        $sqlQuery = "DROP DATABASE IF EXISTS `apuntesphp`;\n";
        mysqli_query($connection, $sqlQuery);

        $sqlQuery = "CREATE DATABASE IF NOT EXISTS `apuntesphp`;\n\n";
        mysqli_query($connection, $sqlQuery);

        $sqlQuery = "-- Crear table de los directores\n\n";
        $sqlQuery = "CREATE TABLE IF NOT EXISTS `apuntesphp`.`director`(\n";
        $sqlQuery .= "\tId INT PRIMARY KEY AUTO_INCREMENT,\n";
        $sqlQuery .= "\tNombre VARCHAR(50),\n";
        $sqlQuery .= "\tApellidos VARCHAR(50)\n";
        $sqlQuery .= ");\n";
        mysqli_query($connection, $sqlQuery);

        $sqlQuery = "-- Crear table si no existe de apuntesphp\n";
        $sqlQuery .= "CREATE TABLE IF NOT EXISTS `apuntesphp`.`pelicula`(\n";
        $sqlQuery .= "\tId INT AUTO_INCREMENT,\n";
        $sqlQuery .= "\tTitulo VARCHAR(100),\n";
        $sqlQuery .= "\tDirectorId INT,\n";
        $sqlQuery .= "\tPais VARCHAR(100),\n";
        $sqlQuery .= "\tDuracion DECIMAL,\n";
        $sqlQuery .= "\tGenero VARCHAR(50), FOREIGN KEY(DirectorId) REFERENCES director(Id), PRIMARY KEY(Id)\n";
        $sqlQuery .= ");\n";
        mysqli_query($connection, $sqlQuery);

        $sqlQuery = "-- Insertar datos los datos de prueba de director\n";
        $sqlQuery .= "INSERT INTO `apuntesphp`.`director`(`Nombre`, `Apellidos`) VALUES\n";
        $sqlQuery .= "\t('David', 'Yates'),\n";
        $sqlQuery .= "\t('Anthony', 'Russo'),\n";
        $sqlQuery .= "\t('Roger', 'Alles'),\n";
        $sqlQuery .= "\t('Joe', 'Johson');\n";
        mysqli_query($connection, $sqlQuery);

        $sqlQuery = "-- Insertar datos de apuntesphp relacionando con la clave foranea al director\n";
        $sqlQuery .= "INSERT INTO `apuntesphp`.`pelicula` (`Id`, `Titulo`, `DirectorId`, `Pais`, `Duracion`, `Genero`) VALUES\n";
        $sqlQuery .= "\t(1, 'Harry potter: la orden del fenix', 1, 'UK', 2, 'fantasia'),\n";
        $sqlQuery .= "\t(2, 'Vengadores: EndGame', 2, 'USA', 3, 'ciencia ficcion'),\n";
        $sqlQuery .= "\t(3, 'El rey leon', 3, 'USA', 1, 'musical'),\n";
        $sqlQuery .= "\t(4, 'Animales fantasticos: Los crimenes de Grindelwald', 1, 'USA', 2, 'fantasia'),\n";
        $sqlQuery .= "\t(5, 'Jumaji 1995', 4, 'USA', 1, 'Aventura');\n";
        mysqli_query($connection, $sqlQuery);
    }
}
