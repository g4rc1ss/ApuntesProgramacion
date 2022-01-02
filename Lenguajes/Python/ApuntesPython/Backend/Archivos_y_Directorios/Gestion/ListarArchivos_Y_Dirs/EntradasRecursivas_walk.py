import os
from datetime import datetime

'''
    La funcion os.walk() se utiliza para leer recursivamente archivos y directorios partiendo
    del directorio indicado
    Las llamadas se reazlizan a os.scandir() para ganar velocidad y optimizacion
    ej:
        os.walk(top, topdown=True,onerror=None,followlinks=False) 

        top         : Ruta del directorio a leer y tratar
        topdown     : Con el valor True indica que la lecura se hace comenzando por el directorio de
                        menos profundidad y en False por el de mayor profundidad
        onerror     : Ignora los errores de "os.listdir()". es posible usar una funcion para la gestion
                        de errores
        followlinks : Por defecto False, indica que no se resuelven los enlaces simbolicos
    
    En cada lectura la funcion nos devuelve una tupla con la info:
        root: Directorio leido
        dirs: lista de directorios existentes en el directorio leido
        files: lista de archivos existentes en el directorio leido
'''

ruta_app = os.path.abspath(os.path.dirname(__file__))+"\\prueba"
total = 0
num_archivos = 0
formato = '%d-%m-%y %H:%M:%S'
linea = '-' * 60

for ruta, directorios, archivos in os.walk(ruta_app, topdown=True):
    print('\nruta       :', ruta) 
    for elemento in archivos:
        num_archivos += 1
        archivo = ruta + os.sep + elemento
        estado = os.stat(archivo)
        tamaño = estado.st_size
        ult_acceso = datetime.fromtimestamp(estado.st_atime)
        modificado = datetime.fromtimestamp(estado.st_mtime)
        ult_acceso = ult_acceso.strftime(formato)
        modificado = modificado.strftime(formato)
        total += tamaño
        print(linea)
        print('archivo      :', elemento)
        print('modificado   :', modificado)        
        print('último acceso:', ult_acceso)
        print('tamaño (Kb)  :', round(tamaño/1024, 1))

print(linea)
print('Núm. archivos:', num_archivos)
print('Total (kb)   :', round(total/1024, 1))
