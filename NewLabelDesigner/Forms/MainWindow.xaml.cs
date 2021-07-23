using LabelDesigner.Logic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LabelDesigner.Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Private Fields
        private LabelDesignerFacade myLogicFacade;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            myLogicFacade = new LabelDesignerFacade();
            this.DataContext = myLogicFacade.GetViewModel();

            myLogicFacade.SetWindowTitle("NewLabelDesigner v0.1");

            myLogicFacade.ResetLabelDesigner();
            myLogicFacade.InitDefaultProject();
            
        }
        #endregion

        #region Menu Click Events
        private async void menu_file_new_Click(object sender, RoutedEventArgs e)
        {
            var controller = await this.ShowProgressAsync("Setze LabelDesigner zurück", "Bitte warten...");
            controller.SetIndeterminate();

            controller.SetMessage("Setzte LabelDesigner zurück!");
            myLogicFacade.ResetLabelDesigner();

            controller.SetMessage("Erstelle Default Template Project");
            myLogicFacade.InitDefaultProject();

            controller.SetMessage("Erstelle ZPL Vorschau!");
            myLogicFacade.GeneratePreview();

            await controller.CloseAsync();
        }

        private async void menu_file_open_Click(object sender, RoutedEventArgs e)
        {
            var controller = await this.ShowProgressAsync("ZPL Datei laden", "Bitte warten...");
            controller.SetIndeterminate();

            controller.SetMessage("Lade ZPL...");
            string[] zplCode = myLogicFacade.LoadZPL();

            controller.SetMessage("Erstelle LabelDesigner Objekte...");
            myLogicFacade.CreateLabelDesignerObjects(zplCode);

            controller.SetMessage("Setzte ZPL Code...");
            myLogicFacade.CreateResultZPL(zplCode);

            controller.SetMessage("Lade ZPL Platzhalter Variablen...");
            myLogicFacade.GetZPLPrintVariables();

            controller.SetMessage("Erstelle ZPL Vorschau...");
            myLogicFacade.GeneratePreview();

            await controller.CloseAsync();
        }

        private async void menu_file_save_Click(object sender, RoutedEventArgs e)
        {
            var controller = await this.ShowProgressAsync("Speichere ZPL", "Bitte warten...");
            controller.SetIndeterminate();
            myLogicFacade.SaveZPL();
            await controller.CloseAsync();
        }

        private void menu_file_exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private async void menu_print_open_Click(object sender, RoutedEventArgs e)
        {
            await OpenProgressBlockerWindow(myLogicFacade.OpenPrintFrom(), "Bitte warten...", "Druck Maske geöffnet!");
        }

        private async void menu_variables_open_Click(object sender, RoutedEventArgs e)
        {
            await OpenProgressBlockerWindow(myLogicFacade.OpenPrintVariablesForm(), "Bitte warten...", "Platzhalter Maske geöffnet!");
        }

        private async void menu_checksum_open_Click(object sender, RoutedEventArgs e)
        {
            await OpenProgressBlockerWindow(myLogicFacade.OpenCheckSumForm(), "Bitte warten...", "Checksum Maske geöffnet!");
        }

        private async void menu_epc_open_Click(object sender, RoutedEventArgs e)
        {
            await OpenProgressBlockerWindow(myLogicFacade.OpenEPCForm(), "Bitte warten...", "EPC Maske geöffnet"); 
        }

        private async void menu_import_Click(object sender, RoutedEventArgs e)
        {
            var controller = await this.ShowProgressAsync("Import", "Importiere ZPL Koordinaten");
            controller.SetIndeterminate();

            bool result = myLogicFacade.ImportExcel();
            if (result)
            {
                await this.ShowMessageAsync("Import", "Import der ZPL Koordinaten erfolgreich!", MessageDialogStyle.Affirmative);
                myLogicFacade.GenerateZPL();
            }
            await controller.CloseAsync();
        }

        private async void menu_export_Click(object sender, RoutedEventArgs e)
        {
            var controller = await this.ShowProgressAsync("Export", "Exportiere ZPL Koordinaten");
            controller.SetIndeterminate();

            bool result = myLogicFacade.ExportExcel();
            if (result)
            {
                await this.ShowMessageAsync("Export", "Export der ZPL Koordinaten erfolgreich!", MessageDialogStyle.Affirmative);
            }
            await controller.CloseAsync();
        }
        #endregion

        #region ZPLCommandGroup Events
        private void lstBox_elementLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myLogicFacade.SelectedCommandGroupChanged();
        }

        private void btn_set_groupName_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.UpdateSelectedCommandGroup();
        }

        private void btn_moveCommandGroupUp_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.MoveSelectedCommandGroupUp(lstBox_elementLines.SelectedIndex);
        }

        private void btn_moveCommandGroupDown_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.MoveSelectedCommandGroupDown(lstBox_elementLines.SelectedIndex);
        }

        private void btn_addCommandGroup_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.AddNewCommandGroup();
        }

        private void btn_removeCommandGroup_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.RemoveSelectedCommandGroup();
        }
        #endregion

        #region ZPLCommand Events
        private void lstBox_elements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myLogicFacade.SelectedCommandChanged();
        }

        private void btn_setCommandValues_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.UpdateSelectedCommand(txtBox_command.Text, txtBox_commandParameter.Text);
        }

        private void btn_addZPLCommandElement_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.AddNewCommand();
        }

        private void btn_removeZPLCommandElement_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.RemoveSelectedCommand();
        }

        private void btn_moveZPLCommandElementUp_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.MoveSelectedCommandUp(lstBox_elements.SelectedIndex);

            
        }

        private void btn_moveZPLCommandElementDown_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.MoveSelectedCommandDown(lstBox_elements.SelectedIndex);

            
        }
        #endregion

        #region Utils
        private async Task<bool> OpenProgressBlockerWindow(MetroWindow formToOpen, string title, string message)
        {
            var controller = await this.ShowProgressAsync(title, message);
            controller.SetIndeterminate();
            formToOpen.ShowDialog();
            await controller.CloseAsync();
            return true;
        }
        private void btn_generateZPL_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.GenerateZPL();
            myLogicFacade.GetZPLPrintVariables();
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.GeneratePreview();
        }

        private void btn_help_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.OpenHelp();

        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                myLogicFacade.CreateLabelDesignerObjects(myLogicFacade.LoadZPL(txtBox_zplCode.Text));
                myLogicFacade.CheckForZPLErrors();
                myLogicFacade.GeneratePreview();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Something went horribly wrong ==> " + ex.Message);
                await this.ShowMessageAsync("Exception :D", ex.Message);
            }
        }
        private void btn_rotateAngle_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.RotateImage();
        }

        private void btn_resetRotation_Click(object sender, RoutedEventArgs e)
        {
            myLogicFacade.ResetImageRotation();
        }
        #endregion
    }
}
