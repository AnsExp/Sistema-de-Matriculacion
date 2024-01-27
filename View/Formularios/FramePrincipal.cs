using Controller.Documento;
using System;
using View.Grids;

namespace View.Formularios
{
    internal class FramePrincipal : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tablaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profesorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarMatriculaToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem estudianteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignaturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaProfesorItem;
        private System.Windows.Forms.ToolStripMenuItem tablaAsignaturaItem;
        private System.Windows.Forms.ToolStripMenuItem tablaMatriculaItem;
        private System.Windows.Forms.ToolStripMenuItem agregarProfesorItem;
        private System.Windows.Forms.ToolStripMenuItem tablaEstudianteItem;
        private System.Windows.Forms.ToolStripMenuItem agregarMatriculaItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarProfesorItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarMatriculaItem;
        private System.Windows.Forms.ToolStripMenuItem agregarEstudianteItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarProfesorItem;
        private System.Windows.Forms.ToolStripMenuItem agregarAsignaturaItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarEstudianteItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarAsignaturaItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarMatriculaItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarAsignaturaItem;
        private System.Windows.Forms.ToolStripMenuItem exportarEstudianteItem;
        private System.Windows.Forms.ToolStripMenuItem exportarProfesorItem;
        private System.Windows.Forms.ToolStripMenuItem exportarAsignaturaItem;
        private System.Windows.Forms.ToolStripMenuItem exportarMatriculaItem;
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.ToolStripMenuItem actualizarEstudianteItem;

        public FramePrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.estudianteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarEstudianteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarEstudianteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarEstudianteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarEstudianteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProfesorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProfesorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarProfesorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarProfesorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarAsignaturaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarAsignaturaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarAsignaturaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarAsignaturaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarMatriculaToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarMatriculaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarMatriculaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarMatriculaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarMatriculaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaEstudianteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaProfesorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaAsignaturaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaMatriculaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.content = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estudianteToolStripMenuItem,
            this.profesorToolStripMenuItem,
            this.asignaturaToolStripMenuItem,
            this.agregarMatriculaToolStripItem,
            this.tablaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // estudianteToolStripMenuItem
            // 
            this.estudianteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarEstudianteItem,
            this.eliminarEstudianteItem,
            this.actualizarEstudianteItem,
            this.exportarEstudianteItem});
            this.estudianteToolStripMenuItem.Name = "estudianteToolStripMenuItem";
            this.estudianteToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.estudianteToolStripMenuItem.Text = "Estudiante";
            // 
            // agregarEstudianteItem
            // 
            this.agregarEstudianteItem.Name = "agregarEstudianteItem";
            this.agregarEstudianteItem.Size = new System.Drawing.Size(205, 22);
            this.agregarEstudianteItem.Text = "Agregar Estudiante";
            this.agregarEstudianteItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // eliminarEstudianteItem
            // 
            this.eliminarEstudianteItem.Name = "eliminarEstudianteItem";
            this.eliminarEstudianteItem.Size = new System.Drawing.Size(205, 22);
            this.eliminarEstudianteItem.Text = "Eliminar Estudiante";
            this.eliminarEstudianteItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // actualizarEstudianteItem
            // 
            this.actualizarEstudianteItem.Name = "actualizarEstudianteItem";
            this.actualizarEstudianteItem.Size = new System.Drawing.Size(205, 22);
            this.actualizarEstudianteItem.Text = "Actualizar Estudiante";
            this.actualizarEstudianteItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // exportarEstudianteItem
            // 
            this.exportarEstudianteItem.Name = "exportarEstudianteItem";
            this.exportarEstudianteItem.Size = new System.Drawing.Size(205, 22);
            this.exportarEstudianteItem.Text = "Exportar Estudiantes PDF";
            this.exportarEstudianteItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // profesorToolStripMenuItem
            // 
            this.profesorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarProfesorItem,
            this.eliminarProfesorItem,
            this.actualizarProfesorItem,
            this.exportarProfesorItem});
            this.profesorToolStripMenuItem.Name = "profesorToolStripMenuItem";
            this.profesorToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.profesorToolStripMenuItem.Text = "Profesor";
            // 
            // agregarProfesorItem
            // 
            this.agregarProfesorItem.Name = "agregarProfesorItem";
            this.agregarProfesorItem.Size = new System.Drawing.Size(200, 22);
            this.agregarProfesorItem.Text = "Agregar Profesor";
            this.agregarProfesorItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // eliminarProfesorItem
            // 
            this.eliminarProfesorItem.Name = "eliminarProfesorItem";
            this.eliminarProfesorItem.Size = new System.Drawing.Size(200, 22);
            this.eliminarProfesorItem.Text = "Eliminar Profesor";
            this.eliminarProfesorItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // actualizarProfesorItem
            // 
            this.actualizarProfesorItem.Name = "actualizarProfesorItem";
            this.actualizarProfesorItem.Size = new System.Drawing.Size(200, 22);
            this.actualizarProfesorItem.Text = "Actualizar Profesor";
            this.actualizarProfesorItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // exportarProfesorItem
            // 
            this.exportarProfesorItem.Name = "exportarProfesorItem";
            this.exportarProfesorItem.Size = new System.Drawing.Size(200, 22);
            this.exportarProfesorItem.Text = "Exportar Profesores PDF";
            this.exportarProfesorItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // asignaturaToolStripMenuItem
            // 
            this.asignaturaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarAsignaturaItem,
            this.eliminarAsignaturaItem,
            this.actualizarAsignaturaItem,
            this.exportarAsignaturaItem});
            this.asignaturaToolStripMenuItem.Name = "asignaturaToolStripMenuItem";
            this.asignaturaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.asignaturaToolStripMenuItem.Text = "Asignatura";
            // 
            // agregarAsignaturaItem
            // 
            this.agregarAsignaturaItem.Name = "agregarAsignaturaItem";
            this.agregarAsignaturaItem.Size = new System.Drawing.Size(207, 22);
            this.agregarAsignaturaItem.Text = "Agregar Asignatura";
            this.agregarAsignaturaItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // eliminarAsignaturaItem
            // 
            this.eliminarAsignaturaItem.Name = "eliminarAsignaturaItem";
            this.eliminarAsignaturaItem.Size = new System.Drawing.Size(207, 22);
            this.eliminarAsignaturaItem.Text = "Eliminar Asignatura";
            this.eliminarAsignaturaItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // actualizarAsignaturaItem
            // 
            this.actualizarAsignaturaItem.Name = "actualizarAsignaturaItem";
            this.actualizarAsignaturaItem.Size = new System.Drawing.Size(207, 22);
            this.actualizarAsignaturaItem.Text = "Actualizar Asignatura";
            this.actualizarAsignaturaItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // exportarAsignaturaItem
            // 
            this.exportarAsignaturaItem.Name = "exportarAsignaturaItem";
            this.exportarAsignaturaItem.Size = new System.Drawing.Size(207, 22);
            this.exportarAsignaturaItem.Text = "Exportar Asignaturas PDF";
            this.exportarAsignaturaItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // agregarMatriculaItem
            // 
            this.agregarMatriculaToolStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarMatriculaItem,
            this.eliminarMatriculaItem,
            this.actualizarMatriculaItem,
            this.exportarMatriculaItem});
            this.agregarMatriculaToolStripItem.Name = "agregarMatriculaItem";
            this.agregarMatriculaToolStripItem.Size = new System.Drawing.Size(69, 20);
            this.agregarMatriculaToolStripItem.Text = "Matrícula";
            // 
            // agregarMatriculaToolStripMenuItem
            // 
            this.agregarMatriculaItem.Name = "agregarMatriculaToolStripMenuItem";
            this.agregarMatriculaItem.Size = new System.Drawing.Size(200, 22);
            this.agregarMatriculaItem.Text = "Agregar Matrícula";
            this.agregarMatriculaItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // eliminarMatriculaItem
            // 
            this.eliminarMatriculaItem.Name = "eliminarMatriculaItem";
            this.eliminarMatriculaItem.Size = new System.Drawing.Size(200, 22);
            this.eliminarMatriculaItem.Text = "Eliminar Matrícula";
            this.eliminarMatriculaItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // actualizarMatriculaItem
            // 
            this.actualizarMatriculaItem.Name = "actualizarMatriculaItem";
            this.actualizarMatriculaItem.Size = new System.Drawing.Size(200, 22);
            this.actualizarMatriculaItem.Text = "Actualizar Matrícula";
            this.actualizarMatriculaItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // exportarMatriculaItem
            // 
            this.exportarMatriculaItem.Name = "exportarMatriculaItem";
            this.exportarMatriculaItem.Size = new System.Drawing.Size(200, 22);
            this.exportarMatriculaItem.Text = "Exportar Matriculas PDF";
            this.exportarMatriculaItem.Click += new System.EventHandler(this.LlamadaFormulario);
            // 
            // tablaToolStripMenuItem
            // 
            this.tablaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tablaEstudianteItem,
            this.tablaProfesorItem,
            this.tablaAsignaturaItem,
            this.tablaMatriculaItem});
            this.tablaToolStripMenuItem.Name = "tablaToolStripMenuItem";
            this.tablaToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.tablaToolStripMenuItem.Text = "Tabla";
            // 
            // tablaEstudianteItem
            // 
            this.tablaEstudianteItem.Name = "tablaEstudianteItem";
            this.tablaEstudianteItem.Size = new System.Drawing.Size(180, 22);
            this.tablaEstudianteItem.Text = "Tabla Estudiantes";
            this.tablaEstudianteItem.Click += new System.EventHandler(this.MostrarTabla);
            // 
            // tablaProfesorItem
            // 
            this.tablaProfesorItem.Name = "tablaProfesorItem";
            this.tablaProfesorItem.Size = new System.Drawing.Size(180, 22);
            this.tablaProfesorItem.Text = "Tabla Profesores";
            this.tablaProfesorItem.Click += new System.EventHandler(this.MostrarTabla);
            // 
            // tablaAsignaturaItem
            // 
            this.tablaAsignaturaItem.Name = "tablaAsignaturaItem";
            this.tablaAsignaturaItem.Size = new System.Drawing.Size(180, 22);
            this.tablaAsignaturaItem.Text = "Tabla Asignaturas";
            this.tablaAsignaturaItem.Click += new System.EventHandler(this.MostrarTabla);
            // 
            // tablaMatriculaItem
            // 
            this.tablaMatriculaItem.Name = "tablaMatriculaItem";
            this.tablaMatriculaItem.Size = new System.Drawing.Size(180, 22);
            this.tablaMatriculaItem.Text = "Tabla Matriculas";
            this.tablaMatriculaItem.Click += new System.EventHandler(this.MostrarTabla);
            // 
            // content
            // 
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 24);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(684, 337);
            this.content.TabIndex = 2;
            // 
            // FramePrincipal
            // 
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.content);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FramePrincipal";
            this.ShowIcon = false;
            this.Text = "Formulario Matriculación";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LlamadaFormulario(object sender, EventArgs e)
        {
                 if (sender == agregarProfesorItem) new AgregarProfesorFormulario().Show(this);
            else if (sender == agregarMatriculaItem) new AgregarMatriculaFormulario().Show(this);
            else if (sender == agregarAsignaturaItem) new AgregarAsignaturaFormulario().Show(this);
            else if (sender == agregarEstudianteItem) new AgregarEstudianteFormulario().Show(this);
            else if (sender == eliminarProfesorItem) new EliminarProfesorFormulario().Show(this);
            else if (sender == eliminarMatriculaItem) new EliminarMatriculaFormulario().Show(this);
            else if (sender == eliminarAsignaturaItem) new EliminarAsignaturaFormulario().Show(this);
            else if (sender == eliminarEstudianteItem) new EliminarEstudianteFormulario().Show(this);
            else if (sender == actualizarProfesorItem) new ActualizarProfesorFormulario().Show(this);
            else if (sender == actualizarMatriculaItem) new ActualizarMatriculaFormulario().Show(this);
            else if (sender == actualizarAsignaturaItem) new ActualizarAsignaturaFormulario().Show(this);
            else if (sender == actualizarEstudianteItem) new ActualizarEstudianteFormulario().Show(this);
            else if (sender == exportarProfesorItem) new ControlDocument().ConfirmSavePDF(gridProfesor.GetGrid, TypeData.Profesor);
            else if (sender == exportarMatriculaItem) new ControlDocument().ConfirmSavePDF(gridMatricula.GetGrid, TypeData.Matricula);
            else if (sender == exportarAsignaturaItem) new ControlDocument().ConfirmSavePDF(gridAsignatura.GetGrid, TypeData.Asignatura);
            else if (sender == exportarEstudianteItem) new ControlDocument().ConfirmSavePDF(gridEstudiante.GetGrid, TypeData.Estudiante);
        }

        private readonly GridProfesor gridProfesor = new GridProfesor();
        private readonly GridMatricula gridMatricula = new GridMatricula();
        private readonly GridAsignatura gridAsignatura = new GridAsignatura();
        private readonly GridEstudiante gridEstudiante = new GridEstudiante();

        private void MostrarTabla(object sender, EventArgs e)
        {
            content.Controls.Clear();

                 if (sender == tablaProfesorItem) content.Controls.Add(gridProfesor);
            else if (sender == tablaMatriculaItem) content.Controls.Add(gridMatricula);
            else if (sender == tablaAsignaturaItem) content.Controls.Add(gridAsignatura);
            else if (sender == tablaEstudianteItem) content.Controls.Add(gridEstudiante);
        }
    }
}
