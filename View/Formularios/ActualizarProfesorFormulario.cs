using Controller.Controles;
using Controller.Enumerations;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formularios
{
    internal class ActualizarProfesorFormulario : Form
    {
        public ActualizarProfesorFormulario()
        {
            InitializeContent();
            InitializeStatus();
            InitializeComponent();
        }

        private void InitializeContent()
        {
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

            content.Controls.Add(lblTipoDocumento, 0, 0);
            content.Controls.Add(lblNumeroDocumento, 2, 0);
            content.Controls.Add(lblDireccion, 0, 2);
            content.Controls.Add(lblProvincia, 0, 3);
            content.Controls.Add(lblCiudad, 2, 3);
            content.Controls.Add(lblTitulo, 0, 4);
            content.Controls.Add(cmbTipoDocumento, 1, 0);
            content.Controls.Add(numeroDocumento, 3, 0);
            content.Controls.Add(direccion, 1, 2);
            content.Controls.Add(cmbProvincia, 1, 3);
            content.Controls.Add(cmbCiudades, 3, 3);
            content.Controls.Add(titulo, 1, 4);
            content.Controls.Add(actualizar, 3, 4);
            content.Controls.Add(buscar, 3, 1);

            content.SetColumnSpan(direccion, 3);
        }

        private void InitializeStatus()
        {
            cmbProvincia.DataSource = Locacion.Provincias;
            cmbCiudades.DataSource = Locacion.CitiesByRegion(((string[])cmbProvincia.DataSource)[0]);
            cmbTipoDocumento.DataSource = Locacion.TypeToArray(typeof(TiposDeDocumentacion));

            cmbProvincia.SelectedIndexChanged += new EventHandler(SeleccionarProvincia);
        }

        private void SeleccionarProvincia(object sender, EventArgs e)
        {
            cmbCiudades.DataSource = Locacion.CitiesByRegion(((string[])cmbProvincia.DataSource)[cmbProvincia.SelectedIndex]);
        }

        private readonly ControlProfesor control = new ControlProfesor();

        private void InitializeComponent()
        {
            Controls.Add(content);

            Width = 500;
            Height = 200;
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Actualizar Profesor";
            FormBorderStyle = FormBorderStyle.FixedSingle;

            buscar.Click += new EventHandler(BuscarEvento);
            actualizar.Click += new EventHandler(ActualizarEvento);
        }

        private void BuscarEvento(object sender, EventArgs e)
        {
            if (cmbTipoDocumento.SelectedItem == null ||
                numeroDocumento.Text == string.Empty)
            {
                return;
            }

            control.SelectEvent(cmbTipoDocumento.SelectedItem.ToString(), numeroDocumento.Text);
        }

        private void ActualizarEvento(object sender, EventArgs e)
        {
            if (direccion.Text == string.Empty ||
                titulo.Text == string.Empty ||
                cmbProvincia.SelectedItem == null ||
                cmbCiudades.SelectedItem == null)
            {
                return;
            }

            control.UpdateEvent
                (direccion.Text,
                cmbProvincia.SelectedItem.ToString(),
                cmbCiudades.SelectedItem.ToString(),
                titulo.Text);
        }

        private readonly Label lblTipoDocumento = new Label { Dock = DockStyle.Fill, Text = "Tipo de documento", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblNumeroDocumento = new Label { Dock = DockStyle.Fill, Text = "Número de Documento:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblDireccion = new Label { Dock = DockStyle.Fill, Text = "Dirección:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblProvincia = new Label { Dock = DockStyle.Fill, Text = "Provincia:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblCiudad = new Label { Dock = DockStyle.Fill, Text = "Ciudad:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblTitulo = new Label { Dock = DockStyle.Fill, Text = "Título:", TextAlign = ContentAlignment.MiddleRight };
        private readonly ComboBox cmbTipoDocumento = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly TextBox numeroDocumento = new TextBox { Dock = DockStyle.Fill, MaxLength = 10 };
        private readonly TextBox direccion = new TextBox { Dock = DockStyle.Fill };
        private readonly ComboBox cmbProvincia = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox cmbCiudades = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly TextBox titulo = new TextBox { Dock = DockStyle.Fill };
        private readonly Button actualizar = new Button { Dock = DockStyle.Fill, Text = "Actualizar" };
        private readonly Button buscar = new Button { Dock = DockStyle.Fill, Text = "Buscar" };
        private readonly TableLayoutPanel content = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 5, ColumnCount = 4 };
    }
}
