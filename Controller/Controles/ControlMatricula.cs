using Model.Database;
using Model.Entity;
using System.Windows.Forms;

namespace Controller.Controles
{
    public class ControlMatricula
    {
        public void DeleteEvent(int id)
        {
            DAO.Delete(
                new Matricula(id));
        }

        public void InsertEvent(object estudiante, object asignatura)
        {
            Estudiante est = estudiante as Estudiante;
            Asignatura asig = asignatura as Asignatura;

            DAO.Insert(
                new Matricula(est.IDRegistro,asig.IDRegistro));
        }

        public void SelectEvent(int id)
        {
            registro = DAO.Select(
                new Matricula(id));

            if (registro != null)
                MessageBox.Show("Registro encontrado: Ingrese los nuevos datos");
            else
                MessageBox.Show("No ha encontrado ningún registro");
        }

        public void UpdateEvent(object estudiante, object asignatura)
        {
            if (registro == null)
            {
                MessageBox.Show("No ha seleccionado ningún registro");
                return;
            }

            Estudiante est = estudiante as Estudiante;
            Asignatura asig = asignatura as Asignatura;

            DAO.Update(new Matricula(
                registro.IDRegistro, est.IDRegistro, asig.IDRegistro));

            registro = null;
        }

        private Matricula registro = null;
        private MatriculaDAO DAO = new MatriculaDAO();
    }
}
