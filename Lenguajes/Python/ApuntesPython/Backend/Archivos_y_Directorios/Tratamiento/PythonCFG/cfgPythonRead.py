#-*- coding: utf-8 -*-

import configparser
import os

configuracion = configparser.ConfigParser()#instanciamos

configuracion.read(os.path.dirname(os.path.abspath(__file__))+"/configRead.cfg")#leemos el archivo cfg

seccionInstalacion = configuracion['INSTALACION']
directorio = seccionInstalacion['Directorio']
permiso = seccionInstalacion['Permisos']

#----------------------------------------------------------------#

seccionMiscelaneo = configuracion['MISCELANEO']
licencia = seccionMiscelaneo['Licencia']
usuario = seccionMiscelaneo['Usuario']

print('Este programa se instalara en: ', directorio, 'bajo la licencia: ', licencia,
      'con el usuario: ', usuario, ' y permisos: ', permiso)

#De esta manera le pasas al metodo get la seccion MISCELANEO y la clave Usuario, entonces leera el archivo
#y te devolvera el contenido
print('Esta es otra manera de obtener el nombre: ', configuracion.get('MISCELANEO', 'Usuario'))