# Almacenamiento Seguro de Datos Sensibles
Evita almacenar datos sensibles, como contraseñas o información financiera, en archivos de texto sin encriptar o en bases de datos sin medidas de seguridad. Utiliza soluciones como bóvedas de claves o servicios de administración de secretos para almacenar datos confidenciales.

# Encriptación de Datos
La encriptación convierte los datos en una forma ilegible para cualquiera que no tenga la clave para descifrarlos. Java proporciona librerías criptográficas para implementar encriptación.

```java
import javax.crypto.Cipher;
import javax.crypto.KeyGenerator;
import javax.crypto.SecretKey;
import java.security.NoSuchAlgorithmException;

public class EncriptacionEjemplo {
    public static void main(String[] args) throws Exception {
        // Generar una clave secreta
        SecretKey claveSecreta = generarClaveSecreta();

        // Encriptar
        String mensajeOriginal = "Este es un mensaje secreto";
        byte[] mensajeEncriptado = encriptar(mensajeOriginal, claveSecreta);

        // Desencriptar
        String mensajeDesencriptado = desencriptar(mensajeEncriptado, claveSecreta);
        System.out.println("Mensaje Desencriptado: " + mensajeDesencriptado);
    }

    private static SecretKey generarClaveSecreta() throws NoSuchAlgorithmException {
        KeyGenerator keyGenerator = KeyGenerator.getInstance("AES");
        return keyGenerator.generateKey();
    }

    private static byte[] encriptar(String mensaje, SecretKey clave) throws Exception {
        Cipher cipher = Cipher.getInstance("AES");
        cipher.init(Cipher.ENCRYPT_MODE, clave);
        return cipher.doFinal(mensaje.getBytes());
    }

    private static String desencriptar(byte[] mensajeEncriptado, SecretKey clave) throws Exception {
        Cipher cipher = Cipher.getInstance("AES");
        cipher.init(Cipher.DECRYPT_MODE, clave);
        byte[] mensajeDesencriptadoBytes = cipher.doFinal(mensajeEncriptado);
        return new String(mensajeDesencriptadoBytes);
    }
}
```

# Manejo Seguro de Contraseñas
Evita almacenar contraseñas en texto claro y utiliza algoritmos de hashing seguros junto con técnicas como "salting" para proteger las contraseñas.

```java
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

public class HashingContraseñas {
    public static void main(String[] args) throws NoSuchAlgorithmException {
        String contraseña = "miContraseña";

        // Generar un salt aleatorio
        byte[] salt = generarSalt();

        // Hashear la contraseña con salt
        String contraseñaHasheada = hashearContraseña(contraseña, salt);
        System.out.println("Contraseña Hasheada: " + contraseñaHasheada);
    }

    private static byte[] generarSalt() {
        // Implementar la generación de salt de manera segura
        return new byte[16];
    }

    private static String hashearContraseña(String contraseña, byte[] salt) throws NoSuchAlgorithmException {
        MessageDigest digest = MessageDigest.getInstance("SHA-256");
        digest.update(salt);
        byte[] hash = digest.digest(contraseña.getBytes());

        // Convertir el hash a una representación legible
        StringBuilder hexHash = new StringBuilder();
        for (byte b : hash) {
            hexHash.append(String.format("%02x", b));
        }
        return hexHash.toString();
    }
}
```

# Validación y Sanitización de Datos de Entrada
Evita la inyección de código malicioso (como SQL Injection o Cross-Site Scripting) validando y sanitizando adecuadamente los datos de entrada recibidos de usuarios o fuentes externas.

```java
public class ValidacionDatosEntrada {
    public static void main(String[] args) {
        String entradaUsuario = "<script>alert('Ataque XSS');</script>";
        String entradaSanitizada = sanitizarEntrada(entradaUsuario);
        System.out.println("Entrada sanitizada: " + entradaSanitizada);
    }

    private static String sanitizarEntrada(String entrada) {
        // Implementar lógica de sanitización adecuada
        return entrada.replaceAll("<", "&lt;")
                      .replaceAll(">", "&gt;");
    }
}
```
