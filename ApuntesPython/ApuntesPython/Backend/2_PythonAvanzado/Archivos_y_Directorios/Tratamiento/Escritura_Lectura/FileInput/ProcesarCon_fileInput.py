# -*- coding: utf-8 -*-

#ejemplos de fileInput sencillos, para algo de mas info:
#https://python-para-impacientes.blogspot.com/2016/06/fileinput-procesar-multiples-archivos.html
import fileinput
import sys, glob, os

'''
    El modulo fileinput consta de una clase y varias funciones para procesar datos de 
    varios archivos, incluidos como elementos de lista o argumentos de un script. Te permite
    leer y procesar todas las lineas de un conuntos de archivos como si se tratara de uno solo
    Tambien permite procesar multiples lineas de datos, reescribir archivos, obtener datos de 
    comprimidos, etc.

    con input() se recorren los archivos de una lista y se muestran todas sus lineas en la salida
    Tambien se antepone el numero de linea leida con lineno()
    ej:
        fileinput.input(files=None, mode="rwb")
'''
ruta = os.path.abspath(os.path.dirname(__file__))

cines = [
    f"{ruta}\\cine1.txt", f"{ruta}\\cine2.txt", f"{ruta}\\cine3.txt"
]

for linea in fileinput.input(cines):
    ln = str(fileinput.lineno())
    print(f"{ln} -->  {linea}")

'''
    La salida anterior tiene en su primera linea una cabecera que describe el contenido
    si solo interesan los datos se hara lo siguiente
'''
print("-"*40)
for linea in fileinput.input(cines):
    if not fileinput.isfirstline():
        sys.stdout.write(linea)

'''
    Procesar con funciones de control de fujo

    
    fileinput.filename():   Devuelve nombre del archivo que se está leyendo en un momento dado. 
                            Antes de leer la primera línea devuelve None.

    fileinput.fileno():     Devuelve número (descriptor) de archivo. Antes de leer la primera línea 
                            y con el proceso entre dos archivos devuelve -1.

    fileinput.lineno():     Devuelve número de línea leída del total de líneas de todos los archivos.
                            Antes de leer la primera línea devuelve 0 y después de la última línea, 
                            devuelve el número de dicha línea.

    fileinput.filelineno(): Devuelve el número de línea leída del archivo actual. Antes de leer la 
                            primera línea devuelve 0 y después de la última línea leída de un archivo,
                            devuelve el número de dicha línea.

    fileinput.isfirstline():Devuelve True si la línea leída es la primera y False si no lo es.

    fileinput.isstdin():    Devuelve True si la última línea se ha leído desde la entrada estándar
                            (sys.stdin), de lo contrario devuelve False.

    fileinput.nextfile():   Cierra el archivo actual y salta al siguiente archivo si fuera posible.
                            No se puede utilizar para omitir el primer archivo.

    fileinput.close():      Finaliza el proceso 
'''

for linea in fileinput.input(cines):    
    if not fileinput.isfirstline():
        ar = fileinput.filename()
        an = str(fileinput.fileno())
        al = str(fileinput.filelineno())
        nl = str(fileinput.lineno())        
        linea = linea.rstrip()
        print(ar, an, al, nl, linea)
        fileinput.nextfile()
    if fileinput.filename()== 'cine3.txt':
        fileinput.close()

'''
    CUando los nombres de archivos siguen un patron se puede usar glob para obtener
    la lista de archivos, como en el siguiente ejemplo:
'''

archivos = glob.glob(f"{ruta}\\cine*.txt")
archivos.sort()
for linea in fileinput.input(archivos):
    if not fileinput.isfirstline():
        linea = linea.rstrip()
        pais = linea.split(";")#para dividir cada linea en 3 partes equivalentes
        if pais[2] == "Colombia":
            print(linea)

'''
    Procesar reescribiendo lista de archivos en la salida
    
    El argumento inplace de la funcion input() con el valor en True permite reescribir
    los archivos de entrada. El contenido previo de cada archivo se puede salvar
    asignando la extension de los archivos de respaldo al argumento backup
    ej:
        fileinput.input(files=None, inplace=False, backup="", mode="r")
    En este ejemplo se trataran los ficheros de manera que se reescribiran, por tanto
    se creara un backup de ellos tmbn, para esto es buena idea usar archivo temporales
    creas un archivo temporal que sea un backup por si sale mal el proceso
'''

for linea in fileinput.input([f"{ruta}\\sala1.txt", f"{ruta}\\sala2.txt"], 
                             inplace=True, backup='.bck'):
    nl = str(fileinput.lineno()) 
    linea = nl + ": " + linea.rstrip('\n')
    print(linea)
