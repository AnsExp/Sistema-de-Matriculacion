using Controller.Controles;
using Controller.Documento;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formularios
{
    internal class ActualizarMatriculaFormulario : Form
    {
        public ActualizarMatriculaFormulario()
        {
            InitializeContent();
            InitializeStatus();
            InitializeComponent();
        }

        private void InitializeContent()
        {
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));

            content.Controls.Add(lblIdAsignatura, 0, 0);
            content.Controls.Add(lblEstudiante, 0, 1);
            content.Controls.Add(lblAsignatura, 0, 2);
            content.Controls.Add(id, 1, 0);
            content.Controls.Add(btnBuscar, 2, 0);
            content.Controls.Add(cmbEstudiante, 1, 1);
            content.Controls.Add(cmbAsignatura, 1, 2);
            content.Controls.Add(btnActualizar, 2, 3);

            content.SetColumnSpan(cmbEstudiante, 2);
            content.SetColumnSpan(cmbAsignatura, 2);
        }

        private void InitializeStatus()
        {
            ComboComand.FillCombo(cmbEstudiante, TypeData.Estudiante);
            ComboComand.FillCombo(cmbAsignatura, TypeData.Asignatura);
        }

        private readonly ControlMatricula control = new ControlMatricula();

        private void InitializeComponent()
        {
            Controls.Add(content);

            Width = 400;
            Height = 175;
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Actualizar Matricula";
            FormBorderStyle = FormBorderStyle.FixedSingle;

            btnBuscar.Click += new EventHandler(BuscarEvento);
            btnActualizar.Click += new EventHandler(ActualizarEvento);
        }

        private void BuscarEvento(object sender, EventArgs e)
        {
            if (id.Text == string.Empty)
                return;

            if (!int.TryParse(id.Text, out int idNum))
                return;

            control.SelectEvent(idNum);
        }

        private void ActualizarEvento(object sender, EventArgs e)
        {
            if (cmbAsignatura.SelectedItem == null ||
                cmbEstudiante.SelectedItem == null)
                return;

            control.UpdateEvent(cmbEstudiante.SelectedItem, cmbAsignatura.SelectedItem);
        }

        private Label lblIdAsignatura = new Label { Dock = DockStyle.Fill, Text = "ID Asignatura:", TextAlign = ContentAlignment.MiddleRight };
        private Label lblEstudiante = new Label { Dock = DockStyle.Fill, Text = "Estudiante:", TextAlign = ContentAlignment.MiddleRight };
        private Label lblAsignatura = new Label { Dock = DockStyle.Fill, Text = "Asignatura:", TextAlign = ContentAlignment.MiddleRight };
        private TextBox id = new TextBox { Dock = DockStyle.Fill };
        private Button btnBuscar = new Button { Dock = DockStyle.Fill, Text = "Buscar" };
        private ComboBox cmbEstudiante = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private ComboBox cmbAsignatura = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private Button btnActualizar = new Button { Dock = DockStyle.Fill, Text = "Actualizar" };
        private TableLayoutPanel content = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 4, ColumnCount = 3 };
    }
}
