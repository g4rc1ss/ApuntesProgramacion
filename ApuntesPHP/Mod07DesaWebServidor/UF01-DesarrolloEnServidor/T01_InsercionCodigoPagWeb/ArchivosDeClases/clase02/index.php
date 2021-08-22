<?php
//DECLARACIÓN DE ARRAY Y FUNCIONES PRINT_R Y VAR_DUMP
$notas[] = 10;
$notas[] = 9;
$notas[] = 8;
print_r($notas);
$notas[] = 7;
echo "<br/>";
var_dump($notas);

//FUNCIÓN UNSET
echo "<br/>";
$otro_array = array(1, 2, 3);
unset($otro_array);
//var_dump($otro_array);

//ISSET, EMPTY, IS_NULL
//ISSET: DETERMINA SI UNA VARIABLE ESTÁ DECLARADA Y NO ES NULA
//EMPTY: DETERMINA SI UNA VARIABLE ESTÁ VACÍA 
//IS_NULL: DETERMINA SI UNA VARIABLE ES NULL
$variable = "Hola";
echo "ISSET: ".isset($variable)."<br/>";
unset($variable);
echo "ISSET: ".isset($variable)."<br/>";
echo "EMPTY: ".empty($variable)."<br/>";
echo "IS_NULL: ".is_null($variable)."<br/>";

$variable = null;
echo "ISSET: ".isset($variable)."<br/>";
echo "EMPTY: ".empty($variable)."<br/>";
echo "IS_NULL: ".is_null($variable)."<br/>";

$variable = 0;
echo "ISSET: ".isset($variable)."<br/>";
echo "EMPTY: ".empty($variable)."<br/>";
echo "IS_NULL: ".is_null($variable)."<br/>";

//FUNCIONES
function suma($a, $b=1){
	$res = $a + $b;
	return $res;
}
$num1 = 10;
$num2 = 4;
$resultado = suma($num1, $num2);
echo $resultado."<br/>";
$resultado = suma(10);
echo $resultado."<br/>";

function suma2($a, $b=1){
	global $res;
	$res = $a + $b;
}
suma2(20);
echo $res."<br/>";

$var1 = 45;
$var2 = 23;
function suma3(){
	$GLOBALS['var1'] = $GLOBALS['var1'] + $GLOBALS['var2'];
}
suma3();
echo $var1;

function mi_funcion(){
	static $num = 0;
	echo "<br/>".$num."<br/>";
	$num++;
}
mi_funcion();
mi_funcion();
mi_funcion();
?>