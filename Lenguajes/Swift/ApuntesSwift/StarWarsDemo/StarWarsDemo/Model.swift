//
//  Model.swift
//  StarWarsDemo
//
//  Created by Asier Garcia Barrenengoa on 30/12/24.
//

import Foundation

// Implementamos el protocolo(interface) Codable para poder serializar el objeto
struct StarCardDTO: Codable {
    let id: Int
    let nombre: String
    let raza: String
    let descripcion: String
    let planetaOrigen: String
    let epoca: String
    let afiliacion: String
    let habilidades: String
    let armas: String
    let imagen: String
}

// crear extensiones de un tipo, como las de .net
extension StarCardDTO {
    var toCard: StarCard {
        StarCard(
            id: id, nombre: nombre, raza: raza, descripcion: descripcion,
            planetaOrigen: planetaOrigen, epoca: epoca,
            afiliacion: afiliacion.components(separatedBy: ", ").map(
                \.capitalized),
            habilidades: habilidades.components(separatedBy: ", ").map(
                \.capitalized),
            armas: armas.components(separatedBy: ", ").map(\.capitalized),
            imagen: imagen)
    }
}

// Implementamos el protocolo Identifiable para indicar un ID unico
// Implementamos el protocolo Hashable para poder comparar la instancia del objeto con otra
struct StarCard: Identifiable, Hashable {
    let id: Int
    let nombre: String
    let raza: String
    let descripcion: String
    let planetaOrigen: String
    let epoca: String
    let afiliacion: [String]
    let habilidades: [String]
    let armas: [String]
    let imagen: String
}

extension StarCard {
    static let test = StarCard(
        id: 1, nombre: "Test", raza: "Test", descripcion: "Test",
        planetaOrigen: "Test", epoca: "Test",
        afiliacion: ["Test"], habilidades: ["Test"],
        armas: ["Test"], imagen: "Test")
}
