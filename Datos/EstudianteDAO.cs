using Data;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Database
{
    public class EstudianteDAO
    {
        private const string DeleteString =
            "DELETE FROM personas " +
            "WHERE tipo_documento=@tipo_documento AND numero_documento=@numero_documento;";

        public void Delete(Estudiante reg)
        {
            using (SqlCommand cmd = new SqlCommand(DeleteString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@tipo_documento", reg.TipoDocumento);
                cmd.Parameters.AddWithValue("@numero_documento",reg.NumeroDocumento);

                cmd.ExecuteNonQuery();
            }
        }

        private const string InsertString =
            "INSERT INTO personas (numero_documento, nombres, apellidos, fecha_nacimiento, genero, tipo_documento, domicilio, provincia, ciudad) " +
            "VALUES (@numero_documento, @nombres, @apellidos, @fecha_nacimiento, @genero, @tipo_documento, @domicilio, @provincia, @ciudad);" +

            "INSERT INTO estudiantes (nota_grado, id_persona) " +
            "VALUES (@nota_grado, SCOPE_IDENTITY());";

        public void Insert(Estudiante reg)
        {
            using (SqlCommand cmd = new SqlCommand(InsertString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@genero", reg.Genero);
                cmd.Parameters.AddWithValue("@ciudad", reg.Ciudad);
                cmd.Parameters.AddWithValue("@nombres", reg.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", reg.Apellidos);
                cmd.Parameters.AddWithValue("@domicilio", reg.Domicilio);
                cmd.Parameters.AddWithValue("@provincia", reg.Provincia);
                cmd.Parameters.AddWithValue("@nota_grado", reg.NotaGrado);
                cmd.Parameters.AddWithValue("@tipo_documento", reg.TipoDocumento);
                cmd.Parameters.AddWithValue("@numero_documento", reg.NumeroDocumento);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", reg.FechaNacimiento);

                cmd.ExecuteNonQuery();
            }
        }

        private const string SelectString =
            "SELECT id_estudiante, estudiantes.id_persona, nota_grado, nombres, " +
            "apellidos, fecha_nacimiento, genero, domicilio, provincia, ciudad " +
            "FROM estudiantes " +

            "INNER JOIN personas ON estudiantes.id_persona = personas.id_persona " +
            "WHERE tipo_documento=@tipo_documento AND numero_documento=@numero_documento;";

        public Estudiante Select(Estudiante reg)
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
                    double notaGrado = reader.GetDouble(reader.GetOrdinal("nota_grado"));
                    int idPersona = reader.GetInt32(reader.GetOrdinal("id_persona"));
                    int idEstudiante = reader.GetInt32(reader.GetOrdinal("id_estudiante"));
                    DateTime fechaNacimiento = reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento"));

                    Estudiante estudianteBuscado =
                        new Estudiante(
                            idEstudiante,
                            nombres,
                            apellidos,
                            idPersona,
                            genero,
                            domicilio,
                            provincia,
                            ciudad,
                            reg.TipoDocumento,
                            reg.NumeroDocumento,
                            notaGrado,
                            fechaNacimiento);

                    return estudianteBuscado;
                }
            }
        }

        private const string SelectStringByID =
            "SELECT id_estudiante, estudiantes.id_persona, nota_grado, numero_documento, nombres, " +
            "apellidos, fecha_nacimiento, genero, tipo_documento, domicilio, provincia, ciudad " +
            "FROM estudiantes " +
            
            "INNER JOIN personas ON estudiantes.id_persona = personas.id_persona " +
            "WHERE id_estudiante=@id_estudiante;";

        public Estudiante SelectByID(Estudiante reg)
        {
            using (SqlCommand cmd = new SqlCommand(SelectStringByID, ConectionDB.Instance))
            {

                cmd.Parameters.AddWithValue("@id_estudiante", reg.IDRegistro);

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
                    double notaGrado = reader.GetDouble(reader.GetOrdinal("nota_grado"));
                    int idPersona = reader.GetInt32(reader.GetOrdinal("id_persona"));
                    DateTime fechaNacimiento = reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento"));

                    Estudiante estudianteBuscado =
                        new Estudiante(
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
                            notaGrado,
                            fechaNacimiento);

                    return estudianteBuscado;
                }
            }
        }

        private const string SelectAllString =
            "SELECT id_estudiante, estudiantes.id_persona, nota_grado, numero_documento, nombres, " +
            "apellidos, fecha_nacimiento, genero, tipo_documento, domicilio, provincia, ciudad " +
            "FROM estudiantes " +
            "INNER JOIN personas ON estudiantes.id_persona = personas.id_persona;";

        public List<Estudiante> SelectAll()
        {
            List<Estudiante> list = new List<Estudiante>();

            using (SqlCommand cmd = new SqlCommand(SelectAllString, ConectionDB.Instance))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return list;

                    while (reader.Read())
                    {
                        bool genero = reader.GetBoolean(reader.GetOrdinal("genero"));
                        string ciudad = reader.GetString(reader.GetOrdinal("ciudad"));
                        string tipoDocumento = reader.GetString(reader.GetOrdinal("tipo_documento"));
                        string numeroDocumento = reader.GetString(reader.GetOrdinal("numero_documento"));
                        string nombres = reader.GetString(reader.GetOrdinal("nombres"));
                        string apellidos = reader.GetString(reader.GetOrdinal("apellidos"));
                        string domicilio = reader.GetString(reader.GetOrdinal("domicilio"));
                        string provincia = reader.GetString(reader.GetOrdinal("provincia"));
                        double notaGrado = reader.GetDouble(reader.GetOrdinal("nota_grado"));
                        int idPersona = reader.GetInt32(reader.GetOrdinal("id_persona"));
                        int idEstudiante = reader.GetInt32(reader.GetOrdinal("id_estudiante"));
                        DateTime fechaNacimiento = reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento"));

                        Estudiante estudianteBuscado =
                        new Estudiante(
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
                            notaGrado,
                            fechaNacimiento);

                        list.Add(estudianteBuscado);
                    }
                }
            }

            return list;
        }

        private const string UpdateString =
            "UPDATE estudiantes SET " +
            "nota_grado=@nota_grado " +
            "WHERE id_estudiante=@id_estudiante;" +

            "UPDATE personas SET " +
            "domicilio=@domicilio, provincia=@provincia, ciudad=@ciudad " +
            "WHERE id_persona=@id_persona;";

        public void Update(Estudiante reg)
        {
            using (SqlCommand cmd = new SqlCommand(UpdateString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@ciudad", reg.Ciudad);
                cmd.Parameters.AddWithValue("@domicilio", reg.Domicilio);
                cmd.Parameters.AddWithValue("@provincia", reg.Provincia);
                cmd.Parameters.AddWithValue("@nota_grado", reg.NotaGrado);
                cmd.Parameters.AddWithValue("@id_persona", reg.IDPersona);
                cmd.Parameters.AddWithValue("@id_estudiante", reg.IDRegistro);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
