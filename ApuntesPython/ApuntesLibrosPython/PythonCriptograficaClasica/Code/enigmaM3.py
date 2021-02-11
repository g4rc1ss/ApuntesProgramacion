#!/bin/python
# -*- coding: utf-8 -*-

# ENIGMA M3
# Octubre 2016
# David Arboledas
# Dominio Público

import re

from Code import pyperclip

LETRAS = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'

#################################################
###  Parámetros de configuración de Enigma M3 ###
#################################################

# Grundstellung
inicio = ('A','A','A')

# Walzenlage
rotores = (1,2,3)

# Umkehrwalze
reflector = 'B'

# Ringstellung
posicion_interna = ('A','A','A')

# Steckerverbindungen
clavijero = [('Z','N'),('Y','O'),('Q','B'),('E','R'),('D','K'),('X','U'),('G','P'),('T','V'),('S','J'),('L','M')]

cableado_rotor =('EKMFLGDQVZNTOWYHXUSPAIBRCJ',
           'AJDKSIRUXBLHWTMCQGZNPYFVOE',
           'BDFHJLCPRTXVZNYEIWGAKMUSQO',
           'ESOVPZJAYQUIRHXLNFTGKDCMWB',
           'VZBRGITYUPSDNHLXAWMJQOFECK',
           'JPGVOUMFYQBENHZRDKASXLICTW',
           'NZJHGRCXMYSWBOUFAIVLPEKQDT',
           'FKQHTLXOCBJSPDZRAMEWNIUYGV')
  
cableado_reflector = ('EJMZALYXVBWFCRQUONTSPIKHGD',
                      'YRUHQSLDPXNGOKMIEBFZCWVJAT', 
                      'FVPJIAOYEDRZXWGCTKUQSBNMHL')


def main():
    print("""\n**** Enigma M3 ****\n 
  1. Cifrar
  2. Descifrar""")

    opcion = int(input('\nOpcion (1, 2)> '))
    if opcion == 1:  # Cifrado
        mensaje = input('Mensaje > ')
        texto = cifrar(mensaje)
        print('\n',texto)
        pyperclip.copy(texto)
                
    elif opcion == 2:  # Descifrado
        mensaje = input('Mensaje > ')
        texto = descifrar(mensaje)
        print('\n', texto)
        pyperclip.copy(texto)

 
def vuelta(cableado):  
    # Sigue el recorrido de vuelta de la señal
    # desde el reflector para un rotor

    salida = ''
    for i in LETRAS:
        salida += LETRAS[cableado.find(i)]
    return salida


def cableado_inverso():
    # Devuelve una tupla con el recorrido
    # inverso de los 8 rotores

    inverso=[]
    for i in range(len(cableado_rotor)):
        inverso.append(vuelta(cableado_rotor[i]))
    inverso = tuple(inverso)
    return inverso


inverso = cableado_inverso()
inicio = list(inicio) # inicio se actualiza con cada caracter
rotores = tuple([q-1 for q in rotores])
                
# Las muescan indican dónde se produce el giro del siguiente rotor
# en el momento en que el anterior pasa por la muesca.
# Los rotores 6, 7 y 8 tienen dos

muesca = (('Q',),('E',),('V',),('J',),('Z',),('Z','M'),('Z','M'),('Z','M'))


def numero(car):
    # Devulve el número correspondiente a cada carácter
    car = car.upper()
    arr = {'A':0,'B':1,'C':2, 'D':3,'E':4, 'F':5, 'G':6, 'H':7, 'I':8, 'J':9, 'K':10, 'L':11, 'M':12,
           'N':13, 'O':14, 'P':15, 'Q':16, 'R':17, 'S':18,'T':19, 'U':20, 'V':21, 'W':22,'X':23,
           'Y':24, 'Z':25}
    return arr[car]


reflector = numero(reflector)


def rotor(letra,veces,cableado_rotor):
        # letra - el carácter de entrada que se cifrará
        # veces - cuántas veces ha girado el rotor
        # cableado_rotor - cableado del rotor
        letra = sustituye(letra,cableado_rotor,veces)
        # Letra de salida por el rotor
        return sustituye(letra,veces=-veces) 


def refleja(letra):
        # Realiza la sustitución del reflector.
        # El reflector se representa por un entero 0-2
        return sustituye(letra,cableado_reflector[reflector])
        

def sustituye(letra,alfabeto=LETRAS,veces=0):
        # sustituye una letra de acuerdo a la clave
        indice = (numero(letra)+veces)%26
        return alfabeto[indice]


def aplicar_clavijero(letra):        
        for i in clavijero:
            if letra == i[0]: return i[1]
            if letra == i[1]: return i[0]
        return letra     


def rotor_avanza():
        # Los rotores mueven al siguiente rotor dependiendo de su posicion
        if inicio[1] in muesca[rotores[1]]:
            # Incrementa la posición 1 letra
            inicio[0] = sustituye(inicio[0],veces=1) 
            inicio[1] = sustituye(inicio[1],veces=1)

        if inicio[2] in muesca[rotores[2]]:
            inicio[1] = sustituye(inicio[1],veces=1)
            
        inicio[2] = sustituye(inicio[2],veces=1)
        

def cifrar_caracter(letra):
        # Con cada letra los rotores avanzan
        rotor_avanza()  

        # Entrada al clavijero
        letra = aplicar_clavijero(letra)

        # Camino de ida de la señal    
        for i in [2,1,0]: 
            veces = ord(inicio[i])-ord(posicion_interna[i])
            letra = rotor(letra,veces,cableado_rotor[rotores[i]])

        # Entrada y salida por el refletor    
        letra = refleja(letra) 

        # Camino de vuelta        
        for i in [0,1,2]: 
            veces = ord(inicio[i])-ord(posicion_interna[i])
            letra = rotor(letra,veces,inverso[rotores[i]])

        # Salida por el clavijero    
        letra = aplicar_clavijero(letra)
        
        return letra
    
                
def descifrar(texto):
        # cifrar y descifrar son la misma operación
        return cifrar(texto)
    
                
def cifrar(texto):  
        texto = eliminar_puntuacion(texto).upper()
        salida = ''
        for c in texto:
            if c.isalpha(): salida += cifrar_caracter(c)
            else: salida += c
        return salida
        
     
def eliminar_puntuacion(texto):
    return re.sub('[^A-Z]','',texto.upper())


if __name__ == "__main__":
	main()


'''
Entra clavijero  A
Sale clavijero  A
Rotor  3  Entra letra  A
Rotor  3  Sale letra  C
Rotor  2  Entra letra  C
Rotor  2  Sale letra  D
Rotor  1  Entra letra  D
Rotor  1  Sale letra  F
Entra reflector  F
Sale reflector  S
Rotor  1  Entra letra  S
Rotor  1  Sale letra  S
Rotor  2  Entra letra  S
Rotor  2  Sale letra  E
Rotor  3  Entra letra  E
Rotor  3  Sale letra  B
Entra clavijero  B
Sale clavijero  Q
'''
