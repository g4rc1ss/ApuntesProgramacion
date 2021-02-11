class Producto(object):#siempre se hereda de object si no hay herencia
    """Ejemplo de una clase en Python
    jaja"""

    def __init__(self, producto, precio, unidades):#constructor
        self.producto = producto
        self.precio = precio
        self.unidades = unidades

    def __costo_total(self):#metodo private

        costo = self.precio * self.unidades
        return costo

    def nuevo_precio(self, precio):
        self.precio = precio
        
    def agrega(self, cantidad):
        self.unidades += cantidad
        
    def saca(self, cantidad):
        if cantidad <= self.unidades:
            self.unidades -= cantidad
        else:
            print ("No hay suficientes")
    def informe(self):
        print ("Producto:\t\t" + str(self.producto))
        print ("Precio:\t\t\t" + str(self.precio))
        print ("Unidades:\t\t" + str(self.unidades))
        print ("Precio Total:\t" + str(self.__costo_total()))

