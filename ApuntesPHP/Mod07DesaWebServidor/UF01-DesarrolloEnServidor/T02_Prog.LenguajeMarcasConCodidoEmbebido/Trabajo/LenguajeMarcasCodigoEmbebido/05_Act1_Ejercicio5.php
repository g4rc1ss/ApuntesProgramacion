<html>

<body>
    <form method="POST">
        <input type="text" name="nombre" placeholder="nombre">
        <input type="text" name="horas" placeholder="horas">
        <input type="submit" title="POST">
    </form>
    <?php
    if (count($_POST) > 0) {
        $nombre = $_POST["nombre"];
        $horas = $_POST["horas"];
        $sueldoTotal = 0.0;

        if ($horas <= 40) {
            $sueldoTotal = $horas * 16;
        } else {
            $sueldoTotal = (($horas - 40) * 20) + (40 * 16);
        }
        echo "{$nombre} has trabajado {$horas} horas. Tu sueldo es {$sueldoTotal}€";
    }
    ?>
</body>

</html>