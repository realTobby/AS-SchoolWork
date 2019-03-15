namespace PraktikantVerwaltungGUI
{
    partial class Abteilung_Erstellung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abteilung_Erstellung));
            this.tbxBezeichnung = new System.Windows.Forms.TextBox();
            this.btnAbbruch = new System.Windows.Forms.Button();
            this.btnErstellen = new System.Windows.Forms.Button();
            this.lblBezeichnung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxBezeichnung
            // 
            this.tbxBezeichnung.Location = new System.Drawing.Point(45, 54);
            this.tbxBezeichnung.Margin = new System.Windows.Forms.Padding(2);
            this.tbxBezeichnung.Name = "tbxBezeichnung";
            this.tbxBezeichnung.Size = new System.Drawing.Size(165, 20);
            this.tbxBezeichnung.TabIndex = 16;
            // 
            // btnAbbruch
            // 
            this.btnAbbruch.BackColor = System.Drawing.Color.Transparent;
            this.btnAbbruch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAbbruch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbbruch.ForeColor = System.Drawing.Color.White;
            this.btnAbbruch.Location = new System.Drawing.Point(133, 94);
            this.btnAbbruch.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbbruch.Name = "btnAbbruch";
            this.btnAbbruch.Size = new System.Drawing.Size(77, 24);
            this.btnAbbruch.TabIndex = 15;
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
            this.btnErstellen.Location = new System.Drawing.Point(45, 94);
            this.btnErstellen.Margin = new System.Windows.Forms.Padding(2);
            this.btnErstellen.Name = "btnErstellen";
            this.btnErstellen.Size = new System.Drawing.Size(84, 24);
            this.btnErstellen.TabIndex = 14;
            this.btnErstellen.Text = "Erstellen";
            this.btnErstellen.UseVisualStyleBackColor = false;
            this.btnErstellen.Click += new System.EventHandler(this.btnErstellen_Click);
            // 
            // lblBezeichnung
            // 
            this.lblBezeichnung.AutoSize = true;
            this.lblBezeichnung.BackColor = System.Drawing.Color.Transparent;
            this.lblBezeichnung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBezeichnung.ForeColor = System.Drawing.Color.White;
            this.lblBezeichnung.Location = new System.Drawing.Point(70, 32);
            this.lblBezeichnung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(113, 20);
            this.lblBezeichnung.TabIndex = 13;
            this.lblBezeichnung.Text = "Bezeichnung";
            // 
            // Abteilung_Erstellung
            // 
            this.AccessibleName = "";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(254, 150);
            this.Controls.Add(this.tbxBezeichnung);
            this.Controls.Add(this.btnAbbruch);
            this.Controls.Add(this.btnErstellen);
            this.Controls.Add(this.lblBezeichnung);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Abteilung_Erstellung";
            this.ShowIcon = false;
            this.Text = "Abteilung_Erstellung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxBezeichnung;
        private System.Windows.Forms.Button btnAbbruch;
        private System.Windows.Forms.Button btnErstellen;
        private System.Windows.Forms.Label lblBezeichnung;
    }
}