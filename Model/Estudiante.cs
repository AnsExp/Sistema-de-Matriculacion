using System;

namespace Model.Entity
{
    public class Estudiante : Persona
    {
        public Estudiante() { }

        public Estudiante(int id)
        {
            IDRegistro = id;
        }

        public Estudiante(
            string tipoDocumento,
            string numeroDocumento)
        {
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
        }

        public Estudiante(
            string nombres,
            string apellidos,
            int idPersona,
            bool genero,
            string domicilio,
            string provincia,
            string ciudad,
            string tipoDocumento,
            string numeroDocumento,
            double notaGrado,
            DateTime fechaNacimiento)
        {
            Ciudad = ciudad;
            Genero = genero;
            Nombres = nombres;
            NotaGrado = notaGrado;
            IDPersona = idPersona;
            Apellidos = apellidos;
            Domicilio = domicilio;
            Provincia = provincia;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            FechaNacimiento = fechaNacimiento;
        }

        public Estudiante(
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
            double notaGrado,
            DateTime fechaNacimiento)
        {
            IDRegistro = id;
            Ciudad = ciudad;
            Genero = genero;
            Nombres = nombres;
            NotaGrado = notaGrado;
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

        public double NotaGrado { get; set; }
    }
}
