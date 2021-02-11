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
                'randomSale': executor.submit(PropiedadDam().getRandomProperties,
                                              3, "Venta"),
                'randomRent': executor.submit(PropiedadDam().getRandomProperties,
                                     3, "Alquiler"),
                'lastProperties': executor.submit(PropiedadDam().getLastProperties,
                                         3, 0),
            }

            randomSaleProperties = procesos['randomSale'].result()
            randomRentProperties = procesos['randomRent'].result()
            lastProperties = procesos['lastProperties'].result()

            response = IndexResponse.IndexResponse()

            listaRandom = []
            for random in randomSaleProperties + randomRentProperties:
                random.preciopropiedad = round(random.preciopropiedad, 2)
                random.imagenid.img = base64.b64encode(random.imagenid.img).decode()
                listaRandom.append(random)

            listaLast = []
            for last in lastProperties:
                last.preciopropiedad = round(last.preciopropiedad, 2)
                last.imagenid.img = base64.b64encode(last.imagenid.img).decode()
                listaLast.append(last)

            response.setRandomProperties(listaRandom)
            response.setLasProperties(listaLast)
            return response
