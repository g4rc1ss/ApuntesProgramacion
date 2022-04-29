package com.example.ApiRestSpringJava.applicationCore;

import com.example.ApiRestSpringJava.contracts.database.FilmsDatabase;
import com.example.ApiRestSpringJava.domain.models.DirectorFilms;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class Films  implements com.example.ApiRestSpringJava.contracts.core.Films {
    private final FilmsDatabase filmsDatabase;

    public Films(FilmsDatabase filmsDatabase) {
        this.filmsDatabase = filmsDatabase;
    }

    @Override
    public List<DirectorFilms> GetDirectorFilms(int directorId) {
        return filmsDatabase.GetDirectorFilmsDatabase(directorId);
    }
}
