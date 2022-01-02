DROP DATABASE IF EXISTS `apuntesnet`;
CREATE DATABASE IF NOT EXISTS `apuntesnet`;

CREATE TABLE `apuntesnet`.`Empleado` (
    `ID`         INT             NOT NULL    AUTO_INCREMENT,
    `Nombre`     VARCHAR(45)                 NULL,
    `Apellidos`  VARCHAR(45)                 NULL,
    `Salario`    DOUBLE                      NULL,
    PRIMARY KEY(`ID`)
);

INSERT INTO `apuntesnet`.`Empleado`(`Nombre`, `Apellidos`, `Salario`) VALUES
	('David', 'Yates', 200000),
	('Anthony', 'Russo', 50000000000),
	('Roger', 'Alles', 2000000),
	('Joe', 'Johson', 6000000);
