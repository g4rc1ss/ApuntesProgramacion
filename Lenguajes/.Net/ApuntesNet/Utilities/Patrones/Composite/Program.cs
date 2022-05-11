using Composite;

/**
 * Usamos el patron Composite para extender la clase de logging
 * Queremos extender esta clase para poder guardar el log en Base de datos.
 * 
 * La clase Patron Composite tiene una relacion con la clase Logging, puesto
 * que ambas clases implementan la misma interfaz y realizan el mismo tipo de accion
 * pero forma diferente.
 */

// 
var articulosNormal = new ArticulosServicio(new Logging());
articulosNormal.ConsultarArticulo("fbvgriouhip");
articulosNormal.GuardarArticulo("kjncbhrvhgr", "fnbherkg");

// 
var articulos = new ArticulosServicio(new PatronComposite());
articulos.ConsultarArticulo("Hola");
articulos.GuardarArticulo("cbhgoipro", "Hola");

Console.ReadKey();
