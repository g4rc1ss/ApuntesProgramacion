<?php
session_start();
	
	echo "<form method ='post' action='login.php'>
		DNI:<input type='text' name='dni'><br/>
		Apellido<input type='text' name='apellido'><br/>
		<input type='submit' value='Entrar'>
	</form>";
	
	if(isset($_SESSION['error_login'])){
		echo $_SESSION['error_login'];
		unset($_SESSION['error_login']);
	}
?>