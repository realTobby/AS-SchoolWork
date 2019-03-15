namespace StrategyPatternExample
{
    partial class Form1
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
            this.lbl_register = new System.Windows.Forms.Label();
            this.txtBox_email = new System.Windows.Forms.TextBox();
            this.txtBox_password = new System.Windows.Forms.TextBox();
            this.txtBox_username = new System.Windows.Forms.TextBox();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.btn_sendRegister = new System.Windows.Forms.Button();
            this.lbl_statusMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_register
            // 
            this.lbl_register.AutoSize = true;
            this.lbl_register.Location = new System.Drawing.Point(12, 9);
            this.lbl_register.Name = "lbl_register";
            this.lbl_register.Size = new System.Drawing.Size(49, 13);
            this.lbl_register.TabIndex = 0;
            this.lbl_register.Text = "Register:";
            // 
            // txtBox_email
            // 
            this.txtBox_email.Location = new System.Drawing.Point(122, 86);
            this.txtBox_email.Name = "txtBox_email";
            this.txtBox_email.Size = new System.Drawing.Size(100, 20);
            this.txtBox_email.TabIndex = 1;
            // 
            // txtBox_password
            // 
            this.txtBox_password.Location = new System.Drawing.Point(122, 119);
            this.txtBox_password.Name = "txtBox_password";
            this.txtBox_password.PasswordChar = '*';
            this.txtBox_password.Size = new System.Drawing.Size(100, 20);
            this.txtBox_password.TabIndex = 2;
            // 
            // txtBox_username
            // 
            this.txtBox_username.Location = new System.Drawing.Point(122, 52);
            this.txtBox_username.Name = "txtBox_username";
            this.txtBox_username.Size = new System.Drawing.Size(100, 20);
            this.txtBox_username.TabIndex = 0;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(43, 52);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(58, 13);
            this.lbl_username.TabIndex = 4;
            this.lbl_username.Text = "Username:";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(62, 89);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(39, 13);
            this.lbl_email.TabIndex = 5;
            this.lbl_email.Text = "E-Mail:";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(45, 122);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(56, 13);
            this.lbl_password.TabIndex = 6;
            this.lbl_password.Text = "Password:";
            // 
            // btn_sendRegister
            // 
            this.btn_sendRegister.Location = new System.Drawing.Point(226, 160);
            this.btn_sendRegister.Name = "btn_sendRegister";
            this.btn_sendRegister.Size = new System.Drawing.Size(49, 23);
            this.btn_sendRegister.TabIndex = 3;
            this.btn_sendRegister.Text = "Send";
            this.btn_sendRegister.UseVisualStyleBackColor = true;
            this.btn_sendRegister.Click += new System.EventHandler(this.btn_sendRegister_Click);
            // 
            // lbl_statusMessage
            // 
            this.lbl_statusMessage.AutoSize = true;
            this.lbl_statusMessage.Location = new System.Drawing.Point(12, 164);
            this.lbl_statusMessage.Name = "lbl_statusMessage";
            this.lbl_statusMessage.Size = new System.Drawing.Size(0, 13);
            this.lbl_statusMessage.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 195);
            this.Controls.Add(this.lbl_statusMessage);
            this.Controls.Add(this.btn_sendRegister);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.txtBox_username);
            this.Controls.Add(this.txtBox_password);
            this.Controls.Add(this.txtBox_email);
            this.Controls.Add(this.lbl_register);
            this.Name = "Form1";
            this.Text = "RegisterFormStrategy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_register;
        private System.Windows.Forms.TextBox txtBox_email;
        private System.Windows.Forms.TextBox txtBox_password;
        private System.Windows.Forms.TextBox txtBox_username;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Button btn_sendRegister;
        private System.Windows.Forms.Label lbl_statusMessage;
    }
}

