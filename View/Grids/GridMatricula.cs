using Controller.Controles;
using Controller.Documento;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Grids
{
    internal class GridMatricula : TableLayoutPanel
    {
        public DataGridView GetGrid
        {
            get
            {
                return grid;
            }
        }

        private readonly DataGridView grid = new DataGridView { Dock = DockStyle.Fill };
        private readonly Label lblFiltro = new Label { Dock = DockStyle.Fill, Text = "Filtrar por:", TextAlign = ContentAlignment.MiddleRight };

        private readonly Button
            btnLlenarTabla = new Button { Dock = DockStyle.Fill, Text = "Actualizar Tabla" },
            btnAplicarFiltro = new Button { Dock = DockStyle.Fill, Text = "Aplicar" };

        private readonly ComboBox
            cmbFiltro = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList },
            cmbFiltroEstudiante = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList },
            cmbFiltroAsignatura = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

        private readonly DataGridViewTextBoxColumn
            idColumn = new DataGridViewTextBoxColumn { HeaderText = "ID", Name = "id" },
            estudianteColumn = new DataGridViewTextBoxColumn { HeaderText = "Estudiante", Name = "estudiante" },
            asignaturaColumn = new DataGridViewTextBoxColumn { HeaderText = "Asignatura", Name = "asignatura" };

        internal GridMatricula()
        {
            RowCount = 2;
            ColumnCount = 5;
            Dock = DockStyle.Fill;

            RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            Controls.Add(lblFiltro, 0, 0);
            Controls.Add(cmbFiltro, 1, 0);
            Controls.Add(btnAplicarFiltro, 3, 0);
            Controls.Add(btnLlenarTabla, 4, 0);
            Controls.Add(grid, 0, 1);

            SetColumnSpan(grid, 5);

            cmbFiltro.DataSource = new string[] { "Estudiante", "Asignatura" };
            ComboComand.FillCombo(cmbFiltroEstudiante, TypeData.Estudiante);
            ComboComand.FillCombo(cmbFiltroAsignatura, TypeData.Asignatura);

            grid.Columns.AddRange
                (idColumn,
                estudianteColumn,
                asignaturaColumn);

            ControlGrid.LlenarGrid(grid, TypeData.Matricula);

            grid.AllowUserToAddRows = false;
            btnAplicarFiltro.Click += EjecutarFiltro;
            cmbFiltro.SelectedIndexChanged += CambiarFiltro;
            btnLlenarTabla.Click += (object sender, EventArgs e) => ControlGrid.LlenarGrid(grid, TypeData.Matricula);
        }

        private void EjecutarFiltro(object sender, EventArgs e)
        {
                 if (cmbFiltro.SelectedItem.ToString().Equals("Estudiante")) AplicarFiltro(new Filtro(estudianteColumn, cmbFiltroEstudiante.SelectedItem.ToString()));
            else if (cmbFiltro.SelectedItem.ToString().Equals("Asignatura")) AplicarFiltro(new Filtro(asignaturaColumn, cmbFiltroAsignatura.SelectedItem.ToString()));
        }

        private void CambiarFiltro(object sender, EventArgs e)
        {
            Controls.Remove(GetControlFromPosition(2, 0));

                 if (cmbFiltro.SelectedItem.ToString().Equals("Estudiante")) Controls.Add(cmbFiltroEstudiante, 2, 0);
            else if (cmbFiltro.SelectedItem.ToString().Equals("Asignatura")) Controls.Add(cmbFiltroAsignatura, 2, 0);
        }

        internal void AplicarFiltro(Filtro filtro)
        {
            int i = filtro.Column.Index;

            foreach (DataGridViewRow row in grid.Rows)
                row.Visible = row.Cells[i].Value.ToString().Contains(filtro.Value.ToString());
        }
    }
}
