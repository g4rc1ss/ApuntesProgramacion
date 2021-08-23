<?php
require_once("control_sesion.php");
require_once("database.php");
	
	controlSesionAdmin();
	
	if(isset($_GET['user']) && isset($_GET['asignatura'])){
		$nota = obtenerNota($con, $_GET['user'], $_GET['asignatura']);
		if($nota == 0){
			header("Location: admin.php");
		}
		else{
			echo "<h3>Alumno:".$nota['apellido']." , Asignatura:".$nota['nombre']."</h3>";
			$alumnos = listarAlumnos($con);
			$asignaturas = listarAsignaturas($con);
			echo "<form method='post' action='".$_SERVER['PHP_SELF']."'>
				<input type='hidden' name='alumno' value='".$_GET['user']."' readonly>
				<input type='hidden' name='asignatura' value='".$_GET['asignatura']."' readonly>
				<input type='text' name='nota' value='".$nota['nota']."'><br/>
				<input type='submit' name='editar' value='Editar'>";
		}
	}
	
	if(isset($_POST['editar'])){
		if(empty($_POST['alumno']) || empty($_POST['asignatura']) || empty($_POST['nota'])){
			echo "Debes rellenar todos los campos";
		}
		else{
			modificarNota($con, $_POST['alumno'], $_POST['asignatura'], $_POST['nota']);
			header("Location: admin.php");
		}
	}
	
	cerrarConexion($con);
?>