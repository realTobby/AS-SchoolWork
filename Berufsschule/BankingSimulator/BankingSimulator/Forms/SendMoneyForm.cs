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
    public partial class SendMoneyForm : Form
    {
        MainComponents mc;
        BankingAccount bank;
        public SendMoneyForm(MainComponents mc, BankingAccount bank)
        {
            this.mc = mc;
            this.bank = bank;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double moneyvalue = Convert.ToDouble(tbx_money.Text.ToString());

            int receiverBankID = Convert.ToInt32(tbx_id.Text);

            string usageText = tbx_usage.Text;

            BankingAccount recieverBank = mc.retrieveBankAccount(receiverBankID);

            if(bank.BALANCE >= moneyvalue && moneyvalue > 0)
            {
                mc.deposit(moneyvalue, recieverBank);
                mc.withdraw(moneyvalue, bank);
                mc.writeTransaction(bank.ID, recieverBank.ID, "SENDING MONEY", moneyvalue);
                MessageBox.Show("Successfully sended money over!");
            }else
            {
                MessageBox.Show("Trying to send negative! / Not enough balance!");
            }




        }
    }
}
