namespace IDE
{
    partial class creareProiect
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
            this.nume = new System.Windows.Forms.TextBox();
            this.labelNume = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nume
            // 
            this.nume.Location = new System.Drawing.Point(12, 28);
            this.nume.Name = "nume";
            this.nume.Size = new System.Drawing.Size(208, 22);
            this.nume.TabIndex = 0;
            // 
            // labelNume
            // 
            this.labelNume.AutoSize = true;
            this.labelNume.Location = new System.Drawing.Point(12, 9);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(78, 16);
            this.labelNume.TabIndex = 1;
            this.labelNume.Text = "Enter name:";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(145, 68);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // creareProiect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(232, 103);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.labelNume);
            this.Controls.Add(this.nume);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "creareProiect";
            this.Text = "Create project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nume;
        private System.Windows.Forms.Label labelNume;
        private System.Windows.Forms.Button createButton;
    }
}