<?php
require_once("control_sesion.php");
require_once("database.php");
	
	echo "<h3>Bienvenido ".$_SESSION['apellido']."</h3>";
	
	echo "<a href='logout.php'>Logout</a>";
	
	$notas = listarMisNotas($con, $_SESSION['dni']);
	
	if(count($notas) == 0){
		echo "<br/>No hay notas<br/>";
	}
	else{
		echo "<table border='1'>
				<tr><td>ASIGNATURA</td><td>NOTA</td></tr>";
		foreach($notas as $nota){
			echo "<tr>
					<td>".$nota['asignatura']."</td>
					<td>".$nota['nota']."</td>
				</tr>";
		}
		echo "</table>";
	}
	
	cerrarConexion($con);