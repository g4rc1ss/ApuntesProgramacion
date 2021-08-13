package Cifrado.Asimetrico.DSA;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;

public class DsaMain {
    public static void main(String[] args) throws IOException, NoSuchAlgorithmException {
        new ExportarClavesJava().exportarClaveDSA();
        new FirmarDocumentos().firmarDocumentosDSA();
    }
}
