<?php
$arr_clientes = array(
    'nombre' => 'Jose', 'edad' => '20', 'genero' => 'masculino',
    'email' => 'correodejose@dominio.com', 'localidad' => 'Madrid', 'telefono' => '91000000'
);


//Creamos el JSON
$json_string = json_encode($arr_clientes);
$file = 'clientes.json';
file_put_contents($file, $json_string);
