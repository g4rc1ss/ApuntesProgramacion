'''Funciones de geometría plana
   Para el cálculo del área de las siguientes figuras:
   
'''

from math import pi

def area_cuadrado(Lado):
    '''Función area_cuadrado: Calcula área de un cuadrado.
    area_cuadrado = Lado ** 2 '''
    return (Lado ** 2)

def area_rectangulo(Base, Altura):
    '''Función area_rectangulo: Calcula área de un rectángulo.
    area_rectangulo = Base * Altura '''
    return (Base * Altura)

def area_triangulo(Base, Altura):
    '''Función area_triangulo: Calcula área de un triángulo.
    area_triangulo = Base * Altura / 2 '''
    return (Base * Altura / 2)

def area_paralelogramo(Base, Altura):
    '''Función area_paralelogramo: Calcula área de un paralelogramo.
    area_paralelogramo = Base * Altura '''
    return (Base * Altura)

def area_trapecio(BaseMayor, BaseMenor, Altura):
    '''Función area_trapecio: Calcula área de un trapecio.
    area_trapecio = (BaseMayor + BaseMenor) * Altura / 2'''
    return (BaseMayor + BaseMenor) * Altura / 2
   
def area_circulo(Radio):
    '''Función area_circulo: Calcula área de un circulo.
    area_ciruculo = Pi * Radio ** 2 '''
    return (pi * Radio ** 2)
