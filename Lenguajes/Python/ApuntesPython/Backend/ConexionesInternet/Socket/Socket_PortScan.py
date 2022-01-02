import socket
import sys
import os

if len(sys.argv) != 4:#comprobacion de argumentos recibidos
    print("[!] Use: PortScan.py [IP_to_scan] [Initial_Port] [Final_Port]")
    import configparser
    configuracion = configparser.ConfigParser()
    configuracion.read(os.path.dirname(os.path.abspath(__file__))+"/portScan.cfg")

    IP = str(configuracion.get("DATOS_DEFECTO", "IP"))
    ip = int(configuracion.get("DATOS_DEFECTO", "initialPort"))
    fp = int(configuracion.get("DATOS_DEFECTO", "finalPort"))
else:
    IP = str(sys.argv[1])  # Direccion a escanear
    ip = int(sys.argv[2])  # initial port
    fp = int(sys.argv[3])  # final port

def connect(IP, port):#recibe la ip y el puerto
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM) #creamos la conexion
    '''(El método setdefaulttimeout() sirve para declarar cuantos segundos podemos
    esperar a que el servidor nos conteste. Esto es útil cuando no queremos esperar
    mucho por una conexión. SI te pones a pensar, esto es lo que usan en los videojuegos 
    para evitar tener a un jugador ocupando un espacio)'''
    socket.setdefaulttimeout(0.6)
    try:
        s.connect((IP, port))#mandamos peticion
        return (1)# 1 si esta abierto
    except:
        return (2)# 2 si esta cerrado


print("[*] Connecting to %s, scanning from %s to %s ..." % (IP, ip, fp))#mensaje que indica que se esta escaneando

for port in range(ip, fp + 1):#mientras port este entre esos rangos
    e = connect(IP, port)#llamamos al metodo que retornara el resultado de abierto o cerrado
    if e == 2:# si esta cerrado
        print("[-] %s closed." % port) #informamos que esta cerrado
    else:
        print("[+] %s open." % port) #informamos que esta abierto
