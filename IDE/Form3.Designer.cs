namespace IDE
{
    partial class Form3
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.actionpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addnew = new System.Windows.Forms.Button();
            this.addold = new System.Windows.Forms.Button();
            this.set = new System.Windows.Forms.Button();
            this.projectpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.open = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.actionpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.actionpanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.projectpanel);
            this.splitContainer1.Size = new System.Drawing.Size(782, 753);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // actionpanel
            // 
            this.actionpanel.Controls.Add(this.addnew);
            this.actionpanel.Controls.Add(this.addold);
            this.actionpanel.Controls.Add(this.open);
            this.actionpanel.Controls.Add(this.set);
            this.actionpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionpanel.Location = new System.Drawing.Point(0, 0);
            this.actionpanel.Name = "actionpanel";
            this.actionpanel.Size = new System.Drawing.Size(782, 25);
            this.actionpanel.TabIndex = 0;
            // 
            // addnew
            // 
            this.addnew.Location = new System.Drawing.Point(3, 3);
            this.addnew.Name = "addnew";
            this.addnew.Size = new System.Drawing.Size(75, 25);
            this.addnew.TabIndex = 1;
            this.addnew.Text = "New";
            this.addnew.UseVisualStyleBackColor = true;
            this.addnew.Click += new System.EventHandler(this.addnew_Click);
            // 
            // addold
            // 
            this.addold.Location = new System.Drawing.Point(84, 3);
            this.addold.Name = "addold";
            this.addold.Size = new System.Drawing.Size(75, 25);
            this.addold.TabIndex = 2;
            this.addold.Text = "Add";
            this.addold.UseVisualStyleBackColor = true;
            this.addold.Click += new System.EventHandler(this.addold_Click);
            // 
            // set
            // 
            this.set.Location = new System.Drawing.Point(246, 3);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(75, 25);
            this.set.TabIndex = 3;
            this.set.Text = "Settings";
            this.set.UseVisualStyleBackColor = true;
            this.set.Click += new System.EventHandler(this.set_Click);
            // 
            // projectpanel
            // 
            this.projectpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectpanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.projectpanel.Location = new System.Drawing.Point(0, 0);
            this.projectpanel.Name = "projectpanel";
            this.projectpanel.Size = new System.Drawing.Size(782, 724);
            this.projectpanel.TabIndex = 0;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(165, 3);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 4;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.actionpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel actionpanel;
        private System.Windows.Forms.Button addnew;
        private System.Windows.Forms.Button addold;
        private System.Windows.Forms.Button set;
        private System.Windows.Forms.FlowLayoutPanel projectpanel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button open;
    }
}