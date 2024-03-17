#!/bin/python
# -*- coding: utf-8 -*-

# Descifra la transposición columnar con palabra clave
#
# El programa descifra cualquier criptograma obtenido mediante 
# una palabra clave. De la clave, que solo puede contener letras, elimina
# los caracteres repetidos. Conserva en el texto plano
# todos los caracteres imprimibles, incluidos números,
# caracteres especiales y  signos de puntuacion.
 

import math

import transColumDescif

from Code import pyperclip


def main():
    print('''Este programa descifra un criptograma obtenido mediante
una transposición controlada por una palabra clave''')
    criptograma = input('\nIntroduce el criptograma: ')

    # Quitamos las letras duplicadas en la clave
    clave = eliminar_duplicados(input('y la palabra clave: '))

    criptograma = descifrar(criptograma, clave)
    texto_plano = transColumDescif.descifrar(criptograma, len(clave))

    # Imprime en pantalla el texto llano
    print('\nEl texto es:\n', texto_plano.lower().rstrip('x'))

    # Y lo copia al portapepeles
    pyperclip.copy(texto_plano)


def eliminar_duplicados(clave):
    clave = clave.upper()
    clave2 = clave[0] 
    for simbolo in clave:
            if simbolo not in clave2:
                    clave2 += simbolo
    return clave2


def ordenar(criptograma,clave):
    salida = []
    clave_ordenada = sorted(clave)
    for i in range(len(clave)):
        letra = clave[i]
        salida.append(criptograma[clave_ordenada.index(letra)])
    return ''.join(salida)


def descifrar(criptograma, clave):
    # Número de columnas de la matriz
    num_col = math.ceil(len(criptograma)/len(clave))
   
    texto=[]
    bloque = len(clave)
    elementos = num_col
    
    for i in range(0,len(criptograma)+1,elementos):
        texto.append(criptograma[i:i+elementos])
    
    criptograma = ordenar(texto,clave)
    
    return criptograma
    
# Si se ejecuta el programa (en vez de importarse)
# llama a la función main()
if __name__ == '__main__':
    main()
