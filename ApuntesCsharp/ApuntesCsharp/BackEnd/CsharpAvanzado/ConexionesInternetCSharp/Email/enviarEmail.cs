using System;
using System.Net;
using System.Net.Mail;

namespace ConexionesInternetCSharp.Email {
    public class EnviarEmail {
        public void EnvioMail() {
            var servidorDeEnvio = "smtp.gmail.com";
            try {
                //Enviamos el mensaje
                Console.WriteLine("Usuario y Contraseña");
                var usuario = Console.ReadLine();
                var contraseña = string.Empty;

                //Capuramos la contraseña de modo que no se vea en la consola
                for (var stop = false; stop == false;) {
                    var ultimaKey = Console.ReadKey(true);
                    if (ultimaKey.Key == ConsoleKey.Backspace) {
                        try {
                            contraseña = contraseña.Remove(contraseña.Length - 1);
                        } catch (Exception) {
                            Console.WriteLine("Todo borrado");
                        }
                    } else if (ultimaKey.Key != ConsoleKey.Enter) {
                        contraseña += ultimaKey.KeyChar;
                    } else {
                        //Encriptamos la contraseña y limpiamos el string con la original
                        var contraseñaCifrada = "";
                        stop = true;
                        Console.Write("\n");
                    }
                }

                //Creas el mensaje indicando:
                //lo correos con OTP o doble factor de authertication no funcionan
                Console.WriteLine("A quien quieres mandar el mensaje?");
                var mensaje = new MailMessage(
                    from: usuario,// Emisor
                    to: Console.ReadLine(),// Receptor
                    subject: "Prueba Envio Mensaje",// Asunto del mensaje
                    body: "Hola, es la prueba del envio de un mensaje por c# \n" +
                    "Un saludo, \n"// Cuerpo del mensaje
                );

                using (var cliente = new SmtpClient(servidorDeEnvio)) {
                    cliente.EnableSsl = true;
                    cliente.Credentials = new NetworkCredential(
                        usuario,
                        contraseña
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
