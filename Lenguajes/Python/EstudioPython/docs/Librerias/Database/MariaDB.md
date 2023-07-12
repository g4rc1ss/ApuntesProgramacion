MariaDB es un sistema de gestión de bases de datos relacionales (RDBMS) que es compatible con MySQL. Puedes utilizar la biblioteca `mysql-connector-python` en Python para conectarte y trabajar con bases de datos MariaDB.

## Instalación e importación de la biblioteca `mysql-connector-python`:
Para comenzar, debes instalar la biblioteca `mysql-connector-python` utilizando el administrador de paquetes de Python, como pip. Luego, puedes importar la biblioteca en tu código.

```bash
pip install mysql-connector-python
```

```python
import mysql.connector
```

## Establecimiento de la conexión a la base de datos:
Para conectarte a una base de datos MariaDB, necesitas establecer una conexión proporcionando los detalles de conexión, como el host, el puerto, el nombre de usuario y la contraseña.

```python
mydb = mysql.connector.connect(
  host="localhost",
  user="usuario",
  password="contraseña",
  database="basedatos"
)
```

En este ejemplo, estamos estableciendo una conexión a una base de datos MariaDB que se ejecuta en el host local (`localhost`) utilizando el nombre de usuario y la contraseña proporcionados. Además, hemos especificado el nombre de la base de datos que deseamos utilizar.

## Ejecución de consultas SQL:
Una vez que tienes una conexión establecida, puedes ejecutar consultas SQL para interactuar con la base de datos.

```python
mycursor = mydb.cursor()

# Ejecutar una consulta SQL
mycursor.execute("SELECT * FROM tabla")

# Obtener los resultados de la consulta
resultados = mycursor.fetchall()

# Recorrer los resultados
for fila in resultados:
  print(fila)
```

En este ejemplo, hemos creado un cursor utilizando el método `cursor()` de la conexión. Luego, ejecutamos una consulta SQL utilizando el método `execute()` y recuperamos los resultados utilizando el método `fetchall()`. Finalmente, iteramos sobre los resultados y los imprimimos en la consola.

## Inserción de datos en la base de datos:
Puedes insertar datos en la base de datos utilizando consultas SQL con parámetros.

```python
mycursor = mydb.cursor()

# Consulta SQL con parámetros
sql = "INSERT INTO tabla (columna1, columna2) VALUES (%s, %s)"
valores = ("valor1", "valor2")

# Ejecutar la consulta con los valores
mycursor.execute(sql, valores)

# Confirmar los cambios en la base de datos
mydb.commit()

print(mycursor.rowcount, "registro(s) insertado(s)")
```

En este ejemplo, hemos definido una consulta SQL con parámetros utilizando marcadores de posición `%s`. Luego, hemos proporcionado los valores para los parámetros en forma de una tupla `valores`. Ejecutamos la consulta utilizando el método `execute()` y luego confirmamos los cambios en la base de datos utilizando el método `commit()`. Finalmente, imprimimos la cantidad de registros insertados.
