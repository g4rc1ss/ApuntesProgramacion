<?php

class UpdateData
{
    public function __construct($connection)
    {
        $sqlQuery = "UPDATE `apuntesphp`.`director` 
        SET Nombre = 'Quentin'
        WHERE Nombre  = 'Quentn'";
        mysqli_query($connection, $sqlQuery);
    }
}
