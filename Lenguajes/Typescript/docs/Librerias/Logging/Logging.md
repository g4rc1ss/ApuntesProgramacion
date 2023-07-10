# Logging

**Log4js en TypeScript:**

Log4js es una popular librería de logging para Node.js que ofrece una amplia gama de características y flexibilidad en la gestión de logs. Puedes utilizar Log4js en TypeScript para generar registros detallados, configurar diferentes niveles de log, utilizar diferentes formatos de salida (consola, archivos, bases de datos), entre otras funcionalidades.

**Instalación:**

Para utilizar Log4js en TypeScript, primero debes instalar la librería y sus tipos de TypeScript. Puedes hacerlo utilizando npm:

```bash
npm install log4js @types/log4js
```

**Configuración básica:**

Para empezar a utilizar Log4js, debes realizar una configuración básica. Puedes crear un archivo de configuración `log4js.json` con la siguiente estructura:

```json
{
  "appenders": {
    "console": { "type": "console" },
    "file": { "type": "file", "filename": "app.log" }
  },
  "categories": {
    "default": { "appenders": ["console", "file"], "level": "info" }
  }
}
```

En este ejemplo, configuramos dos appenders: uno para la consola y otro para un archivo de log llamado `app.log`. El nivel de log está establecido en "info". Puedes personalizar esta configuración según tus necesidades.

**Uso básico:**

A continuación, puedes utilizar Log4js en tu código TypeScript. Aquí tienes un ejemplo básico:

```typescript
import log4js from 'log4js';

// Configuración de Log4js
log4js.configure('log4js.json');

// Creación de un logger
const logger = log4js.getLogger();

// Registro de mensajes
logger.trace('Este es un mensaje de nivel trace');
logger.debug('Este es un mensaje de nivel debug');
logger.info('Este es un mensaje de nivel info');
logger.warn('Este es un mensaje de nivel warn');
logger.error('Este es un mensaje de nivel error');
logger.fatal('Este es un mensaje de nivel fatal');
```

En este ejemplo, importamos Log4js y configuramos la librería utilizando el archivo `log4js.json`. Luego, creamos un logger utilizando `log4js.getLogger()`. Finalmente, utilizamos el logger para registrar mensajes en diferentes niveles de log.

**Configuración avanzada:**

Log4js ofrece una amplia gama de opciones de configuración y personalización. Puedes configurar diferentes appenders, niveles de log, formatos de salida, patrones de nombres de archivos, entre otros. Aquí tienes un ejemplo de configuración avanzada:

```json
{
  "appenders": {
    "console": { "type": "console" },
    "file": { "type": "file", "filename": "logs/app.log", "pattern": ".yyyy-MM-dd" }
  },
  "categories": {
    "default": { "appenders": ["console", "file"], "level": "info" }
  }
}
```

En esta configuración, hemos modificado el patrón del archivo de log para que se cree un archivo nuevo cada día, con el formato `app.yyyy-MM-dd.log`. Esto es útil para mantener los logs organizados y divididos por fecha.

**Más características:**

Log4js ofrece muchas más características, como la posibilidad de enviar logs a servidores remotos, utilizar diferentes formatos de log (JSON, texto plano, etc.), configurar filtros y agregar contextos personalizados a los logs.
