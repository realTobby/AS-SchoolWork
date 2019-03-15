namespace PraktikantVerwaltungGUI
{
    partial class PraktikantÄndern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PraktikantÄndern));
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblPraktikant = new System.Windows.Forms.Label();
            this.lblAbteilung = new System.Windows.Forms.Label();
            this.btnLoeschen = new System.Windows.Forms.Button();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.btnAbbruch = new System.Windows.Forms.Button();
            this.cboAbteilung = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(51, 67);
            this.tbxName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(165, 20);
            this.tbxName.TabIndex = 13;
            this.tbxName.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            // 
            // lblPraktikant
            // 
            this.lblPraktikant.AutoSize = true;
            this.lblPraktikant.BackColor = System.Drawing.Color.Transparent;
            this.lblPraktikant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPraktikant.ForeColor = System.Drawing.Color.White;
            this.lblPraktikant.Location = new System.Drawing.Point(47, 41);
            this.lblPraktikant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPraktikant.Name = "lblPraktikant";
            this.lblPraktikant.Size = new System.Drawing.Size(84, 18);
            this.lblPraktikant.TabIndex = 15;
            this.lblPraktikant.Text = "Praktikant";
            // 
            // lblAbteilung
            // 
            this.lblAbteilung.AutoSize = true;
            this.lblAbteilung.BackColor = System.Drawing.Color.Transparent;
            this.lblAbteilung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbteilung.ForeColor = System.Drawing.Color.White;
            this.lblAbteilung.Location = new System.Drawing.Point(216, 41);
            this.lblAbteilung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(76, 18);
            this.lblAbteilung.TabIndex = 16;
            this.lblAbteilung.Text = "Abteilung";
            // 
            // btnLoeschen
            // 
            this.btnLoeschen.BackColor = System.Drawing.Color.Transparent;
            this.btnLoeschen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoeschen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoeschen.ForeColor = System.Drawing.Color.White;
            this.btnLoeschen.Location = new System.Drawing.Point(176, 110);
            this.btnLoeschen.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoeschen.Name = "btnLoeschen";
            this.btnLoeschen.Size = new System.Drawing.Size(93, 24);
            this.btnLoeschen.TabIndex = 18;
            this.btnLoeschen.Text = "Löschen";
            this.btnLoeschen.UseVisualStyleBackColor = false;
            this.btnLoeschen.Click += new System.EventHandler(this.btnLoeschen_Click);
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.BackColor = System.Drawing.Color.Transparent;
            this.btnSpeichern.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSpeichern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeichern.ForeColor = System.Drawing.Color.White;
            this.btnSpeichern.Location = new System.Drawing.Point(89, 110);
            this.btnSpeichern.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(93, 24);
            this.btnSpeichern.TabIndex = 17;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = false;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // btnAbbruch
            // 
            this.btnAbbruch.BackColor = System.Drawing.Color.Transparent;
            this.btnAbbruch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAbbruch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbbruch.ForeColor = System.Drawing.Color.White;
            this.btnAbbruch.Location = new System.Drawing.Point(264, 110);
            this.btnAbbruch.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbbruch.Name = "btnAbbruch";
            this.btnAbbruch.Size = new System.Drawing.Size(90, 24);
            this.btnAbbruch.TabIndex = 19;
            this.btnAbbruch.Text = "Abbruch";
            this.btnAbbruch.UseVisualStyleBackColor = false;
            this.btnAbbruch.Click += new System.EventHandler(this.btnAbbruch_Click);
            // 
            // cboAbteilung
            // 
            this.cboAbteilung.FormattingEnabled = true;
            this.cboAbteilung.Location = new System.Drawing.Point(219, 67);
            this.cboAbteilung.Name = "cboAbteilung";
            this.cboAbteilung.Size = new System.Drawing.Size(165, 21);
            this.cboAbteilung.TabIndex = 20;
            this.cboAbteilung.SelectedIndexChanged += new System.EventHandler(this.cboAbteilung_SelectedIndexChanged);
            // 
            // PraktikantÄndern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(436, 150);
            this.Controls.Add(this.cboAbteilung);
            this.Controls.Add(this.btnAbbruch);
            this.Controls.Add(this.btnLoeschen);
            this.Controls.Add(this.btnSpeichern);
            this.Controls.Add(this.lblAbteilung);
            this.Controls.Add(this.lblPraktikant);
            this.Controls.Add(this.tbxName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PraktikantÄndern";
            this.Text = "Praktikant_Ändern";
            this.Load += new System.EventHandler(this.PraktikantÄndern_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblPraktikant;
        private System.Windows.Forms.Label lblAbteilung;
        private System.Windows.Forms.Button btnLoeschen;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Button btnAbbruch;
        private System.Windows.Forms.ComboBox cboAbteilung;
    }
}