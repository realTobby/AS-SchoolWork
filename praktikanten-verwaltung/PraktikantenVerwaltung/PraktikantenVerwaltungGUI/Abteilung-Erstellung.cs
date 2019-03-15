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
    public partial class Abteilung_Erstellung : Form
    {
        private Fachkonzept GUIFachkonzept;
        public void TransparencyButtons()
        {
            btnErstellen.FlatStyle = FlatStyle.Popup;
            btnAbbruch.FlatStyle = FlatStyle.Popup;
        }
        public Abteilung_Erstellung(Fachkonzept fachkonzept)
        {
            GUIFachkonzept = fachkonzept;
            InitializeComponent();
        }

        private void btnErstellen_Click(object sender, EventArgs e)
        {
            GUIFachkonzept.createAbteilung(tbxBezeichnung.Text);
            tbxBezeichnung.Text = String.Empty;
        }

        private void btnAbbruch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
