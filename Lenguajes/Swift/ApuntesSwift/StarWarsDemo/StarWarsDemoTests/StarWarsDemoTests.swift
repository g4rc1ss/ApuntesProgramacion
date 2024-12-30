//
//  Created by Asier Garcia Barrenengoa on 30/12/24.
//

import Testing

@testable import StarWarsDemo

extension Tag {
    @Tag static var repository: Self
}

@Suite("Prueba del repo", .tags(.repository))
struct StarWarsDemoTests {
    let repository = RepositoryTests()
    let viewModel = StarCardViewModel(repository: RepositoryTests())

    @Test("Prueba de carga de datos")
    func example() throws {
        let data = try repository.getData()

        #expect(data.count == 4)
    }

    @Test("Prueba de carga del ViewModel")
    func dataLoadVM() throws {
        #expect(viewModel.cards.count == 4)
    }
}
