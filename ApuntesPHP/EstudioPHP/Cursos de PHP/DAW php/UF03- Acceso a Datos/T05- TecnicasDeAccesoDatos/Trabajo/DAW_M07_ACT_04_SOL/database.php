<?php
	$server = "localhost";
	$user = "root";
	$pass = "12345";
	$db = "ucoc_act05";

	$con = mysqli_connect($server, $user, $pass, $db) or die ("Error al conectar con la base de datos");
	
	function login($con, $dni, $apellido){
		$result = mysqli_query($con, "select * from Usuario where dni='".$dni."' and apellido='".$apellido."'");
		if(mysqli_num_rows($result)==0){
			return 0; //Si no existe el usuario devuelvo 0
		}
		else{
			$usuario = mysqli_fetch_array($result);
			return $usuario;//Si existe el usuario devuelvo un array con sus datos
		}
	}
	
	function listarMisNotas($con, $dni){
		$result = mysqli_query($con, "select * from Nota where alumno='".$dni."'");
		if(mysqli_num_rows($result)==0){
			return 0; //Si el usuario no tiene notas devuelvo 0
		}
		else{
			$notas = array();
			while($fila = mysqli_fetch_array($result)){
				$notas[] = $fila;
			}
			return $notas;//Si tiene notas devuelvo un array con éstas
		}
	}
	
	function cerrarConexion($con){
		mysqli_close($con);
	}
	
	////////////////////////////////////////////// FUNCIONES DE USUARIOS //////////////////////////////////////////////
	function listarUsuarios($con){
		$result = mysqli_query($con, "select * from Usuario");
		$usuarios = array();
		while($fila = mysqli_fetch_array($result)){
			$usuarios[] = $fila;
		}
		return $usuarios;//Devuelvo un array con los datos de todos los usuarios
	}
	
	function insertarUsuario($con, $dni, $apellido, $tipo_usuario){
		mysqli_query($con, "insert into Usuario values('$dni', '$apellido', $tipo_usuario)");
	}
	
	function obtenerUsuario($con, $dni){
		$resultado = mysqli_query($con, "select * from Usuario where dni='$dni'");
		if(mysqli_num_rows($resultado)==0){
			return 0; //Si no existe el usuario devuelvo 0
		}
		else{
			$usuario = mysqli_fetch_array($resultado);
			return $usuario;//Si existe el usuario devuelvo un array con sus datos
		}
	}
	
	function modificarUsuario($con, $dni, $apellido, $tipo_usuario){
		mysqli_query($con, "update Usuario set apellido='$apellido', tipo_usuario=$tipo_usuario where dni='$dni'");
	}
	
	function borrarUsuario($con, $dni){
		mysqli_query($con, "delete from Usuario where dni='$dni'");
	}
	
	////////////////////////////////////////////// FUNCIONES DE ASIGNATURAS //////////////////////////////////////////////
	function listarAsignaturas($con){
		$result = mysqli_query($con, "select * from Asignatura");
		$asignaturas = array();
		while($fila = mysqli_fetch_array($result)){
			$asignaturas[] = $fila;
		}
		return $asignaturas;//Devuelvo un array con los datos de todas las asignaturas
	}
	
	function insertarAsignatura($con, $nombre){
		mysqli_query($con, "insert into Asignatura (nombre) values('$nombre')");
	}
	
	function obtenerAsignatura($con, $id){
		$resultado = mysqli_query($con, "select * from Asignatura where id=$id");
		if(mysqli_num_rows($resultado)==0){
			return 0; //Si no existe la asignatura devuelvo 0
		}
		else{
			$asignatura = mysqli_fetch_array($resultado);
			return $asignatura;//Si existe la asignatura devuelvo un array con sus datos
		}
	}
	
	function modificarAsignatura($con, $id, $nombre){
		mysqli_query($con, "update Asignatura set nombre='$nombre' where id=$id");
	}
	
	function borrarAsignatura($con, $id){
		mysqli_query($con, "delete from Asignatura where id=$id");
	}
	
	////////////////////////////////////////////// FUNCIONES DE NOTAS //////////////////////////////////////////////
	function listarAlumnos($con){
		$result = mysqli_query($con, "select * from Usuario where tipo_usuario=1");
		$alumnos = array();
		while($fila = mysqli_fetch_array($result)){
			$alumnos[] = $fila;
		}
		return $alumnos;//Devuelvo un array con los datos de todos los alumnos
	}
	
	function listarNotas($con){
		$result = mysqli_query($con, "select n.alumno, n.asignatura, n.nota, u.apellido, a.nombre from Nota n, Usuario u, Asignatura a where n.alumno=u.dni and n.asignatura = a.id");
		$notas = array();
		while($fila = mysqli_fetch_array($result)){
			$notas[] = $fila;
		}
		return $notas;//Devuelvo un array con los datos de todas las notas
	}
	
	function insertarNota($con, $alumno, $asignatura, $nota){
		mysqli_query($con, "insert into Nota values('$alumno', $asignatura, $nota)");
	}
	
	function obtenerNota($con, $alumno, $asignatura){
		$resultado = mysqli_query($con, "select n.alumno, n.asignatura, n.nota, u.apellido, a.nombre from Nota n, Usuario u, Asignatura a where n.alumno=u.dni and n.asignatura = a.id and n.alumno='$alumno' and n.asignatura=$asignatura");
		if(mysqli_num_rows($resultado)==0){
			return 0; //Si no existe la nota devuelvo 0
		}
		else{
			$nota = mysqli_fetch_array($resultado);
			return $nota;//Si existe la nota devuelvo un array con sus datos
		}
	}
	
	function modificarNota($con, $alumno, $asignatura, $nota){
		mysqli_query($con, "update Nota set nota=$nota where alumno='$alumno' and asignatura=$asignatura");
	}
	
	function borrarNota($con, $alumno, $asignatura){
		mysqli_query($con, "delete from Nota where alumno='$alumno' and asignatura=$asignatura");
	}
	
?>