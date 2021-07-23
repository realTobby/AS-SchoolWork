using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelDesigner.Models
{
    [Serializable]
    public class SysProZPLProjectModel
    {
        public List<IZPLElement> ElementCollection = new List<IZPLElement>();
        public List<PrintDataRow> PrintVariables = new List<PrintDataRow>();
    }
}
