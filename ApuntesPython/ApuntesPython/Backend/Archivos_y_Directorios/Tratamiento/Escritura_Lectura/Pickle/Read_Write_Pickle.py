import pickle
import os

'''
    Pickle se usa para escribir cualquier tipo de objeto, no solo str()
    en el ejemplo se va a escribir una lista(array) y un diccionario
'''

lista = ["Perl", "Python", "Ruby"]

with open(os.path.abspath(os.path.dirname(__file__))+"/lista.txt", "wb") as archivo:
    pickle.dump(lista, archivo)#le pasamos el objeto(la lista) y la ubicacion del archivo
    archivo.close()
del lista#borramos la lista creada de memoria

with open(os.path.abspath(os.path.dirname(__file__))+"/lista.txt", "rb") as archivo:
    lista = pickle.load(archivo)
print(lista)
del lista

#----------------------------------------------------------------------#
diccionario = {"nombre":"asier", "apel1":"garcia", "apel2":"barrenengoa", "edad":21}

with open(os.path.abspath(os.path.dirname(__file__))+"/diccionario.txt", "wb") as archivo:
    pickle.dump(diccionario, archivo)
    archivo.close()
del diccionario

with open(os.path.abspath(os.path.dirname(__file__))+"/diccionario.txt", "rb") as archivo:
    diccionario = pickle.load(archivo)
print(diccionario)
del diccionario
