import os, platform, logging

'''
    El modulo logging es muy util y se utiliza para crear un archivo en el que se van registrando
    eventos del programa para saber que pasa en cada momento, se suelen poner en los ty except para
    cuando salta una excepcion quedar registrada, muy utiles tmbn para debuggear etc
'''

fichero_log = os.path.abspath(os.path.dirname(__file__))+"\\test.log"
print(f"{'La ruta del fichero es: '+fichero_log if os.path.exists(fichero_log) else 'No existe el fichero' and logging.error('No existe el fichero')}")

logging.basicConfig(level=logging.DEBUG,
                    format='%(asctime)s : %(levelname)s : %(message)s',
                    filename=fichero_log,
                    filemode='w')
logging.debug("Comienza el programa")
logging.info("Peocesando con normalidad")
logging.warning("Advertencia")
logging.error("hay un error")