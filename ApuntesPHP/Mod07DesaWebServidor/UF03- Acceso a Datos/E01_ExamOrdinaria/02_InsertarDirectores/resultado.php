<?php

$nombre = '';
$edad = 0;
$aficiones = [];
if (count($_POST) > 0) {
    $nombre = $_POST["name"];
    $edad = $_POST["age"];
    $aficiones = $_POST["aficiones"];
}
if ($edad > 0 || $nombre != '') {
    $mensajeRespuesta = "Hola {$nombre}";
    if ($edad < 18) {
        echo "No puedes continuar";
    } else {
        echo "Hola, tu nombre es {$nombre} y tus aficiones son ";
        foreach($aficiones as $aficion){
            echo "{$aficion} ";
        }
    }
} else{
    echo "Debes introducir tu nombre y tu edad";
}
?>