//
//  StarCardViewModel.swift
//  StarWarsDemo
//
//  Created by Asier Garcia Barrenengoa on 30/12/24.
//

import SwiftUI

@Observable
final class StarCardViewModel {
    let repository: DataRepository

    var cards: [StarCard]

    init(repository: DataRepository = Repository()) {
        self.repository = repository
        do {
            cards = try repository.getData()
        } catch {
            cards = []
        }
    }
}
