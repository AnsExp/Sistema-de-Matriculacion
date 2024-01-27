using Data;
using Model.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Database
{
    public class MatriculaDAO
    {
        private const string SelectString =
            "SELECT id_estudiante, id_asignatura " +
            "FROM matriculas " +
            "WHERE id_matricula=@id_matricula;";

        public Matricula Select(Matricula reg)
        {
            using (SqlCommand cmd = new SqlCommand(SelectString, ConectionDB.Instance))
            {

                cmd.Parameters.AddWithValue("@id_matricula", reg.IDRegistro);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    reader.Read();

                    int idEstudiante = reader.GetInt32(reader.GetOrdinal("id_estudiante"));
                    int idAsignatura = reader.GetInt32(reader.GetOrdinal("id_asignatura"));

                    Matricula matriculaEncontrada = new Matricula(reg.IDRegistro, idEstudiante, idAsignatura);

                    return matriculaEncontrada;
                }
            }
        }

        private const string InsertString =
            "INSERT INTO matriculas " +
            "(id_estudiante, id_asignatura) VALUES " +
            "(@id_estudiante, @id_asignatura);";

        public void Insert(Matricula reg)
        {
            using (SqlCommand cmd = new SqlCommand(InsertString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@id_estudiante", reg.IDEstudiante);
                cmd.Parameters.AddWithValue("@id_asignatura", reg.IDAsignatura);

                cmd.ExecuteNonQuery();
            }
        }

        private const string DeleteString =
            "DELETE FROM matriculas " +
            "WHERE id_matricula=@id_matricula";

        public void Delete(Matricula reg)
        {
            using (SqlCommand cmd = new SqlCommand(DeleteString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@id_matricula", reg.IDRegistro);

                cmd.ExecuteNonQuery();
            }
        }

        private const string UpdateString =
            "UPDATE matriculas SET " +
            "id_estudiante=@id_estudiante, id_asignatura=@id_asignatura " +
            "WHERE id_matricula=@id_matricula;";

        public void Update(Matricula reg)
        {
            using (SqlCommand cmd = new SqlCommand(UpdateString, ConectionDB.Instance))
            {
                cmd.Parameters.AddWithValue("@id_matricula", reg.IDRegistro);
                cmd.Parameters.AddWithValue("@id_estudiante", reg.IDEstudiante);
                cmd.Parameters.AddWithValue("@id_asignatura", reg.IDAsignatura);

                cmd.ExecuteNonQuery();
            }
        }

        private const string SelectAllString =
            "SELECT id_matricula, id_estudiante, id_asignatura " +
            "FROM matriculas;";

        public List<Matricula> SelectAll()
        {
            List<Matricula> list = new List<Matricula>();

            using (SqlCommand cmd = new SqlCommand(SelectAllString, ConectionDB.Instance))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return list;

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("id_matricula"));
                        int idEstudiante = reader.GetInt32(reader.GetOrdinal("id_estudiante"));
                        int idAsignatura = reader.GetInt32(reader.GetOrdinal("id_asignatura"));

                        Matricula matriculaEncontrada = new Matricula(id, idEstudiante, idAsignatura);

                        list.Add(matriculaEncontrada);
                    }
                }
            }

            return list;
        }
    }
}
