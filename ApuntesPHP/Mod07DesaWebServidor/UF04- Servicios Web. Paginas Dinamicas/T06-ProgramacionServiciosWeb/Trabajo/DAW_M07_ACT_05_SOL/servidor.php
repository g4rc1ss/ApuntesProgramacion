<?php
/////////////////////////////////////////////////////////////////////////////////////
	function insertaProducto($nombre, $categoria){
		$con = mysqli_connect("localhost", "root", "12345", "soap");
		$query = "insert into producto (nombre, categoria) values ('$nombre', $categoria)";
		mysqli_query($con, $query);
		mysqli_close($con);
		return "Todo OK!";
	}
/////////////////////////////////////////////////////////////////////////////////////
	function listaProductos($categoria){
		$misProductos = array();
		$con = mysqli_connect("localhost", "root", "12345", "soap");
		$query = "select id, nombre from producto where categoria = $categoria";
		$productos = mysqli_query($con, $query);
		while($producto = mysqli_fetch_assoc($productos)){
			$misProductos [] = $producto;
		}
		mysqli_close($con);
		return $misProductos;
	}
/////////////////////////////////////////////////////////////////////////////////////

    require_once("lib/nusoap.php");
    $namespace = "http://localhost/soap/servidor.php";
    //create a new soap server
    $server = new soap_server();
    $server->configureWSDL("WSDLTST"); //Nombre de mi Web Service
    $server->soap_defencoding = 'UTF-8'; 
    $server->wsdl->schemaTargetNamespace = $namespace; //Indico al WSDL el espacio de nombres donde encontrar los métodos

////////////////////////////DEFINICION DE TIPOS DE DATOS/////////////////////////////
$server->wsdl->addComplexType(
    'Producto',
    'complexType',
    'struct',
    'all',
    '',
    array(
        'id' => array('name'=>'id','type'=>'xsd:int'),
        'nombre' => array('name'=>'nombre','type'=>'xsd:string')
    )
);
$server->wsdl->addComplexType(
    'ArrayProductos',
    'complexType',
    'array',
    '',
    'SOAP-ENC:Array',
    array(),
    array(
        array('ref'=>'SOAP-ENC:arrayType','wsdl:arrayType'=>'tns:Producto[]')
    ),
    'tns:Producto'
);

////////////////////////////REGISTRO DE METODOS/////////////////////////////        
	$server->register(
           'insertaProducto',
           array('nombre'=>'xsd:string', 'categoria'=>'xsd:int'),
           array('return'=>'xsd:string'),
           $namespace,
		   false,
		   'rpc',
		   'encoded',
		   'Método que inserta en la base de datos el producto con el nombre y la cetegoría dados');
	
    $server->register(
           'listaProductos',
           array('categoria'=>'xsd:int'),
           array('return'=>'tns:ArrayProductos'),
           $namespace,
		   false,
		   'rpc',
		   'encoded',
		   'Método que devuelve un array con los productos de una categoría');          
    
	//CREO EL LISTENER
    $server->service(isset($GLOBALS['HTTP_RAW_POST_DATA']) ? $GLOBALS['HTTP_RAW_POST_DATA'] : '');
    //exit();  
?>