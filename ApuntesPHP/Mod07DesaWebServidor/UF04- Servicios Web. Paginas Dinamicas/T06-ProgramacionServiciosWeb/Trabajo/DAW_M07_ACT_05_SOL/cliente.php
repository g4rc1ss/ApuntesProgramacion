<?php
    require_once('lib/nusoap.php');
    $client = new soapclient('http://localhost/soap/servidor.php?wsdl');
	
	$client->insertaProducto('teclado inalambrico', 1);
	
    $result = $client->listaProductos(1);
    echo "<pre>";
    print_r($result);
    echo "</pre>";
?>