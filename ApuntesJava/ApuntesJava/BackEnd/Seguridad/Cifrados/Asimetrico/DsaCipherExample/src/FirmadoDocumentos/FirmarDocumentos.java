package DsaCipherExample.FirmadoDocumentos;

/*Generación de claves pública y privada*/
/*Se genera la pareja de claves, Se firma un mensaje con firma privada y se verifica con clave pública*/
/**
 * @author
 */

import java.security.*;

public class FirmarDocumentos {
    public void firmarDocumentosDSA() {
        try {
            KeyPairGenerator keyGen = KeyPairGenerator.getInstance("DSA");
            // SE INICIALIZA EL GENERADOR DE CLAVES
            SecureRandom numero = SecureRandom.getInstance("SHA1PRNG");
            keyGen.initialize(1024, numero);
            // SE CREA EL PAR DE CLAVES PRIVADA Y PÚBLICA
            KeyPair par = keyGen.generateKeyPair();
            PrivateKey clavepriv = par.getPrivate();
            PublicKey clavepub = par.getPublic();
            // FIRMA CON CLAVE PRIVADA EL MENSAJE
            // AL OBJETO Signature SE LE SUMINISTRAN LOS DATOS A FIRMAR
            Signature dsa = Signature.getInstance("SHA1withDSA");
            dsa.initSign(clavepriv);
            String mensaje = "Este mensaje va a ser firmado";
            dsa.update(mensaje.getBytes());
            byte[] firma = dsa.sign(); // MENSAJE FIRMADO
            // EL RECEPTOR DEL MENSAJE
            // VERIFICA CON LA CLAVE PÚBLICA EL MENSAJE FIRMADO
            // AL OBJETO signature SE LE SUMINIST. LOS DATOS A VERIFICAR
            Signature verificadsa = Signature.getInstance("SHA1withDSA");
            verificadsa.initVerify(clavepub);
            verificadsa.update(mensaje.getBytes());
            boolean check = verificadsa.verify(firma);
            if (check)
                System.out.println("FIRMA VERIFICADA CON CLAVE PÚBLICA");
            else
                System.out.println("FIRMA NO VERIFICADA");
        } catch (NoSuchAlgorithmException e1) {
            e1.printStackTrace();
        } catch (InvalidKeyException e) {
            e.printStackTrace();
        } catch (SignatureException e) {
            e.printStackTrace();
        }
    }
}