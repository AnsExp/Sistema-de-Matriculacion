using Controller.Controles;
using Controller.Enumerations;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formularios
{
    internal class AgregarEstudianteFormulario : Form
    {
        public AgregarEstudianteFormulario()
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

            content.Controls.Add(lblNotaGrado, 0, 5);
            content.Controls.Add(notaGrado, 1, 5);
            content.Controls.Add(lblTipoDocumento, 0, 1);
            content.Controls.Add(apellidos, 3, 0);
            content.Controls.Add(lblNombres, 0, 0);
            content.Controls.Add(lblApellidos, 2, 0);
            content.Controls.Add(nombres, 1, 0);
            content.Controls.Add(tipoDocumento, 1, 1);
            content.Controls.Add(lblNumeroDocumento, 2, 1);
            content.Controls.Add(numeroDocumento, 3, 1);
            content.Controls.Add(provincia, 1, 3);
            content.Controls.Add(ciudad, 3, 3);
            content.Controls.Add(lblProvincia, 0, 3);
            content.Controls.Add(lblDireccion, 0, 2);
            content.Controls.Add(lblCiudad, 2, 3);
            content.Controls.Add(direccion, 1, 2);
            content.Controls.Add(fechaNacimiento, 1, 4);
            content.Controls.Add(lblFechaNacimiento, 0, 4);
            content.Controls.Add(genero, 2, 4);
            content.Controls.Add(agregar, 3, 6);

            content.SetRowSpan(genero, 2);
            content.SetColumnSpan(genero, 2);
            content.SetColumnSpan(direccion, 3);

            genero.Controls.Add(rdbtnMujer);
            genero.Controls.Add(radbtnHombre);
        }

        private void InitializeStatus()
        {
            string[] arrayLocation = Locacion.Provincias;
            provincia.DataSource = arrayLocation;
            ciudad.DataSource = Locacion.CitiesByRegion(arrayLocation[0]);

            tipoDocumento.DataSource = Locacion.TypeToArray(typeof(TiposDeDocumentacion));

            provincia.SelectedIndexChanged += new EventHandler(SeleccionarProvincia);
        }

        private void SeleccionarProvincia(object sender, EventArgs eventArgs)
        {

            ciudad.DataSource = Locacion.CitiesByRegion(((string[])provincia.DataSource)[provincia.SelectedIndex]);

        }

        private void InitializeComponent()
        {
            Controls.Add(content);

            FormBorderStyle = FormBorderStyle.FixedSingle;

            Width = 500;
            Height = 300;
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Agregar Estudiante";

            agregar.Click += new EventHandler(AgregarEvento);
        }

        private readonly ControlEstudiante control = new ControlEstudiante();

        private void AgregarEvento(object sender, EventArgs e)
        {
            if (nombres.Text == string.Empty ||
                apellidos.Text == string.Empty ||
                direccion.Text == string.Empty ||
                notaGrado.Text == string.Empty ||
                numeroDocumento.Text == string.Empty ||
                provincia.SelectedItem == null ||
                ciudad.SelectedItem == null ||
                tipoDocumento.SelectedItem == null ||
                !GroupBoxControl.HayRadioButtonSeleccionado(genero))
            {
                return;
            }

            if (!double.TryParse(notaGrado.Text, out double notaGradoDouble))
            {
                return;
            }

            bool generoSeleccionado = GroupBoxControl.ObtenerRadioButtonSeleccionado(genero).Text.Equals("Hombre");

            control.InsertEvent
                (nombres.Text,
                apellidos.Text,
                generoSeleccionado,
                direccion.Text,
                provincia.SelectedItem.ToString(),
                ciudad.SelectedItem.ToString(),
                tipoDocumento.SelectedItem.ToString(),
                numeroDocumento.Text,
                notaGradoDouble,
                fechaNacimiento.Value);
        }

        private readonly TextBox nombres = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox apellidos = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox direccion = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox notaGrado = new TextBox { Dock = DockStyle.Fill };
        private readonly Button agregar = new Button { Dock = DockStyle.Fill, Text = "Agregar" };
        private readonly GroupBox genero = new GroupBox { Dock = DockStyle.Fill, Text = "Género" };
        private readonly TextBox numeroDocumento = new TextBox { Dock = DockStyle.Fill, MaxLength = 10 };
        private readonly DateTimePicker fechaNacimiento = new DateTimePicker { Dock = DockStyle.Fill };
        private readonly RadioButton rdbtnMujer = new RadioButton { Dock = DockStyle.Right, Text = "Mujer" };
        private readonly RadioButton radbtnHombre = new RadioButton { Dock = DockStyle.Left, Text = "Hombre" };
        private readonly ComboBox ciudad = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox provincia = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly TableLayoutPanel content = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 7, ColumnCount = 4 };
        private readonly ComboBox tipoDocumento = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly Label lblCiudad = new Label { Dock = DockStyle.Fill, Text = "Ciudad:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblNombres = new Label {Dock = DockStyle.Fill, Text = "Nombres:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblProvincia = new Label {Dock = DockStyle.Fill, Text = "Provincia:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblDireccion = new Label {Dock = DockStyle.Fill, Text = "Dirección:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblApellidos = new Label {Dock = DockStyle.Fill, Text = "Apellidos:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblNotaGrado = new Label { Dock = DockStyle.Fill, Text = "Nota de Grado:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblTipoDocumento = new Label {Dock = DockStyle.Fill, Text = "Tipo de Documento:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblNumeroDocumento = new Label {Dock = DockStyle.Fill, Text = "Número de documento:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblFechaNacimiento = new Label { Dock = DockStyle.Fill, Text = "Fecha de Nacimiento:", TextAlign = ContentAlignment.MiddleRight };
    }
}
