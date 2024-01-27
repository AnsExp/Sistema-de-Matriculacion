using Controller.Controles;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formularios
{
    internal class EliminarMatriculaFormulario : Form
    {
        private readonly TextBox id = new TextBox { Dock = DockStyle.Fill };
        private readonly Button btnEliminar = new Button { Dock = DockStyle.Fill, Text = "Eliminar" };
        private readonly TableLayoutPanel content = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 3 };
        private readonly Label lblId = new Label { Dock = DockStyle.Fill, Text = "ID Matrícula:", TextAlign = ContentAlignment.MiddleRight };

        public EliminarMatriculaFormulario()
        {
            InitializeContent();
            InitializeComponent();
        }

        private void InitializeContent()
        {
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));

            content.Controls.Add(lblId, 0, 0);
            content.Controls.Add(id, 1, 0);
            content.Controls.Add(btnEliminar, 2, 1);

            content.SetColumnSpan(id, 2);
        }

        private void InitializeComponent()
        {
            Controls.Add(content);

            Width = 300;
            Height = 100;
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Eliminar Matricula";

            btnEliminar.Click += new EventHandler(DeleteEvent);
        }

        private readonly ControlMatricula control = new ControlMatricula();

        private void DeleteEvent(object sender, EventArgs e)
        {
            if (id.Text == string.Empty)
            {
                return;
            }

            if (!int.TryParse(id.Text, out int idInt))
            {
                return;
            }

            control.DeleteEvent(idInt);
        }
    }
}
