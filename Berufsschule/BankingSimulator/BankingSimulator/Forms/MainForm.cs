using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSimulator
{
    // MainForm is the Main Form of this application. It starts the application.
    // gives the user the choice to register or login

    public partial class MainForm : Form
    {
        MainComponents mc = new MainComponents();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // should something happen when the Form successfully loaded? i prefer to use the constructor
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm(this.mc);
            var loginResult = loginform.ShowDialog();
            if (loginResult == DialogResult.OK)
            {
                if(loginform.login() == true)
                {
                    BankingForm bankingform = new BankingForm(this.mc, loginform.getUserEmail());
                    bankingform.ShowDialog();
                }

            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this.mc);
            registerForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mc.clearPersonalData();
            mc.clearBankAccount();
            mc.clearTransactions();
            MessageBox.Show("Deleted all Database records!");
        }
    }
}
