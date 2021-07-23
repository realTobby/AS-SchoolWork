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
    public partial class AddBankForm : Form
    {
        MainComponents mc;
        PersonalData owner;

        public AddBankForm(MainComponents mc, PersonalData owner)
        {
            this.mc = mc;
            this.owner = owner;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankingAccount account = new BankingAccount();

            if (tbx_name.Text != string.Empty)
            {
                account.NAME = tbx_name.Text;
                account.OWNER = owner.ID;

                if (mc.createBankAccount(account) == true)
                {
                    MessageBox.Show("Successfully created a new bank Account!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You already have a bank account with that name!");
                }
            }
            else
            {
                MessageBox.Show("Please specify a name...");
            }
        }
    }
}
