
class IndexResponse(object):
    lastProperties : list
    randomProperties : list

    def __init__(self):
        super().__init__()

    def setLasProperties(self, properties : list):
        self.lastProperties = properties

    def setRandomProperties(self, properties : list):
        self.randomProperties = properties

    def getLastProperties(self):
        return self.lastProperties
    
    def getRandomProperties(self):
        return self.randomProperties
    