<html>

<body>
    <?php
    $menuRestaurante = array(
        'Lunes' => 'Primero, segundo y postre 1',
        'Martes' => 'Primero, segundo y postre 2',
        'Miercoles' => 'Primero, segundo y postre 3',
        'Jueves' => 'Primero, segundo y postre 4',
        'Viernes' => 'Primero, segundo y postre 5',
        'Sabado' => 'Primero, segundo y postre 6',
        'Domingo' => 'Primero, segundo y postre 7',
    );
    foreach ($menuRestaurante as $key => $value) {
        echo "{$key} : {$value} </br>";
    }
    ?>
</body>

</html>