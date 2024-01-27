using Controller.Controles;
using Controller.Documento;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formularios
{
    internal class ActualizarAsignaturaFormulario : Form
    {
        private readonly TextBox id = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox nombre = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox creditos = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox tiempoHoras = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox componenteAutonomo = new TextBox { Dock = DockStyle.Fill };
        private readonly TextBox componenteParticipacion = new TextBox { Dock = DockStyle.Fill };
        private readonly Button buscar = new Button { Dock = DockStyle.Fill, Text = "Buscar" };
        private readonly Button actualizar = new Button { Dock = DockStyle.Fill, Text = "Actualizar" };
        private readonly ComboBox cmbProfesor = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly TableLayoutPanel content = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 4, ColumnCount = 4 };
        private readonly Label lblId = new Label { Dock = DockStyle.Fill, Text = "ID:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblNombre = new Label { Dock = DockStyle.Fill, Text = "Nombre:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblProfesor = new Label { Dock = DockStyle.Fill, Text = "Profesor:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblCreditos = new Label { Dock = DockStyle.Fill, Text = "Créditos:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblTiempoHoras = new Label { Dock = DockStyle.Fill, Text = "Tiempo Horas:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblComponenteAutonomo = new Label { Dock = DockStyle.Fill, Text = "Componente Autónomo:", TextAlign = ContentAlignment.MiddleRight };
        private readonly Label lblComponenteParticipacion = new Label { Dock = DockStyle.Fill, Text = "Componente Participación:", TextAlign = ContentAlignment.MiddleRight };

        public ActualizarAsignaturaFormulario()
        {
            InitializeContent();
            InitializeStatus();
            InitializeComponent();
        }

        private void InitializeStatus()
        {
            ComboComand.FillCombo(cmbProfesor, TypeData.Profesor);
        }

        private void InitializeContent()
        {
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

            content.Controls.Add(id, 1, 3);
            content.Controls.Add(lblId, 0, 3);
            content.Controls.Add(componenteParticipacion, 3, 2);
            content.Controls.Add(componenteAutonomo, 1, 2);
            content.Controls.Add(tiempoHoras, 3, 1);
            content.Controls.Add(creditos, 1, 1);
            content.Controls.Add(lblNombre, 0, 0);
            content.Controls.Add(lblProfesor, 2, 0);
            content.Controls.Add(lblCreditos, 0, 1);
            content.Controls.Add(lblTiempoHoras, 2, 1);
            content.Controls.Add(lblComponenteAutonomo, 0, 2);
            content.Controls.Add(lblComponenteParticipacion, 2, 2);
            content.Controls.Add(nombre, 1, 0);
            content.Controls.Add(cmbProfesor, 3, 0);
            content.Controls.Add(actualizar, 3, 3);
            content.Controls.Add(buscar, 2, 3);
        }

        private void InitializeComponent()
        {
            Controls.Add(content);

            Width = 500;
            Height = 150;
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Agregar Asignatura";
            FormBorderStyle = FormBorderStyle.FixedSingle;

            buscar.Click += new EventHandler(BuscarEvento);
            actualizar.Click += new EventHandler(ActualizarEvento);
        }

        private readonly ControlAsignatura control = new ControlAsignatura();

        private void BuscarEvento(object sender, EventArgs e)
        {
            if (id.Text == string.Empty)
                return;

            if (!int.TryParse(id.Text, out _))
                return;

            control.SelectEvent(Convert.ToInt32(id.Text));
        }

        private void ActualizarEvento(object sender, EventArgs e)
        {
            if (nombre.Text == string.Empty ||
                creditos.Text == string.Empty ||
                tiempoHoras.Text == string.Empty ||
                componenteAutonomo.Text == string.Empty ||
                componenteParticipacion.Text == string.Empty)
                return;

            if (!int.TryParse(creditos.Text, out _) ||
                !int.TryParse(tiempoHoras.Text, out _) ||
                !int.TryParse(componenteAutonomo.Text, out _) ||
                !int.TryParse(componenteParticipacion.Text, out _))
                return;

            control.UpdateEvent
                (nombre.Text,
                Convert.ToInt32(creditos.Text),
                Convert.ToInt32(tiempoHoras.Text),
                Convert.ToInt32(componenteAutonomo.Text),
                Convert.ToInt32(componenteParticipacion.Text),
                cmbProfesor.SelectedItem);
        }
    }
}
