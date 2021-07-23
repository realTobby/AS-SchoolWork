using LabelDesigner.ViewModels;
using MahApps.Metro.Controls;

namespace LabelDesigner.Forms
{
    /// <summary>
    /// Interaction logic for EPCWindow.xaml
    /// </summary>
    public partial class EPCWindow : MetroWindow
    {
        public EPCWindow(MainWindowViewModel dataContext)
        {
            InitializeComponent();

            this.DataContext = dataContext;
        }

        private void btn_Generate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SysPro.EpcCoding.SGTIN96 epcGenetator = new SysPro.EpcCoding.SGTIN96();

            string fullElementString = string.Format("(01){0}(21){1}", txtBox_elementString.Text, txtBox_serialNumber.Text);

            string eanFirstPart = txtBox_elementString.Text.Substring(0, 6);
            string eanLastPart = txtBox_elementString.Text.Substring(6, txtBox_elementString.Text.Length - 6);

            string epcURI = string.Format("urn:epc:tag:sgtin-96:0.{0}.{1}.{2}", eanFirstPart, eanLastPart, txtBox_serialNumber.Text);

            var epcInfo = epcGenetator.Encode(epcURI);

            txtBox_epc.Text = epcInfo.EPC;

        }
    }
}
