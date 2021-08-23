create database google_maps;
use google_maps;
create table locales(
	id int auto_increment primary key,
    nombre varchar(255),
    direccion varchar(255),
    tipo varchar(255)
);
insert into locales (nombre, direccion, tipo) values ('Bar Marsella', 'Carrer de Sant Pau, 65, 08001 Barcelona', 'Bar');
insert into locales (nombre, direccion, tipo) values ('Icebarcelona', 'Ramón Trías Fargas, 2, 08005 Barcelona', 'Bar');
insert into locales (nombre, direccion, tipo) values ('Espit chupitos', 'Carrer Aribau, 77, 08032 Barcelona', 'Bar');
insert into locales (nombre, direccion, tipo) values ('Los Caracoles', 'Calle de los Escudellers, 14, 08002 Barcelona', 'Restaurante');
insert into locales (nombre, direccion, tipo) values ('Restaurante Barceloneta', 'Carrer de Escar, 22, 08039 Barcelona', 'Restaurante');
insert into locales (nombre, direccion, tipo) values ('Mayura', 'Carrer de Girona, 57, 08009 Barcelona', 'Restaurante');
insert into locales (nombre, direccion, tipo) values ('Razzmatazz', 'Carrer Almogàvers, 122, 08018 Barcelona', 'Discoteca');
insert into locales (nombre, direccion, tipo) values ('Bikini', 'Avinguda Diagonal, 547, 08029 Barcelona', 'Discoteca');
insert into locales (nombre, direccion, tipo) values ('Danzatoria', 'Ramón Trias Fargas, 2, 08005 Barcelona', 'Discoteca');
