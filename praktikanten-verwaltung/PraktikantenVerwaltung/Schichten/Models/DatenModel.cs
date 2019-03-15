using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichten
{
    public class DatenModel
    {
        public List<AbteilungModel> ABTEILUNGEN { get; set; }
        public List<PraktikantModel> PRAKTIKANTEN { get; set; }

        public DatenModel()
        {
            ABTEILUNGEN = new List<AbteilungModel>();
            PRAKTIKANTEN = new List<PraktikantModel>();
        }
    }
}
