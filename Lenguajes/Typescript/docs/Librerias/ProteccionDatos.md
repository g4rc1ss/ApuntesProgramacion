# Proteccion de Datos

**Hashing:**

Puedes utilizar la biblioteca `crypto` para generar hashes criptográficos utilizando varios algoritmos, como MD5, SHA-256, SHA-512, entre otros. Aquí tienes un ejemplo de cómo generar un hash SHA-256:

```typescript
import { createHash } from 'crypto';

const textoOriginal = 'Este es un texto';
const algoritmo = 'sha256';

const hash = createHash(algoritmo)
  .update(textoOriginal)
  .digest('hex');

console.log('Hash SHA-256:', hash);
```

En este ejemplo, utilizamos la función `createHash()` para crear un objeto de hash con el algoritmo SHA-256. Luego, actualizamos el hash con el texto original utilizando el método `update()` y obtenemos el hash en formato hexadecimal utilizando el método `digest()`. El resultado se muestra en la consola.

**Cifrado y descifrado:**

La biblioteca `crypto` también te permite cifrar y descifrar datos utilizando algoritmos de cifrado simétricos o asimétricos. Aquí tienes un ejemplo de cifrado y descifrado utilizando el algoritmo AES:

```typescript
import { createCipheriv, createDecipheriv, randomBytes } from 'crypto';

const textoOriginal = 'Este es un texto';
const clave = randomBytes(32); // Convertir la clave a un Buffer
const algoritmo = 'aes-256-cbc';

const iv = randomBytes(16); // Vector de inicialización aleatorio

// Cifrado
const cipher = createCipheriv(algoritmo, clave, iv);
let textoCifrado = cipher.update(textoOriginal, 'utf8', 'hex');
textoCifrado += cipher.final('hex');

console.log('Texto cifrado:', textoCifrado);

// Descifrado
const decipher = createDecipheriv(algoritmo, clave, iv);
let textoDescifrado = decipher.update(textoCifrado, 'hex', 'utf8');
textoDescifrado += decipher.final('utf8');

console.log('Texto descifrado:', textoDescifrado);
```

En este ejemplo, utilizamos las funciones `createCipheriv()` y `createDecipheriv()` para crear objetos de cifrado y descifrado utilizando el algoritmo AES en modo CBC. Generamos un vector de inicialización aleatorio utilizando `randomBytes()`. Luego, ciframos el texto original utilizando el objeto de cifrado y desciframos el texto cifrado utilizando el objeto de descifrado. El resultado del texto cifrado y descifrado se muestra en la consola.

**Generación de números aleatorios:**

La biblioteca `crypto` también proporciona funciones para generar números aleatorios criptográficamente seguros. Aquí tienes un ejemplo de generación de un número aleatorio:

```typescript
import { randomBytes } from 'crypto';

const bytesAleatorios = randomBytes(8); // 8 bytes aleatorios

console.log('Bytes aleatorios:', bytesAleatorios.toString('hex'));
```

En este ejemplo, utilizamos la función `randomBytes()` para generar 8 bytes aleatorios. El resultado se muestra en la consola en formato hexadecimal.

**Consideraciones adicionales:**

Al utilizar la biblioteca `crypto` en TypeScript, ten en cuenta las siguientes consideraciones:

- Lee la documentación oficial de Node.js sobre la biblioteca `crypto` para comprender completamente los algoritmos, opciones y mejores prácticas de seguridad.
- Utiliza algoritmos criptográficos seguros y recomendados para tu caso de uso.
- Mantén tus claves y datos sensibles seguros y sigue las mejores prácticas de seguridad al manejarlos.
- Considera utilizar bibliotecas de alto nivel y probadas para escenarios criptográficos más complejos, como `bcrypt` para hash de contraseñas o `jsonwebtoken` para firmar y verificar tokens JWT.
