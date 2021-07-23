using LabelDesigner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZPLUtility.Models;
using ZPLUtility.Utils;

namespace LabelDesigner.ViewModels
{
    public class MainWindowViewModel : BaseNotifier
    {

        #region Private Fields

        #region ZPL Objects
        private ZPLCommandGroupDefines _selectedNewZPLCommandGroupDefine = ZPLCommandGroupDefines.EmptyGroup;
        private ObservableCollection<ZPLCommandGroup> _zplCommandGroups = new ObservableCollection<ZPLCommandGroup>();
        private ZPLCommandGroup _selectedZPLCommandGroup = null;
        private string _commandGroupName = string.Empty;

        private ZPLCommands _selectedNewZPLCommand = ZPLUtility.Models.ZPLCommands.XA;
        private ObservableCollection<ZPLCommand> _zplCommands = new ObservableCollection<ZPLCommand>();
        private ZPLCommand _selectedZPLCommand = null;    
        private string _commandName = string.Empty;
        private string _command = string.Empty;
        private string _commandParameter = string.Empty;

        private string _resultZPL = string.Empty;
        #endregion

        #region UI Misc
        private string _versionString = string.Empty;
        private ObservableCollection<ZPLMessage> _zplErrorMessages = new ObservableCollection<ZPLMessage>();
        #endregion

        #region Printing
        private string _printerAddressAndPort = "127.0.0.1:6101";
        private ObservableCollection<PrintDataRow> selectedPrintDataSet = new ObservableCollection<PrintDataRow>();
        private bool _replacePrintVariables = false;
        #endregion

        #region Preview
        private string _previewDPMM = "8";
        private string _previewWidth = "2.5";
        private string _previewHeight = "1.5";
        private BitmapSource imageSource;
        private double rotateAngle;
        #endregion

        #endregion

        #region Public Properties

        #region ZPL Objects
        public IEnumerable<ZPLCommands> AllZPLCommands
        {
            get
            {
                return Enum.GetValues(typeof(ZPLCommands)).Cast<ZPLCommands>();
            }
        }

        public ZPLCommands SelectedNewZPLCommand
        {
            set { _selectedNewZPLCommand = value; OnPropertyChanged(nameof(SelectedNewZPLCommand)); }
            get { return _selectedNewZPLCommand; }
        }

        public IEnumerable<ZPLCommandGroupDefines> AllZPLCommandGroupDefines
        {
            get
            {
                return Enum.GetValues(typeof(ZPLCommandGroupDefines))
                    .Cast<ZPLCommandGroupDefines>();
            }
        }

        public ZPLCommandGroupDefines SelectedNewZPLCommandGroupDefine
        {
            get { return _selectedNewZPLCommandGroupDefine; }
            set { _selectedNewZPLCommandGroupDefine = value; OnPropertyChanged(nameof(SelectedNewZPLCommandGroupDefine)); }
        }

        public ObservableCollection<ZPLCommandGroup> ZPLCommandGroups
        {
            get { return _zplCommandGroups; }
            set { _zplCommandGroups = value; OnPropertyChanged(nameof(ZPLCommandGroups)); }
        }
        public ZPLCommandGroup SelectedZPLGroup
        {
            get { return _selectedZPLCommandGroup; }
            set
            {
                _selectedZPLCommandGroup = value;
                OnPropertyChanged(nameof(SelectedZPLGroup));
                if (value != null)
                    ZPLCommands = new ObservableCollection<ZPLCommand>(_zplCommandGroups.Where(x => x == value).FirstOrDefault().Commands);
            }
        }

        public string CommandGroupName
        {
            get { return _commandGroupName; }
            set { _commandGroupName = value; OnPropertyChanged(nameof(CommandGroupName)); }
        }

        public ObservableCollection<ZPLCommand> ZPLCommands
        {
            get { return _zplCommands; }
            set
            {
                _zplCommands = value;
                OnPropertyChanged(nameof(ZPLCommands));
            }
        }

        public ZPLCommand SelectedZPLCommand
        {
            get { return _selectedZPLCommand; }
            set { _selectedZPLCommand = value; OnPropertyChanged(nameof(SelectedZPLCommand)); }
        }

        public string CommandParameter
        {
            get { return _commandParameter; }
            set { _commandParameter = value; OnPropertyChanged(nameof(CommandParameter)); }
        }

        public string Command
        {
            get { return _command; }
            set { _command = value; OnPropertyChanged(nameof(Command)); }
        }

        public string CommandName
        {
            get { return _commandName; }
            set { _commandName = value; OnPropertyChanged(nameof(CommandName)); }
        }

        public string ResultZPL
        {
            get { return _resultZPL; }
            set { _resultZPL = value; base.OnPropertyChanged(nameof(ResultZPL)); }
        }
        #endregion

        #region UI Misc
        public string VersionString
        {
            get { return _versionString; }
            set { _versionString = value; base.OnPropertyChanged(nameof(VersionString)); }
        }

        public int ZPLErrorMessagesCount
        {
            get
            {
                return _zplErrorMessages.Where(x => x.isError == true)?.Count() ?? 0 ;
            }
        }

        public ObservableCollection<ZPLMessage> ZPLErrorMessages
        {
            get { return _zplErrorMessages; }
            set { _zplErrorMessages = value; OnPropertyChanged(nameof(ZPLErrorMessages)); OnPropertyChanged(nameof(ZPLErrorMessagesCount)); }
        }

        #endregion

        #region Printing
        public bool ReplacePrintVariables
        {
            get { return _replacePrintVariables; }
            set { _replacePrintVariables = value; OnPropertyChanged(nameof(ReplacePrintVariables)); }
        }

        public string PrinterAddressAndPort
        {
            get { return _printerAddressAndPort; }
            set { _printerAddressAndPort = value; OnPropertyChanged("PrinterAddressAndPort"); }
        }

        public ObservableCollection<PrintDataRow> PrintVariableList
        {
            get
            {
                return selectedPrintDataSet;
            }
            set
            {
                selectedPrintDataSet = value;
                OnPropertyChanged("PrintVariableList");
            }
        }

        #endregion

        #region Preview
        public BitmapSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
                OnPropertyChanged(nameof(RotatedImage));
            }
        }

        public double RotateAngle
        {
            get => rotateAngle;
            set
            {
                rotateAngle = value;
                OnPropertyChanged(nameof(RotateAngle));
                OnPropertyChanged(nameof(RotatedImage));
            }
        }

        public BitmapSource RotatedImage
        {
            get
            {
                if (ImageSource != null)
                {
                    try
                    {
                        return new TransformedBitmap(ImageSource, new RotateTransform(RotateAngle));
                    }
                    catch(Exception ex)
                    {
                        return null;
                    }
                }
                return null;
            }
        }

        public string PreviewHeight
        {
            get { return _previewHeight; }
            set { _previewHeight = value; OnPropertyChanged(nameof(PreviewHeight)); }
        }

        public string PreviewWidth
        {
            get { return _previewWidth; }
            set { _previewWidth = value; OnPropertyChanged(nameof(PreviewWidth)); }
        }

        public string PreviewDPMM
        {
            get { return _previewDPMM; }
            set { _previewDPMM = value; OnPropertyChanged(nameof(PreviewDPMM)); }
        }
        #endregion

        #endregion

        
    }

}
