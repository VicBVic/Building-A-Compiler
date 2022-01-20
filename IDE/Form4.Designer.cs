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
            this.projectlist = new System.Windows.Forms.FlowLayoutPanel();
            this.remove = new System.Windows.Forms.Button();
            this.defaultt = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
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
            // projectlist
            // 
            this.projectlist.AutoScroll = true;
            this.projectlist.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.projectlist.Location = new System.Drawing.Point(12, 40);
            this.projectlist.Name = "projectlist";
            this.projectlist.Size = new System.Drawing.Size(758, 636);
            this.projectlist.TabIndex = 5;
            this.projectlist.WrapContents = false;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(620, 682);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(150, 23);
            this.remove.TabIndex = 6;
            this.remove.Text = "Remove all projects";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // defaultt
            // 
            this.defaultt.Location = new System.Drawing.Point(488, 682);
            this.defaultt.Name = "defaultt";
            this.defaultt.Size = new System.Drawing.Size(126, 25);
            this.defaultt.TabIndex = 7;
            this.defaultt.Text = "Reset to default ";
            this.defaultt.UseVisualStyleBackColor = true;
            this.defaultt.Click += new System.EventHandler(this.defaultt_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(695, 718);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 8;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.defaultt);
            this.Controls.Add(this.projectlist);
            this.Controls.Add(this.def);
            this.Controls.Add(this.save);
            this.Controls.Add(this.defpath);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 800);
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
    }
}