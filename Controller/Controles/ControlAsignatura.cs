using Model;
using Model.Entity;
using System;
using System.Windows.Forms;

namespace Controller.Controles
{
    public class ControlAsignatura
    {
        public void DeleteEvent(int id)
        {
            DAO.Delete(new Asignatura(id));
        }

        public void InsertEvent(string nombre, int creditos, int tiempoHoras, int componenteAutonomo, int componenteParticipacion, object profesor)
        {
            Profesor p = profesor as Profesor;

            DAO.Insert
                (new Asignatura(
                    nombre,
                    creditos,
                    tiempoHoras,
                    p.IDRegistro,
                    componenteAutonomo,
                    componenteParticipacion));
        }

        public void SelectEvent(int id)
        {
            register = DAO.Select(new Asignatura(id));

            if (register == null)
                MessageBox.Show("No ha encontrado ningún registro");
        }

        public void UpdateEvent(string nombre, int creditos, int tiempoHoras, int componenteAutonomo, int componenteParticipacion, object profesor)
        {
            if (register == null)
            {
                MessageBox.Show("No ha seleccionado ningún registro");
                return;
            }

            Profesor p = profesor as Profesor;

            DAO.Update
                (new Asignatura(
                    register.IDRegistro,
                    nombre,
                    creditos,
                    tiempoHoras,
                    p.IDRegistro,
                    componenteAutonomo,
                    componenteParticipacion));

            register = null;
        }

        private Asignatura register = null;
        private readonly AsignaturaDAO DAO = new AsignaturaDAO();
    }
}
