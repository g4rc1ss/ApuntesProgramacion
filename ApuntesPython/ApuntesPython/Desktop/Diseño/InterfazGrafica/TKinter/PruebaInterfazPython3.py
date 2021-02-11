# -*- coding: utf-8 -*-

import tkinter

# crea un objeto de la clase Tk
v = tkinter.Tk()
# título de la ventana
v.title('Ventana Tkinter')
# posición y tamaño
v.geometry('400x100+600+100')
# introducimos un widget
tkinter.Label(v, text='Hola Mundo!!!').pack()
# inicia el bucle de eventos
v.mainloop()