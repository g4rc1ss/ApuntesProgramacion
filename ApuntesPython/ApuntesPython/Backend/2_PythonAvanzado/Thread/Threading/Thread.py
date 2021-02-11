from concurrent import futures
import threading
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
    task = futures.ThreadPoolExecutor(len(listaToIterar))
    wait_for = [
        task.submit(functionToSelectTheFunction, i)
        for i in range(0, 100)
    ]
    for i in futures.as_completed(wait_for):
        i.result()
    print("Programa Terminado")
