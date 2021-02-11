#!/bin/python
# -*- coding: utf-8 -*-

# Análisis estadístico de criptogramas

from math import log10

#  Fletcher Pratt, Secret and Urgent: the Story of Codes and Ciphers Blue Ribbon Books, 1939, pp. 254-255.
frec_esp = {'A': 12.53, 'B': 1.42, 'C': 4.68, 'D': 5.86, 'E': 13.68, 'F': 0.69, 'G': 1.01, 'H': 0.70, 'I': 6.25, 'J': 0.44, 'K': 0.01, 'L': 4.97, 'M': 3.15, 'N': 6.71, 'O': 8.68, 'P': 2.51, 'Q': 0.88, 'R': 6.87, 'S': 7.98, 'T': 4.63, 'U': 3.93, 'V': 0.90, 'W': 0.02, 'X': 0.22, 'Y': 0.90, 'Z': 0.52}
AEO = 'EAOSRNIDLCTUMPBGVYQHFZJXWK'
LETRAS = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'


def contar_letras(mensaje):
    # Devuelve un diccionario con claves letras y valores
    # el número de veces que aparece cada una en el mensaje
    num_letras = {'A': 0, 'B': 0, 'C': 0, 'D': 0, 'E': 0, 'F': 0, 'G': 0, 'H': 0, 'I': 0, 'J': 0, 'K': 0, 'L': 0, 'M': 0, 'N': 0, 'O': 0, 'P': 0, 'Q': 0, 'R': 0, 'S': 0, 'T': 0, 'U': 0, 'V': 0, 'W': 0, 'X': 0, 'Y': 0, 'Z': 0}

    for letras in mensaje.upper():
        if letras in LETRAS:
            num_letras[letras] += 1

    return num_letras


def item_indice_0(x):
    return x[0]


def ordenar_frecuencias(mensaje):
    # Devuelve una cadena con las letras del alfabeto ordenadas
    # de mayor a menor frecuencia en mensaje.
    # Primero, obtiene un diccionario con la frecuencia de cada letra
    frec_letras = contar_letras(mensaje)
    
    # Segundo, construye un diccionario agrupando todas las letras
    # con la misma frecuencia en una misma lista
    frec_a_letras = {}
    for letras in LETRAS:
        if frec_letras[letras] not in frec_a_letras:
            frec_a_letras[frec_letras[letras]] = [letras]
        else:
            frec_a_letras[frec_letras[letras]].append(letras)
    
    # Tercero, pone cada lista de LETRAS en orden "AEO" inverso, y
    # las convierte en cadenas
    for freq in frec_a_letras:
        frec_a_letras[freq].sort(key=AEO.find, reverse=True)
        frec_a_letras[freq] = ''.join(frec_a_letras[freq])
    
    # Cuarto, convierte el diccionario frec_a_letras en una lista
    # de pares de tuplas  (frecuencia, letra) y las ordena
    pares_frec = list(frec_a_letras.items())
    pares_frec.sort(key=item_indice_0, reverse=True)
    
    # Por último, extrae todas las LETRAS
    orden_frec = []
    for freqPair in pares_frec:
        orden_frec.append(freqPair[1])
    return ''.join(orden_frec)
    

def indice_frec_esp(mensaje):
    # Devuelve el número de coincidencias que posee el mensaje
    # cuando se compara sus frecuencias con las del español.
 
    orden_frec = ordenar_frecuencias(mensaje)

    indice = 0
    # Halla cuántas letras, de las 6 más comunes, hay
    for mas_comun in AEO[:6]:
        if mas_comun in orden_frec[:6]:
            indice += 1
    # Halla cuántas letras, de las 6 menos frecuentes, hay.
    for menos_comun in AEO[-6:]:
        if menos_comun in orden_frec[-6:]:
            indice += 1

    return indice


def letras_tot(mensaje):
    fk = contar_letras(mensaje).values()
    N=0
    for num in fk:
        N += num
    return N, fk


def IC(mensaje):
    # Devuelve el índice de coincidencia de William Friendman
    # Para el castellano IC = 0,0775
    ind = 0
    N = letras_tot(mensaje)[0]
    fk = letras_tot(mensaje)[1]
    for num in fk:
        ind += num*(num-1)
    ind /= N * (N - 1)
    return  ind


def entropia(mensaje):
    # Devuelve la entropía de un mensaje
    # Para el castellano H = 4,04
    H = 0
    N = letras_tot(mensaje)[0]
    fk = letras_tot(mensaje)[1]
    for num in fk:
        if num != 0:
            H += num/N * (log10(num/N)/log10(2))
    return -H
    
    
