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
            Form1 f = new Form1();
            f.projectpath = (sender as LinkLabel).Text;
            f.settings = sett;
            f.ShowDialog();
            Close();
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
            settings=new Settings().getsettings();
            getprojects();
            if(!Directory.Exists(settings.projectdir))Directory.CreateDirectory(settings.projectdir);
        }

        private void close(object sender, FormClosingEventArgs e)
        {
            if ((sender as creareProiect).created) {
                Close(); 
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            creareProiect create=new creareProiect();
            create.settings=settings;
            create.Show();
            create.FormClosing += new FormClosingEventHandler(close);
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
            sett.setsettings(settings);
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
            Form1 f=new Form1();
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
            Form4 f=new Form4();
            f.settings = settings;
        }
    }
}
