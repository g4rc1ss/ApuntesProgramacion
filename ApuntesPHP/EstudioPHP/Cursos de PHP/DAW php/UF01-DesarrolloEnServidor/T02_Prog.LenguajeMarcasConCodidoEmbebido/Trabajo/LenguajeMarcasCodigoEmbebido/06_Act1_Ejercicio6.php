<html>

<body>
    <?php
    $numerosParaMediaModa = array(1, 2, 3, 4, 1, 1, 1, 1, 1, 1, 5, 3, 2, 3, 4, 5);

    $media = 0;
    $respuesta = "La moda de los valores ";
    foreach ($numerosParaMediaModa as $key => $value) {
        $media += $value;
        $respuesta .= $key < count($numerosParaMediaModa) 
            ? "{$value}, "
            : "{$value}";
    }
    $media /= count($numerosParaMediaModa);

    $contadorValores = array_count_values($numerosParaMediaModa);
    arsort($contadorValores);
    $moda =  key($contadorValores);

    echo $respuesta . "es {$moda} </br>";
    echo "y la media es {$media}";
    ?>
</body>

</html>