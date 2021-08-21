#!/bin/python
# -*- coding: utf-8 -*-

# Recupera la clave por fuerza bruta de una cifra César

ALFABETO = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'

# Almacena el criptograma  
criptograma  = input('Criptograma: ')

# Recorre una a una todas las claves (1-25)
for clave in range(1,len(ALFABETO)):
    
    # Almacena la cadena descifrada
    salida = ''
    for simbolo in criptograma:
        if simbolo in ALFABETO:
            pos = ALFABETO.find(simbolo)
            # Descifra el carácter
            pos = (pos - clave) % len(ALFABETO)
      
            # Añade el  símbolo descifraado a la cadena
            salida += ALFABETO[pos]
        
        # Si hay un espacio y otro carácter no alfabético
        # lo añade a la cadena sin tocar
        else:
            salida += simbolo

    # Imprime en pantalla el resultado completo
    print('Clave  %d: %s' % (clave, salida))



