'''
    El modulo shutil sirve para realizar operaciones de alto nivel con archivo
    y directorios. Entre esas operaciones esta la copia, borrado o mover, como
    copias permisos y estado de los archivos y directorios


    La función shutil.move() mueve un archivo o un directorio (y su contenido) 
    a otra ubicación y devuelve la ruta del nuevo destino.

    ej:
        shutil.move(src, dst, copy_function=copy2)

    La manera en la que se mueve es copiando y borrando, por tanto se usara
    copy2 para mover los archivos con los metadatos y permisos, para que queden iguales
'''

import shutil, os

ruta = ruta = os.path.abspath(os.path.dirname(__file__))

origen = ruta + '\\prueba'
destino = ruta + '\\mover'

if os.path.exists(origen):  
    ruta = shutil.move(origen, destino)
    print('El directorio ha sido movido a', ruta)
else:
    print('El directorio origen no existe')
