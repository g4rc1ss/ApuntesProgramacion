from threading import Thread
import concurrent.futures

from _03_DataAccessLayer.Dam.PropiedadDam import PropiedadDam
from _02_Backend.BusinessObject.IndexBO import IndexResponse
import base64

class IndexManager(object):
    def __init__(self):
        super().__init__()

    def getIndex(self):
        with concurrent.futures.ThreadPoolExecutor(max_workers=3) as executor:
            procesos = {
                'randomFantasia': executor.submit(PropiedadDam().getRandomPeliculas,
                                              3, "Fantasia"),
                'randomAventura': executor.submit(PropiedadDam().getRandomPeliculas,
                                     3, "Aventura"),
                'listaPeliculas': executor.submit(PropiedadDam().getPeliculas,
                                         3, 0),
            }

            randomFantasia = procesos['randomFantasia'].result()
            randomAventura = procesos['randomAventura'].result()
            listaPeliculas = procesos['listaPeliculas'].result()

            response = IndexResponse.IndexResponse()

            listaRandom = randomFantasia + randomAventura

            response.setRandomPeliculas(listaRandom)
            response.setPeliculas(listaPeliculas)
            return response
