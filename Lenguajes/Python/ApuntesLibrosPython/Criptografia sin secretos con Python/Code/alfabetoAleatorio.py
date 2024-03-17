#!/bin/python
# -*- coding: utf-8 -*-

import random

def alf_aleatorio():
    alfabeto = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
    salida =''
    for i in range(len(alfabeto)):
          letra = random.choice(alfabeto)
          salida += letra
          alfabeto = alfabeto.replace(letra,'')
    
    return salida
    
    

salida = alf_aleatorio()
print(salida)
