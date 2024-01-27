using Controller.Documento;
using Model;
using Model.Database;
using Model.Entity;
using System.Windows.Forms;

namespace Controller.Controles
{
    public class ControlGrid
    {
        public static void LlenarGrid(DataGridView grid, TypeData type)
        {
            grid.Rows.Clear();

            switch (type)
            {
                case TypeData.Profesor:

                    foreach (Profesor p in new ProfesorDAO().SelectAll())
                    {
                        int index = grid.Rows.Add();

                        grid.Rows[index].Cells["id"].Value = p.IDRegistro;
                        grid.Rows[index].Cells["ciudad"].Value = p.Ciudad;
                        grid.Rows[index].Cells["genero"].Value = p.Genero ? "Hombre" : "Mujer";
                        grid.Rows[index].Cells["nombre"].Value = p.Nombres;
                        grid.Rows[index].Cells["apellido"].Value = p.Apellidos;
                        grid.Rows[index].Cells["provincia"].Value = p.Provincia;
                        grid.Rows[index].Cells["titulo"].Value = p.Titulo;
                        grid.Rows[index].Cells["domicilio"].Value = p.Domicilio;
                        grid.Rows[index].Cells["tipoDocumento"].Value = p.TipoDocumento;
                        grid.Rows[index].Cells["numeroDocumento"].Value = p.NumeroDocumento;
                        grid.Rows[index].Cells["fechaNacimiento"].Value = p.FechaNacimiento;
                    }

                    break;

                case TypeData.Matricula:

                    foreach (Matricula p in new MatriculaDAO().SelectAll())
                    {
                        int index = grid.Rows.Add();
                        
                        Asignatura a = new AsignaturaDAO().Select(new Asignatura(p.IDAsignatura));
                        Estudiante e = new EstudianteDAO().SelectByID(new Estudiante(p.IDEstudiante));

                        grid.Rows[index].Cells["id"].Value = p.IDRegistro;
                        grid.Rows[index].Cells["asignatura"].Value = a.Nombre;
                        grid.Rows[index].Cells["estudiante"].Value = e.Nombres + " " + e.Apellidos;
                    }

                    break;

                case TypeData.Asignatura:

                    foreach (Asignatura a in new AsignaturaDAO().SelectAll())
                    {
                        int index = grid.Rows.Add();

                        Profesor p = new ProfesorDAO().SelectByID(new Profesor(a.IDProfesor));

                        grid.Rows[index].Cells["id"].Value = a.IDRegistro;
                        grid.Rows[index].Cells["nombre"].Value = a.Nombre;
                        grid.Rows[index].Cells["creditos"].Value = a.Creditos;
                        grid.Rows[index].Cells["tiempoHoras"].Value = a.TiempoHoras;
                        grid.Rows[index].Cells["profesor"].Value = p.Nombres + " " + p.Apellidos;
                        grid.Rows[index].Cells["componenteAutonomo"].Value = a.ComponenteAutonomo;
                        grid.Rows[index].Cells["componenteParticipacion"].Value = a.ComponenteParticipacion;
                    }

                    break;

                case TypeData.Estudiante:

                    foreach (Estudiante e in new EstudianteDAO().SelectAll())
                    {
                        int index = grid.Rows.Add();

                        grid.Rows[index].Cells["id"].Value = e.IDRegistro;
                        grid.Rows[index].Cells["ciudad"].Value = e.Ciudad;
                        grid.Rows[index].Cells["genero"].Value = e.Genero ? "Hombre" : "Mujer";
                        grid.Rows[index].Cells["nombre"].Value = e.Nombres;
                        grid.Rows[index].Cells["apellido"].Value = e.Apellidos;
                        grid.Rows[index].Cells["provincia"].Value = e.Provincia;
                        grid.Rows[index].Cells["notaGrado"].Value = e.NotaGrado;
                        grid.Rows[index].Cells["domicilio"].Value = e.Domicilio;
                        grid.Rows[index].Cells["tipoDocumento"].Value = e.TipoDocumento;
                        grid.Rows[index].Cells["numeroDocumento"].Value = e.NumeroDocumento;
                        grid.Rows[index].Cells["fechaNacimiento"].Value = e.FechaNacimiento;
                    }

                    break;
            }
        }
    }
}
