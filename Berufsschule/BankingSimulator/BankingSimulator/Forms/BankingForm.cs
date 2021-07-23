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
    public partial class BankingForm : Form
    {
        MainComponents mc;
        PersonalData loggedInUser;

        public BankingForm(MainComponents mc, string useremail)
        {
            this.mc = mc;
            InitializeComponent();

            loggedInUser = mc.retrievePerson(useremail);
            lbl_welcome.Text = "Welcome, " + loggedInUser.LASTNAME + " " + loggedInUser.NAME + " - Personal ID: " + loggedInUser.ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBankForm newbankform = new AddBankForm(mc, loggedInUser);
            newbankform.ShowDialog();
            if(newbankform.DialogResult == DialogResult.OK)
            {
                LoadBanks();
            }
        }

        private void LoadBanks()
        {
            comboBox1.Items.Clear();
            var bankAccounts = mc.retrieveBankAccounts(loggedInUser);
            foreach (var item in bankAccounts)
            {
                comboBox1.Items.Add(item.ID + ", " + item.NAME);
            }
        }

        private void BankingForm_Load(object sender, EventArgs e)
        {
            LoadBanks();

        }

        public BankingAccount GetBankAccount()
        {
            var selectedItem = comboBox1.SelectedItem.ToString().Split(',');
            return mc.retrieveBankAccount(Convert.ToInt32(selectedItem[0]));
        }

        public void RefreshForm()
        {
            BankingAccount selectedBank = GetBankAccount();

            List<string> records = mc.GetTransactionRecords(selectedBank);
            listBox1.Items.Clear();
            foreach(var record in records)
            {
                listBox1.Items.Add(record);
            }

            lbl_balance.Text = string.Empty;
            lbl_balance.Text = selectedBank.BALANCE.ToString();

            lbl_bank_id.Text = string.Empty;
            lbl_bank_id.Text = selectedBank.ID.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DepositForm depositform = new DepositForm(mc, GetBankAccount());
            depositform.ShowDialog();
            if(depositform.DialogResult == DialogResult.OK)
            {
                
            }
            RefreshForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WithdrawForm withdrawform = new WithdrawForm(mc, GetBankAccount());
            withdrawform.ShowDialog();
            if (withdrawform.DialogResult == DialogResult.OK)
            {

            }
            RefreshForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SendMoneyForm sendmoneyform = new SendMoneyForm(mc, GetBankAccount());
            sendmoneyform.ShowDialog();
            if (sendmoneyform.DialogResult == DialogResult.OK)
            {

            }
            RefreshForm();
        }
    }
}
