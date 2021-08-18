<?php
try {
    session_start();

    $letra = $_GET["letra"];
    if (empty($letra)) {
        http_response_code(204);
        return;
    }

    $cadena = $_SESSION["Keyword"];
    $listaCaracteres = "";
    for ($i = 0; $i < strlen($cadena); $i++) {
        if ($cadena[$i] == $letra[0]) {
            $listaCaracteres .= $i . " ";
        }
    }

    echo $listaCaracteres;
} catch (Exception $th) {
    http_response_code(204);
}
