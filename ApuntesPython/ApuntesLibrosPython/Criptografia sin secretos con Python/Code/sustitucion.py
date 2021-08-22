#!/bin/python
# -*- coding: utf-8 -*-

# Cifra de Sustitución

import random
import sys

from Code import pyperclip

LETRAS = r"""!¡"#$%&'()*+,-./0123456789:;<=>¿?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~"""

def main():
    print("""\nElije una opcion:
  1. Cifrar
  2. Descifrar
  3. Generar clave""")

    opcion = int(input('\nOpcion > '))

    # Menú de opciones
    if opcion == 1:
        modo = 'cifrado'
        mensaje = input('Mensaje > ')
        clave = claveAleatoria()
        comprobarClave(clave)
        texto = cifrarMensaje(clave, mensaje)
        
    elif opcion == 2:
        modo = 'descifrado'
        mensaje = input('Mensaje > ')
        clave = input('Clave >')
        comprobarClave(clave)
        texto = descifrarMensaje(clave, mensaje)

    elif opcion == 3: 
        clave = claveAleatoria()
        print('Clave: ', clave)
        sys.exit()

    # Impresión del texto llano o criptograma
    
    print('\nClave %s' % (clave))
    print('El mensaje %s es:' % (modo))
    print('  ',texto)
    pyperclip.copy(texto)
    print()
    print('El mensaje se ha copiado al portapapeles.')


def comprobarClave(clave):
    listaClave = list(clave)
    listaLetras = list(LETRAS)
    listaClave.sort()
    listaLetras.sort()
    if listaClave != listaLetras:
        print('Clave incorrecta.')
        sys.exit()


def cifrarMensaje(clave, mensaje):
    return mensajeCod(clave, mensaje, 'cifrar')


def descifrarMensaje(clave, mensaje):
    return mensajeCod(clave, mensaje, 'descifrar')


def mensajeCod(clave, mensaje, modo):
    texto = ''
    carsA = LETRAS
    carsB = clave
    if modo == 'descifrar':
        # Para descifrar es el mismo código que para cifrar.
        # Solo se intercambian clave y LETRAS.
        carsA, carsB = carsB, carsA

    # Se recorre uno a uno cada simbolo del mensaje
    for simbolo in mensaje:
        if simbolo in carsA:
            # cifra/descifra el simbolo
            Indice = carsA.find(simbolo)  
            texto += carsB[Indice]
        else:
            texto += simbolo

    return texto


def claveAleatoria():
    clave = list(LETRAS)
    random.shuffle(clave)
    return ''.join(clave)


if __name__ == '__main__':
    main()
