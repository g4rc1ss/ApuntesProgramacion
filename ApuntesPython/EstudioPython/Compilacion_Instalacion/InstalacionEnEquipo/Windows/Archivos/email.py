#-*- coding: utf-8 -*-

import smtplib, ssl, getpass, logging, os, sys


#--------CONFIG LOGS-------------#
def crearLogs():
    fichero_log = f"{os.path.abspath(os.path.dirname(__file__))}\\"
    if not os.path.exists(f"{fichero_log}informe.log"):
        fichero_log = f"{fichero_log}informe.log"
    else:
        for i in range(1, 100):
            if not os.path.exists(f"{fichero_log}informe{i}.log"):
                fichero_log = f"{fichero_log}informe{i}.log"
                break
    logging.basicConfig(
        level=logging.DEBUG,
        format='%(asctime)s : %(levelname)s : %(message)s',
        filename=fichero_log,
        filemode='w'
    )
#--------FIN CONFIG LOGS---------#

def iniciarSesionCorreo():
    context = ssl.create_default_context()

    with smtplib.SMTP_SSL("smtp.gmail.com", context=context) as server:
        try:    
            server.login(
                user=str(input("Introduce tu correo\n")),
                password=str(getpass.getpass("Introduce tu contraseña\n"))
            )
            os.system("cls" if "win" in sys.platform else "reset")
            server.sendmail(
                str(input("introduce tu direccion de correo(origen): " )),
                str(input("introduce la direccion de correo(destino): ")),
                str(input("introduce el mensaje: "))
            )
        except Exception as e:
            print("error")
            logging.error("autenticacion fallida")
            
if __name__ == "__main__":
    crearLogs()
    iniciarSesionCorreo()