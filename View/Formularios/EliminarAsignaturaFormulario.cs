using Controller.Controles;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View.Formularios
{
    internal class EliminarAsignaturaFormulario : Form
    {
        private readonly TextBox id = new TextBox { Dock = DockStyle.Fill };
        private readonly Button btnEliminar = new Button { Dock = DockStyle.Fill, Text = "Eliminar" };
        private readonly TableLayoutPanel content = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 3 };
        private readonly Label lblId = new Label { Dock = DockStyle.Fill, Text = "ID:", TextAlign = ContentAlignment.MiddleRight };

        public EliminarAsignaturaFormulario()
        {
            InitializeContent();
            InitializeComponent();
        }

        private void InitializeContent()
        {
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
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
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Eliminar Asignatura";
            FormBorderStyle = FormBorderStyle.FixedDialog;

            btnEliminar.Click += new EventHandler(DeleteEvent);
        }

        private readonly ControlAsignatura control = new ControlAsignatura();

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
