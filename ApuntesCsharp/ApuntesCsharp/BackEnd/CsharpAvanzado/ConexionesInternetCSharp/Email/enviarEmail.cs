using System;
using System.Net;
using System.Net.Mail;

namespace ConexionesInternetCSharp.Email {
    public class EnviarEmail {
        public void EnvioMail() {
            var servidorDeEnvio = "smtp.gmail.com";

            try {
                //Creas el mensaje indicando:
                //lo correos con OTP o doble factor de authertication no funcionan
                var mensaje = new MailMessage(
                    from: "jarchalark@gmail.com",// Emisor
                    to: "ga15asiergarcia@gmail.com",// Receptor
                    subject: "Prueba Envio Mensaje",// Asunto del mensaje
                    body: "Hola, es la prueba del envio de un mensaje por c# \n" +
                    "Un saludo, \n" +
                    "Asier Garcia"// Cuerpo del mensaje
                );

                //Enviamos el mensaje
                using (var cliente = new SmtpClient(servidorDeEnvio)) {
                    cliente.EnableSsl = true;
                    var cifradoAES = new AESHelper();
                    Console.WriteLine("Usuario y Contraseña");
                    var usuario = Console.ReadLine();
                    var contraseña = string.Empty;
                    byte[] contraseñaCifrada = null;

                    //Capuramos la contraseña de modo que no se vea en la consola
                    for (var stop = false; stop == false;) {
                        var ultimaKey = Console.ReadKey(true);
                        if (ultimaKey.Key == ConsoleKey.Backspace) {
                            try {
                                contraseña = contraseña.Remove((contraseña.Length) - 1);
                            } catch (Exception) {
                                Console.WriteLine("Todo borrado");
                            }
                        } else if (ultimaKey.Key != ConsoleKey.Enter) {
                            contraseña += ultimaKey.KeyChar;
                        } else {
                            //Encriptamos la contraseña y limpiamos el string con la original
                            contraseñaCifrada = cifradoAES.EncriptarTexto(contraseña);
                            contraseña = string.Empty;
                            stop = true;
                            Console.Write("\n");
                        }
                    }

                    cliente.Credentials = new NetworkCredential(
                        usuario,
                        cifradoAES.DesencriptarTexto(contraseñaCifrada, cifradoAES.Key, cifradoAES.IV)
                    );
                    cliente.Send(mensaje);
                }
                Console.WriteLine();
            } catch (Exception) {
                Console.WriteLine("Hay un error, revisa el fichero de LOG");
            }
            Console.ReadKey();
        }
    }
}
