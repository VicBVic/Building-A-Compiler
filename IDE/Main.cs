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
    public partial class Main : Form
    {
        public dynamic settings = new ExpandoObject();

        public Main()
        {
            InitializeComponent();
        }

        public void openproject(string path)
        {
            Directory.CreateDirectory(path);
            MainFCTB f = new MainFCTB();
            f.projectpath = path;
            new Router().transition(this, f);
        }

        private void labelclick(object sender, EventArgs e)
        {
            openproject((sender as LinkLabel).Text);
        }

        private void addproject(string project)
        {
            LinkLabel proj = new LinkLabel();
            proj.Text = project;
            proj.Height = 25;
            proj.Width = 800;
            proj.Click += new EventHandler(labelclick);
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
            new Settings().setsettings(settings);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            settings = new Settings().getsettings();
            if (!File.Exists("settings.json"))new Settings().resetToDefault(settings);
            getprojects();
            if(!Directory.Exists(settings.projectdir))Directory.CreateDirectory(settings.projectdir);
        }

        private void createproject(object sender, FormClosingEventArgs e)
        {
            (sender as creareProiect).Visible = false;
            if ((sender as creareProiect).fpath!="") {
                openproject((sender as creareProiect).fpath);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            creareProiect create=new creareProiect();
            create.settings=settings;
            create.FormClosing += new FormClosingEventHandler(createproject);
            create.ShowDialog();
        }

        private bool match(string other)
        {
            return other == folderBrowserDialog1.SelectedPath;
        }

        private bool addproject()
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath == "") return false ;
            Predicate<string> pred = match;
            if (settings.projects.FindIndex(pred) != -1)
            {
                MessageBox.Show("The project already exists!");
                return false ;
            }
            settings.projects.Add(folderBrowserDialog1.SelectedPath);
            new Settings().setsettings(settings);
            addproject(folderBrowserDialog1.SelectedPath);
            return true;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addproject();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!addproject()) return;
            MainFCTB f=new MainFCTB();
            f.settings=settings;
            f.projectpath=folderBrowserDialog1.SelectedPath;
            f.ShowDialog();
            Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new SettingsWindow().ShowDialog();
        }
    }
}
