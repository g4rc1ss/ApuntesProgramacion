<html>

<body>
    <?php
    $coeficienteA = 5;
    $coeficienteB = 6;
    $coeficienteC = 1;

    # Convertimos el numero de B en negativo
    $coeficienteNegativoB = -1;

    $raizCuadrada = sqrt(pow($coeficienteB, 2) - (4 * $coeficienteA * $coeficienteC));

    $restaParaDivision = 2 * $coeficienteA;


    $resultadoMenos = ($coeficienteNegativoB - $raizCuadrada) / 2 * $coeficienteA;
    $resultadoMas = ($coeficienteNegativoB + $raizCuadrada) / 2 * $coeficienteA;

    echo "resultado menos = " . $resultadoMenos . "</br>";
    echo "resultado mas = " . $resultadoMas . "</br>";1
    ?>
</body>

</html>