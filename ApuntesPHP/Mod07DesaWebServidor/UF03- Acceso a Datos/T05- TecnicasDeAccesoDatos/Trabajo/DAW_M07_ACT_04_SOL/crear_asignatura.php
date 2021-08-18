<?php
require_once("control_sesion.php");
require_once("database.php");
	
	controlSesionAdmin();
	
	echo "<form method='post' action='".$_SERVER['PHP_SELF']."'>
		Nombre:<input type='text' name='nombre'><br/>
		<input type='submit' name='crear' value='Crear'>";
	
	if(isset($_POST['crear'])){
		if(empty($_POST['nombre'])){
			echo "Debes rellenar todos los campos";
		}
		else{
			insertarAsignatura($con, $_POST['nombre']);
			header("Location: admin.php");
		}
	}
	
	cerrarConexion($con);
?>