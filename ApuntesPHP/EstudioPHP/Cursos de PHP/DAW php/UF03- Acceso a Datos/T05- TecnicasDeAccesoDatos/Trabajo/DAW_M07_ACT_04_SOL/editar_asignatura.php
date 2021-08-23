<?php
require_once("control_sesion.php");
require_once("database.php");
	
	controlSesionAdmin();
	
	if(isset($_GET['asignatura'])){
		$asignatura = obtenerAsignatura($con, $_GET['asignatura']);
		if($asignatura == 0){
			header("Location: admin.php");
		}
		else{
			echo "<form method='post' action='".$_SERVER['PHP_SELF']."'>
				ID:<input type='text' name='id' value='".$asignatura['id']."' readonly><br/>
				Nombre:<input type='text' name='nombre' value='".$asignatura['nombre']."'><br/>
				<input type='submit' name='editar' value='Editar'>";
		}
	}
	
	if(isset($_POST['editar'])){
		if(empty($_POST['id']) || empty($_POST['nombre'])){
			echo "Debes rellenar todos los campos";
		}
		else{
			modificarAsignatura($con, $_POST['id'], $_POST['nombre']);
			header("Location: admin.php");
		}
	}
	
	cerrarConexion($con);
?>