using Data;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Database
{
    public class ProfesorDAO
    {
        private const string SelectString =
            "SELECT id_profesor, profesores.id_persona, titulo, nombres, " +
            "apellidos, fecha_nacimiento, genero, domicilio, provincia, ciudad " +
            "FROM profesores " +

            "INNER JOIN personas ON profesores.id_persona=personas.id_persona " +
            "WHERE tipo_documento=@tipo_documento AND numero_documento=@numero_documento;";

        public Profesor Select(Profesor reg)
        {
            using (SqlCommand cmd = new SqlCommand(SelectString, ConectionDB.Instance))
            {

                cmd.Parameters.AddWithValue("@tipo_documento", reg.TipoDocumento);
                cmd.Parameters.AddWithValue("@numero_documento", reg.NumeroDocumento);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    reader.Read();

                    bool genero = reader.GetBoolean(reader.GetOrdinal("genero"));
                    string ciudad = reader.GetString(reader.GetOrdinal("ciudad"));
                    string nombres = reader.GetString(reader.GetOrdinal("nombres"));
                    string apellidos = reader.GetString(reader.GetOrdinal("apellidos"));
                    string domicilio = reader.GetString(reader.GetOrdinal("domicilio"));
                    string provincia = reader.GetString(reader.GetOrdinal("provincia"));
                    string titulo = reader.GetString(reader.GetOrdinal("titulo"));
                    int idPersona = reader.GetInt32(reader.GetOrdinal("id_persona"));
                    int idProfesor = reader.GetInt32(reader.GetOrdinal("id_profesor"));
                    DateTime fechaNacimiento = reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento"));

                    Profesor estudianteBuscado =
                        new Profesor(
                            idProfesor,
                            nombres,
                            apellidos,
                            idPersona,
                            genero,
                            domicilio,
                            provincia,
                            ciudad,
                            reg.TipoDocumento,
                            reg.NumeroDocumento,
                            titulo,
                            fechaNacimiento);

                    return estudianteBuscado;
                }
            }
        }

        private const string SelectStringByID =
            "SELECT profesores.id_persona, titulo, nombres, apellidos, fecha_nacimiento, " +
            "genero, domicilio, provincia, ciudad, tipo_documento, numero_documento " +
            "FROM profesores " +
            "INNER JOIN personas ON profesores.id_persona = personas.id_persona " +
            "WHERE id_profesor=@id_profesor;";

        public Profesor SelectByID(Profesor reg)
        {
            using (SqlCommand cmd = new SqlCommand(SelectStringByID, ConectionDB.Instance))
            {

                cmd.Parameters.AddWithValue("@id_profesor", reg.IDRegistro);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    reader.Read();

                    bool genero = reader.GetBoolean(reader.GetOrdinal("genero"));
                    string ciudad = reader.GetString(reader.GetOrdinal("ciudad"));
                    string tipoDocumento = reader.GetString(reader.GetOrdinal("tipo_documento"));
                    string numeroDocumento = reader.GetString(reader.GetOrdinal("numero_documento"));
                    string nombres = reader.GetString(reader.GetOrdinal("nombres"));
                    string apellidos = reader.GetString(reader.GetOrdinal("apellidos"));
                    string domicilio = reader.GetString(reader.GetOrdinal("domicilio"));
                    string provincia = reader.GetString(reader.GetOrdinal("provincia"));
                    string titulo = reader.GetString(reader.GetOrdinal("titulo"));
                    int idPersona = reader.GetInt32(reader.GetOrdinal("id_persona"));
                    DateTime fechaNacimiento = reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento"));

                    Profesor estudianteBuscado =
                        new Profesor(
                            reg.IDRegistro,
                            nombres,
                            apellidos,
                            idPersona,
                            genero,
                            domicilio,
                            provincia,
                            ciudad,
                            tipoDocumento,
                            numeroDocumento,
                            titulo,
                            fechaNacimiento);

                    return estudianteBuscado;
                }
            }
        }

        private const string InsertString =
            "INSERT INTO personas (numero_documento, nombres, apellidos, fecha_nacimiento, genero, tipo_documento, domicilio, provincia, ciudad) " +
            "VALUES (@numero_documento, @nombres, @apellidos, @fecha_nacimiento, @genero, @tipo_documento, @domicilio, @provincia, @ciudad);" +

            "INSERT INTO profesores (titulo, id_persona) " +
            "VALUES (@titulo, SCOPE_IDENTITY());";

        public void Insert(Profesor reg)
        {
            using (SqlCommand cmd = new SqlCommand(InsertString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@ciudad", reg.Ciudad);
                cmd.Parameters.AddWithValue("@genero", reg.Genero);
                cmd.Parameters.AddWithValue("@titulo", reg.Titulo);
                cmd.Parameters.AddWithValue("@nombres", reg.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", reg.Apellidos);
                cmd.Parameters.AddWithValue("@provincia", reg.Provincia);
                cmd.Parameters.AddWithValue("@domicilio", reg.Domicilio);
                cmd.Parameters.AddWithValue("@tipo_documento", reg.TipoDocumento);
                cmd.Parameters.AddWithValue("@numero_documento", reg.NumeroDocumento);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", reg.FechaNacimiento);

                cmd.ExecuteNonQuery();
            }
        }

        private const string DeleteString =
            "DELETE FROM personas " +
            "WHERE tipo_documento=@tipo_documento AND numero_documento=@numero_documento;";

        public void Delete(Profesor reg)
        {
            using (SqlCommand cmd = new SqlCommand(DeleteString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@tipo_documento", reg.TipoDocumento);
                cmd.Parameters.AddWithValue("@numero_documento", reg.NumeroDocumento);

                cmd.ExecuteNonQuery();
            }
        }

        private const string UpdateString =
            "UPDATE profesores SET " +
            "titulo=@titulo " +
            "WHERE id_profesor = @id_profesor;" +

            "UPDATE personas SET " +
            "domicilio=@domicilio, provincia=@provincia, ciudad=@ciudad " +
            "WHERE id_persona=@id_persona;";

        public void Update(Profesor reg)
        {
            using (SqlCommand cmd = new SqlCommand(UpdateString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@ciudad", reg.Ciudad);
                cmd.Parameters.AddWithValue("@titulo", reg.Titulo);
                cmd.Parameters.AddWithValue("@provincia", reg.Provincia);
                cmd.Parameters.AddWithValue("@domicilio", reg.Domicilio);
                cmd.Parameters.AddWithValue("@id_persona", reg.IDPersona);
                cmd.Parameters.AddWithValue("@id_profesor", reg.IDRegistro);

                cmd.ExecuteNonQuery();
            }
        }

        private const string SelectAllString =
            "SELECT id_profesor, profesores.id_persona, titulo, numero_documento, nombres, " +
            "apellidos, fecha_nacimiento, genero, tipo_documento, domicilio, provincia, ciudad " +
            "FROM profesores " +
            "INNER JOIN personas ON profesores.id_persona = personas.id_persona;";

        public List<Profesor> SelectAll()
        {
            List<Profesor> list = new List<Profesor>();

            using (SqlCommand cmd = new SqlCommand(SelectAllString, ConectionDB.Instance))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return list;

                    while (reader.Read())
                    {
                        bool genero = reader.GetBoolean(reader.GetOrdinal("genero"));
                        string ciudad = reader.GetString(reader.GetOrdinal("ciudad"));
                        string titulo = reader.GetString(reader.GetOrdinal("titulo"));
                        string nombres = reader.GetString(reader.GetOrdinal("nombres"));
                        string apellidos = reader.GetString(reader.GetOrdinal("apellidos"));
                        string domicilio = reader.GetString(reader.GetOrdinal("domicilio"));
                        string provincia = reader.GetString(reader.GetOrdinal("provincia"));
                        string tipoDocumento = reader.GetString(reader.GetOrdinal("tipo_documento"));
                        string numeroDocumento = reader.GetString(reader.GetOrdinal("numero_documento"));
                        int idPersona = reader.GetInt32(reader.GetOrdinal("id_persona"));
                        int idEstudiante = reader.GetInt32(reader.GetOrdinal("id_profesor"));
                        DateTime fechaNacimiento = reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento"));

                        Profesor estudianteBuscado =
                        new Profesor(
                            idEstudiante,
                            nombres,
                            apellidos,
                            idPersona,
                            genero,
                            domicilio,
                            provincia,
                            ciudad,
                            tipoDocumento,
                            numeroDocumento,
                            titulo,
                            fechaNacimiento);

                        list.Add(estudianteBuscado);
                    }
                }
            }

            return list;
        }
    }
}