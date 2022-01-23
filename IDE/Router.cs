using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace IDE
{
    internal class Router
    {
        public void transition(Form from, Form to)
        {
            from.Visible = false;
            to.ShowDialog();
            from.Close();
        }
    }
}
