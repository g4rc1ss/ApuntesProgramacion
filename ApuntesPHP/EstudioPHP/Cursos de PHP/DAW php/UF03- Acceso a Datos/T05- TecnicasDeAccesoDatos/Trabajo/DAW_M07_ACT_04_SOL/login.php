<?php
session_start();
require_once("database.php");

	if(empty($_POST['dni']) || empty($_POST['apellido'])){
		$_SESSION['error_login'] = "Debes introducir dni y apellido";
		header("Location: index.php");
	}
	else{
		$dni = $_POST['dni'];
		$apellido = $_POST['apellido'];
		
		$resultado = login($con, $dni, $apellido);
		if($resultado == 0){
			$_SESSION['error_login'] = "Datos incorrectos";
			header("Location: index.php");
		}
		else{
			$_SESSION['dni'] = $resultado['dni'];
			$_SESSION['apellido'] = $resultado['apellido'];
			$_SESSION['tipo_usuario'] = $resultado['tipo_usuario'];
			if($_SESSION['tipo_usuario'] == 0){
				header("Location: admin.php");
			}
			else{
				header("Location: user.php");
			}
		}
	}
	
	cerrarConexion($con);
?>