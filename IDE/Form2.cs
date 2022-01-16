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

        public dynamic settings;
        private string path;
        public bool created=false;
        public creareProiect()
        {
            InitializeComponent();
        }
        private void creareProiect_Load(object sender, EventArgs e)
        {
            path = settings.projectdir+@"\";
            fullpath.Text = path;
            fullpath.Enabled = false;
        }

        private bool match(string other)
        {
            return other == fullpath.Text;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if(nume.Text == "")
            {
                MessageBox.Show("The name cannot be null!");
                return;
            }
            Predicate<string> pred = match;
            if (settings.projects.FindIndex(pred)!=-1)
            {
                MessageBox.Show("The project already exists!");
                return;
            }
            settings.projects.Add(fullpath.Text);
            Settings sett=new Settings();
            sett.setsettings(settings);
            created = true;
            Form1 f = new Form1();
            Directory.CreateDirectory(fullpath.Text);
            File.Create(fullpath.Text+@"\main.rv").Close();
            f.projectpath = fullpath.Text;
            f.settings = settings;
            f.ShowDialog();
            Close();
        }

        private void folderselect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.ShowDialog();
            path = folderBrowserDialog1.SelectedPath;
            fullpath.Text = path + nume.Text;
        }

        private void nume_TextChanged(object sender, EventArgs e)
        {
            fullpath.Text = path + nume.Text;
        }
    }
}
