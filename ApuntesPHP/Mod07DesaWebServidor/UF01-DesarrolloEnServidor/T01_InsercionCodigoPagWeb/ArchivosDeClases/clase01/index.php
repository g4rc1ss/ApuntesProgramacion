<html>
<body>
<?php
	//VARIABLES
	$variable = "Dani";
	$Variable = "Raul";

	//MOSTRAR POR PANTALLA
	echo "<h1>Bienvenidos ".$variable." y ".$Variable."</h1>";

	//CONSTANTES
	define("MI_CONSTANTE", 5);

	//OPERACIONES CON VARIABLES
	$numero1 = 1235;
	$numero2 = 12;
	$division = $numero1 / $numero2;
	echo "El resultado de la division es: ".$division."<br/>";
	$division = sprintf("%.2f", $division);
	echo "El resultado de la division es: ".$division."<br/>";

	$string = 'Moe\'s';
	echo $string."<br/>";

	//CONDICIONALES Y BUCLES
	echo "<table border='1'>";
	$n = 1;
	for($i=0;$i<MI_CONSTANTE;$i++){
		echo "<tr>";
		for($j=0;$j<MI_CONSTANTE;$j++){
			if($n%2 == 0){
				echo "<td bgcolor='green'>$n</td>";
			}
			else{
				echo "<td bgcolor='red'>$n</td>";
			}
			$n++;
		}
		echo "</tr>";
	}
	echo "</table>";

	//ARRAYS
	$miArray = ["hola", "como", "estas"];
	for($i=0;$i<sizeof($miArray);$i++){
		echo "$miArray[$i] ";
	}
	echo "<br/>";

	$miArray2 = array(); //ARRAY ASOCIATIVO
	$miArray2["uno"] = 1;
	$miArray2["dos"] = 2;
	$miArray2["tres"] = 3;
	$miArray2["cuatro"] = 4;
	$miArray2["cinco"] = 5;
	foreach($miArray2 as $clave => $valor){
		echo "$clave => $valor<br/>";
	}
	echo "<br/>";

?>
</body>
</html>