namespace PraktikantVerwaltungGUI
{
    partial class Abteilung_Ändern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abteilung_Ändern));
            this.btnAbbruch = new System.Windows.Forms.Button();
            this.btnLoeschen = new System.Windows.Forms.Button();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.lblAbteilung = new System.Windows.Forms.Label();
            this.tbxAbteilung = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAbbruch
            // 
            this.btnAbbruch.BackColor = System.Drawing.Color.Transparent;
            this.btnAbbruch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAbbruch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbbruch.ForeColor = System.Drawing.Color.White;
            this.btnAbbruch.Location = new System.Drawing.Point(244, 97);
            this.btnAbbruch.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbbruch.Name = "btnAbbruch";
            this.btnAbbruch.Size = new System.Drawing.Size(86, 24);
            this.btnAbbruch.TabIndex = 26;
            this.btnAbbruch.Text = "Abbruch";
            this.btnAbbruch.UseVisualStyleBackColor = false;
            this.btnAbbruch.Click += new System.EventHandler(this.btnAbbruch_Click);
            // 
            // btnLoeschen
            // 
            this.btnLoeschen.BackColor = System.Drawing.Color.Transparent;
            this.btnLoeschen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoeschen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoeschen.ForeColor = System.Drawing.Color.White;
            this.btnLoeschen.Location = new System.Drawing.Point(157, 97);
            this.btnLoeschen.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoeschen.Name = "btnLoeschen";
            this.btnLoeschen.Size = new System.Drawing.Size(93, 24);
            this.btnLoeschen.TabIndex = 25;
            this.btnLoeschen.Text = "Löschen";
            this.btnLoeschen.UseVisualStyleBackColor = false;
            this.btnLoeschen.Click += new System.EventHandler(this.btnLoeschen_Click);
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.BackColor = System.Drawing.Color.Transparent;
            this.btnSpeichern.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSpeichern.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeichern.ForeColor = System.Drawing.Color.White;
            this.btnSpeichern.Location = new System.Drawing.Point(69, 97);
            this.btnSpeichern.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(92, 24);
            this.btnSpeichern.TabIndex = 24;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = false;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // lblAbteilung
            // 
            this.lblAbteilung.AutoSize = true;
            this.lblAbteilung.BackColor = System.Drawing.Color.Transparent;
            this.lblAbteilung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbteilung.ForeColor = System.Drawing.Color.White;
            this.lblAbteilung.Location = new System.Drawing.Point(164, 30);
            this.lblAbteilung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(76, 18);
            this.lblAbteilung.TabIndex = 23;
            this.lblAbteilung.Text = "Abteilung";
            this.lblAbteilung.Click += new System.EventHandler(this.lblAbteilung_Click);
            // 
            // tbxAbteilung
            // 
            this.tbxAbteilung.Location = new System.Drawing.Point(121, 50);
            this.tbxAbteilung.Margin = new System.Windows.Forms.Padding(2);
            this.tbxAbteilung.Name = "tbxAbteilung";
            this.tbxAbteilung.Size = new System.Drawing.Size(165, 20);
            this.tbxAbteilung.TabIndex = 20;
            // 
            // Abteilung_Ändern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(416, 146);
            this.Controls.Add(this.btnAbbruch);
            this.Controls.Add(this.btnLoeschen);
            this.Controls.Add(this.btnSpeichern);
            this.Controls.Add(this.lblAbteilung);
            this.Controls.Add(this.tbxAbteilung);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Abteilung_Ändern";
            this.ShowIcon = false;
            this.Text = "Abteilung_Ändern";
            this.Load += new System.EventHandler(this.Abteilung_Ändern_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbbruch;
        private System.Windows.Forms.Button btnLoeschen;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Label lblAbteilung;
        private System.Windows.Forms.TextBox tbxAbteilung;
    }
}