using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;

namespace IDE
{
    public partial class Form4 : Form
    {

        public dynamic settings;
        public Form4()
        {
            InitializeComponent();
        }

        private void removeproject(string path)
        {
            settings.projects.Remove(path);
            new Settings().setsettings(settings);
            loadprojects();
        }

        private void deleteclick(object sender, EventArgs e)
        {
            removeproject((sender as Button).Tag.ToString());
        }

        private void loadprojects()
        {
            projectlist.Controls.Clear();
            foreach(var project in settings.projects)
            {
                FlowLayoutPanel panel=new FlowLayoutPanel();
                TextBox box = new TextBox();
                box.Text = project;
                box.Enabled = false;
                box.Height = 25;
                box.Width = 475;
                Button button = new Button();
                panel.Width = 650 ;
                panel.Height = 25;
                button.Text = "Delete";
                button.Tag = project;
                button.Click += new EventHandler(deleteclick);
                panel.Controls.Add(box);
                panel.Controls.Add(button);
                projectlist.Controls.Add(panel);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            settings = new Settings().getsettings();
            defpath.Text = settings.projectdir;
            loadprojects();
        }

        private void save_Click(object sender, EventArgs e)
        {
            new Settings().setsettings(settings);
            new Router().transition(this, new Form3());
        }

        private void deff_Click(object sender, EventArgs e)
        {
            
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath == "") return;
            defpath.Text = folderBrowserDialog1.SelectedPath;

        }

        private void remove_Click(object sender, EventArgs e)
        {
            settings.projects.Clear();
            new Settings().setsettings(settings);
            loadprojects();
        }

        private void defaultt_Click(object sender, EventArgs e)
        {
            new Settings().resetToDefault(settings);
            Form4_Load(new object(),new EventArgs());
        }
    }
}
