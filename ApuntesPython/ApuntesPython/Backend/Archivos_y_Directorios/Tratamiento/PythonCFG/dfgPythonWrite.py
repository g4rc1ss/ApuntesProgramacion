#-*- coding: utf-8 -*-

import configparser#libreria para escribir la configuracion
import os

configuracion = configparser.ConfigParser()#creamos la instancia

'''estos archivos van por la clasificacion, con eso quiero decir que
en este caso, LOGIN y LOGINDOS son una refierencia que van a tener dentro las variables como Nombre, Edad...
y estas variables tendran el dato, Asier, 20...'''
configuracion.add_section("LOGIN")
configuracion.add_section('LOGINDOS')
#con set añades el dato, en la seccion, variable y resultado.
configuracion.set("LOGIN", "Nombre", 'Asier')
configuracion.set("LOGINDOS", 'Nombre', 'Pedro')

with open(os.path.dirname(os.path.abspath(__file__))+"/configWrite.cfg", 'w') as f:
    configuracion.write(f)
