<?php

class DeleteData
{
    public function __construct($connection)
    {
        $sqlQuery = "delete from `peliculas`.`Director`
        where id = 5";
        mysqli_query($connection, $sqlQuery);
    }
}