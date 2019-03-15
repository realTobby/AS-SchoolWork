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
    public partial class Praktikanten_Erstellung : Form
    {
        private Fachkonzept GUIFachkonzept;
        public void TransparencyButtons()
        {
            btnErstellen.FlatStyle = FlatStyle.Popup;
            btnAbbruch.FlatStyle = FlatStyle.Popup;
        }
        public Praktikanten_Erstellung(Fachkonzept fachkonzept)
        {
            GUIFachkonzept = fachkonzept;
            InitializeComponent();
        }
        private void LoadParktikantenErstellung(object sender, EventArgs e)
        {
            TransparencyButtons();
        }

        private void btnErstellen_Click(object sender, EventArgs e)
        {
            GUIFachkonzept.createPraktikant(tbxName.Text);
            tbxName.Text = String.Empty;
        }

        private void btnAbbruch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
