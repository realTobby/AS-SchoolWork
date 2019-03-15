using Schichten;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Schichten
{
    public class Fachkonzept : IFachkonzept
    {
        /// <summary>
        /// DATENHALTUNG beinhaltet die Datenhaltung die verwendet werden soll (XML oder Sqlite)
        /// </summary>
        private IDatenhaltung DATENHALTUNG;
        public Fachkonzept(IDatenhaltung datenhaltung)
        {
            DATENHALTUNG = datenhaltung;
        }

        public void changeAbteilung(AbteilungModel oldA, AbteilungModel newA)
        {
            DATENHALTUNG.changeAbteilung(oldA, newA);
        }

        public void changePraktikant(PraktikantModel oldP, PraktikantModel newP)
        {
            DATENHALTUNG.changePraktikant(oldP, newP);
        }

        public void createAbteilung(string name)
        {
            DATENHALTUNG.createAbteilung(name);
        }

        public void createPraktikant(string name)
        {
            DATENHALTUNG.createPraktikant(name);
        }

        public void deleteAbteilung(AbteilungModel item)
        {
            DATENHALTUNG.deleteAbteilung(item);
        }

        public void deletePraktikant(PraktikantModel item)
        {
            DATENHALTUNG.deletePraktikant(item);
        }

        public List<AbteilungModel> getAbteilungen()
        {
            List<AbteilungModel> abteilungen = DATENHALTUNG.getAbteilungen();
            return abteilungen;
        }

        public List<PraktikantModel> getPraktikanten()
        {
            List<PraktikantModel> praktikanten = DATENHALTUNG.getPraktikanten();
            return praktikanten;
        }

        public void save(List<PraktikantModel> praktikanten, List<AbteilungModel> abteilungen)
        {
            DatenModel daten = new DatenModel();
            daten.ABTEILUNGEN = abteilungen;
            daten.PRAKTIKANTEN = praktikanten;
            DATENHALTUNG.save(daten);
        }
    }
}
