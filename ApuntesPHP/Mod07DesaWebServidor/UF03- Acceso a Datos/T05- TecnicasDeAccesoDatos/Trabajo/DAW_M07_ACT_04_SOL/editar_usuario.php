<?php
require_once("control_sesion.php");
require_once("database.php");
	
	controlSesionAdmin();
	
	if(isset($_GET['user'])){
		$usuario = obtenerUsuario($con, $_GET['user']);
		if($usuario == 0){
			header("Location: admin.php");
		}
		else{
			echo "<form method='post' action='".$_SERVER['PHP_SELF']."'>
				DNI:<input type='text' name='dni' value='".$usuario['dni']."' readonly><br/>
				Apellido<input type='text' name='apellido' value='".$usuario['apellido']."'><br/>
				Tipo:<select name='tipo_usuario'>";
					if($usuario['tipo_usuario']==0){
						echo "<option value='0' selected>Admin</option>
							<option value='1'>User</option>";
					}
					else{
						echo "<option value='0'>Admin</option>
							<option value='1' selected>User</option>";
					}
				echo "</select>
				<input type='submit' name='editar' value='Editar'>";
		}
	}
	
	if(isset($_POST['editar'])){
		if(empty($_POST['dni']) || empty($_POST['apellido'])){
			echo "Debes rellenar todos los campos";
		}
		else{
			modificarUsuario($con, $_POST['dni'], $_POST['apellido'], $_POST['tipo_usuario']);
			header("Location: admin.php");
		}
	}
	
	cerrarConexion($con);
?>