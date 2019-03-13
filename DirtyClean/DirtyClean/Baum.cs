using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyClean
{
    public class Baum
    {
        public static int BAUM_GROSS = 75;
        private int AnzahlAeste;

        public Baum()
        {
            setAnzahlAeste(BAUM_GROSS);
        }

        public Baum(int anzahlAeste)
        {
            setAnzahlAeste(anzahlAeste);
        }

        public int getAnzahlAeste()
        {
            return AnzahlAeste;
        }

        public void setAnzahlAeste(int anzahlAeste)
        {
            if (anzahlAeste >= 0)
                this.AnzahlAeste = anzahlAeste;
        }
    }
}
