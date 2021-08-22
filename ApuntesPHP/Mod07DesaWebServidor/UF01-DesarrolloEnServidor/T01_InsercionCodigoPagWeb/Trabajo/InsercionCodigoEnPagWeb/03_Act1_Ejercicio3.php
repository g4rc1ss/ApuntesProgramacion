<html>

<body>
    <?php
    $segundosParaCalcular = 10000;
    $horas = intval($segundosParaCalcular / 3600);
    $minutos = intval($segundosParaCalcular / 60);
    while($minutos > 60){
        $minutos -= 60;
    }
    $segundos = intval($segundosParaCalcular % 60);

    echo $horas . " horas </br>" . $minutos . " minutos </br>" . $segundos . " segundos"
    ?>
</body>

</html>