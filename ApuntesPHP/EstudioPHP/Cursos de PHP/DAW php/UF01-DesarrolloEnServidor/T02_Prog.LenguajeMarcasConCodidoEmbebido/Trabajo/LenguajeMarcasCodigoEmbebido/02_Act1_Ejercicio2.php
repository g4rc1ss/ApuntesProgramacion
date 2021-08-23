<html>

<body>
    <form method="GET">
        <input name="name" type="text" placeholder="Nombre">
        <input name="age" type="text" placeholder="Edad">
        <button type="submit">Entrar con GET</button>
    </form>
    <form method="POST">
        <input name="name" type="text" placeholder="Nombre">
        <input name="age" type="text" placeholder="Edad">
        <button type="submit">Entrar con POST</button>
    </form>
</body>

</html>

<?php
$nombre = '';
$edad = 0;
if (count($_POST) > 0) {
    $nombre = $_POST["name"];
    $edad = $_POST["age"];
} else if (count($_GET) > 0) {
    $nombre = $_GET["name"];
    $edad = $_GET["age"];
}
if ($edad > 0 || $nombre != '') {
    $mensajeRespuesta = "Hola {$nombre}";
    if ($edad < 18) {
        echo "{$mensajeRespuesta}, eres menor de edad, no puedes pasar";
    } else {
        echo "{$mensajeRespuesta}, tienes {$edad}";
    }
}
?>