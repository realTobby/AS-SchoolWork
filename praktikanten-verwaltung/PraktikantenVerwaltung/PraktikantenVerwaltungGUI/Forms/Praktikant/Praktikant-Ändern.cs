using Schichten;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PraktikantVerwaltungGUI
{
    public partial class PraktikantÄndern : Form
    {
        public Fachkonzept GUIFachkonzept;
        public PraktikantModel oldP;
        public void TransparencyButtons()
        {
            btnSpeichern.FlatStyle = FlatStyle.Popup;
            btnLoeschen.FlatStyle = FlatStyle.Popup;
            btnAbbruch.FlatStyle = FlatStyle.Popup;
        }
        public PraktikantÄndern(string praktikantString, Fachkonzept fachkonzept)
        {
            InitializeComponent();

            int praktikantNr = 0;
            string praktikantName = "";

            praktikantNr = Convert.ToInt32(praktikantString.Split(',')[1]);
            praktikantName = praktikantString.Split(',')[0];

            GUIFachkonzept = fachkonzept;
            PraktikantModel praktikantModel = GUIFachkonzept.getPraktikanten().ToList().Where(x => x.Praktikant_NR == praktikantNr && x.Name == praktikantName).FirstOrDefault();
            tbxName.Text = praktikantModel.Name;
            AbteilungModel abt = GUIFachkonzept.getAbteilungen().ToList().Where(x => x.Abteilung_NR == praktikantModel.ZugewieseneAbteilung).FirstOrDefault();
            if (abt != null)
            {
                string abteilung = String.Format("{0},{1}", abt.Bezeichnung, abt.Abteilung_NR);
                cboAbteilung.Text = abteilung;
            }
            
            oldP = new PraktikantModel();
            oldP.Name = praktikantName;
            oldP.Praktikant_NR = praktikantNr;
            oldP.ZugewieseneAbteilung = praktikantModel.ZugewieseneAbteilung;

            int indx = 0;
            int endIndx = 0;
            bool found = false;
            List <AbteilungModel> abteilungList = GUIFachkonzept.getAbteilungen();
            foreach(var item in abteilungList)
            {
                cboAbteilung.Items.Add(item.Bezeichnung + "," + item.Abteilung_NR);
                if(praktikantModel.ZugewieseneAbteilung == item.Abteilung_NR)
                {
                    endIndx = indx;
                    found = true;
                }else
                {
                    if(found == false)
                        indx++;
                }
            }
            if (endIndx != 0)
            {
                cboAbteilung.SelectedIndex = endIndx;
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAbbruch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            Close();
        }

        private void btnLoeschen_Click(object sender, EventArgs e)
        {
            GUIFachkonzept.deletePraktikant(oldP);
            this.DialogResult = DialogResult.OK;
            MessageBox.Show(string.Format("Praktikant: {0} erfolgreich gelöscht!", oldP.Name));
            Close();
        }

        private void PraktikantÄndern_Load(object sender, EventArgs e)
        {

        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            PraktikantModel newPrakt = new PraktikantModel();

            List<AbteilungModel> abteilungList = GUIFachkonzept.getAbteilungen();

            int abteilungNr = Convert.ToInt32(cboAbteilung.SelectedItem.ToString().Split(',')[1]);

            string oldAbteilung = "nicht zugewiesen";
            if (oldP.ZugewieseneAbteilung != -1)
            {
                var abteilung = abteilungList.Where(x => x.Abteilung_NR == oldP.ZugewieseneAbteilung).FirstOrDefault();
                if (abteilung != null)
                    oldAbteilung = abteilung.Bezeichnung;
            }
                
            string newAbteilung = abteilungList.Where(x => x.Abteilung_NR == abteilungNr).FirstOrDefault().Bezeichnung;
            string oldName = oldP.Name;
            string newName = tbxName.Text;

            newPrakt.ZugewieseneAbteilung = abteilungNr;
            newPrakt.Name = newName;
            newPrakt.Praktikant_NR = oldP.Praktikant_NR;

            GUIFachkonzept.changePraktikant(oldP, newPrakt);

            MessageBox.Show(string.Format("Praktikant erfolgreich geändert! ({0},{1} => {2},{3})", oldName, oldAbteilung, newName, newAbteilung));
            this.DialogResult = DialogResult.OK;
            Close();



        }

        private void cboAbteilung_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
