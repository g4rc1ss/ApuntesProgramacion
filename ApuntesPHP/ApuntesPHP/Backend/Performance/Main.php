<?php
include_once "ConsultasMySql\\CreateData.php";
include_once "ConsultasMySql\\SelectData.php";
include_once "ConsultasMySql\\UpdateData.php";
include_once "ConsultasMySql\\InsertData.php";
include_once "ConsultasMySql\\DeleteData.php";

$connection = mysqli_connect("localhost", "root", "1234");
new CreateData($connection);
$objectSelect = new SelectData($connection);
$consultaSelect = $objectSelect->get_listaConsultada();
new UpdateData($connection);
new InsertData($connection);
new DeleteData($connection);
?>

<!DOCTYPE html>
<html>

<head>
    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td,
        th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        tr:nth-child(even) {
            background-color: #dddddd;
        }
    </style>
</head>

<body>
    <table>
        <tr>
            <th>Titulo pelicula</th>
            <th>Nombre director</th>
            <th>Apellido director</th>
        </tr>

        <?php foreach ($consultaSelect as $consulta) : ?>
            <tr>
                <td><?php echo $consulta['Titulo'];?></td>
                <td><?php echo $consulta['Nombre'];?></td>
                <td><?php echo $consulta['Apellidos'];?></td>
            </tr>
        <?php endforeach; ?>
    </table>

</body>

</html>

<?php
$sqlQuery = "DROP DATABASE IF EXISTS `peliculas`;\n";
mysqli_query($connection, $sqlQuery);

$connection->close();
?>