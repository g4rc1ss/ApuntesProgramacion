<?php

class DeleteData
{
    public function __construct($connection)
    {
        $sqlQuery = "delete from `apuntesphp`.`director`
        where id = 5";
        mysqli_query($connection, $sqlQuery);
    }
}