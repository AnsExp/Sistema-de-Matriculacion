namespace Model.Entity
{
    public class Asignatura : Registrable
    {
        public Asignatura() { }

        public Asignatura(int id)
        {
            IDRegistro = id;
        }

        public Asignatura(
            string nombre,
            int creditos,
            int totalHoras,
            int idProfesor,
            int componenteAutonomo,
            int componenteParticipacion)
        {
            Nombre = nombre;
            Creditos = creditos;
            TiempoHoras = totalHoras;
            IDProfesor = idProfesor;
            ComponenteAutonomo = componenteAutonomo;
            ComponenteParticipacion = componenteParticipacion;
        }

        public Asignatura(
            int id,
            string nombre,
            int creditos,
            int totalHoras,
            int idProfesor,
            int componenteAutonomo,
            int componenteParticipacion)
        {
            IDRegistro = id;
            Nombre = nombre;
            Creditos = creditos;
            TiempoHoras = totalHoras;
            IDProfesor = idProfesor;
            ComponenteAutonomo = componenteAutonomo;
            ComponenteParticipacion = componenteParticipacion;
        }
        
        public string Display { get { return Nombre; } }

        public override string ToString()
        {
            return Display;
        }

        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int IDProfesor { get; set; }
        public int TiempoHoras { get; set; }
        public int ComponenteAutonomo { get; set; }
        public int ComponenteParticipacion { get; set; }
    }
}
