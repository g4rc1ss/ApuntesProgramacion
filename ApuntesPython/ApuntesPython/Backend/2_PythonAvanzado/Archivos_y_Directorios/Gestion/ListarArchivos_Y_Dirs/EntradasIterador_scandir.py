import os
from datetime import datetime

'''
    La funcion os.scandir() devuelve un iterador basado en la clase DirEntry que contiene
    informacion relacionada con las entradas (archivo y directorios) del directorio indicado(path)
        os.scandir(path="path")
    
    La clase DirEntry tienes los siguientes metodos:
        
        name: nombre del archivo o directorio leído.
        path: ruta completa del archivo o directorio leído.
        inode(): devuelve número de inodo de la entrada.
        is_dir(*, follow_symlinks=True): devuelve True si es directorio
        is_file(*, follow_symlinks=True): devuelve True si es archivo
        is_symlink(): devuelve True si es un enlace simbólico.
        stat(*, follow_symlinks=True): devuelve estado de la entrada
    
    os.scandir() es una alternativa a listdir porque es mas rapido en la lectura etc de ficheros
    porque realiza menos llamadas a os.stat
'''

ruta_app = os.path.abspath(os.path.dirname(__file__))+"\\prueba"
contenido = os.listdir(ruta_app)
total = 0
archivos = 0
formato = '%d-%m-%y %H:%M:%S'
linea = '-' * 40

contenido = os.scandir(ruta_app)
for elemento in contenido:
    if elemento.is_file():
        archivos += 1
        estado = elemento.stat()        
        tamaño = estado.st_size
        ult_acceso = datetime.fromtimestamp(estado.st_atime)
        modificado = datetime.fromtimestamp(estado.st_mtime)
        ult_acceso = ult_acceso.strftime(formato)
        modificado = modificado.strftime(formato)
        total += tamaño
        print(linea)
        print('archivo      :', elemento.name)
        print('permisos     :', estado.st_mode)
        print('modificado   :', modificado)        
        print('último acceso:', ult_acceso)
        print('tamaño (Kb)  :', round(tamaño/1024, 1))

print(linea)
print('Núm. archivos:', archivos)
print('Total (kb)   :', round(total/1024, 1))
