using System;

namespace Model.Entity
{
    public class Profesor : Persona
    {
        public Profesor() { }

        public Profesor(int id)
        {
            IDRegistro = id;
        }

        public Profesor(
            string tipoDocumento,
            string numeroDocumento)
        {
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
        }

        public Profesor(
            string nombres,
            string apellidos,
            int idPersona,
            bool genero,
            string domicilio,
            string provincia,
            string ciudad,
            string tipoDocumento,
            string numeroDocumento,
            string titulo,
            DateTime fechaNacimiento)
        {
            Ciudad = ciudad;
            Genero = genero;
            Titulo = titulo;
            Nombres = nombres;
            IDPersona = idPersona;
            Apellidos = apellidos;
            Domicilio = domicilio;
            Provincia = provincia;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            FechaNacimiento = fechaNacimiento;
        }

        public Profesor(
            int id,
            string nombres,
            string apellidos,
            int idPersona,
            bool genero,
            string domicilio,
            string provincia,
            string ciudad,
            string tipoDocumento,
            string numeroDocumento,
            string titulo,
            DateTime fechaNacimiento)
        {
            IDRegistro = id;
            Ciudad = ciudad;
            Genero = genero;
            Titulo = titulo;
            Nombres = nombres;
            IDPersona = idPersona;
            Apellidos = apellidos;
            Domicilio = domicilio;
            Provincia = provincia;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            FechaNacimiento = fechaNacimiento;
        }

        public string Display { get { return Nombres + " " + Apellidos; } }

        public override string ToString()
        {
            return Display;
        }

        public string Titulo { get; set; }
    }
}
