using Data;
using Model.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model
{
    public class AsignaturaDAO
    {
        private const string SelectString =
            "SELECT nombre, creditos, componente_autonomo, componente_participacion, tiempo_horas, id_profesor " +
            "FROM asignaturas " +
            "WHERE id_asignatura = @id_asignatura;";

        public Asignatura Select(Asignatura reg)
        {
            using (SqlCommand cmd = new SqlCommand(SelectString, ConectionDB.Instance))
            {

                cmd.Parameters.AddWithValue("@id_asignatura", reg.IDRegistro);

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    reader.Read();

                    string nombre = reader.GetString(reader.GetOrdinal("nombre"));
                    int creditos = reader.GetInt32(reader.GetOrdinal("creditos"));
                    int idProfesor = reader.GetInt32(reader.GetOrdinal("id_profesor"));
                    int totalHoras = reader.GetInt32(reader.GetOrdinal("tiempo_horas"));
                    int componenteAutonomo = reader.GetInt32(reader.GetOrdinal("componente_autonomo"));
                    int componenteParticipacion = reader.GetInt32(reader.GetOrdinal("componente_participacion"));

                    Asignatura asignaturaBuscada = new Asignatura(reg.IDRegistro, nombre, creditos, totalHoras, idProfesor, componenteAutonomo, componenteParticipacion);

                    return asignaturaBuscada;
                }
            }
        }

        private const string InsertString =
            "INSERT INTO asignaturas" +
            "(nombre, creditos, componente_autonomo, componente_participacion, tiempo_horas, id_profesor) VALUES " +
            "(@nombre, @creditos, @componente_autonomo, @componente_participacion, @tiempo_horas, @id_profesor);";

        public void Insert(Asignatura reg)
        {
            using (SqlCommand cmd = new SqlCommand(InsertString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@creditos", reg.Creditos);
                cmd.Parameters.AddWithValue("@id_profesor", reg.IDProfesor);
                cmd.Parameters.AddWithValue("@tiempo_horas", reg.TiempoHoras);
                cmd.Parameters.AddWithValue("@componente_autonomo", reg.ComponenteAutonomo);
                cmd.Parameters.AddWithValue("@componente_participacion", reg.ComponenteParticipacion);

                cmd.ExecuteNonQuery();
            }
        }

        private const string DeleteString =
            "DELETE FROM asignaturas " +
            "WHERE id_asignatura=@id_asignatura";

        public void Delete(Asignatura reg)
        {
            using (SqlCommand cmd = new SqlCommand(DeleteString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@id_asignatura", reg.IDRegistro);

                cmd.ExecuteNonQuery();
            }
        }

        private const string UpdateString =
            "UPDATE asignaturas SET " +
            "nombre=@nombre, creditos=@creditos, componente_autonomo=@componente_autonomo, " +
            "componente_participacion=@componente_participacion, tiempo_horas=@tiempo_horas, id_profesor=@id_profesor " +
            "WHERE id_asignatura=@id_asignatura;";

        public void Update(Asignatura reg)
        {
            using (SqlCommand cmd = new SqlCommand(UpdateString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@creditos", reg.Creditos);
                cmd.Parameters.AddWithValue("@id_profesor", reg.IDProfesor);
                cmd.Parameters.AddWithValue("@id_asignatura", reg.IDRegistro);
                cmd.Parameters.AddWithValue("@tiempo_horas", reg.TiempoHoras);
                cmd.Parameters.AddWithValue("@componente_autonomo", reg.ComponenteAutonomo);
                cmd.Parameters.AddWithValue("@componente_participacion", reg.ComponenteParticipacion);

                cmd.ExecuteNonQuery();
            }
        }

        private const string SelectAllString =
            "SELECT id_asignatura, nombre, creditos, componente_autonomo, componente_participacion, tiempo_horas, id_profesor " + 
            "FROM asignaturas;";

        public List<Asignatura> SelectAll()
        {
            List<Asignatura> list = new List<Asignatura>();

            using (SqlCommand cmd = new SqlCommand(SelectAllString, ConectionDB.Instance))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return list;

                    while (reader.Read())
                    {
                        string nombre = reader.GetString(reader.GetOrdinal("nombre"));
                        int id = reader.GetInt32(reader.GetOrdinal("id_asignatura"));
                        int creditos = reader.GetInt32(reader.GetOrdinal("creditos"));
                        int idProfesor = reader.GetInt32(reader.GetOrdinal("id_profesor"));
                        int totalHoras = reader.GetInt32(reader.GetOrdinal("tiempo_horas"));
                        int componenteAutonomo = reader.GetInt32(reader.GetOrdinal("componente_autonomo"));
                        int componenteParticipacion = reader.GetInt32(reader.GetOrdinal("componente_participacion"));

                        Asignatura asignatura = new Asignatura(id, nombre, creditos, totalHoras, idProfesor, componenteAutonomo, componenteParticipacion);

                        list.Add(asignatura);
                    }
                }
            }

            return list;
        }
    }
}
