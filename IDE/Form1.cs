using System;
using System.IO;
using System.Threading;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ResizeForm(object sender, EventArgs e)
        {
            mainSplitter.Panel1MinSize = 25;
            splitterFTC.Panel1MinSize = 25;
            splitterSecundar.Panel1MinSize = 100;
            mainSplitter.SplitterDistance = 25;
            splitterFTC.SplitterDistance = 25;
            splitterSecundar.SplitterDistance = 100;
        }

        private void openProject(String n)
        {
            FTC.Text = File.ReadAllText(@"Projects\" + n + @"\main.rv");
        }

        private void projectClick(object sender, EventArgs e)
        {
            String n=(sender as Button).Text;
            openProject(n);
        }

        private void loadProjects() 
        {
            projectList.Controls.Clear();
            foreach (String name in Directory.EnumerateDirectories("Projects"))
            {
                String n=name.Remove(0,9);
                Button button = new Button();
                button.Text = n;
                button.Click += new System.EventHandler(projectClick);
                projectList.Controls.Add(button);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadProjects();
        }

        private void TextBox_Load(object sender, EventArgs e)
        {

        }

        private void ProjectList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addProject(object sender, CancelEventArgs e)
        {
            String n = (sender as creareProiect).name;
            Directory.CreateDirectory(@"Projects\" + n);
            FileStream tmp=File.Create(@"Projects\" + n + @"\main.rv");
            tmp.Close();
            loadProjects();
            openProject(n);
        }

        private void add_Click(object sender, EventArgs e)
        {
            creareProiect creareProiect = new creareProiect();
            creareProiect.FormClosing += new System.Windows.Forms.FormClosingEventHandler(addProject);
            creareProiect.ShowDialog();
        }
    }
}
