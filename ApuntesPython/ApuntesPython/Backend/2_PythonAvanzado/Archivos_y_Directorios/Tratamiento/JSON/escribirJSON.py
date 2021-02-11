#-*- conding: utf-8 -*-

import json
import os

def escribir_datos(ruta):
    with open(ruta, 'w') as contenido:
        #Para adaptar bien el contenido al JSON tiene que ir primero en una lista que contenga dentro un diccionario
        diccionario = [{
            "Nombre" : "Asier",
            "Edad" : 20
        }]
        json.dump(diccionario, contenido)#guardamos el contenido en el archivo

    '''with open(ruta, 'r') as contenido2:
        cursos = json.load(contenido2)
        for curso in cursos:
            print(curso)'''

if __name__ == '__main__':
    ruta = os.path.dirname(os.path.abspath(__file__))+"/escribir.json"
    escribir_datos(ruta)