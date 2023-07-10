## Consultas Http

Para realizar consultas HTTP en TypeScript se hace uso de Axios

**Instalación de Axios:**
Antes de comenzar, debes asegurarte de tener Axios instalado en tu proyecto. Puedes instalarlo ejecutando el siguiente comando en tu terminal:

```
npm install axios
```

**Realización de consultas HTTP con Axios:**
Una vez que tienes Axios instalado, puedes utilizarlo para realizar consultas HTTP en TypeScript. Aquí tienes un ejemplo de cómo realizar una solicitud GET:

```typescript
import axios, { AxiosResponse } from 'axios';

async function obtenerDatos(): Promise<void> {
  try {
    const response: AxiosResponse = await axios.get('https://api.example.com/data');
    const datos = response.data;
    console.log('Datos obtenidos:', datos);
  } catch (error) {
    console.error('Error al obtener los datos:', error);
  }
}

obtenerDatos();
```

En este ejemplo, importamos Axios y AxiosResponse de la librería 'axios'. Luego, definimos una función asincrona `obtenerDatos()` que realiza una solicitud GET a la URL 'https://api.example.com/data'. Utilizamos `await` para esperar a que se complete la solicitud y almacenamos la respuesta en la variable `response`. A continuación, accedemos a los datos de la respuesta utilizando `response.data`. Finalmente, mostramos los datos obtenidos en la consola.

Puedes realizar solicitudes POST, PUT, DELETE y otras utilizando las funciones correspondientes de Axios, como `axios.post()`, `axios.put()`, `axios.delete()`, etc. Estas funciones aceptan parámetros adicionales, como datos a enviar en la solicitud, encabezados personalizados, etc.


**Consideraciones adicionales:**
Al utilizar librerías externas como Axios para realizar consultas HTTP en TypeScript, ten en cuenta lo siguiente:

- Asegúrate de manejar adecuadamente los errores que puedan ocurrir durante las solicitudes HTTP. Puedes utilizar bloques `try...catch` para capturar y manejar los errores.
- Considera agregar manejo de errores específico, como verificar el estado de respuesta HTTP y realizar acciones correspondientes en función de ello.
- Ten en cuenta la seguridad al realizar solicitudes HTTP, especialmente si se envían datos confidenciales. Puedes utilizar métodos como HTTPS y autenticación para garantizar la seguridad de tus solicitudes.