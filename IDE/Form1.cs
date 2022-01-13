using System;
using System.IO;
using System.Diagnostics;
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

        private String projectName;
        private int eline = 0;

        private void ResizeForm(object sender, EventArgs e)
        {
            mainSplitter.Panel1MinSize = 25;
            splitterFTC.Panel1MinSize = 25;
            splitterSecundar.Panel1MinSize = 100;
            mainSplitter.SplitterDistance = 25;
            splitterFTC.SplitterDistance = 25;
            splitterSecundar.SplitterDistance = 100;
        }

        private void removemark()
        {
            if(eline!=0)FTC.UnbookmarkLine(eline);
            eline = 0;
        }

        private void openProject(String n)
        {
            removemark();
            FTC.Show();
            projectName = n;
            FTC.Text = File.ReadAllText(@"Projects\" + n + @"\main.rv");
        }

        private void projectClick(object sender, EventArgs e)
        {
            String n = (sender as Button).Text;
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
            FTC.BookmarkColor= Color.Red;
            if (!Directory.Exists("Projects")) Directory.CreateDirectory("Projects");
            if (!Directory.Exists("Compiler")) Directory.CreateDirectory("Compiler");
            loadProjects();
            FTC.Hide();
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

        private void save()
        {
            File.WriteAllText(@"Projects\" + projectName + @"\main.rv", FTC.Text);
        }

        private void runBoy()
        {
            save();
            removemark();
            File.WriteAllText(@"Compiler\main.tmp", FTC.Text);
            Process p=Process.Start(@"Compiler\Compiler.exe");
            p.WaitForExit();
            if (p.ExitCode == 0) return;

            int errorcode = p.ExitCode%10;
            int line = (p.ExitCode/10)-1;

            switch (errorcode)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    MessageBox.Show("Eroare 5 la linia " + line.ToString());
                    break;
                
            }

            FTC.BookmarkLine (line);
            FTC.GotoNextBookmark(line);
            eline = line;
        }

        private void FTC_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control&& e.KeyValue == 83)
            {
                save();
            }
            if (e.Control && e.KeyValue == 82)
            {
                runBoy();
            }

        }

        private void run_Click(object sender, EventArgs e)
        {
            runBoy();
        }
    }
}
