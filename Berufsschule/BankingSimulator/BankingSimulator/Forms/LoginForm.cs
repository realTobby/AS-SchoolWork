using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSimulator
{
    public partial class LoginForm : Form
    {
        private MainComponents mc;
        private bool loginAccepted = false;

        private string EMAILUSED = "";


        public LoginForm(MainComponents mc)
        {
            this.mc = mc;
            InitializeComponent();
        }

        private void btn_send_login_Click(object sender, EventArgs e)
        {

            PersonalData data = new PersonalData();

            data.EMAIL = tbx_email.Text;
            data.PASSWORD = mc.GetPasswordHash(tbx_password.Text);

            EMAILUSED = data.EMAIL;

            if(mc.login(data) == true)
            {
                MessageBox.Show("Susseccfully Logged in");
                loginAccepted = true;
            }
            else
            {
                MessageBox.Show("No match found.");
                loginAccepted = false;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();


        }

        public bool login()
        {
            return loginAccepted;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        public string getUserEmail()
        {
            return EMAILUSED;
        }
    }
}
