# Middleware

Para crear el middleware utilizando express.

```typescript
import express, { Request, Response, NextFunction } from 'express';

// Crear la aplicación Express
const app = express();

// Middleware personalizado
const loggerMiddleware = (req: Request, res: Response, next: NextFunction) => {
  console.log(`[${new Date().toISOString()}] ${req.method} ${req.path}`);
  next();
};

// Aplicar el middleware a todas las rutas
app.use(loggerMiddleware);

// Ruta de ejemplo
app.get('/', (req: Request, res: Response) => {
  res.send('Hola, mundo!');
});

// Iniciar el servidor
app.listen(3000, () => {
  console.log('Servidor iniciado en el puerto 3000');
});
```

En este ejemplo, hemos creado un middleware personalizado llamado `loggerMiddleware` que se ejecutará en cada solicitud. El middleware simplemente registra en la consola la hora actual, el método de la solicitud y la ruta antes de pasar la solicitud al siguiente middleware o ruta.

Luego, utilizamos `app.use()` para aplicar el middleware a todas las rutas de la aplicación Express. Esto asegura que el middleware se ejecute en cada solicitud entrante.

Finalmente, hemos definido una ruta de ejemplo utilizando `app.get()` que responde con el mensaje "Hola, mundo!" cuando se accede a la ruta raíz ("/").

Al iniciar el servidor y realizar una solicitud, verás que el middleware registra los detalles de la solicitud en la consola antes de que la respuesta se envíe al cliente.

Recuerda que los middlewares en Express tienen acceso a los objetos `Request`, `Response` y `NextFunction`. Puedes utilizarlos para realizar acciones adicionales, modificar la solicitud o respuesta, o incluso detener el flujo de ejecución si es necesario.
