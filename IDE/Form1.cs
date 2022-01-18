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

        public String projectpath;
        private int eline = 0;
        public dynamic settings;

        private void ResizeForm(object sender, EventArgs e)
        {
            mainSplitter.Panel1MinSize = 25;
            splitterFTC.Panel1MinSize = 25;
            splitterSecundar.Panel1MinSize = 150;
            mainSplitter.SplitterDistance = 25;
            splitterFTC.SplitterDistance = 25;
            splitterSecundar.SplitterDistance = 150;
        }

        private void removemark()
        {
            //if(eline!=0)FTC.UnbookmarkLine(eline);
           // eline = 0;
        }

        private void openProject(String n)
        {
            //removemark();
            //FTC.Show();
            //run.Enabled = true;
            //projectName = n;
            //FTC.Text = File.ReadAllText(@"Projects\" + n + @"\main.rv");
        }

        private void projectClick(object sender, EventArgs e)
        {
            //String n = (sender as Button).Text;
            //openProject(n);
        }

        private string removepath(string path)
        {
            string name;
            name = path.Substring(path.LastIndexOf('\\')+1);
            return name;
        } 

        private void loadProject(TreeNodeCollection nodes,string path) 
        {
            foreach(string name in Directory.EnumerateFiles(path))
            {
                nodes.Add(removepath(name));
                nodes[nodes.Count - 1].Tag = name;
            }
            
            foreach (string name in Directory.EnumerateDirectories(path))
            {
                nodes.Add(removepath(name));
                loadProject(nodes[nodes.Count - 1].Nodes,name);
            }
        }

        private void nodeclick(object sender,TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Tag == null) return;
            string n = node.Tag.ToString();
            foreach(TabPage t in tabs.TabPages)
            {
                if (t.Tag.ToString() == n) return;
            }
            TabPage tab=new TabPage();
            FastColoredTextBoxNS.FastColoredTextBox FCTB = new FastColoredTextBoxNS.FastColoredTextBox();
            FCTB.Dock = DockStyle.Fill;
            FCTB.Text = File.ReadAllText(n); 
            tab.Controls.Add(FCTB);
            tab.Tag = n;
            tab.Text=removepath(n);
            tabs.TabPages.Add(tab);
            tabs.SelectedIndex = tabs.TabPages.Count-1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FTC.BookmarkColor= Color.Red;
            if (!Directory.Exists("Projects")) Directory.CreateDirectory("Projects");
            if (!Directory.Exists("Compiler")) Directory.CreateDirectory("Compiler");
            files.Nodes.Add(removepath(projectpath));
            loadProject(files.Nodes[0].Nodes,projectpath);
            settings = new Settings().getsettings();
            this.WindowState = FormWindowState.Maximized;
            files.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(nodeclick);
        }

        private void addProject(object sender, CancelEventArgs e)
        {
            //String n = (sender as creareProiect).name;
            //Directory.CreateDirectory(@"Projects\" + n);
            //File.Create(@"Projects\" + n + @"\main.rv").Close();
            //loadProject();
            //openProject(n);
        }

        private void add_Click(object sender, EventArgs e)
        {
            creareProiect creareProiect = new creareProiect();
            creareProiect.FormClosing += new System.Windows.Forms.FormClosingEventHandler(addProject);
            creareProiect.ShowDialog();
        }

        private void save()
        {
            File.WriteAllText(tabs.SelectedTab.Tag.ToString(),(tabs.SelectedTab.Controls[0] as FastColoredTextBoxNS.FastColoredTextBox).Text);
        }

        private void runBoy()
        {
            FastColoredTextBoxNS.FastColoredTextBox FTC = tabs.SelectedTab.Controls[0] as FastColoredTextBoxNS.FastColoredTextBox;
            save();
            removemark();
            File.WriteAllText(@"main.tmp", FTC.Text);
            Process p=new Process();
            Console.OpenStandardOutput();
            p.StartInfo.FileName = @"Compiler\Compiler.exe";
            p.Start();
            p.WaitForExit();
            File.Delete(@"main.tmp");
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

            //FTC.BookmarkLine (line);
            //FTC.GotoNextBookmark(line);
            eline = line;
        }

        private void FTC_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control&& e.KeyValue == 83)
            {
                //save();
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

        private void salv_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}
