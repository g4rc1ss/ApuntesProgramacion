<?php
include_once "Juego.php";
class Videojuego extends Juego
{
    private $plataforma = "";
    private $genero = "";
    function __construct($nombre, $edad_minima, $plataforma, $genero)
    {
        parent::__construct($nombre, $edad_minima);
        $this->plataforma = $plataforma;
        $this->genero = $genero;
    }

    function get_plataforma()
    {
        return $this->plataforma;
    }
    function set_plataforma($plataforma)
    {
        $this->plataforma = $plataforma;
    }
    
    function get_genero()
    {
        return $this->genero;
    }
    function set_genero($genero)
    {
        $this->genero = $genero;
    }
    
    function __toString()
    {
        echo "Soy un Videojuego de " . $this->genero . " genero y para " . $this->plataforma . " plataforma,
        me llamo " . parent::get_Nombre() . " y la edad minima es " . parent::get_EdadMinima();
    }
}
