using LabelDesigner.Models;
using LabelDesigner.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ZPLUtility.Utils;

namespace LabelDesigner.Forms
{
    /// <summary>
    /// Interaction logic for PrintingWindow.xaml
    /// </summary>
    public partial class PrintingWindow : MetroWindow
    {
        MainWindowViewModel tempViewModel;
        public PrintingWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            tempViewModel = viewModel;
            this.DataContext = tempViewModel;
            bool beforeValue = tempViewModel.ReplacePrintVariables;
            tempViewModel.ReplacePrintVariables = true;
            tempViewModel.ReplacePrintVariables = beforeValue;
        }

        private void btn_print_Click(object sender, RoutedEventArgs e)
        {
            // get print count

            int printCount = Convert.ToInt32(txtBox_Counter.Text);
            for(int i = 0; i < printCount; i++)
                PrintOverIP();
        }

        private void PrintOverIP()
        {
            Dictionary<string, string> printVariables = new Dictionary<string, string>();

            if (tempViewModel.PrintVariableList == null || tempViewModel.PrintVariableList.Count == 0)
            {
                tempViewModel.PrintVariableList = new ObservableCollection<PrintDataRow>();
                tempViewModel.PrintVariableList.Add(new PrintDataRow() { VariableName = "test", VariableValue = "Hello" });
            }

            foreach (var variable in tempViewModel.PrintVariableList)
            {
                if (!printVariables.ContainsKey(variable.VariableName))
                    printVariables.Add(variable.VariableName, variable.VariableValue);
            }

            string result = tempViewModel.ResultZPL;
            foreach (KeyValuePair<string, string> entry in printVariables)
            {
                result = result.Replace(entry.Key, entry.Value);
            }


            ZPLPrint.PrintToSocket(tempViewModel.PrinterAddressAndPort.Split(':')[0], Convert.ToInt32(tempViewModel.PrinterAddressAndPort.Split(':')[1]), result, printVariables, "last.txt");
        }
    }
}
