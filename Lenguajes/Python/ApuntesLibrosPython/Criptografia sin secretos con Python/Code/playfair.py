#!/bin/python
# -*- coding: utf-8 -*-

# Cifra digrámica de Playfair
# David Arboledas Brihuega
# Dominio público

import re
import sys

from Code import pyperclip

LETRAS = 'ABCDEFGHIKLMNOPQRSTUVWXYZ'  # I = J


def main():
    print("""\nCifra Playfair.\n 
  1. Cifrar
  2. Descifrar""")

    opcion = int(input('\nOpcion > '))

    if opcion == 1:  # Cifrado
        mensaje, clave_a = datos()
        texto = cifrarMensaje(clave_a, mensaje)
        print('\n',texto)
        pyperclip.copy(texto)
                
    elif opcion == 2:  # Descifrado
        mensaje, clave_a = datos()
        texto = descifrarMensaje(clave_a, mensaje)
        print('\n', texto)
        pyperclip.copy(texto)


def datos():
    mensaje = input('\nMensaje > ')
    clave = input ('Clave > ')
    clave = re.sub('[^A-Z]','',clave.upper())  # solo A..Z
    clave = re.sub(r'[J]','I',clave)  #  J == I
    clave_a = alfabetoSustitucion(clave)
    matriz = mostrar_matriz(clave_a)
    return (mensaje.upper(), clave_a)

        
def alfabetoSustitucion(clave):
    # Crea el alfabeto de sustitución con la clave
    nuevaClave = ''
    clave = clave.upper()
    alfabeto = list(LETRAS)
    for i in range(len(clave)):
        if clave[i] not in nuevaClave:
            nuevaClave += clave[i]
            alfabeto.remove(clave[i])
    clave = nuevaClave + ''.join(alfabeto)
    return clave


def mostrar_matriz(clave):
    print('\nMatriz de sustitución: ')
    for i in range(0,5):
        for j in range(5*i,5*(1+i)):
            print(clave[j],' ', end='')
        print()


def cifrarMensaje(clave_a, mensaje):
    return cifrar_descifrar(clave_a, mensaje, 'cifrar').upper()


def descifrarMensaje(clave_a, mensaje):
    return cifrar_descifrar(clave_a, mensaje, 'descifrar').lower()


def cifrar_digrama(a,b,clave_a):
    return digrama(a, b, clave_a, 'cifrar')


def descifrar_digrama(a,b,clave_a):
    return digrama(a, b, clave_a, 'descifrar')


def digrama(a,b,clave, modo):
    if modo == 'cifrar':
        if a == b: b = 'X'
    else:
        if a == b:
            print('Existen dos letras iguales en un digrama.')
            sys.exit()
    fila_a,col_a = clave.index(a)//5 , clave.index(a)%5  # Coordenadas de a
    fila_b,col_b = clave.index(b)//5 , clave.index(b)%5  # Coordenadas de b
    
    if modo == 'cifrar':
        pos = 1
    elif modo == 'descifrar':
        pos = -1

    if fila_a == fila_b:
        return (clave[fila_a*5+(col_a+pos)%5] + clave[fila_b*5+(col_b+pos)%5])
    elif col_a == col_b:
        return (clave[((fila_a+pos)%5)*5+col_a] + clave[((fila_b+pos)%5)*5+col_b])
    else:
        return (clave[fila_a*5 + col_b] + clave[fila_b*5 + col_a])
    
              
def cifrar_descifrar(clave, mensaje, modo):
    mensaje = re.sub('[^A-Z]','',mensaje.upper())
    mensaje = re.sub(r'[J]','I',mensaje)  # cambiamos J por I
    if len(mensaje)%2 == 1: mensaje += 'X'
    salida = ''
    for c in range(0,len(mensaje),2):
        salida += digrama(mensaje[c],mensaje[c+1],clave,modo)
    return salida


if __name__ == "__main__":
	main()
