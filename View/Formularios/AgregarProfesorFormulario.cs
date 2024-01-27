using Controller.Controles;
using Controller.Enumerations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formularios
{
    internal class AgregarProfesorFormulario : Form
    {
        private readonly Label lblNombres = new Label { Dock = DockStyle.Fill, Text = "Nombres:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblTipoDocumento = new Label { Dock = DockStyle.Fill, Text = "Tipo de documento:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblNumeroDocumento = new Label { Dock = DockStyle.Fill, Text = "Número de documento:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblApellidos = new Label { Dock = DockStyle.Fill, Text = "Apellidos:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblProvincia = new Label { Dock = DockStyle.Fill, Text = "Provincia:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblDireccion = new Label { Dock = DockStyle.Fill, Text = "Dirección:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblCiudad = new Label { Dock = DockStyle.Fill, Text = "Ciudad:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblFechaNacimiento = new Label { Dock = DockStyle.Fill, Text = "Fecha de nacimiento:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblTitulo = new Label { Dock = DockStyle.Fill, Text = "Título:", TextAlign = ContentAlignment.MiddleRight };
        private readonly TextBox nombres = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox apellidos = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox direccion = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox numeroDocumento = new TextBox { Dock = DockStyle.Fill, MaxLength = 10 };
        private readonly ComboBox cmbCiudades = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox cmbProvincia = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox cmbTiposDocumentos = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly DateTimePicker fechaNacimiento = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short };
        private readonly RadioButton rdbtnMujer = new RadioButton { Dock = DockStyle.Right, Text = "Mujer" };
        private readonly RadioButton rdbtnHombre = new RadioButton { Dock = DockStyle.Left, Text = "Hombre" };
        private readonly GroupBox genero = new GroupBox { Dock = DockStyle.Fill };
        private readonly TextBox titulo = new TextBox { Dock = DockStyle.Fill };
        private readonly Button agregar = new Button { Dock = DockStyle.Fill, Text = "Agregar" };
        private readonly TableLayoutPanel content = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 7, ColumnCount = 4 };

        public AgregarProfesorFormulario()
        {
            InitializeContent();
            InitializeStatus();
            InitializeComponent();
        }

        private void InitializeContent()
        {
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 7F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 7F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 7F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 7F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 7F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 7F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 7F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

            content.Controls.Add(lblTitulo, 0, 5);
            content.Controls.Add(titulo, 1, 5);
            content.Controls.Add(lblTipoDocumento, 0, 1);
            content.Controls.Add(apellidos, 3, 0);
            content.Controls.Add(lblNombres, 0, 0);
            content.Controls.Add(lblApellidos, 2, 0);
            content.Controls.Add(nombres, 1, 0);
            content.Controls.Add(cmbTiposDocumentos, 1, 1);
            content.Controls.Add(lblNumeroDocumento, 2, 1);
            content.Controls.Add(numeroDocumento, 3, 1);
            content.Controls.Add(cmbProvincia, 1, 3);
            content.Controls.Add(cmbCiudades, 3, 3);
            content.Controls.Add(lblProvincia, 0, 3);
            content.Controls.Add(lblDireccion, 0, 2);
            content.Controls.Add(lblCiudad, 2, 3);
            content.Controls.Add(direccion, 1, 2);
            content.Controls.Add(fechaNacimiento, 1, 4);
            content.Controls.Add(lblFechaNacimiento, 0, 4);
            content.Controls.Add(genero, 2, 4);
            content.Controls.Add(agregar, 3, 6);

            content.SetRowSpan(genero, 2);
            content.SetColumnSpan(direccion, 3);
            content.SetColumnSpan(genero, 2);

            genero.Controls.Add(rdbtnMujer);
            genero.Controls.Add(rdbtnHombre);
        }

        private void InitializeStatus()
        {
            cmbProvincia.DataSource = Locacion.Provincias;
            cmbCiudades.DataSource = Locacion.CitiesByRegion(((string[])cmbProvincia.DataSource)[0]);
            cmbTiposDocumentos.DataSource = Locacion.TypeToArray(typeof(TiposDeDocumentacion));

            cmbProvincia.SelectedIndexChanged += new EventHandler(SeleccionarProvincia);
        }

        private void SeleccionarProvincia(object sender, EventArgs eventArgs)
        {
            cmbCiudades.DataSource = Locacion.CitiesByRegion(((string[])cmbProvincia.DataSource)[cmbProvincia.SelectedIndex]);
        }
        
        private void InitializeComponent()
        {
            Controls.Add(content);

            Width = 500;
            Height = 300;
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Agregar Estudiante";
            FormBorderStyle = FormBorderStyle.FixedSingle;

            agregar.Click += new EventHandler(AgregarEvento);
        }

        private readonly ControlProfesor control = new ControlProfesor();

        private void AgregarEvento(object sender, EventArgs e)
        {
            if (titulo.Text == string.Empty ||
                nombres.Text == string.Empty ||
                apellidos.Text == string.Empty ||
                direccion.Text == string.Empty ||
                numeroDocumento.Text == string.Empty ||
                cmbProvincia.SelectedItem == null ||
                cmbCiudades.SelectedItem == null ||
                cmbTiposDocumentos.SelectedItem == null ||
                !GroupBoxControl.HayRadioButtonSeleccionado(genero))
            {
                return;
            }

            bool generoSeleccionado = GroupBoxControl.ObtenerRadioButtonSeleccionado(genero).Text == "Hombre";

            control.InsertEvent
                (nombres.Text,
                apellidos.Text,
                generoSeleccionado,
                direccion.Text,
                cmbProvincia.SelectedItem.ToString(),
                cmbCiudades.SelectedItem.ToString(),
                cmbTiposDocumentos.SelectedItem.ToString(),
                numeroDocumento.Text,
                titulo.Text,
                fechaNacimiento.Value);
        }
    }
}
