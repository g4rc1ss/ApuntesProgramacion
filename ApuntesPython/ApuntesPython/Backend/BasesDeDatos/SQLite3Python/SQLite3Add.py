#-*- coding: utf-8 -*-
"""
Vamos a crear una base de datos en python con SQLite3 para poder almacenar datos etc y extraerlos mediante
consulas SQL.
"""

import sqlite3 #importamos el modulo
import os
'''una vez importado el modulo, conectamos con la base de datos, creandola si no existe,
o conectando simplemente'''

connection = sqlite3.connect(os.path.dirname(os.path.abspath(__file__))+"/database.db")
#Para que la base de datos se cargue solamente en memoria:
    #connection = sqlite3.connect(':memory:')

'''creamos un objeto del metodo cursor para poder realizar acciones con la base de datos, como eliminar
modificar, crear, consultas....'''
cursor = connection.cursor()

#creamos una tabla: 
cursor.execute('''CREATE TABLE EMPRESA(
                    ID          INT       PRIMARY KEY      NOT NULL,
                    NOMBRE      TEXT                       NOT NULL,
                    EDAD        INT                        NOT NULL,
                    DIRECCION   INT                        NOT NULL, 
                    SALARIO     REAL)''')

print("Tabla creada")

#Insertamos datos en una tabla
cursor.execute("INSERT INTO EMPRESA (ID, NOMBRE, EDAD, DIRECCION, SALARIO) VALUES (1, 'Pablo', 32, 'Montevideo', 20000.00)")

print("Datos insertados")

connection.commit()#Esta parte es practicamente obligatoria, sino no se guardaran los cambios en la base de datos

connection.close()#fundamental