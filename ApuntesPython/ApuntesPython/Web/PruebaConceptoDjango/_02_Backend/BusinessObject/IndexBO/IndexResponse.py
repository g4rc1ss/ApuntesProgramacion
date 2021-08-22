
class IndexResponse(object):
    listaPeliculas : list
    randomPeliculas : list

    def __init__(self):
        super().__init__()

    def setPeliculas(self, properties : list):
        self.listaPeliculas = properties

    def setRandomPeliculas(self, properties : list):
        self.randomPeliculas = properties

    def getPeliculas(self):
        return self.listaPeliculas
    
    def getRandomPeliculas(self):
        return self.randomPeliculas
    