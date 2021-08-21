import requests, os

ruta = os.path.abspath(os.path.dirname(__file__))+"/"

'''
    Simplemente usamos la libreria requests para descargar la imagen.
    La url apunta a la imagen directamente y este la descarga
'''
if not os.path.exists(f"{ruta}PythonImage.png"):
    url = "https://www.python.org/static/img/python-logo@2x.png"
    myfile = requests.get(url)
    open(f"{ruta}PythonImage.png", "wb").write(myfile.content)
    del url
    del myfile


'''
    Aqui esta direccion nos redirigue a otra donde se descarga el pdd,
    pasamos el parametro "allow_redirects=True" y con esto hacemos que
    despues de las redirecciones se descargue el archivo final
'''
if not os.path.exists(f"{ruta}guide.pdf"):
    url = "https://readthedocs.org/projects/python-guide/downloads/pdf/latest/"
    myfile = requests.get(url, allow_redirects=True)
    open(f"{ruta}guide.pdf", "wb").write(myfile.content)
    del url
    del myfile

'''
    Con esto indicamos que queremos descargar el archivo a trozos de 1024 de tamaño por trozo
'''
if not os.path.exists(f"{ruta}PythonBook.pdf"):
    url = 'https://www.cs.uky.edu/~keen/115/Haltermanpythonbook.pdf'
    myfile = requests.get(url, stream=True)
    with open(f"{ruta}PythonBook.pdf", "wb") as Pypdf:
        for chunk in myfile.iter_content(chunk_size=1024):
            if chunk:
                Pypdf.write(chunk)

'''
    h
'''
