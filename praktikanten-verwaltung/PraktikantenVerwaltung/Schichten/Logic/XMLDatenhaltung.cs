using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Schichten
{
    public class XMLDatenhaltung : IDatenhaltung
    {

        #region Praktikanten
        public void createPraktikant(string name)
        {
            DatenModel daten = load();
            PraktikantModel newPraktikant = new PraktikantModel();
            newPraktikant.Name = name;

            bool canUseNumber = false;
            int praktikantNr = 0;

            while (canUseNumber == false)
            {
                if (daten.PRAKTIKANTEN.Where(x => x.Praktikant_NR == praktikantNr).FirstOrDefault() == null)
                {
                    canUseNumber = true;
                }
                else
                {
                    praktikantNr++;
                }
            }
            newPraktikant.Praktikant_NR = praktikantNr;

            daten.PRAKTIKANTEN.Add(newPraktikant);

            save(daten);

        }

        List<PraktikantModel> IDatenhaltung.getPraktikanten()
        {
            DatenModel daten = load();
            return daten.PRAKTIKANTEN;
        }

        public void deletePraktikant(PraktikantModel item)
        {
            DatenModel daten = load();
            PraktikantModel ziel = daten.PRAKTIKANTEN.Where(x => x.Name == item.Name && x.Praktikant_NR == item.Praktikant_NR).FirstOrDefault();
            daten.PRAKTIKANTEN.Remove(ziel);
            save(daten);
        }

        public void changePraktikant(PraktikantModel oldP, PraktikantModel newP)
        {
            DatenModel daten = load();
            PraktikantModel ziel = new PraktikantModel();
            ziel = daten.PRAKTIKANTEN.Where(x => x.Name == oldP.Name && x.Praktikant_NR == oldP.Praktikant_NR).FirstOrDefault();
            ziel.Name = newP.Name;
            ziel.Praktikant_NR = newP.Praktikant_NR;
            ziel.ZugewieseneAbteilung = newP.ZugewieseneAbteilung;
            save(daten);

        }
        #endregion

        #region Abteilungen

        public void createAbteilung(string name)
        {
            DatenModel daten = load();
            AbteilungModel newAbteilung = new AbteilungModel();
            newAbteilung.Bezeichnung = name;

            bool canUseNumber = false;
            int abteilungsNr = 0;

            while (canUseNumber == false)
            {
                if (daten.ABTEILUNGEN.Where(x => x.Abteilung_NR == abteilungsNr).FirstOrDefault() == null)
                {
                    canUseNumber = true;
                }
                else
                {
                    abteilungsNr++;
                }
            }
            newAbteilung.Abteilung_NR = abteilungsNr;

            daten.ABTEILUNGEN.Add(newAbteilung);

            save(daten);
        }

        List<AbteilungModel> IDatenhaltung.getAbteilungen()
        {
            DatenModel daten = load();
            return daten.ABTEILUNGEN;
        }

        public void changeAbteilung(AbteilungModel oldA, AbteilungModel newA)
        {
            DatenModel daten = load();
            AbteilungModel ziel = new AbteilungModel();
            ziel = daten.ABTEILUNGEN.Where(x => x.Bezeichnung == oldA.Bezeichnung && x.Abteilung_NR == oldA.Abteilung_NR).FirstOrDefault();
            ziel.Bezeichnung = newA.Bezeichnung;
            ziel.Abteilung_NR = newA.Abteilung_NR;
            save(daten);
        }

        public void deleteAbteilung(AbteilungModel item)
        {
            DatenModel daten = load();

            AbteilungModel ziel = daten.ABTEILUNGEN.Where(x => x.Bezeichnung == item.Bezeichnung && x.Abteilung_NR == item.Abteilung_NR).FirstOrDefault();
            daten.ABTEILUNGEN.Remove(ziel);

            save(daten);
        }

        #endregion

        #region LoadAndSave
        public void save(DatenModel daten)
        {
            saveXML(daten);
        }

        private void saveXML(DatenModel daten)
        {
            string xmlPath = "xmlDB.xml";
            FileStream fileStream = File.Create(xmlPath);

            XmlSerializer xmlPrakikanten = new XmlSerializer(typeof(DatenModel));
            xmlPrakikanten.Serialize(fileStream, daten);
            fileStream.Close();
        }

        private DatenModel loadXML()
        {
            if (System.IO.File.Exists("xmlDB.xml"))
            {
                XmlSerializer xmlReader = new XmlSerializer(typeof(DatenModel));
                TextReader reader = new StreamReader("xmlDB.xml");
                object obj = xmlReader.Deserialize(reader);
                DatenModel daten = (DatenModel)obj;
                reader.Close();
                return daten;
            }
            else
            {
                return new DatenModel();
            }
        }

        public DatenModel load()
        {
            DatenModel daten = loadXML();
            return daten;
        }
        #endregion

    }
}
