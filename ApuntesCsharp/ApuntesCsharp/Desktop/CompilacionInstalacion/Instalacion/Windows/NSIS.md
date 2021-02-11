# NSIS

Para compilar las aplicaciones desarrolladas en C# se usara "Publish"

Con este programa crearemos un ``exe`` autoextraible para descomprimir los archivos en una ruta como ``%programfiles%``
## Guía de compilación
---

![NSIS](Img_md/NSIS/1.JPG)

Ejecutamos el programa y le podemos dar a Compilar un script NSI, que consiste en crear un script para la configuración de la instalación, rutas, iconos, etc
En esto elegiremos el "installer based on .ZIP file

---
![NSIS](Img_md/NSIS/2.JPG)

Elegimos el proyecto comprimido con "open" y lo demás lo dejamos como esta y "generate"

---
![NSIS](Img_md/NSIS/3.JPG)

Se genera un log en el programa para indicar lo que se ha realizado

---

## INSTALACIÓN

![NSIS](Img_md/NSIS/4.JPG)

Ejecutamos el ``.exe`` y seleccionamos la ruta donde queremos instalarlo

---
![NSIS](Img_md/NSIS/5.JPG)

Indica el proceso de instalación mediante una progress bar y un los indicando los ficheros como van siendo extraídos