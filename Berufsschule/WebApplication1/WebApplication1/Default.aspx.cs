using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tbx_changed(object sender, EventArgs e)
        {
            CalcTheZinsen(sender, e);
        }

        protected void ButtonCalc_Click(object sender, EventArgs e)
        {

            CalcTheZinsen(sender, e);

        }

        private void CalcTheZinsen(object sender, EventArgs e)
        {

            if (sender == tbx_betragEuro) tbx_startjahr.Focus();
            if (sender == tbx_startjahr) tbx_laufzeit.Focus();
            if (sender == tbx_zinssatz) tbx_betragEuro.Focus();




            try
            {
                labelHeader.Text = "Zinseszins-Rechnung";
                labelHeader.ForeColor = System.Drawing.Color.Black;

                int euro = Convert.ToInt32(tbx_betragEuro.Text);
                int laufzeit = Convert.ToInt32(tbx_laufzeit.Text);
                double zinssatz = Convert.ToDouble(tbx_zinssatz.Text);

                double vorErg = 1 + Convert.ToDouble(zinssatz) / 100;
                double potent = Math.Pow(vorErg, laufzeit);
                double erg = potent * 3000;
                lbl_result.Text = Math.Round(erg, 2).ToString() + "€";
            }
            catch (System.FormatException)
            {
                labelHeader.Text = "NUR ZAHLEN ZUGELASSEN!";
                labelHeader.ForeColor = System.Drawing.Color.Red;
            }
        }


    }
}