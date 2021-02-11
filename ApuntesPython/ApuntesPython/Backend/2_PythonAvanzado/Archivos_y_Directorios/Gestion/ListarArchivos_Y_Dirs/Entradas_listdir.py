import os
from datetime import datetime

ruta = os.path.abspath(os.path.dirname(__file__))+"\\prueba"

'''
    Con la funcion os.listdir() lo unico que obtenemos es una lista de archivos y directorios en la ruta
    indicada, solo muestra 1 nivel y la lista no esta ordenada, ni nada
'''

contenido = os.listdir(path=ruta)

total = 0
archivos = 0
formato = "%d-%m-%y %H:%M:%S"
linea = "-" * 40

for elemento in contenido:
    archivo = ruta + os.sep + elemento
    if os.path.isfile(archivo):
        archivos += 1
        estado = os.stat(archivo)#obtiene el estado del archivo(las propiedades)
        tamanio = estado.st_size#obtiene el tamaño del archivo

        #convertimos las propiedades de fecha a tipo datetime para tratarlos
        ult_acceso = datetime.fromtimestamp(estado.st_atime)
        modificado = datetime.fromtimestamp(estado.st_mtime)

        #damos formato a las fechas de tipo datetime
        ult_acceso = ult_acceso.strftime(formato)
        modificado = modificado.strftime(formato)

        total += tamanio
        print(linea)
        print(f"archivo      : {elemento}")
        print(f"modificado   : {modificado}")
        print(f"ultimo acceso: {ult_acceso}")
        print(f"tamaño  (Kb) : {round(tamanio/1024, 1)}")

print(linea)
print(f"Num. archivos: {archivos}")
print(f"Total (Kb)   : {round(total/1024, 1)}")

'''
    Metodos de la clase stat y explocacion resumida:

    st_size: tamaño en bytes.
    st_mode: tipo de archivo y bits de permisos.
    st_ino: número de inodo.
    st_dev: identificador del dispositivo.
    st_uid: identificador del usuario propietario.
    st_gid: identificador del grupo propietario.
    st_atime: fecha-hora del último acceso (en segundos).
    st_mtime: fecha-hora de la última modificación (en segundos).
    st_ctime: fecha-hora ultimo cambio (unix) o creación (win).
    st_atime_ns, st_mtime_ns y st_ctime_ns (idem. expresado en nanoseg).
    st_blocks: número de bloques de 512 bytes asignados.
    st_blksize: tamaño de bloque preferido por sistema.
    st_rdev: tipo de dispositivo si un dispositivo inode.
    st_flags: banderas definidas por usuario.
    st_gen: Número fichero generado.
    st_birthtime: tiempo de creación del archivo.
    st_rsize: tamaño real del archivo.
    st_creator: creador del archivo.
    st_type: tipo de archivo.
    st_file_attributes: atributos.

'''
