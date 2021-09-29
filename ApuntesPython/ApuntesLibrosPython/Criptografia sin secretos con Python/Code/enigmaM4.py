#!/bin/python
# -*- coding: utf-8 -*-

# ENIGMA M4 - KRIEGSMARINE
# Octubre 2016
# David Arboledas
# Dominio Público

import re

LETRAS = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'

#################################################
###  Parámetros de configuración de Enigma M4 ###
#################################################

# Grundstellung
inicio = ('N','A','Q','L')

# Walzenlage
rotores = ('Beta',6,1,3)

# Umkehrwalze
reflector = 'b'

# Ringstellung
posicion_interna = ('Z','Z','D','G')

# Steckerverbindungen
clavijero = [('B','Q'),('C','R'),('D','I'),('E','J'),('K','W'),('M','T'),('O','S'),('P','X'),('U','Z'),('G','H')]

cableado_rotor ={1:'EKMFLGDQVZNTOWYHXUSPAIBRCJ',
                 2:'AJDKSIRUXBLHWTMCQGZNPYFVOE',
                 3:'BDFHJLCPRTXVZNYEIWGAKMUSQO',
                 4:'ESOVPZJAYQUIRHXLNFTGKDCMWB',
                 5:'VZBRGITYUPSDNHLXAWMJQOFECK',
                 6:'JPGVOUMFYQBENHZRDKASXLICTW',
                 7:'NZJHGRCXMYSWBOUFAIVLPEKQDT',
                 8:'FKQHTLXOCBJSPDZRAMEWNIUYGV',
            'Beta':'LEYJVCNIXWPBQMDRTAKZGFUHOS',
           'Gamma':'FSOKANUERHMBTIYCWLQPZXVGJD'}

cableado_inverso ={1: 'UWYGADFPVZBECKMTHXSLRINQOJ',
                   2: 'AJPCZWRLFBDKOTYUQGENHXMIVS',
                   3: 'TAGBPCSDQEUFVNZHYIXJWLRKOM',
                   4: 'HZWVARTNLGUPXQCEJMBSKDYOIF',
                   5: 'QCYLXWENFTZOSMVJUDKGIARPHB',
                   6: 'SKXQLHCNWARVGMEBJPTYFDZUIO',
                   7: 'QMGYVPEDRCWTIANUXFKZOSLHJB',
                   8: 'QJINSAYDVKBFRUHMCPLEWZTGXO',
              'Beta': 'RLFOBVUXHDSANGYKMPZQWEJICT',
             'Gamma': 'ELPZHAXJNYDRKFCTSIBMGWQVOU',}
  
cableado_reflector = {'b':'ENKQAUYWJICOPBLMDXZVFTHRGS',
                      'c':'RDOBJNTKVEHMLFCWZAXGYIPSUQ'}


def main():
    print("""\n**** Enigma M4  U- BOOT ****\n """)
    mensaje = input('Mensaje > ')
    texto = cifrar(mensaje)
    print('\n',texto)


inicio = list(inicio) # inicio se actualiza con cada caracter



# Las muescan indican dónde se produce el giro del siguiente rotor
# en el momento en que el anterior pasa por la muesca.
# Los rotores 6, 7 y 8 tienen dos

muesca = {1:('Q'), 2: ('E'), 3:('V'),4:('J'), 5: ('Z'),
          6: ('Z','M'),7: ('Z','M'),8: ('Z','M')}


def numero(car):
    # Devulve el número correspondiente a cada carácter
    car = car.upper()
    arr = {'A':0,'B':1,'C':2, 'D':3,'E':4, 'F':5, 'G':6, 'H':7, 'I':8, 'J':9, 'K':10, 'L':11, 'M':12,
           'N':13, 'O':14, 'P':15, 'Q':16, 'R':17, 'S':18,'T':19, 'U':20, 'V':21, 'W':22,'X':23,
           'Y':24, 'Z':25}
    return arr[car]
    

def sustituye(letra,alfabeto=LETRAS,veces=0):
        # sustituye una letra de acuerdo a la clave
        indice = (numero(letra)+veces)%26
        return alfabeto[indice]


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
        # El rotor Beta o Gamma, inicio[0], nunca se movía durante el proceso
        if inicio[2] in muesca[rotores[2]]:
            inicio[1] = sustituye(inicio[1],veces=1)
            inicio[2] = sustituye(inicio[2],veces=1)

        if inicio[3] in muesca[rotores[3]]:
            inicio[2] = sustituye(inicio[2],veces=1)
            
        inicio[3] = sustituye(inicio[3],veces=1)
     

def cifrar_caracter(letra):
       
        # Con cada letra los rotores avanzan
        rotor_avanza()  

        # Entrada al clavijero
        letra = aplicar_clavijero(letra)

        # Camino de ida de la señal    
        for i in [3,2,1,0]:
        
            veces = ord(inicio[i])-ord(posicion_interna[i])

            letra = rotor(letra,veces,cableado_rotor[rotores[i]])
        

        # Entrada y salida por el refletor    
        letra = refleja(letra) 

        # Camino de vuelta        
        for i in [0,1,2,3]: 
            veces = ord(inicio[i])-ord(posicion_interna[i])
            letra = rotor(letra,veces,cableado_inverso[rotores[i]])

        # Salida por el clavijero    
        letra = aplicar_clavijero(letra)
        
        return letra
                
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
