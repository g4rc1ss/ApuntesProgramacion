<?php
require_once("control_sesion.php");
require_once("database.php");
	
	controlSesionAdmin();

	echo "<h2>Página de administración</h2>";
	
	echo "<a href='logout.php'>Logout</a>";
	
	///////////////// GESTION USUARIOS /////////////////
	echo "<h3>Gestión usuarios</h3>";
	
	echo "<a href='crear_usuario.php'>Crear usuario</a>";
	
	$usuarios = listarUsuarios($con);
	echo "<table border='1'>
			<tr><td>DNI</td><td>APELLIDO</td><td>TIPO USUARIO</td><td>ACCIONES</td></tr>";
	foreach($usuarios as $usuario){
		echo "<tr>
				<td>".$usuario['dni']."</td>
				<td>".$usuario['apellido']."</td>";
				if($usuario['tipo_usuario'] == 0){
					echo "<td>Admin</td>";
				}
				else{
					echo "<td>User</td>";
				}
				echo "<td>
						<a href='editar_usuario.php?user=".$usuario['dni']."'>Editar</a>
						<a href='borrar_usuario.php?user=".$usuario['dni']."'>Borrar</a>
					</td>
			</tr>";
	}
	echo "</table>";
	
	///////////////// GESTION ASIGNATURAS /////////////////
	echo "<h3>Gestión asignaturas</h3>";
	
	echo "<a href='crear_asignatura.php'>Crear asignatura</a>";
	
	$asignaturas = listarAsignaturas($con);
	
	if(count($asignaturas) == 0){
		echo "<br/>No hay asignaturas<br/>";
	}
	else{
		echo "<table border='1'>
				<tr><td>NOMBRE</td><td>ACCIONES</td></tr>";
		foreach($asignaturas as $asignatura){
			echo "<tr>
					<td>".$asignatura['nombre']."</td>
					<td>
						<a href='editar_asignatura.php?asignatura=".$asignatura['id']."'>Editar</a>
						<a href='borrar_asignatura.php?asignatura=".$asignatura['id']."'>Borrar</a>
					</td>
				</tr>";
		}
		echo "</table>";
	}
	
	///////////////// GESTION NOTAS /////////////////
	echo "<h3>Gestión notas</h3>";
	
	echo "<a href='crear_nota.php'>Añadir nota</a>";
	
	$notas = listarNotas($con);
	
	if(count($notas) == 0){
		echo "<br/>No hay notas<br/>";
	}
	else{
		echo "<table border='1'>
				<tr><td>ALUMNO</td><td>ASIGNATURA</td><td>NOTA</td><td>ACCIONES</td></tr>";
		foreach($notas as $nota){
			echo "<tr>
					<td>".$nota['apellido']."</td>
					<td>".$nota['nombre']."</td>
					<td>".$nota['nota']."</td>
					<td>
						<a href='editar_nota.php?user=".$nota['alumno']."&asignatura=".$nota['asignatura']."'>Editar</a>
						<a href='borrar_nota.php?user=".$nota['alumno']."&asignatura=".$nota['asignatura']."'>Borrar</a>
					</td>
				</tr>";
		}
		echo "</table>";
	}
	
	cerrarConexion($con);
?>