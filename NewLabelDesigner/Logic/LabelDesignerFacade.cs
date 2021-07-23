using LabelDesigner.Forms;
using LabelDesigner.Interfaces;
using LabelDesigner.Models;
using LabelDesigner.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using ZPLUtility.Models;
using ZPLUtility.Utils;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using System.Text;
using System.Net;

namespace LabelDesigner.Logic
{
    public class LabelDesignerFacade : ILabelDesigner
    {
        #region Private Fields
        private string zplGuide = "https://www.zebra.com/content/dam/zebra/manuals/printers/common/programming/zpl-zbi2-pm-en.pdf";
        private MainWindowViewModel viewModel;
        private ZPLUtility.Logic.ZPLCommandFactory zplcmdfactory = new ZPLUtility.Logic.ZPLCommandFactory();
        private ZPLErrorFinder zplErrorFinder = new ZPLErrorFinder();
        #endregion

        #region Public Fields

        #endregion

        #region Constructor
        public LabelDesignerFacade()
        {
            viewModel = new MainWindowViewModel();
        }
        #endregion

        #region CommandGroup Methods
        /// <summary>
        /// Fügt der ZPL Kommando Gruppen Liste einen neuen Eintrag an
        /// </summary>
        public void AddNewCommandGroup()
        {
            ZPLCommandGroup newZPLGroup = zplcmdfactory.CreateSingleZPLCommandGroupFromEnum(viewModel.SelectedNewZPLCommandGroupDefine);
            viewModel.ZPLCommandGroups.Add(newZPLGroup);
        }
        /// <summary>
        /// Verschiebt die selektierte ZPL Kommando Gruppe nach unten
        /// </summary>
        /// <param name="index"></param>
        public void MoveSelectedCommandGroupDown(int index)
        {
            viewModel.ZPLCommandGroups.Swap(index, index + 1);
        }
        /// <summary>
        /// Verschiebt die selektierte ZPL Kommando Gruppe nach oben
        /// </summary>
        /// <param name="index"></param>
        public void MoveSelectedCommandGroupUp(int index)
        {
            viewModel.ZPLCommandGroups.Swap(index, index - 1);
        }
        /// <summary>
        /// Entfernt die selektierte ZPL Kommando Gruppe
        /// </summary>
        public void RemoveSelectedCommandGroup()
        {
            viewModel.ZPLCommandGroups.Remove(viewModel.SelectedZPLGroup);
        }
        /// <summary>
        /// Ändert die Informationen der selektierten ZPL Kommando Gruppe
        /// </summary>
        public void SelectedCommandGroupChanged()
        {
            if (viewModel.SelectedZPLGroup != null)
            {
                viewModel.CommandGroupName = viewModel.SelectedZPLGroup.LineDescription;
            }
        }
        /// <summary>
        /// Setzt neue Informationen in die selektierte ZPL Kommando Gruppe
        /// </summary>
        public void UpdateSelectedCommandGroup()
        {
            if (viewModel.SelectedZPLGroup != null)
            {
                viewModel.ZPLCommandGroups.Where(x => x == viewModel.SelectedZPLGroup).FirstOrDefault().LineDescription = viewModel.CommandGroupName;
            }
        }
        #endregion

        #region Command Methods
        /// <summary>
        /// Fügt der selektierten ZPL Kommando Gruppe ein neues ZPL Kommando hinzu
        /// </summary>
        public void AddNewCommand()
        {
            if (viewModel.SelectedZPLGroup != null)
            {
                viewModel.ZPLCommandGroups.Where(x => x == viewModel.SelectedZPLGroup).FirstOrDefault().Commands.Add(new ZPLCommand() { ElementName = viewModel.SelectedNewZPLCommand.GetDescription(), CommandName = viewModel.SelectedNewZPLCommand.ToString() }); ;
            }
        }
        /// <summary>
        /// Verschiebt das selektierte ZPL Kommando nach unten
        /// </summary>
        /// <param name="index"></param>
        public void MoveSelectedCommandDown(int index)
        {
            viewModel.SelectedZPLGroup.Commands.Swap(index, index + 1);
        }
        /// <summary>
        /// Verschiebt das selektierte ZPL Kommando nach oben
        /// </summary>
        /// <param name="index"></param>
        public void MoveSelectedCommandUp(int index)
        {
            viewModel.SelectedZPLGroup.Commands.Swap(index, index - 1);
        }
        /// <summary>
        /// Entfernt das selektierte ZPL Kommando
        /// </summary>
        public void RemoveSelectedCommand()
        {
            viewModel.SelectedZPLGroup.Commands.Remove(viewModel.SelectedZPLCommand);
        }
        /// <summary>
        /// Ändert Informationen des selektierten ZPL Kommandos
        /// </summary>
        public void SelectedCommandChanged()
        {
            if (viewModel.SelectedZPLCommand != null)
            {
                viewModel.CommandName = viewModel.SelectedZPLCommand.ElementName;
                viewModel.Command = viewModel.SelectedZPLCommand.CommandName;
                viewModel.CommandParameter = viewModel.SelectedZPLCommand.ParameterList;
            }
        }
        /// <summary>
        /// Ändert Informationen des selektierten ZPL Kommandos
        /// </summary>
        /// <param name="commandName"></param>
        /// <param name="parameterString"></param>
        public void UpdateSelectedCommand(string commandName, string parameterString)
        {
            if (viewModel.SelectedZPLCommand != null)
            {
                ZPLCommand commandToUpdate = viewModel.ZPLCommands.Where(x => x == viewModel.SelectedZPLCommand).FirstOrDefault();
                if(commandToUpdate != null)
                {
                    commandToUpdate.CommandName = commandName;
                    commandToUpdate.ParameterList = parameterString;
                }
                
            }
        }
        #endregion

        #region Core Methods
        /// <summary>
        /// Setzt den LabelDesigner auf einen Anfangszustand
        /// </summary>
        public void ResetLabelDesigner()
        {
            viewModel.ZPLCommands.Clear();
            viewModel.ZPLCommandGroups.Clear();
            viewModel.PrintVariableList.Clear();
            viewModel.PrinterAddressAndPort = "127.0.0.1:6101";
            viewModel.ResultZPL = string.Empty;
            viewModel.SelectedNewZPLCommandGroupDefine = ZPLCommandGroupDefines.EmptyGroup;
            viewModel.ImageSource = null;
            viewModel.ZPLErrorMessages.Clear();
        }
        /// <summary>
        /// Öffnet die Hilfe Dokumentation von Zebra mit dem selektierten ZPL Kommando als SearchParameter
        /// </summary>
        public void OpenHelp()
        {
            string searchString = viewModel.SelectedNewZPLCommand.ToString();

            Process.Start(zplGuide + @"#search=""^" + searchString + @"""");
        }
        /// <summary>
        /// Fügt dem LabeDesigner ein kleines ZPL Projekt hinzu
        /// </summary>
        public void InitDefaultProject()
        {
            viewModel.ZPLCommandGroups.Add(zplcmdfactory.CreateSingleZPLCommandGroupFromEnum(ZPLCommandGroupDefines.LabelParameterGroup));
            viewModel.ZPLCommandGroups.Add(zplcmdfactory.CreateSingleZPLCommandGroupFromEnum(ZPLCommandGroupDefines.LabelStart));
            viewModel.ZPLCommandGroups.Add(zplcmdfactory.CreateSingleZPLCommandGroupFromEnum(ZPLCommandGroupDefines.TextGroup));
            viewModel.ZPLCommandGroups.Add(zplcmdfactory.CreateSingleZPLCommandGroupFromEnum(ZPLCommandGroupDefines.LabelEnd));
            GenerateZPL(zplcmdfactory.CreateZPLCodeFromZPLCommandGroupList(viewModel.ZPLCommandGroups.ToList()).ToArray());
        }
        /// <summary>
        /// Erzeugt eine Vorschau des ZPL Codes
        /// </summary>
        public void GeneratePreview()
        {
            string result = viewModel.ResultZPL;
            if (viewModel.ReplacePrintVariables)
            {
                Dictionary<string, string> printVariables = new Dictionary<string, string>();

                if (viewModel.PrintVariableList == null || viewModel.PrintVariableList.Count == 0)
                {
                    viewModel.PrintVariableList = new ObservableCollection<PrintDataRow>();
                    viewModel.PrintVariableList.Add(new PrintDataRow() { VariableName = "test", VariableValue = "Hello" });
                }

                foreach (PrintDataRow variable in viewModel.PrintVariableList)
                {
                    if (!printVariables.ContainsKey(variable.VariableName))
                        printVariables.Add(variable.VariableName, variable.VariableValue);
                }
                foreach (KeyValuePair<string, string> entry in printVariables)
                {
                    result = result.Replace(entry.Key, entry.Value);
                }
            }

            viewModel.ImageSource = null;
            viewModel.ImageSource = GenerateSourceFromBitmap(GetZPLPreview(result));
        }

        public void CheckForZPLErrors()
        {
            viewModel.ZPLErrorMessages = new ObservableCollection<ZPLMessage>(zplErrorFinder.CheckForErrors(viewModel.ZPLCommandGroups.ToList()));
        }

        /// <summary>
        /// Erzeugt den ZPL Code anhand der ZPLCommanLine Objekte
        /// </summary>
        public void GenerateZPL(string[] zplLines)
        {
            viewModel.ZPLErrorMessages.Clear();

            viewModel.ResultZPL = string.Empty;
            string resultZPL = string.Empty;
            foreach (string zplLine in zplLines)
            {
                resultZPL = resultZPL + zplLine + System.Environment.NewLine;
            }
            viewModel.ResultZPL = resultZPL;
            GeneratePreview();

            viewModel.ZPLErrorMessages = new ObservableCollection<ZPLMessage>(zplErrorFinder.CheckForErrors(viewModel.ZPLCommandGroups.ToList()));

        }


        public void GenerateZPL()
        {
            GenerateZPL(zplcmdfactory.CreateZPLCodeFromZPLCommandGroupList(viewModel.ZPLCommandGroups.ToList()).ToArray());
        }

        /// <summary>
        /// Gibt das ViewModel aus der Fassade herraus (z.B: zum Binden oder an Masken weitergeben)
        /// </summary>
        /// <returns></returns>
        public MainWindowViewModel GetViewModel()
        {
            return viewModel;
        }
        /// <summary>
        /// Erzeugt PrintVariablen anhand des ZPL Codes
        /// </summary>
        public void GetZPLPrintVariables()
        {
            //viewModel.PrintVariableList.Clear(); ==> DONT CLEAR
            foreach (var element in viewModel.ZPLCommandGroups)
            {
                // get zpl content from ^FD command
                foreach (var cmd in element.Commands)
                {
                    if (cmd.GetCommand() == "FD")
                    {
                        List<string> printContent = cmd.GetParameter();

                        if (printContent.Count == 1)
                        {
                            if (printContent[0].Contains("[") && printContent[0].Contains("]"))
                            {
                                PrintDataRow pdr = new PrintDataRow();
                                string variable = printContent[0].Substring(printContent[0].IndexOf("["), printContent[0].IndexOf("]") - printContent[0].IndexOf("[") + 1);
                                pdr.VariableName = variable;
                                pdr.VariableValue = variable;
                                if (viewModel.PrintVariableList.Where(x => x.VariableName == pdr.VariableName).FirstOrDefault() == null)
                                    viewModel.PrintVariableList.Add(pdr);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Setzt den Window Title des LabelDesigners
        /// </summary>
        /// <param name="title"></param>
        public void SetWindowTitle(string title)
        {
            viewModel.VersionString = title;
        }
        #endregion

        #region LabelDesigner Methods
        /// <summary>
        /// Erzeugt ZPL Kommando Gruppen anhand ZPL Code
        /// </summary>
        /// <param name="zplCode"></param>
        public void CreateLabelDesignerObjects(string[] zplCode)
        {
            viewModel.ZPLCommandGroups = new ObservableCollection<ZPLCommandGroup>(zplcmdfactory.CreateZPLCommandGroupListFromZPLCodeArray(zplCode));
        }
        /// <summary>
        /// Erzeugt ZPL Code anhand ZPL Code als string-array
        /// </summary>
        /// <param name="rawZPL"></param>
        public void CreateResultZPL(string[] rawZPL)
        {
            string zplResult = string.Empty;
            foreach (var item in rawZPL)
            {
                zplResult = zplResult + item + System.Environment.NewLine;
            }
            viewModel.ResultZPL = zplResult;
        }
        /// <summary>
        /// Öffnet einen FileDialog und lädt eine ZPL 
        /// </summary>
        /// <returns></returns>
        public string[] LoadZPL()
        {
            string[] zplCode = new string[1];
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ZPL (*.zpl) | *.zpl";
            if (openFileDialog.ShowDialog() == true)
            {
                //ResetLabelDesigner();
                // read zpl code // seperate by line!
                zplCode = System.IO.File.ReadAllLines(openFileDialog.FileName);
            }
            return zplCode;
        }

        /// <summary>
        /// Konvertiert ZPL von string nach string[]
        /// </summary>
        /// <param name="zpl"></param>
        /// <returns></returns>
        public string[] LoadZPL(string zpl)
        {
            string[] result = zpl.Split(new[] { "\r\n", "\r", "\n" },StringSplitOptions.None);
            return result;
        }

        /// <summary>
        /// Öffnet die Druck Maske
        /// </summary>
        /// <returns></returns>
        public PrintingWindow OpenPrintFrom()
        {
            if (viewModel.ResultZPL == string.Empty)
            {
                List<string> rawZPLArray = zplcmdfactory.CreateZPLCodeFromZPLCommandGroupList(viewModel.ZPLCommandGroups.ToList());
                string toPrintZPL = string.Empty;
                foreach (string zplLine in rawZPLArray)
                {
                    toPrintZPL = toPrintZPL + zplLine + System.Environment.NewLine;
                }
                viewModel.ResultZPL = toPrintZPL;
            }
            return new PrintingWindow(viewModel);
        }
        /// <summary>
        /// Öffnet die PrintVariablen (Platzhalter) Maske
        /// </summary>
        /// <returns></returns>
        public PrintVariablesWindow OpenPrintVariablesForm()
        {
            return new PrintVariablesWindow(viewModel);
        }

        public ChecksumWindow OpenCheckSumForm()
        {
            return new ChecksumWindow(viewModel);
        }

        public EPCWindow OpenEPCForm()
        {
            return new EPCWindow(viewModel);
        }

        /// <summary>
        /// öffnet einen Speicher Dialog und speichert das ZPL
        /// </summary>
        public void SaveZPL()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ZPL (*.zpl | *.zpl";
            if (saveFileDialog.ShowDialog() == true)
            {
                char[] delimeters = new[] { '\r', '\n' };
                string[] zplLines = viewModel.ResultZPL.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                System.IO.File.WriteAllLines(saveFileDialog.FileName, zplLines);
            }
        }

        /// <summary>
        /// Importiert ZPL Koordinaten aus Excel
        /// </summary>
        /// <returns></returns>
        public bool ImportExcel()
        {
            // importiere excel datei und passe koordinaten an
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel (*.xls) | *.xls";
            if (openFileDialog.ShowDialog() == true)
            {
                Excel.Application xlApp = new Excel.Application();

                if (xlApp == null)
                {
                    //"Excel is not properly installed!!"
                    return false;
                }

                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(openFileDialog.FileName);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                for(int row = 2; row < xlRange.Rows.Count+1; row++)
                {
                    int identifierIndex = Convert.ToInt32(xlRange.Cells[row, 1].Text.ToString());
                    string identifier = xlRange.Cells[row, 2].Text.ToString();
                    string commandName = xlRange.Cells[row, 3].Text.ToString();
                    string xPos = xlRange.Cells[row, 4].Text.ToString();
                    string yPos = xlRange.Cells[row, 5].Text.ToString();

                    var match = viewModel.ZPLCommandGroups.Where(x => x.LineDescription == identifier && x.IdentifierIndex == identifierIndex).FirstOrDefault().Commands.Where(x => x.CommandName == commandName).FirstOrDefault();
                    if(match != null)
                        match.SetParameter(new List<string>() { xPos, yPos });
                }

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Exportiert ZPL Koordinaten nach Excel
        /// </summary>
        /// <returns></returns>
        public bool ExportExcel()
        {
            // nehme alle koordinaten und exportiere nach excel
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                //"Excel is not properly installed!!"
                return false;
            }

            object misValue = System.Reflection.Missing.Value;
            var xlWorkBook = xlApp.Workbooks.Add(misValue);
            var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int row = 2;

            xlWorkSheet.Cells[1, 1] = "IdentifierIndex";
            xlWorkSheet.Cells[1, 2] = "Identifier";
            xlWorkSheet.Cells[1, 3] = "KommandoName";
            xlWorkSheet.Cells[1, 4] = "PositionX";
            xlWorkSheet.Cells[1, 5] = "PositionY";

            foreach (var zplgroup in viewModel.ZPLCommandGroups)
            {
                foreach(var zplcommand in zplgroup.Commands)
                {
                   if(zplcommand.CommandName == "FT" || zplcommand.CommandName == "FO")
                    {
                        string identifierIndex = zplgroup.IdentifierIndex.ToString();
                        string identifier = zplgroup.LineDescription;
                        string command = zplcommand.CommandName;
                        string xCoord = zplcommand.GetParameter()[0];
                        string yCoord = zplcommand.GetParameter()[1];

                        xlWorkSheet.Cells[row, 1] = identifierIndex;
                        xlWorkSheet.Cells[row, 2] = identifier;
                        xlWorkSheet.Cells[row, 3] = command;
                        xlWorkSheet.Cells[row, 4] = xCoord;
                        xlWorkSheet.Cells[row, 5] = yCoord;

                        row++;
                    }

                }
            }
            bool isSaveComplete = false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xls | *.xls";
            if (saveFileDialog.ShowDialog() == true)
            {
                xlWorkBook.SaveAs(saveFileDialog.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                isSaveComplete = true;
            }
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            return isSaveComplete;
        }

        /// <summary>
        /// Rotates Preview Image +90°
        /// </summary>
        public void RotateImage()
        {
            //viewModel.RotateAngle += 90;

            //if(Convert.ToInt32(viewModel.RotateAngle) >360)
            //{
            //    viewModel.RotateAngle = "0";
            //}
            viewModel.RotateAngle += 90;

            if (viewModel.RotateAngle >= 360)
                viewModel.RotateAngle = 0;

        }

        /// <summary>
        /// Setzt Preview Bild Rotierung zrück
        /// </summary>
        public void ResetImageRotation()
        {
            viewModel.RotateAngle = 0;
        }
        #endregion

        #region Methods
        private BitmapSource GenerateSourceFromBitmap(Bitmap srcBitmap)
        {
            System.Windows.Media.Imaging.BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();

            if (srcBitmap != null)
            {
                MemoryStream ms = new MemoryStream();
                srcBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                bImg.BeginInit();
                bImg.StreamSource = new MemoryStream(ms.ToArray());
                bImg.EndInit();
                ms.Close();
                ms.Dispose();
            }
            return bImg;
        }

        private Bitmap GetZPLPreview(string zplRawString)
        {
            if (zplRawString != string.Empty)
            {
                byte[] zpl = Encoding.UTF8.GetBytes(zplRawString);

                WebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("http://api.labelary.com/v1/printers/{0}dpmm/labels/{1}x{2}/0/", viewModel.PreviewDPMM, viewModel.PreviewWidth, viewModel.PreviewHeight));
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = zpl.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(zpl, 0, zpl.Length);
                requestStream.Close();
                try
                {
                    WebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    return new Bitmap(responseStream);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }

        #endregion
    }
}
