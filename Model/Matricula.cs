namespace Model.Entity
{
    public class Matricula : Registrable
    {
        public Matricula() { }

        public Matricula(int id)
        {
            IDRegistro = id;
        }

        public Matricula(int idEstudiante, int idAsignatura)
        {
            IDEstudiante = idEstudiante;
            IDAsignatura = idAsignatura;
        }

        public Matricula(int id, int idEstudiante, int idAsignatura)
        {
            IDRegistro = id;
            IDEstudiante = idEstudiante;
            IDAsignatura = idAsignatura;
        }

        public int IDEstudiante { get; set; }
        public int IDAsignatura { get; set; }
    }
}
