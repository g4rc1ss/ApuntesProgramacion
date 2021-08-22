<?php
require_once("control_sesion.php");
require_once("database.php");
	
	controlSesionAdmin();
	
	if(isset($_GET['user'])){
		borrarUsuario($con, $_GET['user']);
		header("Location: admin.php");
	}
?>