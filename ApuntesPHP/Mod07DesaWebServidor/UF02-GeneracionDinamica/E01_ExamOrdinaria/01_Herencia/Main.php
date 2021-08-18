<?php
include_once "De_mesa.php";
include_once "Videojuego.php";

$arrayObjetos = array(
    new De_mesa("Uno", 7, 2, "cartas"),
    new Videojuego("WoW", 12, "PC", "MMORPG"),
    new Videojuego("Overwatch", 12, "PS4", "Shooter"),
    new De_mesa("trivial", 4, 2, "conocimiento"),
);

foreach($arrayObjetos as $juego){
    echo $juego->__toString() . "<br>";
}