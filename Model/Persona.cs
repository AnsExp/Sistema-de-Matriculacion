using System;

namespace Model.Entity
{
    public abstract class Persona : Registrable
    {
        public bool Genero { get; set;  }
        public string Ciudad { get; set; }
        public string Nombres { get; set; }
        public int IDPersona {  get; set; }
        public string Apellidos { get; set; }
        public string Provincia { get; set; }
        public string Domicilio { get; set; }
        public string TipoDocumento {  get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
