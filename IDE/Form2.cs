using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE
{
    public partial class creareProiect : Form
    {

        public String name = "";
        public creareProiect()
        {
            if (!Directory.Exists("Projects"))
            {
                Directory.CreateDirectory("Projects");
            }
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            name = nume.Text;
            if (Directory.Exists( @"Projects\" +name))
            {
                MessageBox.Show("Proiectul deja exista");
            }
            else
            {
                this.Close();
            }
        }
    }
}
