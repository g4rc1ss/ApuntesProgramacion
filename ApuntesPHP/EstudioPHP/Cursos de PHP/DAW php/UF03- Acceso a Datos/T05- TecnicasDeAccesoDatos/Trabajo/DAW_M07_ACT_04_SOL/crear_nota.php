<?php
require_once("control_sesion.php");
require_once("database.php");
	
	controlSesionAdmin();
	
	$alumnos = listarAlumnos($con);
	$asignaturas = listarAsignaturas($con);
	
	if(count($alumnos)==0 || count($asignaturas)==0){
		echo "Debes introducir algun alumno y alguna asignatura para poder introducir notas";
	}
	else{
		echo "<form method='post' action='".$_SERVER['PHP_SELF']."'>
			Alumno:<select name='alumno'>";
					foreach($alumnos as $alumno){
						echo "<option value='".$alumno['dni']."'>".$alumno['apellido']."</option>";
					}
				echo "</select><br/>
			Asignatura:<select name='asignatura'>";
					foreach($asignaturas as $asignatura){
						echo "<option value='".$asignatura['id']."'>".$asignatura['nombre']."</option>";
					}
				echo "</select><br/>
			<input type='text' name='nota'><br/>
			<input type='submit' name='crear' value='Crear'>";
		
		if(isset($_POST['crear'])){
			if(empty($_POST['nota'])){
				echo "Debes rellenar todos los campos";
			}
			else{
				insertarNota($con, $_POST['alumno'], $_POST['asignatura'], $_POST['nota']);
				header("Location: admin.php");
			}
		}
	}
	
	cerrarConexion($con);
?>