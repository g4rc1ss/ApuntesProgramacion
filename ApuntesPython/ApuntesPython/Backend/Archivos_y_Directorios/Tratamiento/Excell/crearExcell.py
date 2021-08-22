#http://www.decodigo.com/python-crear-un-archivo-de-excel-con-pandas
#pip install pandas
#pip install xlrd
import pandas as pd
from pandas import ExcelWriter
import os

df = pd.DataFrame({'Id': [1, 3, 2, 4],
                    'Nombre': ['Juan', 'Eva', 'Maria', 'Pablo'],
                    'Apellido': ['Mendez', 'Lopez', 'Tito', 'Hernandez']
                 })
df = df[['Id', 'Nombre', 'Apellido']]

writer = ExcelWriter(os.path.dirname(os.path.abspath(__file__))+"/ejemplo.xlsx")
df.to_excel(writer, 'Hoja de datos', index=False)
writer.save()