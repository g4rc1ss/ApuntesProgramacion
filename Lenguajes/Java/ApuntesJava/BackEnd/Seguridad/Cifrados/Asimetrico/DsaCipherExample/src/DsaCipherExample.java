package DsaCipherExample;

import DsaCipherExample.FirmadoDocumentos.FirmarDocumentos;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;

public class DsaCipherExample {
    public static void main(String[] args) throws IOException, NoSuchAlgorithmException {
        new ExportarClavesJava().exportarClaveDSA();
        new FirmarDocumentos().firmarDocumentosDSA();
    }
}
