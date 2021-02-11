# coding: utf-8

    #Argumentos para python.

from argparse import ArgumentParser #importamos ArgumentParser

#prog='' -> se añade el nombre del programa
#description='' -> se añade una explicacion de como funciona
#usage -> modo de uso, pj: argumentos [options] [-f file]
parse = ArgumentParser(prog='Arguments', description='Descripcion')

'''
    añadimos un argumento mediante el obj parse y metodo add_argument
    -f, --file -> se indica que se ha de introducir esto como argumento y despues lo pedido(en este caso
        un archivo)
    
    help -> se añade  una descripcion del argumento
    
    required=True -> se ha de poner si o si el argumento
    
    dest='' -> el nombre que usara el programa para identificar el argumento
    
    action='store_true' -> se ejecuta la sentencia con el argumento obligatorio, no requiere de nada mas pj:
        -f requiere de un archivo, pero -p no porque le indicas que quieres leer el archivo que has indicado con -f
        por tanto con invocar -p sirve... es como cuando haces un ls -l, al poner -l ya sabe que quieres mostrar el
        resultado en forma de lista
'''
parse.add_argument('-f', '--file', help='Crear archivo', required=True, dest='archivo')
parse.add_argument('-p', '--print', help='printear el archivo', dest='printeo', action='store_true')

#pasamos todos los argumentos leidos al objeto args
args = parse.parse_args()

#identificamos el argumento o argumentos pasados y ejecutamos unas sentencias u otras
if not args.archivo:# si no se ha usado el argumento archivo(-f)
    exit(0)
else:#Si se ha usado el argumento archivo,:
    with open(args.archivo, 'w') as f:#abrimos el archivo pasado por el argumento como escritura y lo creamos
        f.write('Hola')#escribimos dentro del archivo
        print("Archivo creado")#indicamos que el archivo ha sido creado


if args.printeo:#si se ha puesto el argumento printeo(-p)
    print("p")#sabemos que ha entrado
    with open(args.archivo, 'r') as r:#abrimos el archivo de texto indicado en archivo(-f) como lectura
        for line in r:# un for para leer linea a linea
            print("linea: %s" %(line))#sacams las lineas del archivo, la escrita anteriormente