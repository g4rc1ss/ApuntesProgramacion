import os
from wget import download

ruta = os.path.abspath(os.path.dirname(__file__))+"/"

if not os.path.exists(f"{ruta}PythonLogo.png"):
    url = "https://www.python.org/static/img/python-logo@2x.png"
    download(url, out=f"{ruta}PythonLogo.png")
    del url
