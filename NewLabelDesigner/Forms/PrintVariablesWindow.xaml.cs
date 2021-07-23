using LabelDesigner.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LabelDesigner.Forms
{
    /// <summary>
    /// Interaction logic for PrintVariablesWindow.xaml
    /// </summary>
    public partial class PrintVariablesWindow : MetroWindow
    {
        MainWindowViewModel tmpViewModel;
        public PrintVariablesWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            tmpViewModel = viewModel;
            this.DataContext = tmpViewModel;
        }
    }
}
