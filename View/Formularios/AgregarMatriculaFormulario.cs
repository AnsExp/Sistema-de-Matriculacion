using Controller.Controles;
using Controller.Documento;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formularios
{
    internal class AgregarMatriculaFormulario : Form
    {
        private readonly TableLayoutPanel content = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 3 };
        private readonly Label lblEstudiante = new Label {Dock = DockStyle.Fill, Text = "Estudiante:", TextAlign= ContentAlignment.MiddleRight };
        private readonly Label lblAsignatura = new Label { Dock = DockStyle.Fill, Text = "Asignatura:", TextAlign = ContentAlignment.MiddleRight };
        private readonly ComboBox cmbEstudiante = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox cmbAsignatura = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly Button btnAgregar = new Button { Dock = DockStyle.Fill, Text = "Agregar" };

        public AgregarMatriculaFormulario()
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

            content.Controls.Add(lblEstudiante, 0, 0);
            content.Controls.Add(lblAsignatura, 0, 1);
            content.Controls.Add(cmbEstudiante, 1, 0);
            content.Controls.Add(cmbAsignatura, 1, 1);
            content.Controls.Add(btnAgregar, 2, 2);

            content.SetColumnSpan(cmbEstudiante, 2);
            content.SetColumnSpan(cmbAsignatura, 2);
        }

        private void InitializeStatus()
        {
            ComboComand.FillCombo(cmbEstudiante, TypeData.Estudiante);
            ComboComand.FillCombo(cmbAsignatura, TypeData.Asignatura);
        }

        private void InitializeComponent()
        {
            Controls.Add(content);
            
            Width = 300;
            Height = 150;
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Agregar Matrícula";
            FormBorderStyle = FormBorderStyle.FixedSingle;

            btnAgregar.Click += new EventHandler(AgregarEvento);
        }

        private readonly ControlMatricula control = new ControlMatricula();

        private void AgregarEvento(object sender, EventArgs e)
        {
            if (cmbAsignatura.SelectedItem == null || cmbEstudiante.SelectedItem == null)
                return;

            control.InsertEvent(cmbEstudiante.SelectedItem, cmbAsignatura.SelectedItem);
        }
    }
}
