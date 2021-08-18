<?php
include_once "Juego.php";
class De_mesa extends Juego
{
    private $num_jugadores = 0;
    private $Tipo = "";
    function __construct($nombre, $edad_minima, $num_jugadores, $Tipo)
    {
        parent::__construct($nombre, $edad_minima);
        $this->num_jugadores = $num_jugadores;
        $this->Tipo = $Tipo;
    }

    function get_num_jugadores()
    {
        return $this->num_jugadores;
    }
    function set_num_jugadores($num_jugadores)
    {
        $this->num_jugadores = $num_jugadores;
    }
    
    function get_Tipo()
    {
        return $this->Tipo;
    }
    function set_Tipo($Tipo)
    {
        $this->Tipo = $Tipo;
    }
    
    function __toString()
    {
        echo "Soy un Juego de mesa para " . $this->num_jugadores . " jugadores y de " . $this->Tipo . ", 
        me llamo " . parent::get_Nombre() . " y la edad minima es " . parent::get_EdadMinima();
    }
}
