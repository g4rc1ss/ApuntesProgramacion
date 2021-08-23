<?php
require_once("database.php");
$db = new Database();
$db->query("select distinct(tipo) from locales");
$resultado = $db->rows();
?>
<form method='post' action='mapa.php'>
	Selecciona tipo de local:
	<select name='tipo'>
	<?php
		foreach($resultado as $categoria){
			echo "<option value='".$categoria['tipo']."'>".$categoria['tipo']."</option>";
		}
	?>
	</select>
	<input type='submit'/>
</form>
<?php
$db->disconnect();
?>