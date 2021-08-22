# WinRaR

Para compilar las aplicaciones desarrolladas en python se usara "pyinstaller"

Con este programa crearemos un ``exe`` autoextraible para descomprimir los archivos en una ruta como ``%programfiles%``
## Guía de compilación
---
Antes de todo ejecutaremos el programa ``pyinstaller`` sobre el proyecto python con el parámetro --onedir para preparar el proyecto para ser extraído, luego accedemos a la carpeta dist y nos encontraremos otra carpeta con el nombre del proyecto, accedemos también.

![Selección WinRar](Img_md/Winrar/1.JPG)

Seleccionamos los archivos y los "añadimos al archivo" para empezar la compresión.

![Selección WinRar](Img_md/Winrar/2.JPG)

Marcamos la opción "Crear un archivo autoextraible"

---
![Selección WinRar](Img_md/Winrar/3.JPG)

En avanzado, seleccionamos "Autoextraible..." para configurar el .exe

---
![Selección WinRar](Img_md/Winrar/4.JPG)

En general seleccionamos el nombre de la carpeta donde vamos a extraer todos los archivos del programa y también la ubicación donde vamos a crearla "Archivos de programa", etc.

---
![Selección WinRar](Img_md/Winrar/5.JPG)

En actualizar depende del programa usaremos una opción u otra, si es para actualizar un programa ya instalado, pues actualizar ficheros, si es para instalar, pues extraer y reemplazar, etc.

---
![Selección WinRar](Img_md/Winrar/6.JPG)

En Instalación pondremos los archivos que queremos ejecutar antes y después de la instalación del programa. la ruta se hace en base a como lo vemos en el explorador de archivos del winrar

---
![Selección WinRar](Img_md/Winrar/7.JPG)

en Texto e Icono Pondremos el titulo de la ventana de instalación, la descripción del programa, el logo para el fondo y el icono del programa

---
![Selección WinRar](Img_md/Winrar/8.JPG)

En avanzado podremos seleccionar ficheros a borrar de la carpeta, crear un acceso directo en el escritorio al programa y solicitar permisos de instalación(dependiendo de la ruta puede ser necesario)

---
![Selección WinRar](Img_md/Winrar/9.JPG)

Le damos a aceptar en la ventana de configuración y a aceptar en la ventana principal del winrar y empezara la compresión

---
## INSTALACIÓN

![Selección WinRar](Img_md/Winrar/10.JPG)

ejecutamos el archivo y nos da la opción de cambiar la ruta de instalación, sino sera esa por defecto

---
![Selección WinRar](Img_md/Winrar/11.JPG)

Se empezara a instalar, informando de los ficheros que esta extrayendo con una progressBar y un TextBox
