from _04_DatabaseModels.Tables.models import Directores
import time

class PropiedadDam(object):
    def __init__(self):
        super().__init__()

    def getLastDirectores(self, numberOfPropertiesToTake: int, numberOfSkipProperties: int):
        listaDirectores = list(
            Directores.objects
            .all()
            .select_related('propiedaddetalleid')
            .order_by('propiedaddetalleid__modifieddate')
            [numberOfSkipProperties:numberOfPropertiesToTake]
        )
        return listaDirectores

    def getRandomDirectores(self, numberOfPropertiesToTake: int, tipoOperacion=""):
        listaDirectores = list(
            Directores.objects
            .filter(tipooperacionid__nombre=tipoOperacion)
            .select_related('propiedaddetalleid')
            .order_by('?')[:numberOfPropertiesToTake]
        )
        return listaDirectores
