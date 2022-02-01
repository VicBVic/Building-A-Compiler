using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IDE
{
    public partial class NewFileorFolder : Form
    {
        public TreeNode node;
        public bool file;
        public NewFileorFolder()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int val = e.KeyValue;
            e.SuppressKeyPress = !((val >= 'a' && val <= 'z') || (val >= 'A' && val <= 'Z') || (val >= '0' && val <= '9') || (val == ' ') || (val == 8)|| (val==190));
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (box.Text == "") MessageBox.Show("The textbox cannot be empty!");
            else
            {
                string path = node.Tag.ToString();
                path+=@"\"+box.Text;
                if (File.Exists(path)) { MessageBox.Show("A file with the same name already exists!");return; }
                if (Directory.Exists(path)) { MessageBox.Show("A folder with the same name already exists!"); return; }
                node.Nodes.Add(path.Substring(path.LastIndexOf('\\') + 1));
                node.Nodes[node.Nodes.Count - 1].Tag = path;
                if(file)File.Create(path).Close();
                else Directory.CreateDirectory(path);
                if (file) 
                {
                    node.Nodes[node.Nodes.Count - 1].ImageIndex = 1;
                    node.Nodes[node.Nodes.Count - 1].SelectedImageIndex = 1;
                }
                
                Close();
            }
        }
    }
}
