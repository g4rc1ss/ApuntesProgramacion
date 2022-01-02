#!/bin/python
# -*- coding: utf-8 -*-

# Módulo criptomat
# Dominio público

def mcd(a, b):
    # Devuelve el MCD de dos números a y b mediante
    # el algoritmo de Euclides
    while a != 0:
        a, b = b % a, a
    return b


def invMod(a, m):
    # Devuelve el inverso modular de a mod m, que es el
    # número x tal que  a * x mod m = 1

    if mcd(a, m) != 1:
        return None # a y m no son coprimos. No existe el inverso

    # Cálculo mediante el algoritmo extendido de Euclides:
    u1, u2, u3 = 1, 0, a
    v1, v2, v3 = 0, 1, m
    
    while v3 != 0:
        q = u3 // v3  
        v1, v2, v3, u1, u2, u3 = (u1 - q * v1), (u2 - q * v2), (u3 - q * v3), v1, v2, v3
    return u1 % m
