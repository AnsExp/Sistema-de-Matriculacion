using Controller.Controles;
using Controller.Documento;
using Controller.Enumerations;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Grids
{
    internal class GridProfesor : TableLayoutPanel
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

        private readonly TextBox
            filtroNombre = new TextBox { Dock = DockStyle.Fill },
            filtroApellido = new TextBox { Dock = DockStyle.Fill };

        private readonly ComboBox
            cmbFiltro = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList },
            cmbFiltroCiudad = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList },
            cmbFiltroGenero = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList },
            cmbFiltroProvincia = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

        private readonly DataGridViewTextBoxColumn
            idColumn = new DataGridViewTextBoxColumn { HeaderText = "ID", Name = "id" },
            ciudadColumn = new DataGridViewTextBoxColumn { HeaderText = "Ciudad", Name = "ciudad" },
            generoColumn = new DataGridViewTextBoxColumn { HeaderText = "Género", Name = "genero" },
            nombresColumn = new DataGridViewTextBoxColumn { HeaderText = "Nombres", Name = "nombre" },
            notaGradoColumn = new DataGridViewTextBoxColumn { HeaderText = "Título", Name = "titulo" },
            apellidosColumn = new DataGridViewTextBoxColumn { HeaderText = "Apellidos", Name = "apellido" },
            provinciaColumn = new DataGridViewTextBoxColumn { HeaderText = "Provincia", Name = "provincia" },
            domicilioColumn = new DataGridViewTextBoxColumn { HeaderText = "Domicilio", Name = "domicilio" },
            tipoDocumentoColumn = new DataGridViewTextBoxColumn { HeaderText = "Tipo de documento", Name = "tipoDocumento" },
            numeroDocumentoColumn = new DataGridViewTextBoxColumn { HeaderText = "Número de documento", Name = "numeroDocumento" },
            fechaNacimientoColumn = new DataGridViewTextBoxColumn { HeaderText = "Fecha de nacimiento", Name = "fechaNacimiento" };

        internal GridProfesor()
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

            cmbFiltro.DataSource = new string[] { "Nombre", "Apellido", "Provincia", "Ciudad", "Genero" };
            cmbFiltroGenero.DataSource = new string[] { "Hombre", "Mujer" };
            cmbFiltroCiudad.DataSource = Locacion.Ciudades;
            cmbFiltroProvincia.DataSource = Locacion.Provincias;

            grid.Columns.AddRange
                (idColumn,
                nombresColumn,
                apellidosColumn,
                generoColumn,
                fechaNacimientoColumn,
                notaGradoColumn,
                provinciaColumn,
                ciudadColumn,
                domicilioColumn,
                tipoDocumentoColumn,
                numeroDocumentoColumn);

            ControlGrid.LlenarGrid(grid, TypeData.Profesor);

            grid.AllowUserToAddRows = false;
            btnAplicarFiltro.Click += EjecutarFiltro;
            cmbFiltro.SelectedIndexChanged += CambiarFiltro;
            btnLlenarTabla.Click += (object sender, EventArgs e) => ControlGrid.LlenarGrid(grid, TypeData.Profesor);
        }

        private void EjecutarFiltro(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedItem.ToString().Equals("Nombre")) AplicarFiltro(new Filtro(grid.Columns[1], filtroNombre.Text));
            else if (cmbFiltro.SelectedItem.ToString().Equals("Apellido")) AplicarFiltro(new Filtro(grid.Columns[2], filtroApellido.Text));
            else if (cmbFiltro.SelectedItem.ToString().Equals("Genero")) AplicarFiltro(new Filtro(grid.Columns[3], cmbFiltroGenero.SelectedItem.ToString()));
            else if (cmbFiltro.SelectedItem.ToString().Equals("Ciudad")) AplicarFiltro(new Filtro(grid.Columns[7], cmbFiltroCiudad.SelectedItem.ToString()));
            else if (cmbFiltro.SelectedItem.ToString().Equals("Provincia")) AplicarFiltro(new Filtro(grid.Columns[6], cmbFiltroProvincia.SelectedItem.ToString()));
        }

        private void CambiarFiltro(object sender, EventArgs e)
        {
            Controls.Remove(GetControlFromPosition(2, 0));

            if (cmbFiltro.SelectedItem.ToString().Equals("Nombre")) Controls.Add(filtroNombre, 2, 0);
            else if (cmbFiltro.SelectedItem.ToString().Equals("Ciudad")) Controls.Add(cmbFiltroCiudad, 2, 0);
            else if (cmbFiltro.SelectedItem.ToString().Equals("Genero")) Controls.Add(cmbFiltroGenero, 2, 0);
            else if (cmbFiltro.SelectedItem.ToString().Equals("Apellido")) Controls.Add(filtroApellido, 2, 0);
            else if (cmbFiltro.SelectedItem.ToString().Equals("Provincia")) Controls.Add(cmbFiltroProvincia, 2, 0);
        }

        internal void AplicarFiltro(Filtro filtro)
        {
            int i = filtro.Column.Index;

            foreach (DataGridViewRow row in grid.Rows)
                row.Visible = row.Cells[i].Value.ToString().Contains(filtro.Value.ToString());
        }
    }
}
