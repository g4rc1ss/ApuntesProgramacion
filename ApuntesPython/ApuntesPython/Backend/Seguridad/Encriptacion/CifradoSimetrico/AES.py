from Crypto.Cipher import AES
from Crypto.Util import Padding
from hashlib import md5
from base64 import b64encode, b64decode
import sys, getpass

passphrase = "123456"
content = "Hola, este es el contenido que a saber si funciona"
print(passphrase, content)

mode = AES.MODE_CBC
bs = AES.block_size

# encrypting
key = md5(passphrase.encode('utf-8')).hexdigest().encode('utf-8')
body = Padding.pad(content.encode('utf-8'), bs)
iv = key[8:bs+8]

cipher = AES.new(key, mode, iv)
key = b64encode(key).decode('utf-8')
body = b64encode(cipher.encrypt(body)).decode('utf-8')
iv = b64encode(iv).decode('utf-8')

result = "%s.%s.%s" % (key, body, iv)
print(result)
del key

# decrypting
key = md5(getpass.getpass("Introduce tu contraseña").encode('utf-8')).hexdigest().encode('utf-8')
key, body, iv = result.split(".")
key = b64decode(key.encode('utf-8'))
body = b64decode(body.encode('utf-8'))
iv = b64decode(iv.encode('utf-8'))
cipher = AES.new(key, mode, iv)

body = Padding.unpad(cipher.decrypt(body), bs).decode('utf-8')
print(body)