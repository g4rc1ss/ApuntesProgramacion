El logging en Python es una técnica utilizada para registrar mensajes o eventos de manera estructurada durante la ejecución de una aplicación. Proporciona una forma eficiente de rastrear y depurar el código, así como de generar registros para el monitoreo y el análisis. Python ofrece un módulo de registro incorporado llamado `logging`, que permite configurar diferentes niveles de registro, formatos de registro y destinos de salida.

## Configuración básica del registro:
Para comenzar a utilizar el logging en Python, es necesario importar el módulo `logging` y configurar un registrador básico. El nivel de registro determina el nivel de severidad de los mensajes que se registran.

```python
import logging

# Configuración básica del registro
logging.basicConfig(level=logging.INFO)

# Uso del registrador
logging.debug('Este es un mensaje de depuración')
logging.info('Esta es una información')
logging.warning('Esta es una advertencia')
logging.error('Este es un error')
logging.critical('Este es un mensaje crítico')
```

En este ejemplo, configuramos el nivel de registro en `logging.INFO`, lo que significa que se registrarán mensajes con nivel de información y niveles superiores. Luego, utilizamos diferentes métodos (`debug()`, `info()`, `warning()`, `error()`, `critical()`) para registrar mensajes con diferentes niveles de severidad.

## Configuración avanzada del registro:
El registro se puede personalizar aún más utilizando configuraciones avanzadas, como el formato de los mensajes de registro, el destino de salida y la adición de controladores adicionales.

```python
import logging

# Configuración avanzada del registro
logging.basicConfig(
    level=logging.DEBUG,
    format='%(asctime)s [%(levelname)s] %(message)s',
    handlers=[
        logging.FileHandler('app.log'),  # Registro en un archivo
        logging.StreamHandler()  # Registro en la consola
    ]
)

# Uso del registrador
logging.debug('Este es un mensaje de depuración')
logging.info('Esta es una información')
logging.warning('Esta es una advertencia')
```

En este ejemplo, hemos configurado el nivel de registro en `logging.DEBUG`, lo que significa que se registrarán mensajes con todos los niveles de severidad. Además, hemos especificado un formato personalizado para los mensajes de registro utilizando la cadena de formato `'%(asctime)s [%(levelname)s] %(message)s'`. También hemos agregado dos controladores (`FileHandler` y `StreamHandler`) para enviar los mensajes de registro tanto a un archivo como a la consola.

3. Logging en módulos separados:
Puedes usar el logging en módulos separados para tener un control más granular sobre los mensajes de registro y separar la salida de registro por módulo.

```python
import logging

# Configuración básica del registro
logging.basicConfig(level=logging.INFO)

# En el módulo1.py
logger = logging.getLogger(__name__)
logger.info('Este es un mensaje de módulo1')

# En el módulo2.py
logger = logging.getLogger(__name__)
logger.info('Este es un mensaje de módulo2')
```

En este ejemplo, cada módulo tiene su propio objeto de registro. Al utilizar el nombre del módulo `__name__` como nombre del registrador, se asegura que los mensajes se registren con el nombre del módulo correspondiente.
