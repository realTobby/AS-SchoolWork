using LabelDesigner.ViewModels;
using MahApps.Metro.Controls;
using ZPLUtility.Utils;

namespace LabelDesigner.Forms
{
    /// <summary>
    /// Interaction logic for ChecksumWindow.xaml
    /// </summary>
    public partial class ChecksumWindow : MetroWindow
    {
        public GTIN gtinHelper = new GTIN();

        public ChecksumWindow(MainWindowViewModel dataContext)
        {
            InitializeComponent();

            this.DataContext = dataContext;

        }

        private void btn_Generate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string result = gtinHelper.CalculateGTIN13CheckDigit(txtBox_eanInput.Text);
            txtBox_eanOutput.Text = result;
        }
    }
}
