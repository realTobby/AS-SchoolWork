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
    public partial class RegisterForm : Form
    {
        MainComponents mc;
        public RegisterForm(MainComponents mc)
        {
            this.mc = mc;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonalData person = new PersonalData();

            if(tbx_name.Text != string.Empty
                && tbx_lastname.Text != string.Empty
                && tbx_email.Text != string.Empty
                && tbx_password.Text != string.Empty
                && tbx_username.Text != string.Empty)
            {
                person.LASTNAME = tbx_lastname.Text;
                person.NAME = tbx_name.Text;
                person.TELEPHONE = tbx_telephone.Text;
                person.EMAIL = tbx_email.Text;
                person.PASSWORD = mc.GetPasswordHash(tbx_password.Text);
                person.USERNAME = tbx_username.Text;

                if (mc.RegisterPerson(person) == true)
                {
                    MessageBox.Show("Successfully registered!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email already in use!");
                }
            }
            else
            {
                MessageBox.Show("Please fill out the needed data (*)");
            }
        }

        public void ResetFields()
        {
            tbx_lastname.Text = string.Empty;
            tbx_name.Text = string.Empty;
            tbx_telephone.Text = string.Empty;
            tbx_email.Text = string.Empty;
            tbx_password.Text = string.Empty;
            tbx_username.Text = string.Empty;
        }
    }
}
