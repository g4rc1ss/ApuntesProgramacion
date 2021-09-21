<?php

class SelectData
{
    private $listaConsultada = array();

    public function __construct($connection)
    {
        mysqli_select_db($connection, "Peliculas");

        $query = "select p.Titulo, d.Nombre, d.Apellidos 
        from `apuntesphp`.`director` d 
        inner join `apuntesphp`.`pelicula` p on p.DirectorId = d.Id;";
        $this->listaConsultada = mysqli_query($connection, $query);
    }

    public function get_listaConsultada()
    {
        return $this->listaConsultada;
    }
}
