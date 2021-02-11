import zipfile


with zipfile.ZipFile('zip.zip', 'w') as f:

    print(f.namelist())#obtenemos una lista de nombres de los archivos que hay dentro del zip
    #f.extractall()#Extraemos todos los archivos dentro de zip, puede manda un parametro pwd, inficando la
        #contraseña de descifrado del archivo

    f.setpassword(b"5197-btda")
    #f.write('LibreriasComunes.zip')

with zipfile.ZipFile('zip.zip') as i:
    i.extractall()