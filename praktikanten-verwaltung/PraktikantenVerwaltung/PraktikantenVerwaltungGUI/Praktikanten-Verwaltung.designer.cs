namespace PraktikantVerwaltungGUI
{
    partial class PVerwaltung
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PVerwaltung));
            this.lblPraktikanten = new System.Windows.Forms.Label();
            this.lblAbteilungen = new System.Windows.Forms.Label();
            this.rboPraktikant = new System.Windows.Forms.RadioButton();
            this.rboAbteilung = new System.Windows.Forms.RadioButton();
            this.lbxPraktikanten = new System.Windows.Forms.ListBox();
            this.lbxAbteilungen = new System.Windows.Forms.ListBox();
            this.btnErstellen = new System.Windows.Forms.Button();
            this.btnAendern = new System.Windows.Forms.Button();
            this.btnBeenden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPraktikanten
            // 
            this.lblPraktikanten.AutoSize = true;
            this.lblPraktikanten.BackColor = System.Drawing.Color.Transparent;
            this.lblPraktikanten.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPraktikanten.ForeColor = System.Drawing.Color.White;
            this.lblPraktikanten.Location = new System.Drawing.Point(26, 66);
            this.lblPraktikanten.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPraktikanten.Name = "lblPraktikanten";
            this.lblPraktikanten.Size = new System.Drawing.Size(123, 24);
            this.lblPraktikanten.TabIndex = 0;
            this.lblPraktikanten.Text = "Praktikanten";
            // 
            // lblAbteilungen
            // 
            this.lblAbteilungen.AutoSize = true;
            this.lblAbteilungen.BackColor = System.Drawing.Color.Transparent;
            this.lblAbteilungen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbteilungen.ForeColor = System.Drawing.Color.White;
            this.lblAbteilungen.Location = new System.Drawing.Point(383, 67);
            this.lblAbteilungen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAbteilungen.Name = "lblAbteilungen";
            this.lblAbteilungen.Size = new System.Drawing.Size(123, 24);
            this.lblAbteilungen.TabIndex = 1;
            this.lblAbteilungen.Text = "Abteilungen";
            // 
            // rboPraktikant
            // 
            this.rboPraktikant.AutoSize = true;
            this.rboPraktikant.BackColor = System.Drawing.Color.Transparent;
            this.rboPraktikant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboPraktikant.ForeColor = System.Drawing.Color.White;
            this.rboPraktikant.Location = new System.Drawing.Point(172, 52);
            this.rboPraktikant.Margin = new System.Windows.Forms.Padding(2);
            this.rboPraktikant.Name = "rboPraktikant";
            this.rboPraktikant.Size = new System.Drawing.Size(99, 21);
            this.rboPraktikant.TabIndex = 2;
            this.rboPraktikant.TabStop = true;
            this.rboPraktikant.Text = "Praktikant";
            this.rboPraktikant.UseVisualStyleBackColor = false;
            // 
            // rboAbteilung
            // 
            this.rboAbteilung.AutoSize = true;
            this.rboAbteilung.BackColor = System.Drawing.Color.Transparent;
            this.rboAbteilung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rboAbteilung.ForeColor = System.Drawing.Color.White;
            this.rboAbteilung.Location = new System.Drawing.Point(274, 52);
            this.rboAbteilung.Margin = new System.Windows.Forms.Padding(2);
            this.rboAbteilung.Name = "rboAbteilung";
            this.rboAbteilung.Size = new System.Drawing.Size(94, 21);
            this.rboAbteilung.TabIndex = 3;
            this.rboAbteilung.TabStop = true;
            this.rboAbteilung.Text = "Abteilung";
            this.rboAbteilung.UseVisualStyleBackColor = false;
            // 
            // lbxPraktikanten
            // 
            this.lbxPraktikanten.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxPraktikanten.FormattingEnabled = true;
            this.lbxPraktikanten.HorizontalScrollbar = true;
            this.lbxPraktikanten.ItemHeight = 15;
            this.lbxPraktikanten.Location = new System.Drawing.Point(29, 92);
            this.lbxPraktikanten.Margin = new System.Windows.Forms.Padding(2);
            this.lbxPraktikanten.Name = "lbxPraktikanten";
            this.lbxPraktikanten.Size = new System.Drawing.Size(115, 94);
            this.lbxPraktikanten.TabIndex = 6;
            this.lbxPraktikanten.SelectedIndexChanged += new System.EventHandler(this.lbxPraktikanten_SelectedIndexChanged_1);
            // 
            // lbxAbteilungen
            // 
            this.lbxAbteilungen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAbteilungen.FormattingEnabled = true;
            this.lbxAbteilungen.HorizontalScrollbar = true;
            this.lbxAbteilungen.ItemHeight = 15;
            this.lbxAbteilungen.Location = new System.Drawing.Point(383, 92);
            this.lbxAbteilungen.Margin = new System.Windows.Forms.Padding(2);
            this.lbxAbteilungen.Name = "lbxAbteilungen";
            this.lbxAbteilungen.Size = new System.Drawing.Size(115, 94);
            this.lbxAbteilungen.TabIndex = 7;
            this.lbxAbteilungen.SelectedIndexChanged += new System.EventHandler(this.lbxAbteilungen_SelectedIndexChanged);
            // 
            // btnErstellen
            // 
            this.btnErstellen.BackColor = System.Drawing.Color.Transparent;
            this.btnErstellen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnErstellen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErstellen.ForeColor = System.Drawing.Color.White;
            this.btnErstellen.Location = new System.Drawing.Point(229, 110);
            this.btnErstellen.Margin = new System.Windows.Forms.Padding(2);
            this.btnErstellen.Name = "btnErstellen";
            this.btnErstellen.Size = new System.Drawing.Size(82, 24);
            this.btnErstellen.TabIndex = 8;
            this.btnErstellen.Text = "Erstellen";
            this.btnErstellen.UseVisualStyleBackColor = false;
            this.btnErstellen.Click += new System.EventHandler(this.btnErstellen_Click);
            // 
            // btnAendern
            // 
            this.btnAendern.BackColor = System.Drawing.Color.Transparent;
            this.btnAendern.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAendern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAendern.ForeColor = System.Drawing.Color.White;
            this.btnAendern.Location = new System.Drawing.Point(229, 140);
            this.btnAendern.Margin = new System.Windows.Forms.Padding(2);
            this.btnAendern.Name = "btnAendern";
            this.btnAendern.Size = new System.Drawing.Size(82, 24);
            this.btnAendern.TabIndex = 9;
            this.btnAendern.Text = "Ändern";
            this.btnAendern.UseVisualStyleBackColor = false;
            this.btnAendern.Click += new System.EventHandler(this.btnAendern_Click);
            // 
            // btnBeenden
            // 
            this.btnBeenden.BackColor = System.Drawing.Color.Transparent;
            this.btnBeenden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBeenden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeenden.ForeColor = System.Drawing.Color.White;
            this.btnBeenden.Location = new System.Drawing.Point(229, 168);
            this.btnBeenden.Margin = new System.Windows.Forms.Padding(2);
            this.btnBeenden.Name = "btnBeenden";
            this.btnBeenden.Size = new System.Drawing.Size(82, 24);
            this.btnBeenden.TabIndex = 10;
            this.btnBeenden.Text = "Beenden";
            this.btnBeenden.UseVisualStyleBackColor = false;
            this.btnBeenden.Click += new System.EventHandler(this.btnBeenden_Click);
            // 
            // PVerwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(525, 218);
            this.Controls.Add(this.btnBeenden);
            this.Controls.Add(this.btnAendern);
            this.Controls.Add(this.btnErstellen);
            this.Controls.Add(this.lbxAbteilungen);
            this.Controls.Add(this.lbxPraktikanten);
            this.Controls.Add(this.rboAbteilung);
            this.Controls.Add(this.rboPraktikant);
            this.Controls.Add(this.lblAbteilungen);
            this.Controls.Add(this.lblPraktikanten);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PVerwaltung";
            this.ShowIcon = false;
            this.Text = "Praktikanten-Verwaltung";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPraktikanten;
        private System.Windows.Forms.Label lblAbteilungen;
        private System.Windows.Forms.RadioButton rboPraktikant;
        private System.Windows.Forms.RadioButton rboAbteilung;
        private System.Windows.Forms.ListBox lbxPraktikanten;
        private System.Windows.Forms.ListBox lbxAbteilungen;
        private System.Windows.Forms.Button btnErstellen;
        private System.Windows.Forms.Button btnAendern;
        private System.Windows.Forms.Button btnBeenden;
    }
}

