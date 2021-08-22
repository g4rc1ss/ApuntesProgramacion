<?php
require_once("control_sesion.php");
require_once("database.php");
	
	controlSesionAdmin();
	
	if(isset($_GET['user']) && isset($_GET['asignatura'])){
		borrarNota($con, $_GET['user'], $_GET['asignatura']);
		header("Location: admin.php");
	}
?>