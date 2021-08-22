<?php
$conexion = mysqli_connect("localhost", "linkia", "1234");

mysqli_select_db($conexion, "filmoteca");

$query = "Select * from Director";

$directores = mysqli_query($conexion, $query);

?>

<select name="directores" style="max-width:90%;">
    <?php foreach ($directores as $director): ?>
        <option><?php echo $director['Nombre'];?> <?php echo $director['Apellidos']; ?></option>
    <?php endforeach; ?>
</select>

<?php 
mysqli_close($conexion);
?>