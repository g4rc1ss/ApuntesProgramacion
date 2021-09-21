<?php

class InsertData
{
    public function __construct($connection)
    {
        $sqlQuery = "INSERT INTO `apuntesphp`.`director`(`Nombre`, `Apellidos`) VALUES\n";
        $sqlQuery .= "\t('Quentn', 'Tarantino');\n";
        mysqli_query($connection, $sqlQuery);
    }
}