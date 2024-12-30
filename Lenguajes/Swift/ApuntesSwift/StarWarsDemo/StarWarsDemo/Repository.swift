//
//  Repository.swift
//  StarWarsDemo
//
//  Created by Asier Garcia Barrenengoa on 30/12/24.
//

import Foundation

//func getData() throws -> [StarCard] {
//    // Obtenemos el archivo del path del executable
//    // El URL devuelve un valor opcional(?) o nullable
//    // Si sabemos que nunca va a ser nil(null), podemos poner el !
//    // Si tenemos dudas, podemos usar un guard else para comprobar si el valor es nulo y ejecuta el else
//    guard
//        let url = Bundle.main.url(
//            forResource: "StarWars", withExtension: "json")
//    else { return [] }
//
//    // Al igual que en Java, si el metodo es posible que salte una excepcion, podemos pasarla hacia arriba o capturarla con do{} catch
//    let data = try Data(contentsOf: url)
//
//    let decoder = JSONDecoder()
//    decoder.keyDecodingStrategy = .convertFromSnakeCase
//
//    // Pongo el Self para acceder a dato en si
//    // Con el decode, obtengo el objeto DTO y luego mapeamos, pasando el metodo del mapeo que hemos creado antes para devolver un tipo starCard
//    return try decoder.decode([StarCardDTO].self, from: data)
//        .map(\.toCard)
//}

protocol DataRepository {
    var url: URL { get }
}

extension DataRepository {
    func getData() throws -> [StarCard] {
        // Al igual que en Java, si el metodo es posible que salte una excepcion, podemos pasarla hacia arriba o capturarla con do{} catch
        let data = try Data(contentsOf: url)

        let decoder = JSONDecoder()
        decoder.keyDecodingStrategy = .convertFromSnakeCase

        // Pongo el Self para acceder a dato en si
        // Con el decode, obtengo el objeto DTO y luego mapeamos, pasando el metodo del mapeo que hemos creado antes para devolver un tipo starCard
        return try decoder.decode([StarCardDTO].self, from: data)
            .map(\.toCard)
    }
}

struct Repository: DataRepository {

    var url: URL {
        Bundle.main.url(forResource: "StarWars", withExtension: "json")!
    }
}

// Creamos el mock del fichero de prueba
// No deja de ser frontend
struct RepositoryTests: DataRepository {
    var url: URL {
        Bundle.main.url(forResource: "StarWars Test", withExtension: "json")!
    }
}
