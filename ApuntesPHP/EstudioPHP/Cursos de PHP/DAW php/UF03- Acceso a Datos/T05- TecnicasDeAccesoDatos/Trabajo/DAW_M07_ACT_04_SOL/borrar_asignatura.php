<?php
require_once("control_sesion.php");
require_once("database.php");
	
	controlSesionAdmin();
	
	if(isset($_GET['asignatura'])){
		borrarAsignatura($con, $_GET['asignatura']);
		header("Location: admin.php");
	}
?>