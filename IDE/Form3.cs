using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Dynamic;
using System.IO;

namespace IDE
{
    public partial class Form3 : Form
    {
        public dynamic settings = new ExpandoObject();
        Settings sett = new Settings();

        public Form3()
        {
            InitializeComponent();
        }

        private void openproject(object sender, EventArgs e)
        {
            MessageBox.Show((sender as LinkLabel).Text);
        }

        private void addproject(string project)
        {
            LinkLabel proj = new LinkLabel();
            proj.Text = project;
            proj.Height = 25;
            proj.Width = 800;
            proj.Click += new EventHandler(openproject);
            projectpanel.Controls.Add(proj);
        }

        private void getprojects()
        {
            List<string> toremove = new List<string>();
            foreach(string project in settings.projects)
            {
                if (Directory.Exists(project)) addproject(project);
                else
                {
                    toremove.Add(project);
                }
            }
            foreach(string project in toremove)
            {
                settings.projects.Remove(project);
            }
            sett.setsettings(settings);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (!File.Exists("settings.json"))sett.resetToDefault();
            settings=sett.getsettings();
            getprojects();
        }

        private void close(object sender, FormClosedEventArgs e)
        {
            //Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            creareProiect create=new creareProiect();
            create.settings=settings;
            create.Show();
            create.FormClosed += new FormClosedEventHandler(close);
        }

        private void open_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath == null) return;
            settings.projects.Add(folderBrowserDialog1.SelectedPath);
            sett.setsettings(settings);
            addproject(folderBrowserDialog1.SelectedPath);
        }

        private void set_Click(object sender, EventArgs e)
        {

        }

    }
}
