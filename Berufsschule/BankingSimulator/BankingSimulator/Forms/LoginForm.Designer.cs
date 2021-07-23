namespace BankingSimulator
{
    partial class LoginForm
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
            this.tbx_email = new System.Windows.Forms.TextBox();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.btn_send_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbx_email
            // 
            this.tbx_email.Location = new System.Drawing.Point(15, 54);
            this.tbx_email.Name = "tbx_email";
            this.tbx_email.Size = new System.Drawing.Size(142, 20);
            this.tbx_email.TabIndex = 0;
            // 
            // tbx_password
            // 
            this.tbx_password.Location = new System.Drawing.Point(15, 118);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.PasswordChar = '#';
            this.tbx_password.Size = new System.Drawing.Size(142, 20);
            this.tbx_password.TabIndex = 1;
            // 
            // btn_send_login
            // 
            this.btn_send_login.Location = new System.Drawing.Point(123, 163);
            this.btn_send_login.Name = "btn_send_login";
            this.btn_send_login.Size = new System.Drawing.Size(75, 23);
            this.btn_send_login.TabIndex = 2;
            this.btn_send_login.Text = "Login";
            this.btn_send_login.UseVisualStyleBackColor = true;
            this.btn_send_login.Click += new System.EventHandler(this.btn_send_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "E-Mail: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 198);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_send_login);
            this.Controls.Add(this.tbx_password);
            this.Controls.Add(this.tbx_email);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_email;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.Button btn_send_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}