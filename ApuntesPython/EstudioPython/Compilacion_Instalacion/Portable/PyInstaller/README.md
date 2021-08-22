# PyInstaller

Para compilar las aplicaciones desarrolladas en python se usara "pyinstaller"

Este programa nos compilara en:
- ``.exe`` para windows
- ``.dmg`` para MacOs
- ``.tar.gc`` para Linux

El comando para instalar el programa sera:
```
pip install pyinstaller
```

Una vez instalado el programa, haremos la compilación, la cual hay varias formas

A la hora de ejecutar el comando de compilado se ha de indicar el nombre del archivo, ese nombre sera el del archivo "main"(por si hay varios) y el mismo programa identificara y guardara las correspondientes librerías de las que dependa

---

### Compilación normal
Con este modo se compilara y crearan unas carpetas para la distribución, no es el mejor método
```
pyinstaller archivo_main.py
```

### Compilación sin consola
En la de arriba, si compilas una interfaz gráfica se mostrara la consola también y eso no suele interesar, asique el modo de ocultarla (--windowed o noconsole)
```
pyinstaller --windowed archivo_interfaz.py
pyinstaller --noconsole archivo_interfaz.py
```

---

## Compilar en un archivo
> ### Compilación para crear un archivo único ``.exe``
>Es el mejor método porque permitirá ejecutar el archivo sin ni siquiera tener >instalado python (--onefile)
```
pyinstaller --onefile archivo_main.py
pyinstaller --windowed --onefile archivo_main.py
```

---

### Compilación con icono
Tenemos que tener el icono en local y lo ejecutaremos asi
```
pyinstaller --onefile --icon=./nombre.ico archivo_main.py
```
---

### Opciones

````
pyinstaller [-h] [-v] [-D] [-F] [--specpath DIR] [-n NAME]
                   [--add-data <SRC;DEST or SRC:DEST>]
                   [--add-binary <SRC;DEST or SRC:DEST>] [-p DIR]
                   [--hidden-import MODULENAME]
                   [--additional-hooks-dir HOOKSPATH]
                   [--runtime-hook RUNTIME_HOOKS] [--exclude-module EXCLUDES]
                   [--key KEY] [-d {all,imports,bootloader,noarchive}] [-s]
                   [--noupx] [--upx-exclude FILE] [-c] [-w]
                   [-i <FILE.ico or FILE.exe,ID or FILE.icns>]
                   [--version-file FILE] [-m <FILE or XML>] [-r RESOURCE]
                   [--uac-admin] [--uac-uiaccess] [--win-private-assemblies]
                   [--win-no-prefer-redirects]
                   [--osx-bundle-identifier BUNDLE_IDENTIFIER]
                   [--runtime-tmpdir PATH] [--bootloader-ignore-signals]
                   [--distpath DIR] [--workpath WORKPATH] [-y]
                   [--upx-dir UPX_DIR] [-a] [--clean] [--log-level LEVEL]
                   scriptname [scriptname ...]
````

- ``-h, --help`` Mensaje de ayuda
- ``--clean`` Limpia la cache y borra archivos temporales después de la build
- ``-n NAME, --name NAME`` Nuevo nombre al compilar
- ``--key KEY`` Para cifrar el bytecode, requiere de ``PyCrypto (pip install pycrypto)``
- ``--uac-admin`` Para solicitar permisos de administrador en windows

---

## Ventajas y desventajas
El gran problema con Pyinstaller como os decía al principio son las dependencias.

Si nuestro programa utiliza únicamente módulos de la librería estándar no tendremos ningún problema, pero si queremos utilizar módulos externos es posible que no funcione... A no ser que sea alguno de los soportados como PyQT, django, pandas, matpotlib... pero requieren una configuraciones extra.