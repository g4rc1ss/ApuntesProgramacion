## Cache distribuida en Redis

**Instalación:**

Primero, debes instalar la librería `ioredis` utilizando npm:

```bash
npm install ioredis
```

**Configuración de conexión a Redis:**

Asegúrate de tener una instancia de Redis en funcionamiento y con los parámetros de conexión correctos. Luego, puedes configurar la conexión a Redis en tu aplicación TypeScript. Aquí tienes un ejemplo de configuración básica:

```typescript
import Redis from 'ioredis';

const redis = new Redis({
  host: 'localhost',
  port: 6379,
  password: 'password',
});
```

En este ejemplo, estamos creando una instancia de Redis utilizando los parámetros de conexión adecuados. Asegúrate de proporcionar el host, el puerto y, si es necesario, la contraseña de tu instancia de Redis.

**Uso de Redis como caché:**

Una vez que hayas configurado la conexión a Redis, puedes utilizarlo como una caché en tu aplicación TypeScript. Redis proporciona operaciones simples pero potentes para almacenar y recuperar datos. Aquí tienes un ejemplo básico:

```typescript
// Ejemplo de uso de Redis como caché
async function obtenerValorDesdeCache(clave: string): Promise<string | null> {
  const valor = await redis.get(clave);
  return valor ? valor.toString() : null;
}

async function guardarValorEnCache(clave: string, valor: string, tiempoExpiracion?: number): Promise<void> {
  await redis.set(clave, valor);
  if (tiempoExpiracion) {
    await redis.expire(clave, tiempoExpiracion);
  }
}

// Uso de la caché
async function obtenerResultado(): Promise<string> {
  const clave = 'resultado';
  let resultado = await obtenerValorDesdeCache(clave);

  if (!resultado) {
    // Realizar cálculos costosos para obtener el resultado
    resultado = 'Resultado calculado';
    await guardarValorEnCache(clave, resultado, 60); // Guardar en caché por 60 segundos
  }

  return resultado;
}

obtenerResultado().then((resultado) => {
  console.log(resultado); // Salida: Resultado calculado (o valor en caché si está disponible)
});
```

En este ejemplo, utilizamos `redis.get()` para obtener un valor de la caché y `redis.set()` para guardar un valor en la caché. También utilizamos `redis.expire()` para establecer un tiempo de expiración opcional para el valor en la caché.

En la función `obtenerResultado()`, primero intentamos obtener el resultado desde la caché utilizando `obtenerValorDesdeCache()`. Si el resultado no está en la caché, realizamos cálculos costosos para obtener el resultado y luego lo guardamos en la caché utilizando `guardarValorEnCache()`.

**Consideraciones adicionales:**

Al utilizar Redis como una caché en TypeScript, ten en cuenta las siguientes consideraciones:

- Configura correctamente la conexión a Redis, proporcionando los parámetros adecuados, como el host, el puerto y la contraseña.
- Utiliza las operaciones de Redis adecuadas, como `get()`, `set()`, `expire()`, entre otras, para interactuar con la caché.
- Considera establecer tiempos de expiración para los valores almacenados en la caché, según tus necesidades y requisitos de negocio.
- Evalúa el tamaño de la caché y los recursos disponibles en tu entorno de ejecución para asegurarte de que Redis pueda manejar la carga adecuadamente.
- Utiliza las características adicionales de Redis, como conjuntos, listas y pub/sub, si son necesarias para tu caso de uso específico.

