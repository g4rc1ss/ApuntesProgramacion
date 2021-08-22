listaComprension = [1, 2, 3, 4, 5]

print(f"{listaComprension} \t {[n*2 for n in listaComprension]}")

listaComprension = [["asier", 22], ["pedro", 23]]
print(
    f"{listaComprension} \t {[array for array in listaComprension for nombre in array if nombre == 'asier']}")
