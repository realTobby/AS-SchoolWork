using Schichten;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PraktikantVerwaltungGUI
{
    public partial class PVerwaltung : Form
    {
        public Fachkonzept GUIFAchkonzept;
        public void TransparencyButtons()
        {
            btnErstellen.FlatStyle = FlatStyle.Popup;
            btnAendern.FlatStyle = FlatStyle.Popup;
            btnBeenden.FlatStyle = FlatStyle.Popup;
        }
        public PVerwaltung()
        {
            InitializeComponent();
            GUIFAchkonzept = new Fachkonzept(new SqliteDatenhaltung());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TransparencyButtons();
            LoadListBoxes();
        }

        private void btnBeenden_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void btnErstellen_Click(object sender, EventArgs e)
        {
            if (rboPraktikant.Checked == true)
            {
                Praktikanten_Erstellung newPraktikant = new Praktikanten_Erstellung(GUIFAchkonzept);
                var dialogResult = newPraktikant.ShowDialog();

                if(dialogResult == DialogResult.OK)
                {
                    LoadListBoxes();
                }  
            }
            else
            {
                Abteilung_Erstellung newAbteilung = new Abteilung_Erstellung(GUIFAchkonzept);
                var dialogResult = newAbteilung.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    LoadListBoxes();
                }
            }
        }

        private void btnAendern_Click(object sender, EventArgs e)
        {
            if (rboPraktikant.Checked == true)
            {
                if (lbxPraktikanten.SelectedIndex == -1)
                {
                    MessageBox.Show("Bitte wählen Sie einen Praktikanten aus.");
                }
                else
                {
                    PraktikantÄndern praktikantÄndern = new PraktikantÄndern(lbxPraktikanten.SelectedItem.ToString(), GUIFAchkonzept);
                    var dialogResult = praktikantÄndern.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        LoadListBoxes();
                    }
                }

            }
            else 
            {
                if (lbxAbteilungen.SelectedIndex == -1)
                {
                    MessageBox.Show("Bitte wählen Sie eine Abteilung aus.");
                }
                else
                {
                    Abteilung_Ändern abteilungÄndern = new Abteilung_Ändern(lbxAbteilungen.SelectedItem.ToString(), GUIFAchkonzept);
                    var dialogResult = abteilungÄndern.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        LoadListBoxes();
                    }
                }
            }
        }

        public void LoadListBoxes()
        {
            lbxPraktikanten.Items.Clear();
            lbxAbteilungen.Items.Clear();
            List<PraktikantModel> praktikantenList = new List<PraktikantModel>();
            praktikantenList = GUIFAchkonzept.getPraktikanten();
            foreach (var item in praktikantenList)
            {
                lbxPraktikanten.Items.Add(item.Name + "," + item.Praktikant_NR);
            }
            List<AbteilungModel> abteilungList = new List<AbteilungModel>();
            abteilungList = GUIFAchkonzept.getAbteilungen();
            foreach (var item in abteilungList)
            {
                lbxAbteilungen.Items.Add(item.Bezeichnung + "," + item.Abteilung_NR);
            }
        }
        private void lbxPraktikanten_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            rboPraktikant.Checked = true;

        }

        private void lbxAbteilungen_SelectedIndexChanged(object sender, EventArgs e)
        {
            rboAbteilung.Checked = true;
        }
    }
}