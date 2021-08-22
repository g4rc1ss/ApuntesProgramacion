#!/bin/python
# -*- coding: utf-8 -*-

# Rompe la cifra Vigenère con el test de Kasiski


import itertools
import re

import Vigenere
import analisis
import pyperclip

from Code import detectarEspanol

LETRAS = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
MODO = False # Si es True, el programa no imprime los intentos
NUM_MAS_FREC_LETRAS = 4 # Número de letras probables por subclave
LONG_MAX_CLAVE = 16 # Tamaño máximo de clave
PATRON_LETRAS = re.compile('[^A-Z]')


def main():
    criptograma = input('Criptograma > ')
    #criptograma = """PKSYLRP CKHRMPI KVMJPKOU Y WF GKNPSY P CY OYPUK MGR PDZFCS. GRQUZYYUY S QMY KBUZEUF, RUJPL EEYTE ZTEJYGTFX YL PLJ WCLED UO WYVMFX. FMW CZQIPID UO FY PLSYL ZEUF DCCVCR, VUQ GZENCAMZEOM GRSLWULED, CK CLNFJDCAML, CK WPMDZC MMGTRV, FY VPMYFSGTFX S JE SLOFEE, WR LLSXLC BYNVPJSIL, TPIY NYQMZOH CP LDYL, QSY CYM NVZKKAMRTJDUQ HP XOLKMYRV, OLS OV VIQ QLJ BIRYYUYM W ZTMSXMW LCOAYXZJ XOLGL VCWPMEFC YL JLMYL BI WFC YVTWFDUBSD P VIQ SAISGGHZJ."""
    textoPlano = romperVigenere(criptograma)

    if textoPlano != None:
        print('Copiando texto plano al portapapeles:')
        print(textoPlano)
        pyperclip.copy(textoPlano)
    else:
        print('Imposible romper el criptograma.')


def distanciasSecuenciasRep(mensaje):
    # Recorre el criptograma para hallar secuencias de 3 a 5 letras que
    # se repitan en el mensaje. Devuelve un diccionario en el que las claves son
    # las secuencias y los valores listas con las distancias entre secuencias

    # Usa una expresión regular para eliminar los caracteres no alfabéticos
    mensaje = PATRON_LETRAS.sub('', mensaje.upper())

    # Compila una lista con las secuencias del mensaje
    secEspacios = {}  
    for longSec in range(3, 6):
        for secInicial in range(len(mensaje) - longSec + 1):
            # Halla qué secuencia es y la almacena en sec
            sec = mensaje[secInicial:secInicial + longSec]

            # Busca esta secuencia en el resto del mensaje
            for i in range(secInicial + longSec, len(mensaje) - longSec + 1):
                if mensaje[i:i + longSec] == sec:
                    # Encuentra una secuencia repetida.
                    if sec not in secEspacios:
                        secEspacios[sec] = [] # Inicia una lista en blanco

                    # Anexa la distancia entre las secuencias repetidas
                    secEspacios[sec].append(i - secInicial)
    return secEspacios


def divisoresPosibles(num):
    # Devuelve una lista con los divisores menores que LONG_MAX_CLAVE + 1
    # Por ejemplo, divisoresPosibles(104)
    # devuelve [8, 2, 4, 13]

    if num < 2:
        return [] # No interesan divisores menores que 2

    factores = [] 

    # Solo nos quedamos con los divisores <= LONG_MAX_CLAVE
    
    for i in range(2, LONG_MAX_CLAVE + 1): 
        if num % i == 0:
            factores.append(i)
    return list(set(factores))


def factoresMasComunes(secFactores):
    # Primero contamos cuántas veces aparece un factor en secFactores
    numFactores = {} # La clave es un divisor; el valor, cuánto se repite

    # Las claves de secFactores son secuencias; los valores listas de divisores
    # secFactores es un diccionario del tipo: {'SCG': [2, 3, 4, 6, 9, 138, 207],
    # 'HKX': [2, 3, 4, 6, ...], ...}
    for sec in secFactores:
        listaFactores = secFactores[sec]
        for factor in listaFactores:
            if factor not in numFactores:
                numFactores[factor] = 0
            numFactores[factor] += 1
			
    # Segundo, añadimos el divisor y las veces que aparece en una tupla y generamos
    # una lista con estas para poder ordenarlas
    divisoresYNum = [] 
    for factor in numFactores:
        # Formamos la lista de los factores
        if factor <= LONG_MAX_CLAVE:
            divisoresYNum.append( (factor, numFactores[factor]) )
    
    # Ordenamos la lista por la frecuencia de los factores
    divisoresYNum.sort(key=itemInicial, reverse=True)
    return divisoresYNum

def itemInicial(x):
    return x[1]

def testKasiski(criptograma):
    # Halla las secuencias de entre 3 y 5 letras que se repiten en
    # el criptograma. distSecRep tiene la forma:
    # {'ENG': [155], 'GTK': [239, 472, 321], ... }
    distSecRep = distanciasSecuenciasRep(criptograma)

    secFactores = {}
    for sec in distSecRep:
        secFactores[sec] = []
        for spacing in distSecRep[sec]:
            secFactores[sec].extend(divisoresPosibles(spacing))

    divisoresYNum = factoresMasComunes(secFactores)

    # Extraemos los factores de divisoresYNum y los
    # ponemos en posibleLonClave para usarlos después

    posibleLonClave = [] 
    for j in divisoresYNum:
        posibleLonClave.append(j[0])
    return posibleLonClave


def subCriptograma(n, longClave, mensaje):
    # Devuelve el N-ésimo subcirptograma del mensaje para cada longitud posible de clave.
    # Ej.  subCriptograma(1, 6, 'CAPITAN') devuelve 'CN'
    #      subCriptograma(2, 4, 'CAPITAN') devuelve 'AA'
   
    mensaje = PATRON_LETRAS.sub('', mensaje)

    i = n - 1
    letras = []
    while i < len(mensaje):
        letras.append(mensaje[i])
        i += longClave
    return ''.join(letras)


def probarConLongitudClave(criptograma, longMasProbable):
    # Halla las letras más probables en cada subclave 
    criptograma = criptograma.upper()
    # IFSubclaves es una lista con las letras más probables para cada subclave 
    # Tiene la forma [[('H', 5), ('L', 5),... donde los números son los IF
    IFSubclaves = [] 
    for j in range(1, longMasProbable + 1):
        subcriptograma = subCriptograma(j, longMasProbable, criptograma)
       
        # frecuencias es una lista de tuplas de la forma:
        # [(<letra>, <IF>), ... ]
        # La lista se ordena por el IF. Cuanto mayor es IF, mejor coincidencia
        frecuencias = []
        Vigenere.generar_tabla(Vigenere.ALFABETO)
        for claveProbable in LETRAS:
            textoPlano = Vigenere.descifrarMensaje(claveProbable, subcriptograma)
            letra_e_IF = (claveProbable, analisis.indice_frec_esp(textoPlano))
            frecuencias.append(letra_e_IF)
        # Ordenar por IF
        frecuencias.sort(key=itemInicial, reverse=True)
        IFSubclaves.append(frecuencias[:NUM_MAS_FREC_LETRAS])
    if not MODO:
        for i in range(len(IFSubclaves)):
            # usamos i + 1 para que la primera letra no sea la de índice 0
            print('Posibles letras para la subclave %s: ' % (i + 1), end='')
            for j in IFSubclaves[i]:
                print('%s ' % j[0], end='')
            print()
    

    # Prueba cada combinación posible para cada posición en la clave
    for indices in itertools.product(range(NUM_MAS_FREC_LETRAS), repeat=longMasProbable):
        # Crea una clave posible con las letras de IFSubclaves
        claveProbable = ''
        for i in range(longMasProbable):
            claveProbable += IFSubclaves[i][indices[i]][0]

        if not MODO:
            print('Probando con la clave: %s' % (claveProbable))
        
        textoPlano = Vigenere.descifrarMensaje(claveProbable, criptograma)

        if detectarEspanol.es_espanol(textoPlano)[0]:
            textoPlano = textoPlano.lower()

            # Comprueba con el usuario si se ha encontrado la clave
            print('Posible clave %s:' % (claveProbable))
            print(textoPlano[:200]) 
            print()
            print('Escribe F para acabar o pulsa Enter para continuar probando:')
            respuesta = input('> ')

            if respuesta.strip().upper().startswith('F'):
                return textoPlano
            else: print('Probando claves...')
    # Si no se encuentra la clave
    return None


def romperVigenere(criptograma):
    # Primero, necesitamos realizar el test de Kasiski para
    # hallar la longitud probable de clave
    posibleLonClave = testKasiski(criptograma)
    if not MODO:
        longClaveStr = ''
        for longClave in posibleLonClave:
            longClaveStr += '%s ' % (longClave)
        print('Las longitudes probables de clave son: ' + longClaveStr + '\n')
    else:
        print('Probando claves...')

    for longClave in posibleLonClave:
        if not MODO:
            print('Probando con un tamaño de clave %s (%s posibles claves)...' % (longClave, NUM_MAS_FREC_LETRAS ** longClave))
        textoPlano = probarConLongitudClave(criptograma, longClave)
        
        if textoPlano != None:
            break

    # Si no funciona Kasiski, se realiza fuerza bruta
    # para todas las longitudes de clave
    if textoPlano == None:
        if not MODO:
            print('Imposible romper el criptograma por Kasiski. Probando por fuerza bruta...')
        for longClave in range(1, LONG_MAX_CLAVE + 1):
            # No volvemos a probar las longitudes usadas en Kasiski
            if longClave not in posibleLonClave:
                if not MODO:
                    print('Probando con un tamaño de clave %s (%s posibles claves)...' % (longClave, NUM_MAS_FREC_LETRAS ** longClave))
                textoPlano = probarConLongitudClave(criptograma, longClave)
                if textoPlano != None:
                    break
    return textoPlano


if __name__ == '__main__':
    main()
