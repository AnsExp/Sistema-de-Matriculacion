using Model;
using Model.Database;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controller.Documento
{
    public enum TypeData
    {
        Asignatura,
        Profesor,
        Matricula,
        Estudiante
    }

    public sealed class ComboComand
    {
        private ComboComand() { }

        public static void FillCombo(ComboBox combo, TypeData type)
        {
            switch (type)
            {
                case TypeData.Profesor:

                    combo.DataSource = new ProfesorDAO().SelectAll();
                    break;

                case TypeData.Matricula:

                    combo.DataSource = new MatriculaDAO().SelectAll();
                    break;

                case TypeData.Asignatura:

                    combo.DataSource = new AsignaturaDAO().SelectAll();
                    break;

                case TypeData.Estudiante:

                    combo.DataSource = new EstudianteDAO().SelectAll();
                    break;
            }

            combo.DisplayMember = "Display";
        }
    }
}
