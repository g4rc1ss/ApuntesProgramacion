from django.http import HttpResponse
from django.template import loader

from _02_Backend.Actions.IndexAction import IndexAction


class IndexView(object):
    def Saludo(self):
        index = loader.get_template('Index.html')

        respuestaIndex = IndexAction().getIndex()

        response = index.render({
            "LastProperties": respuestaIndex.getLastProperties(),
            "RandomSaleProperties": [sale for sale in respuestaIndex.getRandomProperties() if sale.tipooperacionid.nombre == "Venta"],
            "RandomRentProperties": [rent for rent in respuestaIndex.getRandomProperties() if rent.tipooperacionid.nombre == "Alquiler"]
        })

        return HttpResponse(response)
