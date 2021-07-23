using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPLUtility.Models;
using ZPLUtility.Utils;

namespace LabelDesigner.Models
{
    public class ZPLMessage : BaseNotifier
    {
        public bool isError = false;
        private string _message = "";

        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(nameof(Message)); }
        }

    }
}
