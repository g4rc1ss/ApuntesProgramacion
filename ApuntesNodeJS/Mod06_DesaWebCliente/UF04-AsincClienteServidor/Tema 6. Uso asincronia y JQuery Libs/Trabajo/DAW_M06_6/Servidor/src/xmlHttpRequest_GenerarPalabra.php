<?php
try {
    session_start();

    $array = array("perro", "gato", "coche", "escoba", "brujo");

    // Si no existe la variable de sesion la creamos generando la palabra
    $palabraRandom =  $array[rand(0, 4)];
    // Prueba para una palabra fija
    //    $palabraRandom = "perro";

    $_SESSION["Keyword"] = $palabraRandom;
    $_SESSION["lenght"] = strlen($palabraRandom);

    $jsonToReturn = json_encode(
        array(
            "longitud" => $_SESSION["lenght"]
        )
    );

    echo ($jsonToReturn);
} catch (Exception $th) {
    http_response_code(204);
}
