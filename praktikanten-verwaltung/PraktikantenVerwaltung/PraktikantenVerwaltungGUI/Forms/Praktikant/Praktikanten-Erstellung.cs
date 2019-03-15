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
            if(tbxName.Text != string.Empty)
            {
                GUIFachkonzept.createPraktikant(tbxName.Text);
                tbxName.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Feld darf nicht leer sein. Bitte Namen eingeben.");
            }
            
        }

        private void btnAbbruch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
