# PyQt5

> Instalación y configuración de PyQT5 con Designer(Herramienta para diseñar la aplicación y exportarla en un xml)

## Instalación PyQt5
> Para instalar esta herramienta se usara:
---------
 ```
pip install pyqt5
pip install pyqt5-tools
 ```
con el segundo comando se instalara el designer y otra herramienta que usaremos mas tarde

Depende de como hayamos instalado python los paquetes se instalaran en:
> ` C:\Program Files\PythonX\Lib\site-packages\pyqt5-tools\`

> ` C:\Users\Usuario\AppData\Local\Programs\Python\Python36-32\Lib\site-packages\ pyqt5-tools\`

En el directorio buscamos el archivo "designer.exe" y podemos crear un acceso directo de este al escritorio para empezar con la creación de la GUI

Cuando guardemos la interfaz, el programa nos creara un archivo ".ui" que es un xml con el contenido de la interfaz y configuración, ese archivo podemos genera un ".py" o cargarlo desde nuestro proyecto principal.

### Ventajas de generar un .py:
-  IntelliSense del IDE(toda la interfaz se carga en un .py, al importarlo como modulo el IDE reconocerá todas las funciones etc)
- Mas velocidad(el XML tiene que leerlo, entenderlo y ejecutarlo)
### Desventajas
- Organización y lectura de código, para mi gusto tener el código organizado en un XML aparte es mas legible y ordenado(entra en juego "rapidez y sencillez" vs "legibilidad")

Para convertir un ".ui" en un ".py"
> `pyuic5 -x nombreDelXML.ui -o nombreDelArchivoPython.py`

El archivo .ui no hay que tirarlo, porque el programa "designer" es capaz de leer el .py
Asique hay que guardarlo y por tanto considero que es mejor para el proyecto convertirlo en .py porque tiene mas ventajas