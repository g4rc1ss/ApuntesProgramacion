SQLite es un sistema de gestión de bases de datos relacional (RDBMS) incorporado en Python. Es una base de datos ligera y autónoma que no requiere un servidor de base de datos separado. Puedes utilizar el módulo `sqlite3` incorporado en Python para conectarte y trabajar con bases de datos SQLite.

## Creación de una base de datos y una tabla:
Para comenzar, debes crear una base de datos SQLite y una tabla dentro de ella.

```python
import sqlite3

# Conexión a la base de datos (se crea automáticamente si no existe)
conexion = sqlite3.connect('basedatos.db')

# Creación de una tabla
cursor = conexion.cursor()
cursor.execute('''CREATE TABLE IF NOT EXISTS usuarios (
                  id INTEGER PRIMARY KEY AUTOINCREMENT,
                  nombre TEXT NOT NULL,
                  edad INTEGER
                )''')
conexion.commit()
```

En este ejemplo, hemos establecido una conexión a la base de datos SQLite utilizando el método `connect()` y especificando el nombre de la base de datos (`basedatos.db`). Luego, hemos creado una tabla llamada "usuarios" utilizando el cursor. La tabla tiene una columna "id" como clave primaria, una columna "nombre" de tipo texto y una columna "edad" de tipo entero.

## Inserción de datos en la tabla:
Puedes insertar datos en la tabla utilizando consultas SQL.

```python
# Inserción de datos en la tabla
cursor.execute("INSERT INTO usuarios (nombre, edad) VALUES (?, ?)", ('Juan', 25))
conexion.commit()
```

En este ejemplo, hemos utilizado una consulta SQL para insertar un registro en la tabla "usuarios". Hemos utilizado parámetros de marcadores de posición (`?`) en la consulta y proporcionado los valores correspondientes en forma de una tupla `('Juan', 25)`. Luego, hemos confirmado los cambios en la base de datos utilizando el método `commit()`.

3. Consulta de datos desde la tabla:
Puedes consultar datos desde la tabla utilizando consultas SQL.

```python
# Consulta de datos desde la tabla
cursor.execute("SELECT * FROM usuarios")
resultados = cursor.fetchall()

# Recorrido de los resultados
for fila in resultados:
    print(fila)
```

En este ejemplo, hemos utilizado una consulta SQL para seleccionar todos los registros de la tabla "usuarios". Utilizamos el método `fetchall()` para obtener todos los resultados y luego iteramos sobre los resultados e imprimimos cada fila.

## Cierre de la conexión:
Es importante cerrar la conexión a la base de datos una vez que hayas terminado de trabajar con ella.

```python
# Cierre de la conexión
conexion.close()
```

En este ejemplo, hemos utilizado el método `close()` para cerrar la conexión a la base de datos SQLite.
