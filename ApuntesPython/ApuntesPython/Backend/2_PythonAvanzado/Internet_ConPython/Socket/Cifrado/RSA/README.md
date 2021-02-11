# Socket RSA

Como la creación de claves públicas y privadas, así como el hashing de la clave pública, necesitamos configurar el socket ahora. Para configurar el socket, debemos importar otro módulo con "importar socket" y conectar (para el cliente) o vincular (para el servidor) la dirección IP y el puerto con el socket que recibe del usuario.

----------Lado del cliente----------
```
server = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
host = raw_input("Server Address To Be Connected -> ")
port = int(input("Port of The Server -> "))
server.connect((host, port))
```
----------Lado del servidor---------
```
  try:
  #setting up socket
  server = socket.socket(socket.AF_INET,socket.SOCK_STREAM)     
  server.bind((host,port))
  server.listen(5)
  except BaseException: print "-----Check Server Address or Port-----"
  ```
``Socket.AF_INET, socket.SOCK_STREAM`` nos permitirá utilizar la función ``accept()`` y los aspectos básicos de los mensajes. En lugar de eso, también podemos usar ``socket.AF_INET, socket.SOCK_DGRAM``, pero esa vez tendremos que usar setblocking (valor).

Proceso de apretón de manos:

> (CLIENTE) La primera tarea es crear claves públicas y privadas. Para crear la clave privada y pública, tenemos que importar algunos módulos. Son: desde Crypto import Random y desde Crypto.PublicKey import RSA. Para crear las claves, tenemos que escribir algunas líneas simples de códigos:

```
random_generator = Random.new().read
key = RSA.generate(1024,random_generator) 
public = key.publickey().exportKey()
```
random_generator se deriva del módulo " desde Crypto import Random ". La clave se deriva de " from Crypto.PublicKey import RSA " que creará una clave privada, tamaño de 1024 generando caracteres aleatorios. Público está exportando clave pública desde clave privada generada anteriormente.

---
> (CLIENTE) Después de crear la clave pública y privada, debemos codificar la clave pública para enviarla al servidor mediante el hash SHA-1. Para usar el hash SHA-1 necesitamos importar otro módulo escribiendo "importar hashlib". Para codificar la clave pública, escribimos dos líneas de código:

```
  hash_object = hashlib.sha1(public) 
  hex_digest = hash_object.hexdigest()
```
Aquí hash_object y hex_digest es nuestra variable. Después de esto, el cliente enviará hex_digest y public al servidor y el Servidor los verificará comparando el hash obtenido del cliente y el nuevo hash de la clave pública. Si el nuevo hash y el hash del cliente coinciden, pasará al siguiente procedimiento. Como el público enviado desde el cliente está en forma de cadena, no podrá utilizarse como clave en el lado del servidor. Para evitar esto y convertir la clave pública de cadena en rsa clave pública, necesitamos escribir server_public_key = RSA.importKey(getpbk) , aquí getpbk es la clave pública del cliente.

---

> (SERVIDOR) El siguiente paso es crear una clave de sesión. Aquí, he usado el módulo "os" para crear una clave aleatoria "key = os.urandom (16)" que nos dará una clave de 16 bits y después de eso he cifrado esa clave en "AES.MODE_CTR" y la hash de nuevo con SHA-1:
```
#encrypt CTR MODE session key
en = AES.new(key_128,AES.MODE_CTR,counter = lambda:key_128)encrypto = en.encrypt(key_128)
#hashing sha1
en_object = hashlib.sha1(encrypto)
en_digest = en_object.hexdigest()
```
Así que el ``en_digest`` será nuestra clave de sesión.

---
> (SERVIDOR) Para la parte final del proceso de protocolo de enlace es cifrar la clave pública obtenida del cliente y la clave de sesión creada en el lado del servidor.
```
#encrypting session key and public key
E = server_public_key.encrypt(encrypto,16)
```
Después del cifrado, el servidor enviará la clave al cliente como una cadena.

---
> (CLIENTE) Después de obtener la cadena cifrada (pública y clave de sesión) del servidor, el cliente los descifra usando la clave privada que se creó anteriormente junto con la clave pública. Como el cifrado (público y clave de sesión) estaba en forma de cadena, ahora debemos recuperarlo como clave mediante el uso de eval (). Si se realiza el descifrado, el proceso de intercambio se completa también, ya que ambas partes confirman que están utilizando las mismas claves. Para descifrar:
```
en = eval(msg)
decrypt = key.decrypt(en)
# hashing sha1
en_object = hashlib.sha1(decrypt) en_digest = en_object.hexdiges()
 ```
He usado el SHA-1 aquí para que sea legible en la salida.

---
Proceso de comunicación:

Para el proceso de comunicación, tenemos que usar la clave de sesión de ambos lados como la CLAVE para el cifrado IDEA MODE_CTR. Ambos lados cifrarán y descifrarán mensajes con IDEA.MODE_CTR usando la clave de sesión.

>(Cifrado) Para el cifrado IDEA, necesitamos una clave de 16 bits de tamaño y contador, como debe ser reclamable. El contador es obligatorio en MODE_CTR. La clave de la sesión que ciframos y hash tiene ahora un tamaño de 40 que excederá la clave límite del cifrado IDEA. Por lo tanto, necesitamos reducir el tamaño de la clave de sesión. Para reducir, podemos usar la función normal python integrada en la cadena de función [valor: valor]. Donde el valor puede ser cualquier valor según la elección del usuario. En nuestro caso, he hecho "clave [: 16]" donde tomará de 0 a 16 valores de la clave. Esta conversión se puede hacer de muchas maneras, como la clave [1:17] o la clave [16:]. La siguiente parte es crear una nueva función de cifrado de IDEA escribiendo IDEA.new () que tomará 3 argumentos para su procesamiento. El primer argumento será CLAVE, el segundo será el modo del cifrado de IDEA (en nuestro caso, IDEA.MODE_CTR) y el tercer argumento será el contador = que es una función que se debe llamar. El contador = mantendrá un tamaño de cadena que será devuelto por la función. Para definir el contador =, debemos tener que usar unos valores razonables. En este caso, he usado el tamaño de la CLAVE definiendo lambda. En lugar de usar lambda, podríamos usar Counter.Util que genera un valor aleatorio para counter =. Para usar Counter.Util, necesitamos importar el módulo de contador desde crypto. Por lo tanto, el código será:

```
  ideaEncrypt = IDEA.new(key, IDEA.MODE_CTR, counter=lambda : key)
````

Una vez que definimos el "IdeaEncrypt" como nuestra variable de cifrado IDEA, podemos usar la función integrada de cifrado para cifrar cualquier mensaje.

```
eMsg = ideaEncrypt.encrypt(whole)
#converting the encrypted message to HEXADECIMAL to readable 
eMsg = eMsg.encode("hex").upper()
````

En este segmento de código, entero es el mensaje que se va a cifrar y eMsg es el mensaje cifrado. Después de cifrar el mensaje, lo he convertido en HEXADECIMAL para que sea legible y upper () es la función incorporada para hacer que los caracteres estén en mayúsculas. Después de eso, este mensaje cifrado se enviará a la estación opuesta para su descifrado.

---
> (Descifrado)
Para descifrar los mensajes cifrados, necesitaremos crear otra variable de cifrado utilizando los mismos argumentos y la misma clave, pero esta vez la variable descifrará los mensajes cifrados. El código para este mismo que la última vez. Sin embargo, antes de descifrar los mensajes, necesitamos decodificar el mensaje de hexadecimal porque en nuestra parte de cifrado, codificamos el mensaje cifrado en hexadecimal para que sea legible. Por lo tanto, todo el código será:

```
decoded = newmess.decode("hex")
ideaDecrypt = IDEA.new(key, IDEA.MODE_CTR, counter=lambda: key) 
dMsg = ideaDecrypt.decrypt(decoded)
```
Estos procesos se realizarán tanto en el servidor como en el lado del cliente para el cifrado y descifrado.

---
