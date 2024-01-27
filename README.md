# Bienvenida, Profesore Verónica

## Confuguraciones

Déjeme darle una pequeña una pequeña indicación para poder configurar el software.

En la carpeta `Resources` ubicada en la raiz del proyecto. Dentro de ella encontrará un archivo de configuraciones llamada `config.xml` que contiene la configuración del sistema:

```xml
<?xml version="1.0" encoding="utf-8"?>
<appSettings>
	<setting key="SecurityIV" value="34A9F545E39CEB1A" />
	<setting key="SecurityKey" value="B65437AF2EE50772" />
	<setting key="ConnectionString" value="Data Source=DESKTOP-M5BV3EC;Initial Catalog=sistema_matriculacion;Trusted_Connection=True" />
</appSettings>
```

El atributo `setting` con la llave `ConnectionString` corresponden a la cadena de conexión. Por favor, Cambie las rutas a sus sus preferecias del sistema.

```xml
<appSettings>
  <setting key="PathImg" value="ruta\a\su\carpeta\" />
  <setting key="ConnectionString" value="Su cadena de conección" />
</appSettings>
```

## Base de datos

En cuanto a las consultas de la base de datos, dentro de la misma carpeta `Resources` encontrara un archivo llamado `SistemaMatriculacion.sql`. Este archivo contiene una consulta sql que crea la tabla empleados necesaria para que el sistema funcione correctamente.

Antes de recuerde creear una base de datos que ccontenga la tabla, en mi proyecto la base de datos se llama `sistema_matriculacion`:

```sql
CREATE DATABASE sistema_matriculacion;
```

El gestor de base de datos que estamos usando en **SQL Server**.