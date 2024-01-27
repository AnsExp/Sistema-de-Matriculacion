CREATE TABLE personas (
    id_persona INT IDENTITY(1, 1) PRIMARY KEY,
    numero_documento VARCHAR(10) NOT NULL,
    nombres VARCHAR(30) NOT NULL,
    apellidos VARCHAR(30) NOT NULL,
    fecha_nacimiento DATE,
    genero BIT NOT NULL,
    tipo_documento VARCHAR(20) NOT NULL,
    domicilio VARCHAR(100) NOT NULL,
    provincia VARCHAR(50) NOT NULL,
    ciudad VARCHAR(50) NOT NULL
);

CREATE TABLE profesores (
    id_profesor INT IDENTITY(1, 1) PRIMARY KEY,
    titulo VARCHAR(20) NOT NULL,
    id_persona INT NOT NULL,
    FOREIGN KEY (id_persona) REFERENCES personas(id_persona) ON DELETE CASCADE
);

CREATE TABLE estudiantes(
    id_estudiante INT IDENTITY(1, 1) PRIMARY KEY,
    nota_grado FLOAT NOT NULL,
    id_persona INT NOT NULL,
    FOREIGN KEY (id_persona) REFERENCES personas(id_persona) ON DELETE CASCADE
);

CREATE TABLE asignaturas (
    id_asignatura INT IDENTITY(1, 1) PRIMARY KEY,
    nombre VARCHAR(20) NOT NULL,
    creditos INT NOT NULL,
    componente_autonomo INT NOT NULL,
    componente_participacion INT NOT NULL,
    tiempo_horas INT NOT NULL,
    id_profesor INT NOT NULL,
    FOREIGN KEY (id_profesor) REFERENCES profesores(id_profesor) ON DELETE CASCADE
);

CREATE TABLE matriculas (
    id_matricula INT IDENTITY(1, 1) PRIMARY KEY,
    id_asignatura INT NOT NULL,
    id_estudiante INT NOT NULL,
    FOREIGN KEY (id_asignatura) REFERENCES asignaturas(id_asignatura) ON DELETE CASCADE,
    FOREIGN KEY (id_estudiante) REFERENCES estudiantes(id_estudiante) ON DELETE NO ACTION
);

/*Prueba listar todas las tablas*/
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='sistema_matriculacion';

/*Prueba Ingreso de profesor*/
INSERT INTO personas (numero_documento, nombres, apellidos, fecha_nacimiento, genero, tipo_documento, domicilio, provincia, ciudad)
VALUES (1234567890, 'Juan', 'Pérez', '1990-01-01', 1, 'Cédula', 'Calle 123', 'Guayas', 'Guayaquil');
DECLARE @id_persona INT;
SET @id_persona = SCOPE_IDENTITY();
INSERT INTO profesores (titulo, id_persona)
VALUES ('Doctor', @id_persona);

/*Prueba Ingreso de estudiante*/
INSERT INTO personas (numero_documento, nombres, apellidos, fecha_nacimiento, genero, tipo_documento, domicilio, provincia, ciudad) 
VALUES ('0123456789', 'Jorge', 'Amor', '1990-01-01', 1, 'Cédula', 'Balsamarahua, Callejón B', 'El Oro', 'Huaquillas');
INSERT INTO estudiantes (nota_grado, id_persona) 
VALUES (7.5, SCOPE_IDENTITY());

/*Prueba ver todos los registros*/
select * from personas;
select * from estudiantes;
select * from profesores;
select * from asignaturas;
select * from matriculas;

/*Prueba seleccionar profesores*/
SELECT id_profesor, profesores.id_persona, titulo, numero_documento, nombres, apellidos, fecha_nacimiento, genero, tipo_documento, domicilio, provincia, ciudad
FROM profesores
INNER JOIN personas ON profesores.id_persona = personas.id_persona;

/*Prueba seleccionar estudiantes*/
SELECT id_estudiante, estudiantes.id_persona, nota_grado, numero_documento, nombres, apellidos, fecha_nacimiento, genero, tipo_documento, domicilio, provincia, ciudad
FROM estudiantes
INNER JOIN personas ON estudiantes.id_persona = personas.id_persona;

/*Prueba eliminar todos los registros*/
DELETE FROM matriculas;
DELETE FROM asignaturas;
DELETE FROM profesores;
DELETE FROM estudiantes;
DELETE FROM personas;

/*Prueba eliminar todas las tablas*/
DROP TABLE matriculas;
DROP TABLE asignaturas;
DROP TABLE estudiantes;
DROP TABLE profesores;
DROP TABLE personas;