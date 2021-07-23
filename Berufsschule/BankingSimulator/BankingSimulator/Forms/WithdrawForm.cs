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
    public partial class WithdrawForm : Form
    {
        MainComponents mc;
        BankingAccount bank;
        public WithdrawForm(MainComponents mc, BankingAccount bank)
        {
            this.mc = mc;
            this.bank = bank;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double moneyValue = Convert.ToDouble(textBox1.Text);

            if (moneyValue > 0 && bank.BALANCE >= moneyValue)
            {
                mc.withdraw(moneyValue, bank);
                mc.writeTransaction(bank.ID, bank.ID, "WITHDRAW", moneyValue);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Trying to withdraw negative / Not enough balance on the bank account!");
            }
        }
    }
}
