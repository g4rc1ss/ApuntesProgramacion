#!/bin/python
# -*- coding: utf-8 -*-

# Programa de fuerza bruta contra el algoritmo
# de transposición columnar simple

import pyperclip
from Code import transColumDescif

from Code import detectarEspanol


def main():
    print('Este programa realiza un ataque por fuerza bruta contra un criptograma \nobtenido por transposición columnar simple')
    criptograma = input('\nIntroduce el criptograma: ')
    criptograma = detectarEspanol.limpiar_texto(criptograma).upper()
    posible_mensaje = criptoanalisis(criptograma)
    
    if posible_mensaje == None:
        print('\nNo ha sido posible hallar un texto.')
    else:
        print('\nCopiando mensaje al portapapeles.')
        print(posible_mensaje)
        pyperclip.copy(posible_mensaje)


def  barra_progreso(limite):
    asteriscos = 0
    for numero in range(2, limite):
        if numero % (limite // 40) == 0:
            asteriscos += 1 # Longitud de la barra

    print ('     0%'+ " " * asteriscos+'100%')
    print ('      |'+ "-" * asteriscos+'|')
    print('Espere ', end='')


def criptoanalisis(criptograma):

    # En windows los programas Python se interrumpen con Ctrl + C
    # En linux o Mac se abortan con Ctrl + D
    print('\nPulsa Ctrl-C para abandonar\n')
    print('Probando claves\n')

    limite = len(criptograma)
    barra_progreso(limite)
    razones =[]
    textos = []
    claves=[]
    
    # Fuerza bruta, se prueban todas las claves
    for clave in range(2, limite):
        texto_descifrado = transColumDescif.descifrar(criptograma, clave)
        espanol, coef = detectarEspanol.es_espanol(texto_descifrado, 0.10)

        # Añadimos marcadores (*) a la barra  
        if clave % (limite // 40) == 0:
            print('*',end='')
            
        # Si el texto devuelto es español almacenamos
        # r_lex, el texto descifrado y la clave en sendas listas
        if  espanol:
            r_lex = coef
            textos.append(texto_descifrado)
            razones.append(r_lex)
            claves.append(clave)
        
    if razones == []:
        return None

    # Se selecciona el máximo de  r_lex (texto probable)
    maximo = razones.index(max(razones))
    solucion = textos[maximo]
    clave = claves[maximo]
    
    # Y permite comprobar al usuario la solución propuesta
    print()
    print('\nPosible clave: %s -> %s' % (clave, solucion[:100]))
    print('\nPulsa F para aceptar el resultado')
    respuesta = input('> ')
    if respuesta.strip().upper().startswith('F'):
        return solucion

    return None

    
if __name__ == '__main__':
    main()
