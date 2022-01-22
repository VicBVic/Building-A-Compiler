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
            this.splitterSecundar = new System.Windows.Forms.SplitContainer();
            this.files = new System.Windows.Forms.TreeView();
            this.splitterFTC = new System.Windows.Forms.SplitContainer();
            this.panouFTC = new System.Windows.Forms.FlowLayoutPanel();
            this.run = new System.Windows.Forms.Button();
            this.salv = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).BeginInit();
            this.mainSplitter.Panel2.SuspendLayout();
            this.mainSplitter.SuspendLayout();
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
            this.mainSplitter.Location = new System.Drawing.Point(0, 0);
            this.mainSplitter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainSplitter.Name = "mainSplitter";
            this.mainSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitter.Panel2
            // 
            this.mainSplitter.Panel2.Controls.Add(this.splitterSecundar);
            this.mainSplitter.Size = new System.Drawing.Size(600, 366);
            this.mainSplitter.SplitterDistance = 25;
            this.mainSplitter.SplitterWidth = 3;
            this.mainSplitter.TabIndex = 2;
            // 
            // splitterSecundar
            // 
            this.splitterSecundar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitterSecundar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitterSecundar.Location = new System.Drawing.Point(0, 0);
            this.splitterSecundar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitterSecundar.Name = "splitterSecundar";
            // 
            // splitterSecundar.Panel1
            // 
            this.splitterSecundar.Panel1.Controls.Add(this.files);
            // 
            // splitterSecundar.Panel2
            // 
            this.splitterSecundar.Panel2.Controls.Add(this.splitterFTC);
            this.splitterSecundar.Size = new System.Drawing.Size(600, 338);
            this.splitterSecundar.SplitterDistance = 112;
            this.splitterSecundar.SplitterWidth = 3;
            this.splitterSecundar.TabIndex = 2;
            // 
            // files
            // 
            this.files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.files.Location = new System.Drawing.Point(0, 0);
            this.files.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.files.Name = "files";
            this.files.Size = new System.Drawing.Size(110, 336);
            this.files.TabIndex = 0;
            // 
            // splitterFTC
            // 
            this.splitterFTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitterFTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitterFTC.Location = new System.Drawing.Point(0, 0);
            this.splitterFTC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.splitterFTC.Size = new System.Drawing.Size(485, 338);
            this.splitterFTC.SplitterDistance = 25;
            this.splitterFTC.SplitterWidth = 3;
            this.splitterFTC.TabIndex = 1;
            // 
            // panouFTC
            // 
            this.panouFTC.Controls.Add(this.run);
            this.panouFTC.Controls.Add(this.salv);
            this.panouFTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panouFTC.Location = new System.Drawing.Point(0, 0);
            this.panouFTC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panouFTC.Name = "panouFTC";
            this.panouFTC.Size = new System.Drawing.Size(483, 23);
            this.panouFTC.TabIndex = 1;
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(2, 2);
            this.run.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(56, 20);
            this.run.TabIndex = 0;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // salv
            // 
            this.salv.Location = new System.Drawing.Point(62, 2);
            this.salv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.salv.Name = "salv";
            this.salv.Size = new System.Drawing.Size(56, 20);
            this.salv.TabIndex = 1;
            this.salv.Text = "Save";
            this.salv.UseVisualStyleBackColor = true;
            this.salv.Click += new System.EventHandler(this.salv_Click);
            // 
            // tabs
            // 
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(483, 308);
            this.tabs.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.mainSplitter);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "IDERV";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.ResizeForm);
            this.mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).EndInit();
            this.mainSplitter.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitterSecundar;
        private System.Windows.Forms.SplitContainer splitterFTC;
        private System.Windows.Forms.FlowLayoutPanel panouFTC;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.TreeView files;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.Button salv;
    }
}

