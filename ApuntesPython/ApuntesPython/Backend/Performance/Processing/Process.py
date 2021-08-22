import multiprocessing
import time


def functionToExecuteWithParameter(parameter):
    print(parameter)


def functionToExecuteWithoutParameter():
    print("Ejecutando sin parametros")


def functionToSelectTheFunction(i):
    time.sleep(1)
    print("Programa" + str(i))
    for x in range(0, 5):
        if x == 3:
            functionToExecuteWithoutParameter()
        else:
            functionToExecuteWithParameter(x)


if __name__ == '__main__':
    listaToIterar = range(0, 100)
    for i in listaToIterar:
        task = multiprocessing.Process(
            target=functionToSelectTheFunction, args=(i,))
        task.start()
    print("Programa Terminado")
