using Model.Database;
using Model.Entity;
using System;
using System.Windows.Forms;

namespace Controller.Controles
{
    public class ControlEstudiante
    {
        public void DeleteEvent(string tipoDocumento, string numeroDocumento)
        {
            DAO.Delete(
                new Estudiante(
                    tipoDocumento,
                    numeroDocumento));
        }

        public void InsertEvent(string nombres, string apellidos, bool genero, string domicilio, string provincia, string ciudad, string tipoDocumento, string numeroDocumento, double notaGrado, DateTime fechaNacimiento)
        {
            DAO.Insert(
                new Estudiante(
                    nombres,
                    apellidos,
                    0,
                    genero,
                    domicilio,
                    provincia,
                    ciudad,
                    tipoDocumento,
                    numeroDocumento,
                    notaGrado,
                    fechaNacimiento));
        }

        public void SelectEvent(string tipoDocumento, string numeroDocumento)
        {
            registro = DAO.Select(
                new Estudiante(
                    tipoDocumento,
            numeroDocumento));

            if (registro != null)
                MessageBox.Show("Registro encontrado: Ingrese los nuevos datos");
            else
                MessageBox.Show("No ha encontrado ningún registro");
        }

        public void UpdateEvent(string domicilio, string provincia, string ciudad, double notaGrado)
        {
            if (registro == null)
            {
                MessageBox.Show("No ha seleccionado ningún registro");
                return;
            }

            DAO.Update(
                new Estudiante(
                    registro.IDRegistro,
                    null,
                    null,
                    registro.IDPersona,
                    false,
                    domicilio,
                    provincia,
                    ciudad,
                    null,
                    null,
                    notaGrado,
                    DateTime.Now));

            registro = null;
        }

        private Estudiante registro = null;
        private EstudianteDAO DAO = new EstudianteDAO();
    }
}
