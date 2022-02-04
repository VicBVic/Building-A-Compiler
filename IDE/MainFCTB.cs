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
    public partial class MainFCTB : Form
    {
        public MainFCTB()
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
                nodes[nodes.Count - 1].ImageIndex = 1;
                nodes[nodes.Count - 1].SelectedImageIndex = 1;
            }
            
            foreach (string name in Directory.EnumerateDirectories(path))
            {
                nodes.Add(removepath(name));
                nodes[nodes.Count - 1].Tag = name;
                loadProject(nodes[nodes.Count - 1].Nodes,name);
                nodes[nodes.Count - 1].ImageIndex = 0;
                nodes[nodes.Count - 1].SelectedImageIndex = 0;
            }
        }

        private void nodeclick(object sender,TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.SelectedImageIndex!=1) return;
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
            saveToolStripButton.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            files.ImageList = imageList1;
            files.Nodes.Add(removepath(projectpath));
            files.Nodes[0].Tag = projectpath;
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

        private void deletefile(string path)
        {
            File.Delete(path);
            for(int i=0;i<tabs.TabCount;i++)
            {
                if(tabs.TabPages[i].Tag.ToString() == path)
                {
                    tabs.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

        private void deletenode(TreeNode node)
        {
            if(node.Tag == projectpath)
            {
                MessageBox.Show("Cannot delete the root folder!");
                return;
            }
            if (node.ImageIndex == 0) deletefolder(node.Tag.ToString());
            else deletefile(node.Tag.ToString());
            node.Remove();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFileorFolder f=new NewFileorFolder();
            if (files.SelectedNode == null) f.node = files.Nodes[0];
            else f.node = files.SelectedNode;
            if (!Directory.Exists(f.node.Tag.ToString()))
            {
                MessageBox.Show("You must select a folder!");
                return;
            }
            f.file = true;
            f.ShowDialog();
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFileorFolder f = new NewFileorFolder();
            if (files.SelectedNode == null) f.node = files.Nodes[0];
            else f.node = files.SelectedNode;
            if (!Directory.Exists(f.node.Tag.ToString()))
            {
                MessageBox.Show("You must select a folder!");
                return;
            }
            f.file = false;
            f.ShowDialog();
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
            new SettingsWindow().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Router().transition(this, new Main());
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("Are you sure you want to delete " + files.SelectedNode.Tag.ToString() +" ?","Are you sure ?", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)deletenode(files.SelectedNode);
        }

        private void tabs_ControlAdded(object sender, ControlEventArgs e)
        {
            saveToolStripButton.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            string file = tabs.SelectedTab.Tag.ToString();
            if (file[file.Length - 1] == 'v' &&
                file[file.Length - 2] == 'r' &&
                file[file.Length - 3] == '.'
                )
            {
                runStripButton1.Enabled = true;
                runToolStripMenuItem.Enabled = true;
            }
            else
            {
                runStripButton1.Enabled = false;
                runToolStripMenuItem.Enabled = false;
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveToolStripButton.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            string file = "";
            if (tabs.SelectedTab == null)
            {
                saveToolStripButton.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                runStripButton1.Enabled = false;
                runToolStripMenuItem.Enabled = false;
                return;
            }
            if (
                file[file.Length - 1] == 'v' &&
                file[file.Length - 2] == 'r' &&
                file[file.Length - 3] == '.'
               )
            {
                runStripButton1.Enabled = true;
                runToolStripMenuItem.Enabled = true;
            }
            else
            {
                runStripButton1.Enabled = false;
                runToolStripMenuItem.Enabled = false;
            }
        }
    }
}
