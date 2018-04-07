/*Database*/
CREATE SCHEMA `belife` 
DEFAULT CHARACTER SET latin1 COLLATE latin1_general_ci;

/*User*/
use sys;
create user 'develop'@'localhost' identified by 'duocavaras';
grant all privileges on belife to 'develop'@'localhost';
flush privileges;

drop user developer;

/*tables*/
use belife;
create table cliente (
	rut varchar(10) not null primary key,
    nombre varchar(32) not null,
    apellidos varchar(32) not null,
    fec_nac date not null,
    id_genero int not null,
    id_ecivil int not null
);

create table genero (
	id_genero int not null auto_increment primary key,
    descripcion varchar(16) not null
);

create table estado_civil (
	id_ecivil int not null auto_increment primary key,
    descripcion varchar(16) not null
);

insert into genero (descripcion)
values
('Femenino'),
('Masculino');

insert into estado_civil (descripcion)
values
('Soltero'),
('Casado'),
('Divorciado'),
('Viudo');

#truncate cliente;

insert into cliente
values
('17754386-1', 'Evangelos', 'Dimitropulos Flores', str_to_date('29-05-1991', '%d-%m-%Y'), 2, 1);

/*select rut, nombre, apellidos, date_format(fec_nac, '%d-%m-%Y') fec_nac, id_genero, id_ecivil, e.descripcion, g.descripcion 
from cliente join genero g using(id_genero) 
join estado_civil e using(id_ecivil);*/