class Persona(object):

    def __init__(self, edad, nombre):
        self.edad = edad
        self.nombre = nombre

    def setCambiarNombre(self, nombre):
        self.nombre = nombre

    def setCambiarEdad(self, edad):
        self.edad = edad

    def getNombre(self):
        return self.nombre

    def getEdad(self):
        return self.edad

class Cliente(Persona):

    def __init__(self,nombre,edad, cuentaBanco, dni):
        Persona.__init__(self,edad, nombre)
        self.cuentaBanco = cuentaBanco
        self.dni = dni

    def setCambiarCuenta(self, cuentaBanco):
        self.cuentaBanco = cuentaBanco

    def setCambiarDni(self, dni):
        self.dni = dni

    def getCuenta(self):
        return self.cuentaBanco

    def getDni(self):
        return self.dni

clienteBanco = Cliente("Asier",21,140006876637, "20232324y")

clienteBanco.setCambiarNombre("Asier Garcia Barrenengoa")

print ("")
print ("Nombre del cliente:\t\t\t\t" + clienteBanco.getNombre())
print ("Edad\t\t\t\t\t\t\t" + str(clienteBanco.getEdad()))
print ("Numero de cuenta Bancaria\t\t" + str(clienteBanco.getCuenta()))
print ("Dni del titular\t\t\t\t\t" + clienteBanco.getDni())
