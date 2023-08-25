LiteDB es una base de datos NoSQL embebida escrita en C# que también ofrece soporte para Python a través de la biblioteca `litecli`. Proporciona una solución ligera y fácil de usar para almacenar y recuperar datos en aplicaciones Python.

## Instalación e importación de la biblioteca `litecli`:
Para comenzar, debes instalar la biblioteca `litecli` utilizando el administrador de paquetes de Python, como pip. Luego, puedes importar la biblioteca en tu código.

```bash
pip install litecli
```

```python
import litecli
```

## Establecimiento de la conexión a la base de datos:
Para conectarte a una base de datos LiteDB, necesitas establecer una conexión proporcionando la ruta del archivo de base de datos.

```python
conexion = litecli.connect('basedatos.db')
```

En este ejemplo, estamos estableciendo una conexión a una base de datos LiteDB almacenada en el archivo `'basedatos.db'`. Si el archivo no existe, LiteDB lo creará automáticamente cuando se realice la primera operación.

## Creación de una colección:
En LiteDB, los datos se organizan en colecciones. Puedes crear una colección utilizando la conexión a la base de datos.

```python
coleccion = conexion["coleccion"]
```

En este ejemplo, hemos creado una colección llamada "coleccion" utilizando la conexión a la base de datos.

## Inserción de documentos en la colección:
Puedes insertar documentos en la colección utilizando el método `insert()`.

```python
documento = {"nombre": "Juan", "edad": 25}
coleccion.insert(documento)
```

En este ejemplo, hemos creado un diccionario `documento` que representa un documento a insertar en la colección. Luego, utilizamos el método `insert()` para insertar el documento en la colección.

## Consulta de documentos desde la colección:
Puedes realizar consultas para obtener documentos de la colección utilizando el método `find()`.

```python
resultados = coleccion.find()

for documento in resultados:
    print(documento)
```

En este ejemplo, utilizamos el método `find()` para obtener todos los documentos de la colección. Luego, iteramos sobre los resultados e imprimimos cada documento.

## Actualización de documentos en la colección:
Puedes actualizar documentos existentes en la colección utilizando el método `update()`.

```python
filtro = {"nombre": "Juan"}
nuevo_valor = {"edad": 30}

coleccion.update(filtro, nuevo_valor)
```

En este ejemplo, hemos definido un filtro para seleccionar el documento a actualizar (`{"nombre": "Juan"}`) y un nuevo valor para la actualización (`{"edad": 30}`). Luego, utilizamos el método `update()` para actualizar los documentos que cumplen con el filtro.

## Eliminación de documentos de la colección:
Puedes eliminar documentos de la colección utilizando el método `remove()`.

```python
filtro = {"nombre": "Juan"}

coleccion.remove(filtro)
```

En este ejemplo, hemos definido un filtro para seleccionar el documento a eliminar (`{"nombre": "Juan"}`). Luego, utilizamos el método `remove()` para eliminar los documentos que cumplen con el filtro.

## Cierre de la conexión:
Es importante cerrar la conexión a la base de datos una vez que hayas terminado de trabajar con ella.

```python
conexion.close()
```

En este ejemplo, hemos utilizado el método `close()` para cerrar la conexión con LiteDB.
