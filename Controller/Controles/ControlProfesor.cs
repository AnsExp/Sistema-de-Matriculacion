using Model.Database;
using Model.Entity;
using System;
using System.Windows.Forms;

namespace Controller.Controles
{
    public class ControlProfesor
    {

        public void InsertEvent(string nombres, string apellidos, bool genero, string domicilio, string provincia, string ciudad, string tipoDocumento, string numeroDocumento, string titulo, DateTime fechaNacimiento)
        {
            DataAccess.Insert(
                new Profesor(
                    nombres,
                    apellidos,
                    0,
                    genero,
                    domicilio,
                    provincia,
                    ciudad,
                    tipoDocumento,
                    numeroDocumento,
                    titulo,
                    fechaNacimiento));
        }

        public void DeleteEvent(string tipoDocumento, string numeroDocumento)
        {
            DataAccess.Delete(
                new Profesor(
                    tipoDocumento,
                    numeroDocumento));
        }

        public void SelectEvent(string tipoDocumento, string numeroDocumento)
        {
            registro = DataAccess.Select(
                new Profesor(
                    tipoDocumento,
                    numeroDocumento));

            if (registro != null)
                MessageBox.Show("Registro encontrado: Ingrese los nuevos datos");
            else
                MessageBox.Show("No ha encontrado ningún registro");
        }

        public void UpdateEvent(string domicilio, string provincia, string ciudad, string titulo)
        {
            if (registro == null)
            {
                MessageBox.Show("No ha seleccionado ningún registro");
                return;
            }

            DataAccess.Update(
                new Profesor(
                    registro.IDRegistro,
                    null,
                    null,
                    registro.IDPersona,
                    false,
                    domicilio,
                    provincia,
                    ciudad,
                    registro.TipoDocumento,
                    registro.NumeroDocumento,
                    titulo,
                    DateTime.Now));

            registro = null;
        }

        private Profesor registro = null;
        private ProfesorDAO DataAccess = new ProfesorDAO();
    }
}
