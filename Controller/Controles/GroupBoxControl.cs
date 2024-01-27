using System.Linq;
using System.Windows.Forms;

namespace Controller.Controles
{
    public class GroupBoxControl
    {
        public static bool HayRadioButtonSeleccionado(GroupBox groupBox)
        {
            return ObtenerRadioButtonSeleccionado(groupBox) != null;
        }

        public static RadioButton ObtenerRadioButtonSeleccionado(GroupBox groupBox)
        {
            RadioButton radioButtonSeleccionado = groupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            return radioButtonSeleccionado;
        }
    }
}
