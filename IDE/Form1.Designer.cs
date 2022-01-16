namespace IDE
{
    partial class Form1
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
            this.mainSplitter = new System.Windows.Forms.SplitContainer();
            this.panouGeneral = new System.Windows.Forms.FlowLayoutPanel();
            this.add = new System.Windows.Forms.Button();
            this.splitterSecundar = new System.Windows.Forms.SplitContainer();
            this.files = new System.Windows.Forms.TreeView();
            this.splitterFTC = new System.Windows.Forms.SplitContainer();
            this.panouFTC = new System.Windows.Forms.FlowLayoutPanel();
            this.run = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.salv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).BeginInit();
            this.mainSplitter.Panel1.SuspendLayout();
            this.mainSplitter.Panel2.SuspendLayout();
            this.mainSplitter.SuspendLayout();
            this.panouGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitterSecundar)).BeginInit();
            this.splitterSecundar.Panel1.SuspendLayout();
            this.splitterSecundar.Panel2.SuspendLayout();
            this.splitterSecundar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitterFTC)).BeginInit();
            this.splitterFTC.Panel1.SuspendLayout();
            this.splitterFTC.Panel2.SuspendLayout();
            this.splitterFTC.SuspendLayout();
            this.panouFTC.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitter
            // 
            this.mainSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitter.Location = new System.Drawing.Point(0, 0);
            this.mainSplitter.Name = "mainSplitter";
            this.mainSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitter.Panel1
            // 
            this.mainSplitter.Panel1.Controls.Add(this.panouGeneral);
            // 
            // mainSplitter.Panel2
            // 
            this.mainSplitter.Panel2.Controls.Add(this.splitterSecundar);
            this.mainSplitter.Size = new System.Drawing.Size(800, 450);
            this.mainSplitter.SplitterDistance = 25;
            this.mainSplitter.TabIndex = 2;
            // 
            // panouGeneral
            // 
            this.panouGeneral.Controls.Add(this.add);
            this.panouGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panouGeneral.Location = new System.Drawing.Point(0, 0);
            this.panouGeneral.Name = "panouGeneral";
            this.panouGeneral.Size = new System.Drawing.Size(798, 23);
            this.panouGeneral.TabIndex = 1;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(3, 3);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(50, 25);
            this.add.TabIndex = 0;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // splitterSecundar
            // 
            this.splitterSecundar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitterSecundar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitterSecundar.Location = new System.Drawing.Point(0, 0);
            this.splitterSecundar.Name = "splitterSecundar";
            // 
            // splitterSecundar.Panel1
            // 
            this.splitterSecundar.Panel1.Controls.Add(this.files);
            // 
            // splitterSecundar.Panel2
            // 
            this.splitterSecundar.Panel2.Controls.Add(this.splitterFTC);
            this.splitterSecundar.Size = new System.Drawing.Size(800, 421);
            this.splitterSecundar.SplitterDistance = 150;
            this.splitterSecundar.TabIndex = 2;
            // 
            // files
            // 
            this.files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.files.Location = new System.Drawing.Point(0, 0);
            this.files.Name = "files";
            this.files.Size = new System.Drawing.Size(148, 419);
            this.files.TabIndex = 0;
            // 
            // splitterFTC
            // 
            this.splitterFTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitterFTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitterFTC.Location = new System.Drawing.Point(0, 0);
            this.splitterFTC.Name = "splitterFTC";
            this.splitterFTC.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitterFTC.Panel1
            // 
            this.splitterFTC.Panel1.Controls.Add(this.panouFTC);
            // 
            // splitterFTC.Panel2
            // 
            this.splitterFTC.Panel2.Controls.Add(this.tabs);
            this.splitterFTC.Size = new System.Drawing.Size(646, 421);
            this.splitterFTC.SplitterDistance = 26;
            this.splitterFTC.TabIndex = 1;
            // 
            // panouFTC
            // 
            this.panouFTC.Controls.Add(this.run);
            this.panouFTC.Controls.Add(this.salv);
            this.panouFTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panouFTC.Location = new System.Drawing.Point(0, 0);
            this.panouFTC.Margin = new System.Windows.Forms.Padding(5);
            this.panouFTC.Name = "panouFTC";
            this.panouFTC.Size = new System.Drawing.Size(644, 24);
            this.panouFTC.TabIndex = 1;
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(3, 3);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(75, 25);
            this.run.TabIndex = 0;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // tabs
            // 
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(644, 389);
            this.tabs.TabIndex = 0;
            // 
            // salv
            // 
            this.salv.Location = new System.Drawing.Point(84, 3);
            this.salv.Name = "salv";
            this.salv.Size = new System.Drawing.Size(75, 25);
            this.salv.TabIndex = 1;
            this.salv.Text = "Save";
            this.salv.UseVisualStyleBackColor = true;
            this.salv.Click += new System.EventHandler(this.salv_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainSplitter);
            this.Name = "Form1";
            this.Text = "IDERV";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.ResizeForm);
            this.mainSplitter.Panel1.ResumeLayout(false);
            this.mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).EndInit();
            this.mainSplitter.ResumeLayout(false);
            this.panouGeneral.ResumeLayout(false);
            this.splitterSecundar.Panel1.ResumeLayout(false);
            this.splitterSecundar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitterSecundar)).EndInit();
            this.splitterSecundar.ResumeLayout(false);
            this.splitterFTC.Panel1.ResumeLayout(false);
            this.splitterFTC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitterFTC)).EndInit();
            this.splitterFTC.ResumeLayout(false);
            this.panouFTC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitter;
        private System.Windows.Forms.FlowLayoutPanel panouGeneral;
        private System.Windows.Forms.SplitContainer splitterSecundar;
        private System.Windows.Forms.SplitContainer splitterFTC;
        private System.Windows.Forms.FlowLayoutPanel panouFTC;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TreeView files;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.Button salv;
    }
}

