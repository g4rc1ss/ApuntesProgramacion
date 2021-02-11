import sqlite3
import os
import hashlib
from getpass import getpass
import sys

connection = sqlite3.connect(os.path.dirname(os.path.abspath(__file__))+"/usersPass.db")

def main():
    crearBBDD()
    menu()
    modo = str(input("Teclea una opcion\n>"))
    opciones(modo = modo)
    connection.commit()
    connection.close()
    exit(0)

def menu():
    print('''
        Menú

        1 -> Crear usuario\n
        2 -> Iniciar sesion\n
        99 -> Exit\n
        ''')

def opciones(modo=""):
    if modo.upper().strip() == '1':
        usuario, password = usuariosHashes()
        crearBBDD()
        crearUsuario(usuario, password)
    elif modo.upper().strip() == '2':
        usuario, password = usuariosHashes()
        verificarUsuario(usuario, password)
    elif modo.upper() == '99':
        exit(0)

def usuariosHashes():
    usuario = hashlib.sha512(str(input("Teclea el usuario: ")).encode()).hexdigest()
    password = hashlib.sha512(getpass("Teclea la contraseña: ").encode()).hexdigest()
    return usuario, password

def crearBBDD():
    cursor = connection.cursor()
    cursor.execute('''CREATE TABLE IF NOT EXISTS USUARIOS(
                        ID          INT     PRIMARY KEY     NOT NULL,
                        USUARIO     TEXT                    NOT NULL,
                        PASSWORD    TEXT                    NOT NULL)''')
    print("Tabla creada")

def crearUsuario(user, password):
    cursor = connection.cursor()
    cursor.execute("SELECT COUNT(ID) FROM USUARIOS")
    for count in cursor: id = count[0]
    values = (id, user, password)
    cursor.execute("INSERT INTO USUARIOS (ID, USUARIO, PASSWORD) VALUES(?, ?, ?)", values)
    print("Usuario y Contraseña creados")

def verificarUsuario(user, password):
    cursor = connection.cursor()
    
    cursor.execute("SELECT USUARIO, PASSWORD FROM USUARIOS WHERE USUARIO = ? AND PASSWORD = ?", (user, password))
    rows = cursor.fetchall()
    if len(rows) is not 0:
        print("ENHORABUENA HAS INCIADO SESION\n %s" % rows) 
    else:
        print("Inicio de sesion fallido, vuelva a intentarlo")

if __name__ == "__main__":
    main()
