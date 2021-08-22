<html>

<body>
    <?php
    $radioCircunferencia = 20;
    $logitudCircunferencia = $radioCircunferencia * 2;
    $areaCircunferencia = M_PI * pow($radioCircunferencia, 2);
    $volumenCircunferencia = (4 * M_PI * pow($radioCircunferencia, 3)) / 3;

    echo "La longitud de la circunferencia " . $logitudCircunferencia . "cm </br>";
    echo "El area es " . $areaCircunferencia . "cm </br>";
    echo "El volumen es " . $volumenCircunferencia . "m<sup>3</sup> </br>";
    ?>
    ?>
</body>

</html>