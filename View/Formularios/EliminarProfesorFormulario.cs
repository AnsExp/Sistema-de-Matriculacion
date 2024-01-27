using Controller.Controles;
using Controller.Enumerations;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formularios
{
    internal class EliminarProfesorFormulario : Form
    {
        public EliminarProfesorFormulario()
        {
            InitializeContent();
            InitializeStatus();
            InitializeComponent();
        }

        private void InitializeContent()
        {
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 3F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 3F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 3F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));

            content.Controls.Add(lblTipoDocumento, 0, 0);
            content.Controls.Add(lblNumeroDocumento, 0, 1);
            content.Controls.Add(tipoDocumento, 1, 0);
            content.Controls.Add(numeroDocumento, 1, 1);
            content.Controls.Add(eliminar, 2, 2);

            content.SetColumnSpan(tipoDocumento, 2);
            content.SetColumnSpan(numeroDocumento, 2);
        }

        private void InitializeStatus()
        {
            tipoDocumento.DataSource = Locacion.TypeToArray(typeof(TiposDeDocumentacion));
        }

        private void InitializeComponent()
        {
            Controls.Add(content);

            Width = 300;
            Height = 150;
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Eliminar Profesor";
            FormBorderStyle = FormBorderStyle.FixedSingle;

            eliminar.Click += new EventHandler(DeleteEvent);
        }

        private readonly ControlProfesor control = new ControlProfesor();

        private void DeleteEvent(object sender, EventArgs e)
        {
            if (numeroDocumento.Text == string.Empty ||
                tipoDocumento.SelectedItem == null)
            {
                return;
            }

            control.DeleteEvent(tipoDocumento.SelectedItem.ToString(), numeroDocumento.Text);
        }

        private readonly TextBox numeroDocumento = new TextBox { Dock = DockStyle.Fill };
        private readonly Button eliminar = new Button { Dock = DockStyle.Fill, Text = "Eliminar" };
        private readonly TableLayoutPanel content = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 3 };
        private readonly ComboBox tipoDocumento = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly Label lblTipoDocumento = new Label { Dock = DockStyle.Fill, Text = "Tipo de Documento:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblNumeroDocumento = new Label { Dock = DockStyle.Fill, Text = "Numero de Documento:", TextAlign = ContentAlignment.MiddleRight };
    }
}
