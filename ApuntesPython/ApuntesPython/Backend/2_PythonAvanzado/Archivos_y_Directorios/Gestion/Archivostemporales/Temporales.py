import tempfile
import os

ruta = os.path.abspath(os.path.dirname(__file__))+"/Temp/"

'''
    Los archivos temporales existen porque a veces un programa requiere de guardar datos de manera persistente
    por el motivo que sea y python te permite crear estos archivos y tratarlos de esta manera

    las ventajas de esta libreria son:
        
        - Permite crear archivos y directorios temporales posibilitando el acceso a los directorios temporales
            que ofrecen los distintos sistemas operativos.

        - Crea automáticamente y con seguridad los nombres de los archivos y directorios temporales pudiéndose
            establecer un prefijo y/o un sufijo para definir dichos nombres, para favorecer con ello su localización
            y tratamiento.

        - Proporciona funciones que suprimen automáticamente los archivos y/o directorios temporales cuando ya
            no son necesarios. Estas funciones son TemporaryFile(), NamedTemporaryFile(), TemporaryDirectory()
            y SpooledTemporaryFile(). Además, para contar con mayor control sobre el borrado de los archivos y
            directorios temporales ofrece, alternativamente, las funciones mkstemp() y mkdtemp(), que requieren
            un borrado manual.
'''
#TemporaryFile()

'''
    Esta funcion crea un archivo temporal de forma segura y devuelve un objeto(sin nombre) para ser usado como espacio
    de almacenamiento y segun se cierre, se borrara de manera automatica

    tempfile.TemporaryFile(mode, buffering, enconding, newline, suffix, prefix, dir)

    mode:                           Modo de apertura del archivo, por defecto es "wb", pero lo puedes cambiar

    suffix y prefix:                Se usaran para indicar los nombres de los archivo temporales

    dir:                            Se indicara el directorio en el que se guardaran los archivos(por defecto es el temp
                                    del sistema)

    buffering, enconding, newline:  tienen el mismo uso que en "open()".
                                    Se establece la policita de almacenamiento del buffer
                                    Se establece la codificacion de caracteres
                                    y se fija como seran los saltos de linea
'''
temporal1 = tempfile.TemporaryFile(dir=ruta)
print(temporal1.name)

temporal1.write(b'Archivos temporales\ncon Python')#tiene que tener la b de binario

temporal1.seek(0)

lectura1 = temporal1.read()
print(lectura1)
temporal1.close()

#NamedTemporaryFile()
'''
    Esta funcion crea un archivo temporal al que le va a asignar un nombre automaticamente, tieniendo en cuenta
    en el caso de que se hayan utilizado

    tempfile.NamedTemporaryFile(mode='w+b', buffering=None, encoding=None, newline=None, 
                                suffix=None, prefix=None, dir=None, delete=True)
    
    delete:     Se especificara si no queremos que se borre el archivo temporal
'''

temporal2 = tempfile.NamedTemporaryFile(dir=ruta, delete=True)

print(temporal2.name)

temporal2.write(b'Hola')
temporal2.seek(0)
print(temporal2.read())
temporal2.close()

#SpooledTemporaryFile()

'''
    Se utiliza para crear ficheros temporales, pero este te hace almacenar un argumento "max_size" para
    establecer el tamaño maximo de memoria que usara el archivo.
    Cuando el limite sea superado o cuando sea llamado el metodo "fileno()" los datos se escribiran en disco

    tempfile.SpooledTemporaryFile(max_size=0, mode='w+b', buffering=None, encoding=None, newline=None,
                                    suffix=None, prefix=None, dir=None)
'''

temporal3 = tempfile.SpooledTemporaryFile(max_size=1024, dir=ruta)

for ciclo in range(0, 30):
    temporal3.write((b"*" * 50) + b"\n")
temporal3.seek(0)
print(temporal3.read().decode("utf-8"))
temporal3.close()

#TemporaryDirectory()
'''
    La funcion crea un directorio temporal cuyo nombre puede ser recuperado accediendo al atributo name
    al final acabara borrando el directorio y todo su contenido
    
        with tempfile.TemporaryDirectory() as dirTemporal:
            print('Directorio temporal', dirTemporal)
'''

tempDir = tempfile.TemporaryDirectory(dir=ruta)
temporal4 = tempfile.NamedTemporaryFile(dir=tempDir.name)

for ciclo in range(0, 50000):
    temporal4.write(b"=" * 20)
del temporal4
del tempDir
