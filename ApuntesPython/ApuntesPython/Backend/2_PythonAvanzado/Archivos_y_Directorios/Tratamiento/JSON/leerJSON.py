# -*- coding: utf-8 -*-
import json
import os

def cargar_datos(ruta):
    try:
        with open(ruta, 'r') as contenido:
            cursos = json.load(contenido)#leemos y lo pasamos a un diccionario
            for curso in cursos:
                print(curso['Nombre'])

            #print(cursos[0]['Nombre'])
    except:
        print(ruta)

if __name__ == '__main__':
    ruta = os.path.dirname(os.path.abspath(__file__))+"/leer.json"
    cargar_datos(ruta)
