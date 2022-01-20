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
                nodes[nodes.Count - 1].Tag = name;
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
            runStripButton1.Enabled = false;
            runToolStripMenuItem.Enabled = false;
            files.Nodes.Add(removepath(projectpath));
            loadProject(files.Nodes[0].Nodes,projectpath);
            settings = new Settings().getsettings();
            this.WindowState = FormWindowState.Maximized;
            files.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(nodeclick);
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

        private void deletefolder(string path)
        {
            Directory.Delete(path, true);
        }

        private void deletenode(TreeNode node)
        {
            if(node.Tag == null)
            {
                MessageBox.Show("Cannot delete the root folder!");
                return;
            }
            deletefolder(node.Tag.ToString());
            node.Remove();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runBoy();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Router().transition(this, new Form3());
        }

        private void tabs_TabIndexChanged(object sender, EventArgs e)
        {
            string file = tabs.SelectedTab.Tag.ToString();
            if (file[file.Length-1]=='v'&&
                file[file.Length - 1] == 'r'&&
                file[file.Length - 1] == '.'
                )
            {
                runStripButton1.Enabled=true;
                runToolStripMenuItem.Enabled=true;
            }
            else
            {
                runStripButton1.Enabled = false;
                runToolStripMenuItem.Enabled = false;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deletenode(files.SelectedNode);
        }
    }
}
