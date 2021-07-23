using LabelDesigner.Forms;
using LabelDesigner.ViewModels;

namespace LabelDesigner.Interfaces
{
    public interface ILabelDesigner
    {
        #region CommandGroup Methods
        void RemoveSelectedCommandGroup();
        void AddNewCommandGroup();
        void MoveSelectedCommandGroupDown(int index);
        void MoveSelectedCommandGroupUp(int index);
        void UpdateSelectedCommandGroup();
        void SelectedCommandGroupChanged();
        #endregion

        #region Command Methods
        void MoveSelectedCommandDown(int index);
        void MoveSelectedCommandUp(int index);
        void RemoveSelectedCommand();
        void AddNewCommand();
        void UpdateSelectedCommand(string commandName, string parameterString);
        void SelectedCommandChanged();
        #endregion

        #region Core Methods
        void OpenHelp();
        void InitDefaultProject();
        void ResetLabelDesigner();
        void GetZPLPrintVariables();
        void GenerateZPL(string[] zplLines);
        void GenerateZPL();
        void GeneratePreview();
        void SetWindowTitle(string title);
        MainWindowViewModel GetViewModel();
        #endregion

        #region LabelDesigner Methods
        string[] LoadZPL();
        string[] LoadZPL(string zpl);
        void CreateLabelDesignerObjects(string[] zplCode);
        void CreateResultZPL(string[] zplCode);
        void SaveZPL();
        PrintingWindow OpenPrintFrom();
        PrintVariablesWindow OpenPrintVariablesForm();
        ChecksumWindow OpenCheckSumForm();
        EPCWindow OpenEPCForm();
        bool ImportExcel();
        bool ExportExcel();
        void RotateImage();
        void ResetImageRotation();
        void CheckForZPLErrors();
        #endregion
    }
}
