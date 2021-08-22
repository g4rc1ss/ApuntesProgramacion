import shutil
'''
    El modulo shutil sirve para realizar operaciones de alto nivel con archivo
    y directorios. Entre esas operaciones esta la copia, borrado o mover, como
    copias permisos y estado de los archivos y directorios


    Borrar un arbol de directorios con sus archivos

    la funcion retree() elimina un arbol de directorios con los archivos existentes.
    la ruta debe de ser un directorio, no un enlace simbolico
    ej:
        shutil.retree(path, ignore_error=False, onerror=None)
'''

import shutil, os

ruta = os.path.abspath(os.path.dirname(__file__))+"\\prueba"

if os.path.exists(ruta):    
    shutil.rmtree(ruta, ignore_errors=False) 
    print('Árbol de directorio borrado')
else:
    print('El directorio no existe')