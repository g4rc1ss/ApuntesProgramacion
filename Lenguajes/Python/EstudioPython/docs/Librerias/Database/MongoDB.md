MongoDB es una base de datos NoSQL orientada a documentos que permite almacenar datos en forma de documentos JSON. Puedes utilizar la biblioteca `pymongo` en Python para conectarte y trabajar con MongoDB.

## Instalación e importación de la biblioteca `pymongo`:
Para comenzar, debes instalar la biblioteca `pymongo` utilizando el administrador de paquetes de Python, como pip. Luego, puedes importar la biblioteca en tu código.

```powershell
pip install pymongo
```

```python
import pymongo
```

## Establecimiento de la conexión a la base de datos:
Para conectarte a una base de datos MongoDB, necesitas establecer una conexión proporcionando los detalles de conexión, como el host y el puerto del servidor MongoDB.

```python
cliente = pymongo.MongoClient("mongodb://localhost:27017/")
```

En este ejemplo, estamos estableciendo una conexión a un servidor MongoDB que se ejecuta en el host local (`localhost`) utilizando el puerto predeterminado (`27017`). Puedes ajustar estos valores según tu configuración de MongoDB.

## Selección de una base de datos y una colección:
En MongoDB, los datos se organizan en bases de datos y colecciones. Debes seleccionar la base de datos y la colección con las que deseas trabajar.

```python
base_datos = cliente["basedatos"]
coleccion = base_datos["coleccion"]
```

En este ejemplo, hemos seleccionado la base de datos llamada "basedatos" y la colección llamada "coleccion". Si la base de datos o la colección no existen, MongoDB las creará automáticamente cuando se realice la primera operación.

## Inserción de documentos en la colección:
Puedes insertar documentos JSON en la colección utilizando el método `insert_one()` o `insert_many()`.

```python
documento = {"nombre": "Juan", "edad": 25}
coleccion.insert_one(documento)
```

En este ejemplo, hemos creado un diccionario `documento` que representa un documento JSON a insertar en la colección. Luego, utilizamos el método `insert_one()` para insertar el documento en la colección.

## Consulta de documentos desde la colección:
Puedes realizar consultas para obtener documentos de la colección utilizando el método `find()`.

```python
resultados = coleccion.find()

for documento in resultados:
    print(documento)
```

En este ejemplo, utilizamos el método `find()` para obtener todos los documentos de la colección. Luego, iteramos sobre los resultados e imprimimos cada documento.

## Actualización de documentos en la colección:
Puedes actualizar documentos existentes en la colección utilizando el método `update_one()` o `update_many()`.

```python
filtro = {"nombre": "Juan"}
nuevo_valor = {"$set": {"edad": 30}}

coleccion.update_one(filtro, nuevo_valor)
```

En este ejemplo, hemos definido un filtro para seleccionar el documento a actualizar (`{"nombre": "Juan"}`) y un nuevo valor para la actualización (`{"$set": {"edad": 30}}`). Luego, utilizamos el método `update_one()` para actualizar el primer documento que cumple con el filtro.

## Eliminación de documentos de la colección:
Puedes eliminar documentos de la colección utilizando el método `delete_one()` o `delete_many()`.

```python
filtro = {"nombre": "Juan"}

coleccion.delete_one(filtro)
```

En este ejemplo, hemos definido un filtro para seleccionar el documento a eliminar (`{"nombre": "Juan"}`). Luego, utilizamos el método `delete_one()` para eliminar el primer documento que cumple con el filtro.

## Cierre de la conexión:
Es importante cerrar la conexión a la base de datos una vez que hayas terminado de trabajar con ella.

```python
cliente.close()
```

En este ejemplo, hemos utilizado el método `close()` para cerrar la conexión con MongoDB.
