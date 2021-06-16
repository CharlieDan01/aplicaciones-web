--BASE DE DATOS HECHA POR CARLOS DANIEL ZUÑIGA CORONADO
--TECNOLOGICO NACIONAL DE MEXICO CAMPUS MONCLOVA 
--TALLER DE BASE DE DATOS Profesor: RUBEN MIGUEL RIOJAS RDZ
create database BIBLIOTECA 
USE BIBLIOTECA;

-------------------------------TABLAS--------------------------------
CREATE TABLE TipoEjemplar(
idTipoEjemplar int IDENTITY(1,1),
descripcion VARCHAR(200)NOT NULL,
imagenFile VARBINARY(MAX),
estatus BIT DEFAULT 1,
idCondicion INT,
CONSTRAINT PK_TipoEjemplar PRIMARY KEY(idTipoEjemplar)
);

CREATE TABLE CondPrestamo(
idCondicion int IDENTITY(1,1),
limitePrestamos VARCHAR(1)NOT NULL,
limiteRenovaciones VARCHAR(1)NOT NULL,
estatus BIT DEFAULT 1,
CONSTRAINT PK_CondPrestamo PRIMARY KEY(idCondicion)
);

CREATE TABLE TipoSocio(
idTipoSocio INT IDENTITY(1,1),
descripcion VARCHAR(50)NOT NULL,
maximoMultas VARCHAR(50)NOT NULL,
estatus BIT DEFAULT 1,
idCondicion INT,
CONSTRAINT PK_TipoSocio PRIMARY KEY(idTipoSocio)
);

CREATE TABLE Autor(
idAutor INT IDENTITY(1,1),
nombre VARCHAR(100)NOT NULL,
pais VARCHAR(100)NOT NULL,
fechaNacimiento datetime,
estatus BIT DEFAULT 1,
CONSTRAINT PK_Autor PRIMARY KEY(idAutor)
);

CREATE TABLE Recurso(--EL RECURSO SE VENDE
idRecurso INT IDENTITY(1,1),
titulo VARCHAR(100)NOT NULL,
descripcion VARCHAR(100)NOT NULL,
estatus BIT DEFAULT 1,
precio INT,
idTipoEjemplar INT,
idPersonal INT,
CONSTRAINT PK_Recurso PRIMARY KEY(idRecurso)
);

CREATE TABLE Personal(
idPersonal INT IDENTITY(1,1),
nombre VARCHAR(50)NOT NULL,
apellidoP VARCHAR(50)NOT NULL,
apellidoM VARCHAR(50)NOT NULL,
constraseña VARCHAR(10)NOT NULL,
rango VARCHAR(30)NOT NULL,
estatus BIT DEFAULT 1,
CONSTRAINT PK_Personal PRIMARY KEY(idPersonal)
);
CREATE TABLE Biblioteca(
idBiblioteca INT IDENTITY(1,1),
imagenFile VARBINARY(MAX),
horario VARCHAR(20)NOT NULL,
telefono VARCHAR(10)NOT NULL,
link VARCHAR(50)NOT NULL,
CONSTRAINT PK_Biblioteca PRIMARY KEY(idBiblioteca)
);
CREATE TABLE Ejemplar(
idEjemplar INT IDENTITY(1,1),
ISBN VARCHAR(10) NOT NULL,
descripcionEjem  VARCHAR(50)NOT NULL,
estatus BIT DEFAULT 1,
idReserva INT,
idRecurso INT,
idBiblioteca INT,
idClasificacion INT,
idColeccion INT,
CONSTRAINT PK_Ejemplar PRIMARY KEY(idEjemplar)
);

CREATE TABLE Reserva(
idReserva INT IDENTITY(1,1),
fecha datetime NOT NULL, 
estatus BIT DEFAULT 1,
CONSTRAINT PK_Reserva PRIMARY KEY(idReserva)
);

CREATE TABLE Socio(
idSocio INT IDENTITY(1,1),
nombre VARCHAR(50)NOT NULL,
apellidoP VARCHAR(50)NOT NULL,
apellidoM VARCHAR(50)NOT NULL,
dirección VARCHAR(80)NOT NULL,
telefono VARCHAR(10)NOT NULL,
email VARCHAR(25)NOT NULL,
estatus BIT DEFAULT 1,
idTipoSocio INT,
idReserva INT,
idPersonal INT,
CONSTRAINT PK_Socio PRIMARY KEY(idSocio)
);

CREATE TABLE Coleccion(
idColeccion INT IDENTITY(1,1),
descripcion VARCHAR(100)NOT NULL,
CONSTRAINT PK_Colecccion PRIMARY KEY(idColeccion)
);

CREATE TABLE Prestamo(
idPrestamo INT IDENTITY(1,1),
fechaDesde datetime,
fechaHasta datetime,
fechaPrevistaDev datetime,
estatus BIT DEFAULT 1,
idSocio INT,
idPersonal INT,
idEjemplar INT,
CONSTRAINT PK_Prestamo PRIMARY KEY(idPrestamo)
);

CREATE TABLE Clasificacion(
idClasificacion INT IDENTITY(1,1),
nombre VARCHAR(100)NOT NULL,
descripcion VARCHAR(100)NOT NULL,
estatus BIT DEFAULT 1,
idSubclasificacion INT,
CONSTRAINT PK_Clasificacion PRIMARY KEY(idClasificacion)
); 

CREATE TABLE Subclasificacion(
IdSubclasificacion INT IDENTITY(1,1),
nombre VARCHAR(100)NOT NULL,
descripcion VARCHAR(100)NOT NULL,
estatus BIT DEFAULT 1,
CONSTRAINT PK_Subclasificacion PRIMARY KEY(idSubclasificacion)
); 


---------------------------------INDICES-----------------------------------
CREATE INDEX  IX_TipoEjemplar ON TipoEjemplar (idTipoEjemplar);
GO

CREATE INDEX  IX_CondPrestamo ON CondPrestamo (idCondicion);
GO

CREATE INDEX  IX_TipoSocio ON TipoSocio (idTipoSocio);
GO

CREATE INDEX  IX_Autor ON Autor (idAutor);
GO

CREATE INDEX  IX_Recurso ON Recurso (idRecurso);
GO

CREATE INDEX  IX_Biblioteca ON Biblioteca (idbiblioteca);
GO

CREATE INDEX  IX_Reserva ON Reserva (idReserva);
GO

CREATE INDEX  IX_Socio ON Socio (idSocio);
GO

CREATE INDEX  IX_Coleccion ON Coleccion (idColeccion);
GO

CREATE INDEX  IX_Prestamo ON Prestamo (idPrestamo);
GO

CREATE INDEX  IX_Clasificacion ON Clasificacion (idClasificacion);
GO

CREATE INDEX  IX_Sublclasificacion ON Subclasificacion (idSubclasificacion);
GO

CREATE INDEX IX_Empleado ON Personal(idPersonal);
GO

------------------------RELACIONES-----------------------------
ALTER TABLE TipoEjemplar
ADD CONSTRAINT FK_TipoEjemplarCondPrestamo
FOREIGN KEY(idCondicion) REFERENCES CondPrestamo(idCondicion);
GO

ALTER TABLE TipoSocio
ADD CONSTRAINT FK_CondPrestamoTipoSocio
FOREIGN KEY(idCondicion) REFERENCES CondPrestamo(idCondicion);
GO

ALTER TABLE Recurso
ADD CONSTRAINT FK_TipoEjemplarRecurso
FOREIGN KEY(idTipoEjemplar) REFERENCES TipoEjemplar(idTipoEjemplar);

ALTER TABLE Recurso
ADD CONSTRAINT FK_PersonalRecurso
FOREIGN KEY(idPersonal) REFERENCES Personal (idPersonal);
GO

ALTER TABLE Socio
ADD CONSTRAINT FK_TiposocioSocio
FOREIGN KEY(idTipoSocio) REFERENCES TipoSocio(idTipoSocio);
GO

ALTER TABLE Socio
ADD CONSTRAINT FK_ReservaSocio
FOREIGN KEY(idReserva) REFERENCES Reserva(idReserva);
GO


ALTER TABLE Socio
ADD CONSTRAINT FK_PersonalSocio
FOREIGN KEY(idPersonal) REFERENCES Personal(idPersonal);
GO

ALTER TABLE Ejemplar
ADD CONSTRAINT FK_ReservaEjemplar
FOREIGN KEY (idReserva) REFERENCES Reserva(idReserva);
GO

ALTER TABLE Ejemplar
ADD CONSTRAINT FK_RecursoEjemplar
FOREIGN KEY (idRecurso) REFERENCES Recurso(idRecurso);
GO

ALTER TABLE Ejemplar
ADD CONSTRAINT FK_BibliotecaEjemplar 
FOREIGN KEY (idBiblioteca) REFERENCES Biblioteca(idBiblioteca);
GO

ALTER TABLE Ejemplar
ADD CONSTRAINT FK_ClasificacionEjemplar
FOREIGN KEY (idClasificacion) REFERENCES Clasificacion(idClasificacion);
GO

ALTER TABLE Ejemplar
ADD CONSTRAINT FK_ColeccionEjemplar
FOREIGN KEY (idColeccion) REFERENCES Coleccion(idColeccion);

GO

ALTER TABLE Prestamo
ADD CONSTRAINT FK_PersonalPrestamo
FOREIGN KEY (idPersonal) REFERENCES Personal(idPersonal);
GO 

ALTER TABLE Prestamo
ADD CONSTRAINT FK_EjemplarPrestamo
FOREIGN KEY (idEjemplar) REFERENCES Ejemplar(idEjemplar);
GO 

ALTER TABLE Clasificacion
ADD CONSTRAINT FK_SubclasificacionClasificacion
FOREIGN KEY (idSubclasificacion) REFERENCES Subclasificacion(idSubclasificacion);
GO

---------------------LLENADO DE DATOS---------------------
----autor---
INSERT INTO Autor(nombre, pais, fechaNacimiento, estatus)
VALUES('DrossRotzank','Argentina','1982-07-16','1');--LUNA DE PLUTON
INSERT INTO Autor(nombre, pais, fechaNacimiento, estatus)
VALUES('Miguel De Cervantes','España','1899-10-29','1');--don quijote I
INSERT INTO Autor(nombre, pais, fechaNacimiento, estatus)
VALUES('Miguel De Cervantes','España','1899-10-29','1');--don quijote II
INSERT INTO Autor(nombre, pais, fechaNacimiento, estatus)
VALUES('William Faulkner','USA','1897-10-25','1');--historias de nuevo orleans 
INSERT INTO Autor(nombre, pais, fechaNacimiento, estatus)
VALUES('Antonie Saint-Exupery','Francia','1900-06-29','1');--el principito


----biblioteca
INSERT INTO Biblioteca(horario, telefono, link)
VALUES('8:00-21:00','8661234567','www.bibliotecaVitali.com');


--clasificacion
INSERT INTO Clasificacion(nombre,descripcion,estatus, idSubclasificacion)
VALUES('100- Filosofía y Psicología.','sensación,la percepción,la inteligencia,la memoria','1',1);
INSERT INTO Clasificacion(nombre,descripcion,estatus, idSubclasificacion)
VALUES('200- Religión, Teología.','biblias, testamentos, ciencia religiosa','1',2);
INSERT INTO Clasificacion(nombre,descripcion,estatus, idSubclasificacion)
VALUES('300- Ciencias Sociales','comportamiento del hombre en la sociedad y sus formas de organización.','1',3);
INSERT INTO Clasificacion(nombre,descripcion,estatus, idSubclasificacion)
VALUES('400- Lenguas.','signos lingüísticos, conformado por la interacción comunicativa y cuyo fin es la comunicación misma.','1',4);
INSERT INTO Clasificacion(nombre,descripcion,estatus, idSubclasificacion)
VALUES('500 - Ciencias Básicas.',' Física, Química y Matemática.','1',5);
INSERT INTO Clasificacion(nombre,descripcion,estatus)
VALUES('600 - Tecnología y Ciencias Aplicadas.','ingenieria, medicina','1');
INSERT INTO Clasificacion(nombre,descripcion,estatus)
VALUES('700 - Artes y recreación.','musica, plástica, circense','1');
INSERT INTO Clasificacion(nombre,descripcion,estatus, idSubclasificacion)
VALUES('800 - Literatura.','Teoría de la composición de las obras escritas en prosa o verso.','1',8);
INSERT INTO Clasificacion(nombre,descripcion,estatus, idSubclasificacion)
VALUES('900 - Historia y Geografía','espacio, continentes, tiempo','1',9);

--Coleccion
INSERT INTO Coleccion(descripcion)
VALUES('Colecccion de Don Quijote De La Mancha');

--Condicion del prestamo 
INSERT INTO CondPrestamo(limitePrestamos, limiteRenovaciones, estatus)
VALUES('3','3','1');
INSERT INTO CondPrestamo(limitePrestamos, limiteRenovaciones, estatus)
VALUES('2','2','1');
--EJEMPLARES 
INSERT INTO Ejemplar(ISBN, descripcionEjem, estatus)
VALUES('9788467046','Luna de plutón','1');
INSERT INTO Ejemplar(ISBN,descripcionEjem,estatus, idColeccion)
VALUES('97814001','las aventuras de don quijote ','1',1);
INSERT INTO Ejemplar(ISBN,descripcionEjem,estatus, idColeccion)
VALUES('97814002','las aventuras de don quijote II','1',1);
INSERT INTO Ejemplar(ISBN,descripcionEjem,estatus)
VALUES('84217429',' leyendas de nuevo orleans','1');
INSERT INTO Ejemplar(ISBN,descripcionEjem,estatus)
VALUES('97817426','El principito','1');

---------PERSONAL------------
INSERT INTO Personal(nombre,apellidoP,apellidoM, constraseña, rango, estatus)
VALUES('Martín', 'Lozano','Estrada','n1k3F44ts0','Librero','1');
INSERT INTO Personal(nombre,apellidoP,apellidoM, constraseña, rango, estatus)
VALUES('Jeremy','Esparza', 'Rosa','p77ma430o2','Conserje','1');

--------prestamo 
INSERT INTO Prestamo(fechaDesde, fechaHasta, fechaPrevistaDev, estatus, idSocio)
VALUES('2021-06-13','2021-06-16','2021-06-15','1',1);
INSERT INTO Prestamo(fechaDesde, fechaHasta, fechaPrevistaDev, estatus)
VALUES('2021-06-14','2021-06-17','2021-06-16','1');


-----------RECURSO----------------
INSERT INTO Recurso(titulo, descripcion, estatus, precio)
VALUES('Luna de plutón','Un lejano parque de atracciones en plena misión secreta para defender su amada','1',300);
INSERT INTO Recurso(titulo, descripcion, estatus, precio)
VALUES('Don Quijote de la mancha','las aventuras de don Quijote','1',100);
INSERT INTO Recurso(titulo, descripcion, estatus, precio)
VALUES('Don Quijote de la mancha Vol II','las aventuras de don Quijote parte 2','1',100);
INSERT INTO Recurso(titulo, descripcion, estatus, precio)
VALUES('Las leyendas de Nuevo Orleans','todas las leyendas del nuevo orleans aquí','1',400);
INSERT INTO Recurso(titulo, descripcion, estatus, precio)
VALUES('El principito','la novela mas famosa y corta del mundo','1',600);

------RESERVAS_______________________________
INSERT INTO Reserva(fecha, estatus)
values('2021-06-13','1')
INSERT INTO Reserva(fecha, estatus)
values('2021-06-13','1')
--------Socio______________
INSERT INTO Socio(nombre,apellidoP,apellidoM,dirección, telefono, email, estatus)
VALUES('Jeff','Cavalera','Pineda','Avenida SiempreViva', '8667651243','jeffcapi@gmail.com','1')
INSERT INTO Socio(nombre,apellidoP,apellidoM,dirección, telefono, email, estatus)
VALUES('José','Canseco','Soto','Blvd Brother', '8669983114','joscan@hotmail.com','1')

--SubClasificacion_________________________
INSERT INTO Subclasificacion(nombre, descripcion,estatus)
VALUES('110 Metafísica','el ser en cuanto tal, el absoluto, Dios, el mundo','1');
INSERT INTO Subclasificacion(nombre, descripcion,estatus)
VALUES('210 Religion Natural','índole religioso relacionados con la naturaleza y con los rituales y leyes de índole moral','1');
INSERT INTO Subclasificacion(nombre, descripcion,estatus)
VALUES('310 Estadística','reúne, clasifica y recuenta todos los hechos que tienen una determinada característica en común','1');
INSERT INTO Subclasificacion(nombre, descripcion,estatus)
VALUES('410 Lingüística','transformaciones y los cambios experimentados por una lengua a través del tiempo.','1');
INSERT INTO Subclasificacion(nombre, descripcion,estatus)
VALUES('510 Matemáticas', 'Ciencia que estudia las propiedades de los números y las relaciones que se establecen entre ellos.','1');
INSERT INTO Subclasificacion(nombre, descripcion,estatus)
VALUES('610 Ciencias médicas', 'área de la salud, ya sea para su restauración, prevención de enfermedades o el fomento de la misma.','1');
INSERT INTO Subclasificacion(nombre, descripcion,estatus)
VALUES('710 Urbanismo y arquitectura del paisaje','planos y diseños se rehabilitan conservan espacios respetando la configuración del medio ambiente','1');
INSERT INTO Subclasificacion(nombre, descripcion,estatus)
VALUES('810 Literatura americana en inglés ','en su conjunto es el escrito u obra literaria producida en el ámbito de USA','1');
INSERT INTO Subclasificacion(nombre, descripcion,estatus)
VALUES('910 Geografía; viajes','los procesos y las interacciones que producen la estructura espacial de los destinos turísticos.','1');




--TIPO SOCIO__________________________________________________
INSERT INTO TipoSocio(descripcion, maximoMultas, estatus)
VALUES('Socio nivel 1','3','1');
INSERT INTO TipoSocio(descripcion, maximoMultas, estatus)
VALUES('Socio nivel 2','2','1');


-----------------VISTAS----------------
-- 1.- VISTA PARA MOSTRAR LOS AUTORES DE TODOS LOS LIBROS 
SELECT * FROM Autor
-- 2.- VISTA PARA MOSTRAR EL HORARIO Y TELEFONO DE LAS BIBLIOTECAS
SELECT horario, telefono FROM Biblioteca
-- 3.- VISTA PARA MOSTRAR EMPLEADOS CON APELLIDO PATERNO CON INICIAL "E"
SELECT ApellidoP  FROM Personal WHERE apellidoP LIKE 'E%'
-- 4.- VISTA PARA MOSTRAR EL NOMBRE Y DESCRIPCION DE LA CLASIFICACION DE LOS LIBROS
SELECT nombre, descripcion FROM Clasificacion
-- 5.- VISTA PARA MOSTRAR EL ID, NOMBRE Y DESCRIPCION DE LA SUBCLASIFICACION DE LOS LIBROS
SELECT idSubclasificacion, nombre, descripcion FROM Subclasificacion
--6.- VISTA PARA VER EL ISBN Y DESCRIPCION DEL EJEMPLAR
SELECT ISBN, descripcionEjem FROM Ejemplar
--7.- VISTA PARA ACOMODAR EL RECURSO CONFORME A SU PRECIO DE MANERA ASCENDENTE 
SELECT * FROM Recurso  ORDER BY precio ASC
--8.- VISTA PARA VER LOS SOCIOS QUE RENTAN O COMPRAN LIBROS, DVD, CD ETC
SELECT nombre, apellidoP, apellidoM, dirección, telefono, email FROM Socio
--9.- VISTA PARA VER QUE TIPOS DE SOCIOS SE MANEJA 
SELECT descripcion, estatus FROM TipoSocio
--10.- VISTA DE LOS PRESTAMOS DADOS 
SELECT fechaDesde, fechaPrevistaDev, fechaHasta,idPersonal FROM Prestamo


--------------------------------TRIGGERS-----------------------------
--1.- trigger que nos enseña un msj cada vez que realizamos una modificacion o insersion dentro de la tabla autor
IF object_id('TR_MensajeInsercionAutor')is not null
begin
drop trigger TR_MensajeInsercionAutor
end
go
CREATE TRIGGER TR_MensajeInsercionAutor
ON Autor
FOR INSERT, UPDATE 
AS
BEGIN
PRINT'#SE HA COMPLETADO UNA MODIFICACION O INSERSION DENTRO DE LA TABLA AUTOR DE MANERA EXITOSA#'
END
GO
--2.- trigger que nos enseña un msj cada que se haga una modificacion o insersion dentro de la tabla biblioteca
IF object_id('TR_MensajeInsercionBiblioteca')is not null
begin
drop trigger TR_MensajeInsercionBiblioteca
end
go
CREATE TRIGGER TR_MensajeInsercionBiblioteca
ON Biblioteca
FOR INSERT, UPDATE 
AS
BEGIN
PRINT'#SE HA COMPLETADO UNA MODIFICACION O INSERSION DENTRO DE LA TABLA BIBLIOTECA DE MANERA EXITOSA#'
END
GO
--3.- trigger que nos enseña un msj cada que se haga una modificacion o insersion dentro de la tabla coleccion
IF object_id('TR_MensajeInsercionColeccion')is not null
begin
drop trigger TR_MensajeInsercionColeccion
end
go
CREATE TRIGGER TR_MensajeInsercionColeccion
ON Coleccion
FOR INSERT, UPDATE 
AS
BEGIN
PRINT'#SE HA COMPLETADO UNA MODIFICACION O INSERSION DENTRO DE LA TABLA COLECCION DE MANERA EXITOSA#'
END
GO
--4.- trigger que nos enseña un msj cada que se haga una modificacion o insersion dentro de la tabla Ejemplar
IF object_id('TR_MensajeInsercionEjemplar')is not null
begin
drop trigger TR_MensajeInsercionEjemplar
end
go
CREATE TRIGGER TR_MensajeInsercionEjemplar
ON Ejemplar
FOR INSERT, UPDATE 
AS
BEGIN
PRINT'#SE HA COMPLETADO UNA MODIFICACION O INSERSION DENTRO DE LA TABLA EJEMPLAR DE MANERA EXITOSA#'
END
GO
--5.- trigger que nos enseña un msj cada que se haga una modificacion o insersion dentro de la tabla Clasificacion
IF object_id('TR_MensajeInsercionClasificacion')is not null
begin
drop trigger TR_MensajeInsercionClasificacion
end
go
CREATE TRIGGER TR_MensajeInsercionClasificacion
ON Clasificacion
FOR INSERT, UPDATE 
AS
BEGIN
PRINT'#SE HA COMPLETADO UNA MODIFICACION O INSERSION DENTRO DE LA TABLA CLASIFICACION DE MANERA EXITOSA#'
END
GO
--6.- trigger que nos enseña un msj cada que se haga una modificacion o insersion dentro de la tabla Recurso
IF object_id('TR_MensajeInsercionRecurso')is not null
begin
drop trigger TR_MensajeInsercionRecurso
end
go
CREATE TRIGGER TR_MensajeInsercionRecurso
ON Recurso
FOR INSERT, UPDATE 
AS
BEGIN
PRINT'#SE HA COMPLETADO UNA MODIFICACION O INSERSION DENTRO DE LA TABLA RECURSO DE MANERA EXITOSA#'
END
GO
--7.- trigger que nos enseña un msj cada que se haga una modificacion o insersion dentro de la tabla Reserva
IF object_id('TR_MensajeInsercionReserva')is not null
begin
drop trigger TR_MensajeInsercionReserva
end
go
CREATE TRIGGER TR_MensajeInsercionReserva
ON Reserva
FOR INSERT, UPDATE 
AS
BEGIN
PRINT'#SE HA COMPLETADO UNA MODIFICACION O INSERSION DENTRO DE LA TABLA RESERVA DE MANERA EXITOSA#'
END
GO
--8.- trigger que nos enseña un msj cada que se haga una modificacion o insersion dentro de la tabla Socio
IF object_id('TR_MensajeInsercionSocio')is not null
begin
drop trigger TR_MensajeInsercionSocio
end
go
CREATE TRIGGER TR_MensajeInsercionSocio
ON Socio
FOR INSERT, UPDATE 
AS
BEGIN
PRINT'#SE HA COMPLETADO UNA MODIFICACION O INSERSION DENTRO DE LA TABLA SOCIO DE MANERA EXITOSA#'
END
GO

--9.- trigger que nos enseña un msj cada que se haga una modificacion o insersion dentro de la tabla TipoEjemplar
IF object_id('TR_MensajeInsercionTipoEjemplar')is not null
begin
drop trigger TR_MensajeInsercionTipoEjemplar
end
go
CREATE TRIGGER TR_MensajeInsercionTipoEjemplar
ON TipoEjemplar
FOR INSERT, UPDATE 
AS
BEGIN
PRINT'#SE HA COMPLETADO UNA MODIFICACION O INSERSION DENTRO DE LA TIPOEJEMPLAR DE MANERA EXITOSA#'
END
GO
--10.- trigger que nos enseña un msj cada que se haga una modificacion o insersion dentro de la tabla TipoSocio
IF object_id('TR_MensajeInsercionTipoSocio')is not null
begin
drop trigger TR_MensajeInsercionTipoSocio
end
go
CREATE TRIGGER TR_MensajeInsercionTipoSocio
ON TipoSocio
FOR INSERT, UPDATE 
AS
BEGIN
PRINT'#SE HA COMPLETADO UNA MODIFICACION O INSERSION DENTRO DE LA TIPOSOCIO DE MANERA EXITOSA#'
END
GO
-----------PROCEDIMIENTOS ALMACENADOS----------------
--1.- procedimiento para hacer consulta de un autor dentro de la tabla en bdd
CREATE PROCEDURE SP_ConsultaAutor
AS 
SELECT * FROM Autor
WHERE nombre='DrossRotzank'

exec SP_ConsultaAutor
--2.- este procedimiento es para insertar nuevos autores a la bdd
CREATE PROCEDURE SP_insertarAutor
(
@nombre VARCHAR(100),
@pais VARCHAR(100),
@fechaNacimiento datetime,
@estatus bit
)
as
begin
insert into Autor(nombre, pais, fechaNacimiento, estatus)
values(@nombre,@pais,@fechaNacimiento,@estatus);
 end

 exec SP_ConsultaAutor 'Alejandro Rodriguez', 'México', 1990113,'1'
 --______________________________________________________________-
 CREATE PROCEDURE SP_ConsultaEjemplar
AS 
SELECT * FROM Ejemplar
WHERE ISBN='9'

exec SP_ConsultaEjemplar
--_______________________________________________________________
 CREATE PROCEDURE SP_ConsultaRecurso
AS 
SELECT * FROM Recurso
WHERE titulo='Don Quijote de la mancha Vol II'

exec SP_ConsultaRecurso
--_________________________________________________________
 CREATE PROCEDURE SP_ConsultaPersonal
AS 
SELECT * FROM Personal
WHERE apellidoP='Estrada'

exec SP_ConsultaPersonal


