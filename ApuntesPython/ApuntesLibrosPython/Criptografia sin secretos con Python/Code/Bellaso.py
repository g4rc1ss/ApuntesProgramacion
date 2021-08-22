#!/bin/python
# -*- coding: utf-8 -*-

# La cifra Bellaso
# David Arboledas Brihuega
# Dominio público

"""
  Este programa cifra/descifra mensajes mediante una
  cifra Bellaso con clave tal y como fue presentada en
  1564 en la obra: "Il vero modo di scrivere in cifra".
  Usa una tabla recíproca de 5 alfabetos adaptados
  a las 26 letras del alfabeto latino.
"""

from Code import pyperclip

#ALFABETO = 'ABCDEFGHILMNOPQRSTUX'
ALFABETO = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
GIRO = len(ALFABETO) // 2 - 1
NUMERO = 26  # Número de alfabetos
global entrada
global alfabeto
alfabeto = [''] * NUMERO
entrada = [''] * NUMERO

def main():
    clave = input('Clave para los alfabetos: ').upper()
    clave = quitar_duplicados(clave)
    entrada, alfabeto = generar_alfabetos(clave)
    opc = input('¿Deseas cifrar o descifrar un texto? (c/d): ' )
    
    if opc.strip().upper().startswith('C'):
        mensaje = input('\nIntroduce el mensaje: ').upper()
        password = input ('Clave: ').upper()
        criptograma = cifrarMensaje(password, mensaje)
        print('\nEl criptograma es: ',criptograma)
        pyperclip.copy(criptograma)
        
    if opc.strip().upper().startswith('D'):
        criptograma = input('\nIntroduce el criptograma: ').upper()
        password = input ('Clave: ').upper()
        texto = descifrarMensaje(password, criptograma).lower()
        print('\nEl texto llano es: ',texto)
        pyperclip.copy(texto)


def quitar_duplicados(clave):  
    nueva_clave = ''
    for letra in clave:
        if letra not in nueva_clave:
            nueva_clave += letra
    clave = nueva_clave
    return clave


def generar_alfabetos(clave):
    # Definimos cómo se coloca la clave en los
    # alfabetos
    clave1_1 = ''
    clave1_2 = ''
    longitud = len(clave)
    
    if len(clave) % 2 == 0:  # si clave es par 
        for j in range(0,longitud // 2):
            clave1_1 += clave[j]
        for j in range(longitud // 2,longitud):
            clave1_2 += clave[j]
         
    else:  # clave es impar
        limite = (longitud + 1) // 2
        for j in range(0, limite):
            clave1_1 += clave[j]
        for j in range(limite,longitud):
            clave1_2 += clave[j]

    # Generamos el primer alfabeto
    alf1_1 = clave1_1
    alf1_2 = clave1_2
    s_alf = [''] * 2 * NUMERO
   
    for i in ALFABETO:
        if i not in clave and len(alf1_1) <= GIRO:
            alf1_1 +=  i
    for j in ALFABETO:
        if j not in clave and j not in alf1_1:
            alf1_2 +=  j

    s_alf[0], s_alf[1] = alf1_1, alf1_2
    alfabeto[0]= s_alf[0]+ s_alf[1]
    
    # Entradas de los alfabetos
    for k in range(0,NUMERO):
        for i in range(k, len(alfabeto[0]),NUMERO):
            entrada[k] += alfabeto[0][i]

    # Resto de alfabetos       
    for k in range (2, 2 * NUMERO):  
        if k % 2 == 0:
            s_alf[k] = s_alf[0]
                    
        else:
            for i in range(0,len(s_alf[0])):   
                pos = (i + GIRO) % len(s_alf[0])
                s_alf[k] += s_alf[k-2][pos]
                
            alfabeto[(k-1)//2] = s_alf[0] + s_alf[k]
    mostrar_tabla(entrada,s_alf)
    return(entrada,alfabeto)


def mostrar_tabla(entrada, s_alf):
    print('\n**** TABLA RECÍPROCA ****\n')

    for i in range(0,NUMERO):
        print(entrada[i], end='')
        if len(entrada[i])-len(entrada[0]) == 0:
            print(' ',s_alf[0].lower())
        else:
            print(' '*2,s_alf[0].lower())

        espacios =len(entrada[0]) + 2
        print(' '*espacios,end='')
        print(s_alf[2*i+1].lower())

    print('\n*************************\n')
    
      
def busqueda(clave): # devuelve el número de alfabeto
    for i in range(0,len(entrada)):
        if clave[0] in entrada[i]:
            return i

        
def cifrarMensaje(clave, mensaje):
    return cifrar_descifrar(clave, mensaje, 'cifrar').upper()


def descifrarMensaje(clave, mensaje):
    return cifrar_descifrar(clave, mensaje, 'descifrar').lower()


def cifrar_descifrar(clave, mensaje,modo):
    clave = ''.join(clave.split())
    palabras = mensaje.split()
    salida = ''
    if modo == 'cifrar' or modo == 'descifrar':
        for i in range(0,len(palabras)):
            n = busqueda(clave[i%len(clave)])
            for j in range(0,len(palabras[i])):
                ind = (n+j)%len(entrada)
                pos = alfabeto[ind].find(palabras[i][j])
                if pos == -1: # No se encuentra el símbolo
                    salida += palabras[i][j]
                else:
                    pos = (pos + len(ALFABETO)//2)%len(ALFABETO)
                    salida += alfabeto[ind][pos]
            salida += ' '
        return salida
    
    
if __name__ == '__main__':
    main()
