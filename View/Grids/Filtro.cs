using System.Windows.Forms;

namespace View.Grids
{
    internal class Filtro
    {
        internal Filtro(DataGridViewColumn column, object value)
        {
            Column = column;
            Value = value;
        }

        public DataGridViewColumn Column { get; }
        public object Value { get; }
    }
}
