import shutil, os
from conversorMedidas import conversor
'''
    Para copiar o mover archivo, muchas veces tenemos que ser capaces de saber
    si tenemos espacio suficiente para hacerlo, aqui se detallan algunos metodos
    para hacerlo


    Obtener informacion del espacio de un disco

    La funcion disk_usage() devuelve informacion del disco donde se ensuentre
    la ruta indicada. Retorna una tupla con 3 valores:
        total, usado, libre
    ej:
        shutil.disk_usage(path)
'''

ruta = ruta = os.path.abspath(os.path.dirname(__file__))
datos = shutil.disk_usage(ruta)
print('Espacio total (bytes): ', conversor(datos.total))
print('Espacio usado (bytes): ', conversor(datos.used))
print('Espacio libre (bytes): ', conversor(datos.free))

'''
    La funcion chown() permite cambiar el usuario y/o grupo del archivo o
    directorio indicado en el argumento path
'''

archivo = ruta + "\\archivoPermisos.txt"

#Antes: -rw-rw-r-- 1 usuario 

try:
    shutil.chown(archivo, group="usuario")
    print("Se ha cambiado el propietario del archivo")
except:
    print("error")

'''
    La funcion which() permite obtener la ruta de acceso a un ejecutable
    (o None si hay acceso)
    ej:
        shutil.which(cmd, mode=os.F_OK | os.X_OK, path=None)

        mode: Permite determinar si un archivo existe y es ejecutable
        path: si no se especifica se usaran las variables de entorno path
'''

archivo = "python"
rutaWhich = shutil.which(archivo)
print(rutaWhich)
