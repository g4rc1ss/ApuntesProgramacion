from django.http import HttpResponse
from django.template import loader

from _02_Backend.Actions.IndexAction import IndexAction


class IndexView(object):
    def Saludo(self):
        index = loader.get_template('Index.html')

        respuestaIndex = IndexAction().getIndex()

        response = index.render({
            "ListaPeliculas": respuestaIndex.getPeliculas(),
            "RandomFantasia": [aventura for aventura in respuestaIndex.getRandomPeliculas() if aventura.tipooperacionid.nombre == "Aventura"],
            "RandomAventura": [fantasia for fantasia in respuestaIndex.getRandomPeliculas() if fantasia.tipooperacionid.nombre == "Fantasia"]
        })

        return HttpResponse(response)
