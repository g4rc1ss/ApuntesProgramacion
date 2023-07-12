La caché distribuida con Redis es una técnica utilizada para almacenar y recuperar datos en una infraestructura distribuida utilizando el sistema de almacenamiento en memoria Redis. Redis es una base de datos en memoria de alto rendimiento que permite almacenar datos clave-valor de manera eficiente. En Python, puedes utilizar la biblioteca `redis-py` para interactuar con Redis y aprovechar su capacidad de caché distribuida.

## Instalación e importación de la biblioteca `redis-py`:
Primero, debes instalar la biblioteca `redis-py` utilizando el administrador de paquetes de Python, como pip. Luego, puedes importar la biblioteca en tu código.

```bash
pip install redis
```

```python
import redis
```

## Configuración de la conexión a Redis:
Debes configurar la conexión a Redis, proporcionando el host y el puerto en los que se ejecuta el servidor Redis.

```python
r = redis.Redis(host='localhost', port=6379)
```

En este ejemplo, hemos configurado la conexión a Redis en el host local (`localhost`) y el puerto predeterminado (`6379`). Asegúrate de ajustar estos valores según tu configuración de Redis.

## Almacenamiento y recuperación de datos en la caché:
Puedes utilizar los métodos proporcionados por la biblioteca `redis-py` para almacenar y recuperar datos en Redis.

```python
# Almacenar datos en la caché
r.set('clave', 'valor')

# Recuperar datos de la caché
valor = r.get('clave')
print(valor)
```

En este ejemplo, hemos almacenado un valor en la clave `'clave'` utilizando el método `set()`. Luego, hemos recuperado el valor almacenado utilizando el método `get()`.

4. Configuración de tiempo de expiración en la caché:
Puedes configurar un tiempo de expiración para los datos almacenados en la caché utilizando el parámetro `ex` al establecer un valor.

```python
# Almacenar datos en la caché con tiempo de expiración de 10 segundos
r.set('clave', 'valor', ex=10)
```

En este ejemplo, hemos establecido un tiempo de expiración de 10 segundos para los datos almacenados en la clave `'clave'`. Después de 10 segundos, los datos se eliminarán automáticamente de la caché.

