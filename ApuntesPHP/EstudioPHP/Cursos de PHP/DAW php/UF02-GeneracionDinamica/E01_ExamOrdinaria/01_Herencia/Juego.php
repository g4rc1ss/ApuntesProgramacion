<?php

class Juego
{
    private $nombre = "";
    private $edad_minima = 0;
    function __construct($nombre, $edad_minima)
    {
        $this->nombre = $nombre;
        $this->edad_minima = $edad_minima;
    }

    function get_Nombre()
    {
        return $this->nombre;
    }
    function set_Nombre($nombre)
    {
        $this->nombre = $nombre;
    }
    
    function get_EdadMinima()
    {
        return $this->edad_minima;
    }
    function set_EdadMinima($edad_minima)
    {
        $this->edad_minima = $edad_minima;
    }
    
    function __toString()
    {
        echo "Soy un Juego";
    }
}