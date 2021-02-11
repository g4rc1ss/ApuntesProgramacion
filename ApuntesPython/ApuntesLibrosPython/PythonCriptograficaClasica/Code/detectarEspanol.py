#!/bin/python
# -*- coding: utf-8 -*-

# Módulo para detectar si una cadena está en español

# Para usarlo, escribe este código:
#   import detectarEspanol
#   detectarEspanol.es_espanol(cadena)  # devuelve True o False
# Debe haber un fichero diccionario.txt en el mismo directorio
# con todas las palabras del español, una por línea.
# Puedes descargarlo de www.davidarboledas.es/python/diccionario.txt

LETRAS_MAYUSCULAS = 'ABCDEFGHIJKLMNÑOPQRSTUVWXYZ'
LETRAS = LETRAS_MAYUSCULAS + LETRAS_MAYUSCULAS.lower()
LETRAS_Y_ESPACIOS = LETRAS + ' \t\n'

def leer_diccionario():
    archivo = open('diccionario.txt')
    palabras_espanol = {}
    for palabra in archivo.read().split('\n'):
        palabras_espanol[palabra] = None
    archivo.close()
    return palabras_espanol


PALABRAS_ESPANOL = leer_diccionario()

def porcentaje_palabras(mensaje):
    mensaje = mensaje.upper()
    letras =[]
    for simbolo in mensaje:
        if simbolo in LETRAS_Y_ESPACIOS:
            letras.append(simbolo)
    mensaje= ''.join(letras)
    
    posibles_palabras = mensaje.split()
    
    if posibles_palabras == []:
        return 0.0 # No hay ninguna palabra

    encontradas = 0
    for palabra in posibles_palabras:
        if palabra in PALABRAS_ESPANOL:
            encontradas += 1
    return float(encontradas) / len(posibles_palabras)


def limpiar_texto(mensaje):
    letras =[]
    for simbolo in mensaje:
        if simbolo in LETRAS:
            letras.append(simbolo)
    return ''.join(letras)


def es_espanol(mensaje, r_lexica=0.50):
    # Por defecto, se considera que el mensaje tiene sentido
    # en castellano si Rlex >= 0,50
    mensaje = limpiar_texto(mensaje).upper()
    longitud = len(mensaje)
    texto = ''
    for palabra in PALABRAS_ESPANOL:
        if mensaje.find(palabra) != -1:
            texto += palabra
    try:
        coef = len(texto)/longitud
    except ZeroDivisionError as err:
        return (False, 0)
    
    if coef >= r_lexica:
        return True, coef
    else:
        return False, coef

