#!/bin/python
# -*- coding: utf-8 -*-

# La cifra Vigenère
# David Arboledas Brihuega
# Dominio público

"""
  Este programa cifra/descifra mensajes mediante una
  cifra Vigenère, con clave para generar la tabla y
  contraseña para cifrar o descifrar, como describe
  en su obra de 1586. Usa una tabla recíproca de 26
  alfabetos que puede adaptarse a cualesquiera otros.
"""

import pyperclip

# ALFABETO = 'ABCDEFGHILMNOPQRSTUX'
ALFABETO = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
NUMERO = len(ALFABETO)  # Número de alfabetos
COL_CLAVE = list(ALFABETO)  # Columna de la clave

global alfabeto
alfabeto = [''] * NUMERO

def main():
    print('''Elige una de estas opciones:
\t1) Generar una tabla con o sin clave.
\t2) Cifrar un mensaje.
\t3) Descifrar un criptograma.''')
    opc = int(input('Opción > ' ))
    if opc == 1:  # Generar tabla
        clave = input('\nClave para la tabla (Enter para omitir) > ').upper()
        inicio = verificar_clave(clave)
        alfabeto = generar_tabla(inicio,True)
    
    if opc == 2:  # Cifrar
        clave = input('\nClave para la tabla (Enter para omitir) > ').upper()
        inicio = verificar_clave(clave)
        alfabeto = generar_tabla(inicio)
        mensaje = input('\nMensaje > ').upper()
        password = input ('Clave > ').upper()
        criptograma = cifrarMensaje(password, mensaje)
        print('\n',criptograma)
        pyperclip.copy(criptograma)
        
    if opc == 3:  # Descifrar
        clave = input('\nClave para la tabla (Enter para omitir) > ').upper()
        inicio = verificar_clave(clave)
        alfabeto = generar_tabla(inicio)
        criptograma = input('\nCriptograma > ').upper()
        password = input ('Clave > ').upper()
        texto = descifrarMensaje(password, criptograma).lower()
        print('\n',texto)
        pyperclip.copy(texto)

def verificar_clave(clave):
    if clave != '':
        inicio = alfabeto_inicial(quitar_duplicados(clave))
    else:
        inicio = ALFABETO
    return inicio


def quitar_duplicados(clave):  
    nueva_clave = ''
    for letra in clave:
        if letra not in nueva_clave:
            nueva_clave += letra
    clave = nueva_clave
    return clave


def alfabeto_inicial(clave):
    # Crea el alfabeto inicial de la tabla a partir de la clave
    nuevaClave = ''
    clave = clave.upper()
    alf_ini = list(ALFABETO)
    for i in range(len(clave)):
        if clave[i] not in nuevaClave:
            nuevaClave += clave[i]
            alf_ini.remove(clave[i])
    clave = nuevaClave + ''.join(alf_ini)
    return clave


def generar_tabla(clave, modo=False):
    alfabeto[0]= clave

    # Resto de alfabetos
    for i in range(1, NUMERO):
        cadena = ''
        for j in range (0, NUMERO):
            pos = (j + 1) % NUMERO
            cadena += alfabeto[i-1][pos]
        alfabeto[i] = cadena          
    if modo:        
        mostrar_tabla(alfabeto)
    return alfabeto


def mostrar_tabla(alfabeto):
    print(' ',' '.join(list(ALFABETO)).lower())
    for i in range(0, NUMERO):
        print(COL_CLAVE[i], end=' ')
        for j in range (0, NUMERO):
            print(alfabeto[i][j], end=' ')
            if j == NUMERO - 1:
                print()
    
    
def cifrarMensaje(clave, mensaje):
    return cifrar_descifrar(clave, mensaje, 'cifrar').upper()


def descifrarMensaje(clave, mensaje):
    return cifrar_descifrar(clave, mensaje, 'descifrar').lower()


def cifrar_descifrar(clave, mensaje, modo):
    clave = ''.join(clave.split())
    salida = ''
    indice_clave = 0
    for simbolo in mensaje:
        pos = ALFABETO.find(simbolo)
        if pos != -1:  # Si está en ALFABETO
            n = ALFABETO.find(clave[indice_clave])
            if modo == 'cifrar':
                salida += alfabeto[n][pos]
            else:  # Descifrar
                pos = alfabeto[n].find(simbolo)
                salida += ALFABETO[pos]
                
            indice_clave += 1
            if indice_clave == len(clave):
                indice_clave = 0
                
        else: # Si simbolo no está, se añade tal cual
           salida += simbolo
    return salida
        
    
if __name__ == '__main__':
    main()
