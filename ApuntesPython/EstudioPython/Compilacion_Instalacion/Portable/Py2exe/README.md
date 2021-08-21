# Py2Exe (Parece un poco obsoleto)

Para compilar las aplicaciones desarrolladas en python se usara "pyinstaller"

Este programa nos compilara en:
- ``.exe`` para windows
- ``.dmg`` para MacOs
- ``.tar.gc`` para Linux

El comando para instalar el programa sera:
```
pip install py2exe
```

Una vez instalado el programa, haremos la compilación, la cual hay varias formas

---

### Compilación

```
build_exe [-h] [-i modname] [-x modname] [-p package_name] [-O] [-s]
          [-r] [-f modname] [-v] [-c] [-d DESTDIR] [-l LIBNAME]
          [-b {0,1,2,3}] [-W setup_path]
          [-svc service]
          [script [script ...]]
```
- ``-h, --help`` Muestra un mensaje de ayuda
- ``-i modname, --include modname`` Incluir un módulos
- ``-x modname, --exclude modname`` Excluir módulos
- ``-p package_name, --package package_name`` Excluir módulos
- ``-O, --optimize`` Usar ByteCode optimizado
- ``-s, --summary`` Imprime que módulos estar obsoletos y que módulos funcionan y cual importar después
- ``-r, --report`` Imprime detalladamente los módulos obsoletos y funcionales
- ``-f modname, --from modname`` Imprime cuando el modulo <modname> esta importado
- ``-v`` Salida mas descriptiva
- ``-c, --compress`` Comprime librerías
- ``-d DESTDIR, --dest DESTDIR`` Carpeta de destino
- ``-l LIBNAME, --library LIBNAME`` Ruta relativa del archivo de python
- ``-b option, --bundle-files option`` Numero de archivos definitivos a crear, cuantos mas archivos mas eficiente y rápido sera el programa, 0=1 archivo, 1=2 archivos, etc
- ``-W setup_path, --write-setup-script setup_path`` No construye un ejecutable(exe, etc) sino que crea un script para ejecutar el programa de manera mas fácil

---

Ejemplo de comando:
```
build_exe archivo.py -c --bundle-files 0
```