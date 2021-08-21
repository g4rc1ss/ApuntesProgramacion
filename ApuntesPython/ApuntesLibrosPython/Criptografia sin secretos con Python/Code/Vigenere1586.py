#!/bin/python
# -*- coding: utf-8 -*-

# La primera cifra Vigenère
# David Arboledas Brihuega
# Dominio público

"""
  Este programa cifra/descifra mensajes mediante la
  primera cifra Vigenère tal y como fue presentada en
  1568 en la obra: "Traicté des Chiffres".
  Usa la tabla recíproca de 10 alfabetos con
  sus 20 letras latinas. El resultado también se
  muestra en su forma orifinaria.
"""

from Code import pyperclip

ENTRADA = ['AB','CD','EF','GH','IL','MN','OP','QR','ST','VX',]
ALFABETO = 'abcdefghilmnopqrstux'.upper()
NUMERO = len(ENTRADA)
NULAS = ['Y','Z']
GIRO = len(ALFABETO) // 2 - 1
MODO = False  # True muestra la tabla recíproca

global alfabeto
alfabeto = [''] * NUMERO

def main():
    
    alfabeto = generar_alfabetos('A')
    opc = input('¿Deseas cifrar o descifrar? (C/D): ' )
    
    if opc.strip().upper().startswith('C'):
        mensaje = input('\nIntroduce el mensaje: ').upper()
        mensaje = val(mensaje)
        clave = input ('Clave: ').upper()
        clave = validar(clave)
      
        criptograma = cifrarMensaje(clave, mensaje)
        print('\nEl criptograma es: ',criptograma)
        pyperclip.copy(criptograma)
        
    if opc.strip().upper().startswith('D'):
        criptograma = input('\nIntroduce el criptograma: ').upper()
        texto = borrar_nulas(criptograma)
        
        clave = input ('Clave: ').upper()
        clave = validar(clave)
        texto = descifrarMensaje(clave, texto)
        print('\nEl texto llano es: ',texto)
        pyperclip.copy(texto)


# Solo se usa al descifrar
# Elimina Y o Z e introduce espacios
def borrar_nulas(criptograma):
    cripto2 =''
    for simbolo in criptograma:
        if simbolo not in NULAS:
            cripto2 += simbolo   
        else:
            cripto2 += ' '
           
    return cripto2


# En la clave no puede haber ni J, ni U
# Si aparecen se cambian por I y V, respectivamente
def validar(clave):
    clave2=''
    for i in range (0,len(clave)):
        if clave[i] != 'U' and clave[i] != 'J':
            clave2 += clave[i]
        else:
            if clave[i] == 'U': clave2 += 'V'
            if clave[i] == 'J': clave2 += 'I'
    
    return clave2


# En el mensaje no puede haber ni J, ni V
# Si aparecen se cambian por I y U, respectivamente
def val(mensaje):
    mensaje2=''
    for i in range (0,len(mensaje)):
        if mensaje[i] != 'V' and mensaje[i] != 'J':
            mensaje2 += mensaje[i]
        else:
            if mensaje[i] == 'V': mensaje2 += 'U'
            if mensaje[i] == 'J': mensaje2 += 'I'
    
    return mensaje2


def generar_alfabetos(clave):
      
    # Generamos el primer alfabeto
    alf1_1 = clave
    alf1_2 = ''
    s_alf = [''] * 2 * NUMERO
   
    for i in ALFABETO:
        if i not in clave and len(alf1_1) <= GIRO:
            alf1_1 +=  i
    for j in ALFABETO:
        if j not in clave and j not in alf1_1:
            alf1_2 +=  j

    s_alf[0], s_alf[1] = alf1_1, alf1_2
    alfabeto[0]= s_alf[0]+ s_alf[1]
    
    # Resto de alfabetos       
    for k in range (2, 2 * NUMERO):  
        if k % 2 == 0:
            s_alf[k] = s_alf[0]
                    
        else:
            for i in range(0,len(s_alf[0])):   
                pos = (i + GIRO) % len(s_alf[0])
                s_alf[k] += s_alf[k-2][pos]
                
            alfabeto[(k-1)//2] = s_alf[0] + s_alf[k]
    if MODO: mostrar_tabla(s_alf)
    return alfabeto


def mostrar_tabla(s_alf):
    print('\n**** TABLA RECÍPROCA ****\n')

    for i in range(0,NUMERO):
        print(ENTRADA[i], end='')
        if len(ENTRADA[i])-len(ENTRADA[0]) == 0:
            print(' ',s_alf[0].lower())
        else:
            print(' '*2,s_alf[0].lower())

        espacios =len(ENTRADA[0]) + 2
        print(' '*espacios,end='')
        print(s_alf[2*i+1].lower())

    print('\n*************************\n')

def busqueda(clave): # devuelve el número de alfabeto
    for i in range(0,len(ENTRADA)):
        if clave[0] in ENTRADA[i]:
            return i

        
def cifrarMensaje(clave, mensaje):
    return cifrar_descifrar(clave, mensaje, 'cifrar').lower()


def descifrarMensaje(clave, mensaje):
    return cifrar_descifrar(clave, mensaje, 'descifrar').lower()


def cifrar_descifrar(clave, mensaje,modo):
    clave = ''.join(clave.split())
    palabras = mensaje.split()
    salida = ''
    indice_clave = 0
    if modo == 'cifrar' or modo == 'descifrar':

        for simbolo in mensaje:

            if simbolo in ALFABETO:
                n = busqueda(clave[indice_clave])
                pos = alfabeto[n].find(simbolo)
                pos = (pos + len(ALFABETO)//2)%len(ALFABETO)
                salida += alfabeto[n][pos]
                indice_clave += 1
                if indice_clave == len(clave):
                   indice_clave = 0
                   
            else:  # símbolo es un espacio u otro caracter o número
                if simbolo == ' ' and modo == 'cifrar':
                    salida += NULAS[indice_clave % 2]
                else: salida += simbolo
        return salida
    
        
if __name__ == '__main__':
    main()
