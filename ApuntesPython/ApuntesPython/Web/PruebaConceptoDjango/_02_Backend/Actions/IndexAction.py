from _02_Backend.BusinessManager.IndexManager.IndexManager import IndexManager


class IndexAction(object):
    def __init__(self):
        super().__init__()

    def getIndex(self):
        result = IndexManager().getIndex()
        return result
