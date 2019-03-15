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
    public partial class Abteilung_Ändern : Form
    {
        private Fachkonzept GUIFachkonzept;
        public AbteilungModel oldAbt = new AbteilungModel();
        public void TransparencyButtons()
        {
            btnSpeichern.FlatStyle = FlatStyle.Popup;
            btnLoeschen.FlatStyle = FlatStyle.Popup;
            btnAbbruch.FlatStyle = FlatStyle.Popup;
        }
        public Abteilung_Ändern(string abteilungString, Fachkonzept konzept)
        {
            //InitializeComponent();
            //GUIFachkonzept = konzept;
            //AbteilungString = abteilungString;
            //string abteilungName = AbteilungString.Split(',')[0];

            //tbxAbteilung.Text = abteilungName;

            InitializeComponent();

            int abteilungsNr = 0;
            string abteilungsBezeichnung = "";

            abteilungsNr = Convert.ToInt32(abteilungString.Split(',')[1]);
            abteilungsBezeichnung = abteilungString.Split(',')[0];

            oldAbt = new AbteilungModel();
            oldAbt.Bezeichnung = abteilungsBezeichnung;
            oldAbt.Abteilung_NR = abteilungsNr;


            GUIFachkonzept = konzept;
            AbteilungModel abteilungModel = GUIFachkonzept.getAbteilungen().ToList().Where(x => x.Abteilung_NR == abteilungsNr && x.Bezeichnung == abteilungsBezeichnung).FirstOrDefault();
            tbxAbteilung.Text = abteilungModel.Bezeichnung;

        }

        private void lblAbteilung_Click(object sender, EventArgs e)
        {

        }

        private void Abteilung_Ändern_Load(object sender, EventArgs e)
        {

        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            int abteilungNummer = oldAbt.Abteilung_NR;
            string abteilungName = tbxAbteilung.Text;

            AbteilungModel newAbt = new AbteilungModel();
            newAbt.Bezeichnung = tbxAbteilung.Text;
            newAbt.Abteilung_NR = oldAbt.Abteilung_NR;

            GUIFachkonzept.changeAbteilung(oldAbt, newAbt);

            this.DialogResult = DialogResult.OK;
            MessageBox.Show(string.Format("Abteilung erfolgreich gespeichert! {0} => {1}", oldAbt.Bezeichnung, newAbt.Bezeichnung));
            Close();

        }

        private void btnLoeschen_Click(object sender, EventArgs e)
        {
            GUIFachkonzept.deleteAbteilung(oldAbt);
            this.DialogResult = DialogResult.OK;
            MessageBox.Show(string.Format("Abteilung: {0} erfolgreich gelöscht!", oldAbt.Bezeichnung));
            Close();
        }

        private void btnAbbruch_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
