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
    public partial class DepositForm : Form
    {
        MainComponents mc;
        BankingAccount bank;
        public DepositForm(MainComponents mc, BankingAccount bank)
        {
            this.mc = mc;
            this.bank = bank;
            InitializeComponent();
        }

        private void DepositForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double moneyValue = Convert.ToDouble(textBox1.Text);

            if(moneyValue > 0)
            {
                mc.deposit(moneyValue, bank);
                mc.writeTransaction(bank.ID, bank.ID, "DEPOSIT", moneyValue);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("You cant deposit negative money!");
            }

            
        }
    }
}
