//
//  main.swift
//  MemoryManagment
//
//  Created by Asier Garcia Barrenengoa on 2/1/25.
//

import Foundation

var lista = [PruebaObjeto]()

for i in 0...1_000_000_0 {
    lista.append(PruebaObjeto(texto: i))
}

let listSize = MemoryLayout<PruebaObjeto>.stride * lista.count
print(
    "Memoria física total: \(listSize) MB"
)

print("Limpiamos la lista")
lista.removeAll()
print(
    "Memoria física total: \(ProcessInfo.processInfo.physicalMemory) MB"
)
//_ = readLine()
