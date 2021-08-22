<?php
require_once("control_sesion.php");
require_once("database.php");
	
	controlSesionAdmin();
	
	echo "<form method='post' action='".$_SERVER['PHP_SELF']."'>
		DNI:<input type='text' name='dni'><br/>
		Apellido<input type='text' name='apellido'><br/>
		Tipo:<select name='tipo_usuario'>
			<option value='0'>Admin</option>
			<option value='1'>User</option>
		</select>
		<input type='submit' name='crear' value='Crear'>";
	
	if(isset($_POST['crear'])){
		if(empty($_POST['dni']) || empty($_POST['apellido'])){
			echo "Debes rellenar todos los campos";
		}
		else{
			insertarUsuario($con, $_POST['dni'], $_POST['apellido'], $_POST['tipo_usuario']);
			header("Location: admin.php");
		}
	}
	
	cerrarConexion($con);
?>