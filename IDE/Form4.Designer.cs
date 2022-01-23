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
            this.components = new System.ComponentModel.Container();
            this.defpath = new System.Windows.Forms.TextBox();
            this.def = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.projectlist = new System.Windows.Forms.FlowLayoutPanel();
            this.remove = new System.Windows.Forms.Button();
            this.defaultt = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // defpath
            // 
            this.defpath.Location = new System.Drawing.Point(8, 22);
            this.defpath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.defpath.Name = "defpath";
            this.defpath.Size = new System.Drawing.Size(509, 20);
            this.defpath.TabIndex = 0;
            // 
            // def
            // 
            this.def.Location = new System.Drawing.Point(521, 22);
            this.def.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.def.Name = "def";
            this.def.Size = new System.Drawing.Size(56, 19);
            this.def.TabIndex = 1;
            this.def.Text = "...";
            this.def.UseVisualStyleBackColor = true;
            this.def.Click += new System.EventHandler(this.deff_Click);
            // 
            // projectlist
            // 
            this.projectlist.AutoScroll = true;
            this.projectlist.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.projectlist.Location = new System.Drawing.Point(9, 46);
            this.projectlist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.projectlist.Name = "projectlist";
            this.projectlist.Size = new System.Drawing.Size(568, 500);
            this.projectlist.TabIndex = 5;
            this.projectlist.WrapContents = false;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(465, 554);
            this.remove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(112, 19);
            this.remove.TabIndex = 6;
            this.remove.Text = "Remove all projects";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // defaultt
            // 
            this.defaultt.Location = new System.Drawing.Point(366, 554);
            this.defaultt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.defaultt.Name = "defaultt";
            this.defaultt.Size = new System.Drawing.Size(94, 20);
            this.defaultt.TabIndex = 7;
            this.defaultt.Text = "Reset to default ";
            this.defaultt.UseVisualStyleBackColor = true;
            this.defaultt.Click += new System.EventHandler(this.defaultt_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(521, 583);
            this.save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(56, 19);
            this.save.TabIndex = 8;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Project path:";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 609);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.defaultt);
            this.Controls.Add(this.projectlist);
            this.Controls.Add(this.def);
            this.Controls.Add(this.save);
            this.Controls.Add(this.defpath);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(603, 656);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(603, 597);
            this.Name = "Form4";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox defpath;
        private System.Windows.Forms.Button def;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel projectlist;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button defaultt;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
    }
}