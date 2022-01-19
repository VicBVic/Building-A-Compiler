namespace IDE
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.defpath = new System.Windows.Forms.TextBox();
            this.def = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectlist = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // defpath
            // 
            this.defpath.Location = new System.Drawing.Point(12, 12);
            this.defpath.Name = "defpath";
            this.defpath.Size = new System.Drawing.Size(677, 22);
            this.defpath.TabIndex = 0;
            // 
            // def
            // 
            this.def.Location = new System.Drawing.Point(695, 12);
            this.def.Name = "def";
            this.def.Size = new System.Drawing.Size(75, 23);
            this.def.TabIndex = 1;
            this.def.Text = "...";
            this.def.UseVisualStyleBackColor = true;
            this.def.Click += new System.EventHandler(this.deff_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.removeAllProjectsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 723);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(782, 30);
            this.menuStrip1.TabIndex = 4;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(54, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // removeAllProjectsToolStripMenuItem
            // 
            this.removeAllProjectsToolStripMenuItem.Name = "removeAllProjectsToolStripMenuItem";
            this.removeAllProjectsToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.removeAllProjectsToolStripMenuItem.Text = "Remove all projects  ";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.resetToolStripMenuItem.Text = "Reset to default";
            // 
            // projectlist
            // 
            this.projectlist.AutoScroll = true;
            this.projectlist.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.projectlist.Location = new System.Drawing.Point(12, 40);
            this.projectlist.Name = "projectlist";
            this.projectlist.Size = new System.Drawing.Size(758, 675);
            this.projectlist.TabIndex = 5;
            this.projectlist.WrapContents = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.projectlist);
            this.Controls.Add(this.def);
            this.Controls.Add(this.defpath);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "Form4";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox defpath;
        private System.Windows.Forms.Button def;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel projectlist;
    }
}