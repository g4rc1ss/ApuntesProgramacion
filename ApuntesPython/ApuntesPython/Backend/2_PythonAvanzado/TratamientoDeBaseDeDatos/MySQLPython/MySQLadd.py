# coding: utf-8
#pip install mysql

import mysql
from mysql.connector import errorcode

try:
    #Conectamos con la base de datos MySQL
    cnx = mysql.connector.connect(user='asier', password=f'{input("Teclea la pass")}', host='127.0.0.1', database='prueba')

    cursor = cnx.cursor()#creamos el objeto para trabajar con la bd

    cursor.execute("select * from prueba.prueba")#hacemos una consulta

    for (id, nombre) in cursor:#Leemos el resultado de la consulta
        print("id ", id)
        print("nombre ", nombre)

except mysql.connector.Error as err:
    if err.errno == errorcode.ER_ACCESS_DENIED_ERROR:
        print("Algo pasa con el usuario o contraseña")
    elif err.errno == errorcode.ER_BAD_DB_ERROR:
        print("No existe la base de datos")
    else:
        print(err)


else:
    #Cerramos la conexion
    print("Conexion cerrada")
    cnx.close()
