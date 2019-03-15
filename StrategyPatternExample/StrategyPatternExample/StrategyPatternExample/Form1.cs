using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrategyPatternExample
{
    public partial class Form1 : Form
    {
        Context myCntx;

        public Form1()
        {
            InitializeComponent();

            myCntx = new Context();

        }

        private void btn_sendRegister_Click(object sender, EventArgs e)
        {
            bool usernameOK = true;
            bool emailOK = false;
            bool passwordOK = false;

            string displayText = "";

            // check email
            myCntx.setUserInput(new UserInputEmail());
            emailOK = myCntx.checkInput(txtBox_email.Text);

            // check password
            myCntx.setUserInput(new UserInputPassword());
            passwordOK = myCntx.checkInput(txtBox_password.Text);

            if(emailOK == false)
            {
                displayText = displayText + "CHECK EMAIL!";
            }

            if(passwordOK == false)
            {
                displayText = displayText + " CHECK PASSWORD!";
            }

            if(emailOK == true && passwordOK == true && usernameOK == true)
            {
                displayText = "REGISTERED SUCCESSFULLY!";
            }

            lbl_statusMessage.Text = displayText;
        }
    }
}
