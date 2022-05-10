using System;
using System.Net;
using System.Net.Mail;

namespace UseEmail.Email
{
    public class EnviarEmail
    {
        public void EnvioMail()
        {
            var servidorDeEnvio = "smtp.gmail.com";
            
            //Enviamos el mensaje
            Console.WriteLine("Usuario");
            var emisor = Console.ReadLine();
            
            Console.WriteLine("Constraseña");
            var contraseña = Console.ReadLine();


            Console.WriteLine("A quien quieres mandar el mensaje?");
            var receptor = Console.ReadLine();

            Console.WriteLine("Asunto");
            var asunto = Console.ReadLine();

            Console.WriteLine("Cuerpo");
            var cuerpo = Console.ReadLine();

            var mensaje = new MailMessage(
                from: emisor,
                to: receptor,
                subject: asunto
                body: cuerpo
            );

            using (var cliente = new SmtpClient(servidorDeEnvio))
            {
                cliente.EnableSsl = true;
                cliente.Credentials = new NetworkCredential(
                    emisor,
                    contraseña
                );
                cliente.Send(mensaje);
            }
            Console.WriteLine();
        }
    }
}
