using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Model.Database;
using Model.Entity;
using Model;

namespace Controller.Documento
{
    public class ControlDocument
    {
        public void ConfirmSavePDF(DataGridView grid, TypeData type)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Portable Document Formant (*.pdf)|*.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<int> ids = new List<int>();

                foreach (DataGridViewRow item in grid.Rows)
                {
                    if (!item.Visible)
                    {
                        continue;
                    }

                    ids.Add(Convert.ToInt32(item.Cells[0].Value));
                }

                try
                {
                    stream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    document = new Document(PageSize.A4, 15, 15, 10, 10);
                    PdfWriter pdf = PdfWriter.GetInstance(document, stream);

                    document.Open();

                    switch (type)
                    {
                        case TypeData.Asignatura:
                            ExportAsignaturaPDF(ids, document);
                            break;
                        case TypeData.Profesor:
                            ExportProfesorPDF(ids, document);
                            break;
                        case TypeData.Estudiante:
                            ExportEstudiantePDF(ids, document);
                            break;
                        case TypeData.Matricula:
                            ExportMatriculaPDF(ids, document);
                            break;
                    }

                    document.Close();
                    pdf.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error al generar el PDF: {e.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    stream?.Close();
                }
            }
        }

        private void ExportEstudiantePDF(List<int> ids, Document document)
        {
            Font font = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.NORMAL);
            document.Add(new Paragraph("Consulta de Datos de Empleados."));
            document.Add(Chunk.NEWLINE);

            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 80;

            PdfPCell colNombre = new PdfPCell(new Phrase("Nombres", font));
            colNombre.BorderWidth = 0;
            colNombre.BorderWidthBottom = 0.25f;

            PdfPCell colApellido = new PdfPCell(new Phrase("Apellidos", font));
            colApellido.BorderWidth = 0;
            colApellido.BorderWidthBottom = 0.25f;

            PdfPCell colGenero = new PdfPCell(new Phrase("Genero", font));
            colGenero.BorderWidth = 0;
            colGenero.BorderWidthBottom = 0.25f;

            PdfPCell colNotaGrado = new PdfPCell(new Phrase("Nota de grado", font));
            colNotaGrado.BorderWidth = 0;
            colNotaGrado.BorderWidthBottom = 0.25f;

            PdfPCell colFechaNacimiento = new PdfPCell(new Phrase("Fecha de nacimiento", font));
            colFechaNacimiento.BorderWidth = 0;
            colFechaNacimiento.BorderWidthBottom = 0.25f;

            table.AddCell(colNombre);
            table.AddCell(colApellido);
            table.AddCell(colGenero);
            table.AddCell(colNotaGrado);
            table.AddCell(colFechaNacimiento);

            List<Estudiante> list = new EstudianteDAO().SelectAll();

            foreach (Estudiante emp in list)
            {
                if (!ids.Contains(emp.IDRegistro))
                    continue;

                colNombre = new PdfPCell(new Phrase(emp.Nombres, font));
                colNombre.BorderWidth = 0;

                colApellido = new PdfPCell(new Phrase(emp.Apellidos, font));
                colApellido.BorderWidth = 0;

                colGenero = new PdfPCell(new Phrase(emp.Genero ? "Hombre" : "Mujer", font));
                colGenero.BorderWidth = 0;

                colNotaGrado = new PdfPCell(new Phrase(emp.NotaGrado.ToString(), font));
                colFechaNacimiento.BorderWidth = 0;

                colFechaNacimiento = new PdfPCell(new Phrase(emp.FechaNacimiento.ToShortDateString()));
                colNotaGrado.BorderWidth = 0;

                table.AddCell(colNombre);
                table.AddCell(colApellido);
                table.AddCell(colGenero);
                table.AddCell(colNotaGrado);
                table.AddCell(colFechaNacimiento);
            }

            document.Add(table);
        }

        private void ExportAsignaturaPDF(List<int> ids, Document document)
        {
            Font font = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.NORMAL);
            document.Add(new Paragraph("Consulta de Datos de Empleados."));
            document.Add(Chunk.NEWLINE);

            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 80;

            PdfPCell colNombre = new PdfPCell(new Phrase("Nombre", font));
            colNombre.BorderWidth = 0;
            colNombre.BorderWidthBottom = 0.25f;

            PdfPCell colTotalHoras = new PdfPCell(new Phrase("Total horas", font));
            colTotalHoras.BorderWidth = 0;
            colTotalHoras.BorderWidthBottom = 0.25f;

            PdfPCell colCreditos = new PdfPCell(new Phrase("Créditos", font));
            colCreditos.BorderWidth = 0;
            colCreditos.BorderWidthBottom = 0.25f;

            PdfPCell colProfeosr = new PdfPCell(new Phrase("ID del profesor", font));
            colProfeosr.BorderWidth = 0;
            colProfeosr.BorderWidthBottom = 0.25f;

            table.AddCell(colNombre);
            table.AddCell(colTotalHoras);
            table.AddCell(colCreditos);
            table.AddCell(colProfeosr);

            List<Asignatura> list = new AsignaturaDAO().SelectAll();

            foreach (Asignatura emp in list)
            {
                if (!ids.Contains(emp.IDRegistro))
                    continue;

                colNombre = new PdfPCell(new Phrase(emp.Nombre, font));
                colNombre.BorderWidth = 0;

                colTotalHoras = new PdfPCell(new Phrase(emp.TiempoHoras.ToString(), font));
                colTotalHoras.BorderWidth = 0;

                colCreditos = new PdfPCell(new Phrase(emp.Creditos.ToString(), font));
                colCreditos.BorderWidth = 0;

                colProfeosr = new PdfPCell(new Phrase(emp.IDProfesor.ToString(), font));
                colProfeosr.BorderWidth = 0;

                table.AddCell(colNombre);
                table.AddCell(colTotalHoras);
                table.AddCell(colCreditos);
                table.AddCell(colProfeosr);
            }

            document.Add(table);
        }

        private void ExportMatriculaPDF(List<int> ids, Document document)
        {
            Font font = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.NORMAL);
            document.Add(new Paragraph("Consulta de Datos de Empleados."));
            document.Add(Chunk.NEWLINE);

            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 80;

            PdfPCell colID = new PdfPCell(new Phrase("ID", font));
            colID.BorderWidth = 0;
            colID.BorderWidthBottom = 0.25f;

            PdfPCell colEstudiante = new PdfPCell(new Phrase("ID estudiante", font));
            colEstudiante.BorderWidth = 0;
            colEstudiante.BorderWidthBottom = 0.25f;

            PdfPCell colAsignatura = new PdfPCell(new Phrase("ID asignatura", font));
            colAsignatura.BorderWidth = 0;
            colAsignatura.BorderWidthBottom = 0.25f;

            table.AddCell(colID);
            table.AddCell(colEstudiante);
            table.AddCell(colAsignatura);

            List<Matricula> list = new MatriculaDAO().SelectAll();

            foreach (Matricula emp in list)
            {
                if (!ids.Contains(emp.IDRegistro))
                    continue;

                colID = new PdfPCell(new Phrase(emp.IDRegistro.ToString(), font));
                colID.BorderWidth = 0;

                colEstudiante = new PdfPCell(new Phrase(emp.IDEstudiante.ToString(), font));
                colEstudiante.BorderWidth = 0;

                colAsignatura = new PdfPCell(new Phrase(emp.IDAsignatura.ToString(), font));
                colAsignatura.BorderWidth = 0;

                table.AddCell(colID);
                table.AddCell(colEstudiante);
                table.AddCell(colAsignatura);
            }

            document.Add(table);
        }

        private void ExportProfesorPDF(List<int> ids, Document document)
        {
            Font font = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.NORMAL);
            document.Add(new Paragraph("Consulta de Datos de Empleados."));
            document.Add(Chunk.NEWLINE);

            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 80;

            PdfPCell colNombre = new PdfPCell(new Phrase("Nombres", font));
            colNombre.BorderWidth = 0;
            colNombre.BorderWidthBottom = 0.25f;

            PdfPCell colApellido = new PdfPCell(new Phrase("Apellidos", font));
            colApellido.BorderWidth = 0;
            colApellido.BorderWidthBottom = 0.25f;

            PdfPCell colGenero = new PdfPCell(new Phrase("Genero", font));
            colGenero.BorderWidth = 0;
            colGenero.BorderWidthBottom = 0.25f;

            PdfPCell colTitulo = new PdfPCell(new Phrase("Título", font));
            colTitulo.BorderWidth = 0;
            colTitulo.BorderWidthBottom = 0.25f;

            PdfPCell colFechaNacimiento = new PdfPCell(new Phrase("Edad", font));
            colFechaNacimiento.BorderWidth = 0;
            colFechaNacimiento.BorderWidthBottom = 0.25f;

            table.AddCell(colNombre);
            table.AddCell(colApellido);
            table.AddCell(colGenero);
            table.AddCell(colTitulo);
            table.AddCell(colFechaNacimiento);

            List<Profesor> list = new ProfesorDAO().SelectAll();

            foreach (Profesor emp in list)
            {
                if (!ids.Contains(emp.IDRegistro))
                    continue;

                colNombre = new PdfPCell(new Phrase(emp.Nombres, font));
                colNombre.BorderWidth = 0;

                colApellido = new PdfPCell(new Phrase(emp.Apellidos, font));
                colApellido.BorderWidth = 0;

                colGenero = new PdfPCell(new Phrase(emp.Genero ? "Hombre" : "Mujer", font));
                colGenero.BorderWidth = 0;

                colTitulo = new PdfPCell(new Phrase(emp.Titulo, font));
                colFechaNacimiento.BorderWidth = 0;

                colFechaNacimiento = new PdfPCell(new Phrase(emp.FechaNacimiento.ToShortDateString()));
                colTitulo.BorderWidth = 0;

                table.AddCell(colNombre);
                table.AddCell(colApellido);
                table.AddCell(colGenero);
                table.AddCell(colTitulo);
                table.AddCell(colFechaNacimiento);
            }

            document.Add(table);
        }

        private Document document = null;
        private FileStream stream = null;
    }
}
