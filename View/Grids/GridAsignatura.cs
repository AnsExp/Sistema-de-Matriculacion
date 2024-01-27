using Controller.Controles;
using Controller.Documento;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Grids
{
    internal class GridAsignatura : TableLayoutPanel
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

        private readonly TextBox filtroNombre = new TextBox { Dock = DockStyle.Fill };

        private readonly ComboBox
            cmbFiltro = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList },
            cmbFiltroProfesor = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

        private readonly DataGridViewTextBoxColumn
            idColumn = new DataGridViewTextBoxColumn { HeaderText = "ID", Name = "id" },
            nombresColumn = new DataGridViewTextBoxColumn { HeaderText = "Nombre", Name = "nombre" },
            creditosColumn = new DataGridViewTextBoxColumn { HeaderText = "Créditos", Name = "creditos" },
            profesorColumn = new DataGridViewTextBoxColumn { HeaderText = "Profesor", Name = "profesor" },
            tiempoHorasColumn = new DataGridViewTextBoxColumn { HeaderText = "Tiempo en horas", Name = "tiempoHoras" },
            componenteAutonomoColumn = new DataGridViewTextBoxColumn { HeaderText = "Componente autónomo", Name = "componenteAutonomo" },
            componenteParticipacionColumn = new DataGridViewTextBoxColumn { HeaderText = "Componente de participación", Name = "componenteParticipacion" };

        internal GridAsignatura()
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

            cmbFiltro.DataSource = new string[] { "Nombre", "Profesor" };
            ComboComand.FillCombo(cmbFiltroProfesor, TypeData.Profesor);

            grid.Columns.AddRange
                (idColumn,
                nombresColumn,
                profesorColumn,
                tiempoHorasColumn,
                componenteAutonomoColumn,
                creditosColumn,
                componenteParticipacionColumn);

            ControlGrid.LlenarGrid(grid, TypeData.Asignatura);

            grid.AllowUserToAddRows = false;
            btnAplicarFiltro.Click += EjecutarFiltro;
            cmbFiltro.SelectedIndexChanged += CambiarFiltro;
            btnLlenarTabla.Click += (object sender, EventArgs e) => ControlGrid.LlenarGrid(grid, TypeData.Asignatura);
        }

        private void EjecutarFiltro(object sender, EventArgs e)
        {
                 if (cmbFiltro.SelectedItem.ToString().Equals("Nombre")) AplicarFiltro(new Filtro(grid.Columns[1], filtroNombre.Text));
            else if (cmbFiltro.SelectedItem.ToString().Equals("Profesor")) AplicarFiltro(new Filtro(grid.Columns[2], cmbFiltroProfesor.SelectedItem.ToString()));
        }

        private void CambiarFiltro(object sender, EventArgs e)
        {
            Controls.Remove(GetControlFromPosition(2, 0));

                 if (cmbFiltro.SelectedItem.ToString().Equals("Nombre")) Controls.Add(filtroNombre, 2, 0);
            else if (cmbFiltro.SelectedItem.ToString().Equals("Profesor")) Controls.Add(cmbFiltroProfesor, 2, 0);
        }

        internal void AplicarFiltro(Filtro filtro)
        {
            int i = filtro.Column.Index;

            foreach (DataGridViewRow row in grid.Rows)
                row.Visible = row.Cells[i].Value.ToString().Contains(filtro.Value.ToString());
        }
    }
}
