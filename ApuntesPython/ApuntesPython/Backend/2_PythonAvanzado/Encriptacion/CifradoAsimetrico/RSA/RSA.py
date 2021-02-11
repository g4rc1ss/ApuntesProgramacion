import Crypto
from Crypto.PublicKey import RSA
from Crypto import Random
from Crypto.Cipher import PKCS1_OAEP
import os

ruta = os.path.abspath(os.path.dirname(__file__))+"/"

#-------------------Escritura de claves--------------------------#
#Creamos una llave de 4096 bits y la exportamos en dos ficheros
#En uno ira la clave publica y en el otro la clave privada
key = RSA.generate(4096)
clavePublica = open(f"{ruta}my_rsa_public.pem", 'wb')
clavePublica.write(key.publickey().exportKey('PEM'))
clavePublica.close()

clavePrivada = open(f"{ruta}my_rsa_private.pem", 'wb')
clavePrivada.write(key.exportKey('PEM'))
clavePrivada.close()

#-------------------Lectura de claves--------------------------#
clavePublica = open(f"{ruta}my_rsa_public.pem", 'rb')
clavePrivada = open(f"{ruta}my_rsa_private.pem", 'rb')

#Importamos las claves de los ficheros en las variables correspondientes
keyPublica = RSA.importKey(clavePublica.read())
keyPrivada = RSA.importKey(clavePrivada.read())

#-------------------Cifrado del documento--------------------#
#Encripto el documento con la clave publica
encriptor = PKCS1_OAEP.new(keyPublica)
mensajeCifrado = encriptor.encrypt(b"dddddd")
print(mensajeCifrado)

#-------------------Descifrado del documento--------------------------#
#Descifro el documento con la clave privada
decryptor = PKCS1_OAEP.new(keyPrivada)
mensajeDescifrado = decryptor.decrypt(mensajeCifrado)
print(f"============================== \n {mensajeDescifrado}")