import fnmatch, os

'''
    El modulo fnmatch cuenta con funciones que facilitan la seleccion de archivo
    y directorios que coinciden con un determinado patron de busqueda.
    Estas funciones on un buen complemento para os.listdir(), scandir o wakl
    ej:
        fnmatch.fnmatch(filename, pattern)

    Comodines:
    ?       Un caracter
    *       Uno o mas caracteres
    []      Caracteres permitidos(filtra sobre estos caracteres)
    [x-y]   Rango de caracteres permitidos
    Con recursive=True se puede usar
    ** que indica busqueda de archivos en subcarpetas

    Para que un sistema trate por igual unas mayusculas o minusculas hay que normalizarlo
    por ejemplo:
        fnmatch.fnmatch(archivo.upper(), '*.MD')
    
    La funcion fnmatchcase devuelve True si el nombre coincide con el patron indicado, mayus o minus
        fnmatch.fnmatchcase(filename, pattern)
    
    La funcion filter() devuelve una lista con los nombres que coincidan con el patron
        Es equivalente a [n for n in names if fnmatch(n, pattern)]
    ej:
        for archivo in fnmatch.filter(directorio, "glob*"):
            print(archivo)

    La funcion translate devuelve un patron de busqueada en expresion regular que se emplean
    con el modulo "re"

    ej:
        import fnmatch, re

        expresion_regular = fnmatch.translate('*.md')
        print('Expresión regular:', expresion_regular)
        objeto_re = re.compile(expresion_regular)
        if objeto_re.match('Nombre_de_fichero.md'):
            print('Nombre_de_fichero.md coincide con la expresión regular')
'''