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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ProjectList = new System.Windows.Forms.FlowLayoutPanel();
            this.TextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjectList
            // 
            this.ProjectList.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProjectList.Location = new System.Drawing.Point(0, 0);
            this.ProjectList.Margin = new System.Windows.Forms.Padding(5);
            this.ProjectList.Name = "ProjectList";
            this.ProjectList.Size = new System.Drawing.Size(150, 450);
            this.ProjectList.TabIndex = 0;
            this.ProjectList.Paint += new System.Windows.Forms.PaintEventHandler(this.ProjectList_Paint);
            // 
            // TextBox
            // 
            this.TextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.TextBox.AutoScrollMinSize = new System.Drawing.Size(221, 18);
            this.TextBox.BackBrush = null;
            this.TextBox.CharHeight = 18;
            this.TextBox.CharWidth = 10;
            this.TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.TextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.TextBox.ForeColor = System.Drawing.Color.Coral;
            this.TextBox.IsReplaceMode = false;
            this.TextBox.Location = new System.Drawing.Point(160, 0);
            this.TextBox.Margin = new System.Windows.Forms.Padding(5);
            this.TextBox.Name = "TextBox";
            this.TextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.TextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.TextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("TextBox.ServiceColors")));
            this.TextBox.Size = new System.Drawing.Size(640, 450);
            this.TextBox.TabIndex = 1;
            this.TextBox.Text = "fastColoredTextBox1";
            this.TextBox.Zoom = 100;
            this.TextBox.Load += new System.EventHandler(this.TextBox_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.ProjectList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ProjectList;
        private FastColoredTextBoxNS.FastColoredTextBox TextBox;
    }
}

