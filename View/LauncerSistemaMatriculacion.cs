using System;
using System.Windows.Forms;
using View.Formularios;

namespace View
{
    internal static class LauncerSistemaMatriculacion
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FramePrincipal());
        }
    }
}
