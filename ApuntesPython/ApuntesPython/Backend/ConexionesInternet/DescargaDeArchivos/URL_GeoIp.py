from urllib.request import urlopen
import sys
from socket import getaddrinfo
from contextlib import closing
import json
import os


diccionario = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n",
            "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" ]

def main():
    if "win" in sys.platform:
        os.system("cls")
    else:
        os.system("reset")

    if len(sys.argv) > 1:
        ip = str(sys.argv[1])
        if [ip for x in ip if x == ":"]:
            localizar(ip)
        elif [ip for letra in diccionario for x in ip if letra.lower() == x.lower()]:
            result = getaddrinfo(ip, None)
            ip = [i for i in result[0][4] if i != 0]
            for i in ip:
                localizar(i)
        else:
            localizar(ip)
    else:
        localizar()

def localizar(ip=""):
    try:
        with closing(urlopen(url=f"https://geoip-db.com/json/{ip}")) as response:
            localizacion = json.loads(response.read())
            print(f"""
                    Direccion ip: {localizacion['IPv4']}
                    Nombre del pais: {localizacion['country_name']}
                    Nombre de la comunidad: {localizacion['state']}
                    Nombre de la ciudad: {localizacion['city']}
                    Latitud {localizacion['latitude']}
                    Longitud {localizacion['longitude']}
                    -----------------------------------------------
                    """)
    except:
        pass

if __name__ == "__main__":
    main()
    