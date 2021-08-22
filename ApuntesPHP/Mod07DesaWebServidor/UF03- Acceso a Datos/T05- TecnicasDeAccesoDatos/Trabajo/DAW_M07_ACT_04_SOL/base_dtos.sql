create database ucoc_act05;
use ucoc_act05;
create table Usuario(
	dni varchar(9) primary key,
    apellido varchar(50),
    tipo_usuario int /* 0 - Admin, 1 - User*/);
create table Asignatura(
	id int primary key auto_increment,
    nombre varchar(30));
create table Nota(
	alumno varchar(9),
    asignatura int,
    nota int,
    primary key(alumno, asignatura),
    foreign key (alumno) references Usuario(dni) on delete cascade on update cascade,
    foreign key (asignatura) references Asignatura(id) on delete cascade on update cascade);
    
insert into Usuario values('12345', 'Santiago', 0);
insert into Usuario values('00000', 'Perez', 1);