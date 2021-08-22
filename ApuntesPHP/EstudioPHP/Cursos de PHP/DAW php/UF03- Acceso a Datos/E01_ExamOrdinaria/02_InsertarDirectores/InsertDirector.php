<?php
$nombre = '';
$apellidos = '';

if (count($_POST) > 0) {
    $nombre = $_POST["name"];
    $apellidos = $_POST["last_name"];

    if ($nombre != '' && $apellidos != '') {
        try {
            $conexion = mysqli_connect("localhost", "linkia", 1234);
            mysqli_select_db($conexion, "filmoteca");

            $query = "INSERT INTO Director(Nombre, Apellidos) VALUES ('{$nombre}', '{$apellidos}')";

            $insertData = mysqli_query($conexion, $query);

            if($insertData == true){
                echo "Los datos se han guardado correctamente";
            } else{
                echo "No se han podido guardar los datos " . mysqli_error($conexion);
            }
        } finally {
            mysqli_close($conexion);
        }
    }
}
