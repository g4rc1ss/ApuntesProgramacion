from _04_DatabaseModels.Tables.models import Peliculas
import time

class PropiedadDam(object):
    def __init__(self):
        super().__init__()

    def getPeliculas(self, numberOfDirectoresToTake: int, numberOfSkipDirectores: int):
        listaPeliculas = list(
            Peliculas.objects
            .all()
            .select_related('directorid')
        )
        return listaPeliculas

    def getRandomPeliculas(self, numberOfDirectoresToTake: int, genero=""):
        listaPeliculas = list(
            Peliculas.objects
            .filter(genero=genero)
            .select_related('directorid')
            .order_by('?')[:numberOfDirectoresToTake]
        )
        return listaPeliculas