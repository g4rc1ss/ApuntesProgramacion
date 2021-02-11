from _04_DatabaseModels.Tables.models import Directores
import time

class PropiedadDam(object):
    def __init__(self):
        super().__init__()

    def getLastPeliculas(self, numberOfPropertiesToTake: int, numberOfSkipProperties: int):
        # listaPeliculas = list(
        #     Peliculas.objects
        #     .all()
        #     .select_related('propiedaddetalleid')
        #     .order_by('propiedaddetalleid__modifieddate')
        #     [numberOfSkipProperties:numberOfPropertiesToTake]
        # )
        # return listaPeliculas
        pass

    def getRandomPeliculas(self, numberOfPropertiesToTake: int, tipoOperacion=""):
        # listaPeliculas = list(
        #     Peliculas.objects
        #     .filter(tipooperacionid__nombre=tipoOperacion)
        #     .select_related('propiedaddetalleid')
        #     .order_by('?')[:numberOfPropertiesToTake]
        # )
        # return listaPeliculas
        pass