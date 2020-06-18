
USE EjemploTresKpas

--IF (OBJECT_ID('Alumnos') IS NOT NULL)
--DROP TABLE Alumnos


--CREATE TABLE Alumnos (IdAlumno int identity (1,1) primary key,
--Documento int not null,
--Nombre varchar(100) not null,
--Apellidos varchar(100) not null,
--Sexo char(1) not null,
--Direccion varchar(100) not null,
--FechaNacimiento date not null)


--Insert Alumnos values(9898989, 'Harry', 'Monsalve', 'M', 'CALLE vs CARRERA', '1999-01-01')
--Insert Alumnos values(9696969, 'Vane', 'Monsalve', 'M', 'CALLE vs CARRERA', '1999-01-01')
--Insert Alumnos values(7373737, 'Mabel', 'Monsalve', 'M', 'CALLE vs CARRERA', '1999-01-01')
--Insert Alumnos values(7070707, 'Leo', 'Monsalve', 'M', 'CALLE vs CARRERA', '1999-01-01')


CREATE PROC AlumnosInsertar(
@Documento int,
@Nombre varchar(100),
@Apellidos varchar(100) ,
@Sexo char(1),
@Direccion varchar(100) ,
@FechaNacimiento date,
@Mensaje varchar(200) OUT)

AS 
	BEGIN
		IF(EXISTS (SELECT * FROM EjemploTresKpas.dbo.Alumnos WHERE Documento = @Documento))
			SET @Mensaje = 'Este documento ya existe.'
			ELSE
				INSERT Alumnos VALUES(@Documento , @Nombre , @Apellidos , @Sexo , @Direccion , @FechaNacimiento )
				SET @Mensaje = 'El registro fue ingresado correctamente.'
	END
GO


CREATE PROC AlumnosConsultar
AS
	SELECT * FROM EjemploTresKpas.dbo.Alumnos
GO


CREATE PROC AlumnosActualizar(
@Documento int, 
@Nombre varchar(100),
@Apellidos varchar(100) ,
@Sexo char(1),
@Direccion varchar(100) ,
@FechaNacimiento date,
@Mensaje varchar(200) OUT)

AS 
	BEGIN
		IF(NOT EXISTS (SELECT * FROM EjemploTresKpas.dbo.Alumnos WHERE Documento = @Documento))
			SET @Mensaje = 'El alumno no existe.'
			ELSE
				UPDATE
				 EjemploTresKpas.Alumnos 
				 SET Nombre = @Nombre , 
					 Apellidos = @Apellidos , 
					 Sexo = @Sexo , 
					 Direccion = @Direccion , 
					 FechaNacimiento = @FechaNacimiento
				SET @Mensaje = 'El registro fue actualizado correctamente.'
	END
GO






