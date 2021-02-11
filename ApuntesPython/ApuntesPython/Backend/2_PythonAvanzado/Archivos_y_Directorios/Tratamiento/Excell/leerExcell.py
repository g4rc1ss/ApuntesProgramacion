#http://www.decodigo.com/python-leer-archivo-de-excel-con-pandas
import pandas as pd
import os

archivo_excel = pd.read_excel(os.path.dirname(os.path.abspath(__file__))+"/ejemplo.xlsx")
print(archivo_excel.columns)

values = archivo_excel['Id'].values

print(values)

columnas = ['Id', 'Nombre', 'Apellido']
df_seleccionado = archivo_excel[columnas]

print(df_seleccionado)