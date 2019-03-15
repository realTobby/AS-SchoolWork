namespace PraktikantVerwaltungGUI
{
    partial class Praktikanten_Erstellung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Praktikanten_Erstellung));
            this.lblName = new System.Windows.Forms.Label();
            this.btnAbbruch = new System.Windows.Forms.Button();
            this.btnErstellen = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(128, 34);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // btnAbbruch
            // 
            this.btnAbbruch.BackColor = System.Drawing.Color.Transparent;
            this.btnAbbruch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAbbruch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbbruch.ForeColor = System.Drawing.Color.White;
            this.btnAbbruch.Location = new System.Drawing.Point(155, 97);
            this.btnAbbruch.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbbruch.Name = "btnAbbruch";
            this.btnAbbruch.Size = new System.Drawing.Size(78, 24);
            this.btnAbbruch.TabIndex = 11;
            this.btnAbbruch.Text = "Abbruch";
            this.btnAbbruch.UseVisualStyleBackColor = false;
            this.btnAbbruch.Click += new System.EventHandler(this.btnAbbruch_Click);
            // 
            // btnErstellen
            // 
            this.btnErstellen.BackColor = System.Drawing.Color.Transparent;
            this.btnErstellen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnErstellen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErstellen.ForeColor = System.Drawing.Color.White;
            this.btnErstellen.Location = new System.Drawing.Point(68, 97);
            this.btnErstellen.Margin = new System.Windows.Forms.Padding(2);
            this.btnErstellen.Name = "btnErstellen";
            this.btnErstellen.Size = new System.Drawing.Size(83, 24);
            this.btnErstellen.TabIndex = 10;
            this.btnErstellen.Text = "Erstellen";
            this.btnErstellen.UseVisualStyleBackColor = false;
            this.btnErstellen.Click += new System.EventHandler(this.btnErstellen_Click);
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(68, 57);
            this.tbxName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(165, 20);
            this.tbxName.TabIndex = 12;
            // 
            // Praktikanten_Erstellung
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(302, 145);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.btnAbbruch);
            this.Controls.Add(this.btnErstellen);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Praktikanten_Erstellung";
            this.Text = "Praktikanten_Erstellung";
            this.Load += new System.EventHandler(this.LoadParktikantenErstellung);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAbbruch;
        private System.Windows.Forms.Button btnErstellen;
        private System.Windows.Forms.TextBox tbxName;
    }
}