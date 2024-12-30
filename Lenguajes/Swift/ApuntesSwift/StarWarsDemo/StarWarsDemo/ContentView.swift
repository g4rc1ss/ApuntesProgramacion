//
//  ContentView.swift
//  StarWarsDemo
//
//  Created by Asier Garcia Barrenengoa on 30/12/24.
//

import SwiftUI

struct ContentView: View {
    @State var viewModel = StarCardViewModel()

    var body: some View {
        List {
            ForEach(viewModel.cards) { card in
                StarCardView(card: card)
            }
        }
    }
}

#Preview {
    ContentView(viewModel: StarCardViewModel(repository: Repository()))
}
