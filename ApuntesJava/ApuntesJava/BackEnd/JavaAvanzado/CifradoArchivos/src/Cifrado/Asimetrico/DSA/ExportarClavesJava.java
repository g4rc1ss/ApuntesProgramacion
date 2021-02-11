/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*Exportar a ficheros las claves privada y pública */
package Cifrado.Asimetrico.DSA;

import java.io.FileOutputStream;
import java.io.IOException;
import java.security.*;
import java.security.spec.PKCS8EncodedKeySpec;
import java.security.spec.X509EncodedKeySpec;

public class ExportarClavesJava {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException, NoSuchAlgorithmException {
        KeyPairGenerator keyGen = KeyPairGenerator.getInstance("DSA");
        // SE INICIALIZA EL GENERADOR DE CLAVES
        SecureRandom numero = SecureRandom.getInstance("SHA1PRNG");
        keyGen.initialize(1024, numero);
        // SE CREA EL PAR DE CLAVES PRIVADA Y PÚBLICA
        KeyPair par = keyGen.generateKeyPair();
        PrivateKey clavepriv = par.getPrivate();
        PublicKey clavepub = par.getPublic();
        PKCS8EncodedKeySpec pk8Spec = new PKCS8EncodedKeySpec(clavepriv.getEncoded());
        // Escribir a fichero binario la clave privada
        FileOutputStream outpriv = new FileOutputStream("ClaveDSA.privada");
        outpriv.write(pk8Spec.getEncoded());
        outpriv.close();
        X509EncodedKeySpec pkX509 = new X509EncodedKeySpec(clavepub.getEncoded());
        // Escribir a fichero binario la clave pública
        FileOutputStream outpub = new FileOutputStream("ClaveDSA.publica");
        outpub.write(pkX509.getEncoded());
        outpub.close();
    }

}
