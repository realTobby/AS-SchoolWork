using Schichten;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PraktikantenVerwaltungTUI
{
    public class MainTUI
    {
        static Fachkonzept MeinFachkonzept;

        static void Main(string[] args)
        {
            MeinFachkonzept = new Fachkonzept(new SqliteDatenhaltung());
            MenuHaupt();
            Console.ReadLine();
        }

        #region HauptMenu
        /// <summary>
        /// // HAUPTMENÜ DER ANWENDUNG
        /// </summary>
        private static void MenuHaupt()
        {
            Console.WriteLine("Praktikanten-Verwaltung");
            Console.WriteLine("");
            Console.WriteLine("=== HAUPTMENU ===");
            Console.WriteLine("Praktikanten Anzeigen/Hinzufügen/Ändern/Löschen (a)");
            Console.WriteLine("Abteilungen Anzeigen/Hinzufügen/Ändern/Löschen (b)");
            Console.WriteLine("Beenden (q)");
            Console.Write("Eingabe: ");

            var input = Console.ReadKey();

            Console.Clear();
            switch (input.KeyChar.ToString())
            {
                default:
                    MenuHaupt();
                    break;
                case "a":
                    MenuPrakikant();
                    break;
                case "b":
                    MenuAbteilung();
                    break;
                case "q":
                    Console.WriteLine("ENTER Taste um Anwendung zu schliessen...");
                    break;
            }

        }
        #endregion

        #region PraktikantenMenu
        /// <summary>
        /// // PRAKTIKANT MENÜ
        /// </summary>
        private static void MenuPrakikant()
        {
            Console.WriteLine("=== PRAKTIKANTEN ===");
            Console.WriteLine("Anzeigen (a)");
            Console.WriteLine("Hinzufügen (b)");
            Console.WriteLine("Ändern (c)");
            Console.WriteLine("Löschen (d)");
            Console.WriteLine("Zurück (q)");
            Console.Write("Eingabe: ");

            var input = Console.ReadKey();
            Console.Clear();
            switch (input.KeyChar.ToString())
            {
                default:
                    MenuPrakikant();
                    break;
                case "a":
                    MenuPraktikantenAnzeigen();
                    break;
                case "b":
                    MenuNeuPraktikant();
                    break;
                case "c":
                    MenuPrakikantAendern();
                    break;
                case "d":
                    MenuPraktikantLoeschen();
                    break;
                case "q":
                    MenuHaupt();
                    break;
            }
        }

        private static void MenuPraktikantenAnzeigen()
        {
            Console.WriteLine("=== PRAKTIKANTEN LISTE ===");
            Console.WriteLine("NR. ---- BEZ. ---- ABTL.");
            List<AbteilungModel> abteilungen = MeinFachkonzept.getAbteilungen();
            List<PraktikantModel> praktikanten = MeinFachkonzept.getPraktikanten();
            if (praktikanten.Count > 0)
            {
                foreach (PraktikantModel praktikant in praktikanten)
                {
                    string abteilungsName = "nicht zugewiesen";

                    if(abteilungen.Where(x => x.Abteilung_NR == praktikant.ZugewieseneAbteilung).FirstOrDefault() != null)
                    {
                        abteilungsName = abteilungen.Where(x => x.Abteilung_NR == praktikant.ZugewieseneAbteilung).FirstOrDefault().Bezeichnung;
                    }


                    Console.WriteLine(praktikant.Praktikant_NR + " --- " + praktikant.Name + " --- " + abteilungsName);
                }
            }
            else
            {
                Console.WriteLine("Keine Praktikanten zum anzeigen!");
            }

            EndOfMenu();
            MenuPrakikant();
        }

        private static void MenuNeuPraktikant()
        {
            Console.WriteLine("=== PRAKTIKANTEN HINZUFÜGEN ===");
            Console.WriteLine("");
            Console.Write("Name des Praktikanten: (Leer lassen für Abbruch) (Mit ENTER bestätigen)");
            var input = Console.ReadLine();
            if(input != string.Empty)
            {
                MeinFachkonzept.createPraktikant(input);

                List<PraktikantModel> praktikanten = MeinFachkonzept.getPraktikanten();
                PraktikantModel newest = praktikanten[praktikanten.Count - 1];
                Console.WriteLine("Praktikant (" + newest.Name + ")" + " mit der NR: " + newest.Praktikant_NR + ", erfolgreich erstellt!");
            }else
            {
                Console.WriteLine("Aktion abgebrochen.");
            }

            EndOfMenu();
            MenuPrakikant();
        }

        private static void MenuPrakikantAendern()
        {
            Console.WriteLine("=== PRAKTIKANT ÄNDERN ===");

            List<PraktikantModel> praktikanten = MeinFachkonzept.getPraktikanten();
            if (praktikanten.Count > 0)
            {
                Console.WriteLine("Umbenennen (a)");
                Console.WriteLine("Zugewiesene Abteilung ändern (b)");
                Console.WriteLine("Zurück (q)");
                var input = Console.ReadKey();
                Console.WriteLine("");
                switch(input.KeyChar.ToString())
                {
                    case "a":
                        MenuPraktikantUmbenennen();
                        break;
                    case "b":
                        MenuPraktikantAbteilungAendern();
                        break;
                    case "q":
                        EndOfMenu();
                        MenuPrakikant();
                        break;
                    default:
                        Console.Clear();
                        MenuPrakikantAendern();
                        break;
                }

            }
            else
            {
                Console.WriteLine("Keine Praktikanten zum ändern verfügbar!");
            }
            EndOfMenu();
            MenuPrakikant();
        }

        private static void MenuPraktikantLoeschen()
        {
            Console.WriteLine("=== PRAKTIKANT LÖSCHEN ===");
            List<PraktikantModel> praktikanten = MeinFachkonzept.getPraktikanten();

            if (praktikanten.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Geben Sie die Nummer (NR.) des zu löschenden Praktikanten ein (Leer lassen für Abbruch) (Mit ENTER bestätigen)");

                var prakikantNrInput = Console.ReadLine();
                int returnPraktikant;
                if (prakikantNrInput != string.Empty && int.TryParse(prakikantNrInput, out returnPraktikant))
                {
                    if(praktikanten.Exists(x=>x.Praktikant_NR == returnPraktikant))
                    {
                        int praktikantNummer = Convert.ToInt32(prakikantNrInput);


                        PraktikantModel zielPraktikant = praktikanten.Find(x => x.Praktikant_NR == praktikantNummer);
                        Console.WriteLine("Praktikant Nr." + zielPraktikant.Praktikant_NR + " (" + zielPraktikant.Name + ") ausgewählt!");

                        Console.WriteLine("");
                        Console.WriteLine("Sind Sie sicher das Sie diesen Praktikanten löschen wollen? <j/n>");
                        var input = Console.ReadKey();
                        Console.WriteLine("");
                        switch (input.KeyChar.ToString().ToLower())
                        {
                            default:
                                Console.WriteLine("Aktion abgebrochen!");
                                break;
                            case "j":
                                MeinFachkonzept.deletePraktikant(zielPraktikant);
                                Console.WriteLine("Ausgewählter Praktikant wurde erfolgreich gelöcht!");
                                break;

                        }

                    }
                    else
                    {
                        Console.WriteLine("Keinen Praktikanten mit dieser Nummer (NR.) gefunden!");
                    }

                    
                }
                else
                {
                    Console.WriteLine("Aktion abgebrochen!");
                }
            }
            else
            {
                Console.WriteLine("Keine Praktikanten zum löschen verfügbar!");
            }
            EndOfMenu();
            MenuPrakikant();
        }

        private static void MenuPraktikantAbteilungAendern()
        {
            List<AbteilungModel> abteilungen = MeinFachkonzept.getAbteilungen();
            List<PraktikantModel> praktikanten = MeinFachkonzept.getPraktikanten();
            Console.WriteLine("Geben Sie die Nummer (NR.) des zu ändernden Praktikanten ein (Leer lassen für Abbruch) (Mit ENTER bestätigen)");
            var prakikantNrInput = Console.ReadLine();
            int returnPraktikantNr;
            if (prakikantNrInput != string.Empty && int.TryParse(prakikantNrInput, out returnPraktikantNr))
            {
                if(praktikanten.Exists(x=>x.Praktikant_NR == returnPraktikantNr))
                {
                    PraktikantModel zielPraktikant = praktikanten.Find(x => x.Praktikant_NR == returnPraktikantNr);

                    string zugewieseneAbteilung = "nicht zugewiesen";
                    int abteilungNr = -1;
                    if (abteilungen.Where(x => x.Abteilung_NR == zielPraktikant.ZugewieseneAbteilung).FirstOrDefault() != null)
                    {
                        zugewieseneAbteilung = abteilungen.Where(x => x.Abteilung_NR == zielPraktikant.ZugewieseneAbteilung).FirstOrDefault().Bezeichnung;
                        abteilungNr = zielPraktikant.ZugewieseneAbteilung;
                    }

                    Console.WriteLine("Nr. " + returnPraktikantNr + " (" + zielPraktikant.Name + ") ausgewählt! ==> " + zugewieseneAbteilung + " (" + abteilungNr + ")");
                    Console.WriteLine("Geben Sie die Nummer (NR.) der Abteilung ein welcher der Praktikant zugewiesen werden soll (Mit ENTER bestätigen)");
                    var praktikantNeueAbteilung = Console.ReadLine();
                    AbteilungModel neueAbteilung = abteilungen.Where(x => x.Abteilung_NR == Convert.ToInt32(praktikantNeueAbteilung)).FirstOrDefault();
                    if (praktikantNeueAbteilung != string.Empty)
                    {
                        if(neueAbteilung != null)
                        {
                            PraktikantModel updatePraktikant = new PraktikantModel();
                            updatePraktikant.Name = zielPraktikant.Name;
                            updatePraktikant.Praktikant_NR = zielPraktikant.Praktikant_NR;
                            updatePraktikant.ZugewieseneAbteilung = neueAbteilung.Abteilung_NR;

                            MeinFachkonzept.changePraktikant(zielPraktikant, updatePraktikant);

                            Console.WriteLine("Abteilung des Praktikanten (" + zielPraktikant.Name + ") erfolgreich geändert! (" + zugewieseneAbteilung + " => " + neueAbteilung.Bezeichnung + ")");
                        }
                        else
                        {
                            Console.WriteLine("Keine Abteilung mit dieser Nummer, Aktion abgebrochen!");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Kein Name angegeben, Aktion abgebrochen!");
                    }
                }
                else
                {
                    Console.WriteLine("Kein Praktikant unter der angegeben Nummer gefunden!");
                }
                
            }
            else
            {
                Console.WriteLine("Aktion abgebrochen!");
            }
        }

        private static void MenuPraktikantUmbenennen()
        {
            List<PraktikantModel> praktikanten = MeinFachkonzept.getPraktikanten();
            Console.WriteLine("Geben Sie die Nummer (NR.) des zu ändernden Praktikanten ein (Leer lassen für Abbruch) (Mit ENTER bestätigen)");
            var prakikantNrInput = Console.ReadLine();
            int returnPraktikant;
            if (prakikantNrInput != string.Empty && int.TryParse(prakikantNrInput, out returnPraktikant))
            {
                if(praktikanten.Exists(x=>x.Praktikant_NR == returnPraktikant))
                {
                    PraktikantModel zielPraktikant = praktikanten.Find(x => x.Praktikant_NR == returnPraktikant);

                    Console.WriteLine("Nr. " + returnPraktikant + " (" + zielPraktikant.Name + ") ausgewählt!");
                    Console.WriteLine("Wie soll der Praktikant nun heißen? (Mit ENTER bestätigen)");
                    var praktikantNameInput = Console.ReadLine();
                    if (praktikantNameInput != string.Empty)
                    {
                        PraktikantModel newPraktikant = new PraktikantModel();
                        newPraktikant.Name = praktikantNameInput;
                        newPraktikant.Praktikant_NR = zielPraktikant.Praktikant_NR;
                        newPraktikant.ZugewieseneAbteilung = zielPraktikant.ZugewieseneAbteilung;

                        MeinFachkonzept.changePraktikant(zielPraktikant, newPraktikant);

                        Console.WriteLine("Praktikant wurde erfolgreich geändert! (" + zielPraktikant.Name + ") ==> (" + praktikantNameInput + ")");
                    }
                    else
                    {
                        Console.WriteLine("Kein Name angegeben, Aktion abgebrochen!");
                    }

                }
                else
                {
                    Console.WriteLine("Kein Praktikant mit der angegeben Praktikant Nummer (NR.) gefunden!");
                }
                
            }
            else
            {
                Console.WriteLine("Aktion abgebrochen!");
            }
        }
        #endregion

        #region AbteilungenMenu
        /// <summary>
        /// // ABTEILUNGS MENÜ
        /// </summary>
        private static void MenuAbteilung()
        {
            Console.WriteLine("=== ABTEILUNGEN ===");
            Console.WriteLine("Anzeigen (a)");
            Console.WriteLine("Hinzufügen (b)");
            Console.WriteLine("Teilnehmer Anzeigen (c)");
            Console.WriteLine("Ändern (d)");
            Console.WriteLine("Löschen (e)");
            Console.WriteLine("Zurück (q)");
            Console.Write("Eingabe:");

            var input = Console.ReadKey();
            Console.Clear();
            switch (input.KeyChar.ToString())
            {
                default:
                    MenuAbteilung();
                    break;
                case "a":
                    MenuAbteilungenAnzeigen();
                    break;
                case "b":
                    MenuNeuAbteilung();
                    break;
                case "c":
                    MenuTeilnehmerAnzeigen();
                    break;
                case "d":
                    MenuAbteilungAendern();
                    break;
                case "e":
                    MenuAbteilungLoeschen();
                    break;

                case "q":
                    MenuHaupt();
                    break;
                
            }
        }

        private static void MenuNeuAbteilung()
        {
            Console.WriteLine("=== ABTEILUNG HINZUFÜGEN ===");
            Console.WriteLine("");
            Console.Write("Name der Abteilung: ");
            var input = Console.ReadLine();
            if(input != string.Empty)
            {
                MeinFachkonzept.createAbteilung(input);

                List<AbteilungModel> abteilungen = MeinFachkonzept.getAbteilungen();
                AbteilungModel newest = abteilungen[abteilungen.Count - 1];
                Console.WriteLine("Abteilung (" + newest.Bezeichnung + ")" + " mit der NR: " + newest.Abteilung_NR + ", erfolgreich erstellt!");

            }
            else
            {
                Console.WriteLine("Keine Eingabe, Aktion abbgebrochen!");
            }
            

            EndOfMenu();
            MenuAbteilung();
        }

        private static void MenuTeilnehmerAnzeigen()
        {
            Console.WriteLine("=== TEILNEHMER (einer Abteilung) ANZEIGEN ===");
            Console.WriteLine("Geben Sie die Nummer (NR.) der Abteilung ein von der Sie die Teilnehmer Liste ansehen wollen (Leer für Abbruch) (Mit ENTER bestätigen)");

            List<PraktikantModel> praktikanten = MeinFachkonzept.getPraktikanten();
            List<AbteilungModel> abteilungen = MeinFachkonzept.getAbteilungen();

            var abteilungsNrInput = Console.ReadLine();
            int returnAbteilungsNummer;
            if (abteilungsNrInput != string.Empty && int.TryParse(abteilungsNrInput, out returnAbteilungsNummer))
            {
                if(abteilungen.Exists(x=>x.Abteilung_NR == returnAbteilungsNummer))
                {

                }else
                {
                    Console.WriteLine("Keine Abteilung mit der Angegeben Nummer gefunden!");
                }
                

                List<PraktikantModel> teilnehmer = new List<PraktikantModel>();
                teilnehmer = praktikanten.Where(x => x.ZugewieseneAbteilung == returnAbteilungsNummer).ToList();

                foreach(var praktikant in teilnehmer)
                {
                    Console.WriteLine(praktikant.Praktikant_NR + " - " + praktikant.Name);
                }

            }
            else
            {
                Console.WriteLine("Aktion abgebrochen!");
            }

            EndOfMenu();
            MenuAbteilung();
        }
        private static void MenuAbteilungenAnzeigen()
        {
            Console.WriteLine("=== ABTEILUNGEN LISTE ===");
            Console.WriteLine("NR. - BEZ.");
            List<AbteilungModel> abteilungen = MeinFachkonzept.getAbteilungen();
            if (abteilungen.Count > 0)
            {
                foreach (AbteilungModel abteilung in abteilungen)
                {
                    Console.WriteLine(abteilung.Abteilung_NR + " - " + abteilung.Bezeichnung);
                }
            }
            else
            {
                Console.WriteLine("Keine Abteilungen zum anzeigen!");
            }

            EndOfMenu();
            MenuAbteilung();
        }

        private static void MenuAbteilungAendern()
        {
            Console.WriteLine("=== ABTEILUNG ÄNDERN ===");
            List<AbteilungModel> abteilungen = MeinFachkonzept.getAbteilungen();

            if (abteilungen.Count > 0)
            {
                Console.WriteLine("Geben Sie die Nummer (NR.) der zu ändernden Abteilung ein (Leer lassen für Abbruch) (Mit ENTER bestätigen)");
                var abteilungsNrInput = Console.ReadLine();
                int returnAbteilungsNummer;
                if (abteilungsNrInput != string.Empty && int.TryParse(abteilungsNrInput, out returnAbteilungsNummer))
                {
                    if(abteilungen.Exists(x=>x.Abteilung_NR == returnAbteilungsNummer))
                    {
                        AbteilungModel zielAbteilung = abteilungen.Find(x => x.Abteilung_NR == returnAbteilungsNummer);

                        Console.WriteLine("Nr. " + returnAbteilungsNummer + " (" + zielAbteilung.Bezeichnung + ") ausgewählt!");
                        Console.WriteLine("Wie soll die Abteilung nun heißen? (Mit ENTER bestätigen)");
                        var abteilungsNameInput = Console.ReadLine();
                        if (abteilungsNameInput != string.Empty)
                        {
                            AbteilungModel newAbteilung = new AbteilungModel();
                            newAbteilung.Abteilung_NR = zielAbteilung.Abteilung_NR;
                            newAbteilung.Bezeichnung = abteilungsNameInput;

                            MeinFachkonzept.changeAbteilung(zielAbteilung, newAbteilung);

                            Console.WriteLine("Abteilung wurde erfolgreich geändert! (" + zielAbteilung.Bezeichnung + ") ==> (" + abteilungsNameInput + ")");
                        }
                        else
                        {
                            Console.WriteLine("Kein Name angegeben, Aktion abgebrochen!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Keine Abteilung mit der angegeben Nummer gefunden!");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Aktion abgebrochen!");
                }

            }
            else
            {
                Console.WriteLine("Keine Abteilungen zum ändern verfügbar!");
            }
            EndOfMenu();
            MenuAbteilung();
        }

        private static void MenuAbteilungLoeschen()
        {
            Console.WriteLine("=== ABTEILUNG LÖSCHEN ===");
            List<AbteilungModel> abteilungen = MeinFachkonzept.getAbteilungen();

            if (abteilungen.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Geben Sie die Nummer (NR.) der zu löschenden Abteilung ein (Leer lassen für Abbruch) (Mit ENTER bestätigen)");

                var abteilungNrInput = Console.ReadLine();
                int returnAbteilungsNummer;
                if (abteilungNrInput != string.Empty && int.TryParse(abteilungNrInput, out returnAbteilungsNummer))
                {
                    if(abteilungen.Exists(x=>x.Abteilung_NR == returnAbteilungsNummer))
                    {
                        AbteilungModel zielAbteilung = abteilungen.Find(x => x.Abteilung_NR == returnAbteilungsNummer);
                        Console.WriteLine("Abteilung Nr." + zielAbteilung.Abteilung_NR + " (" + zielAbteilung.Bezeichnung + ") ausgewählt!");

                        Console.WriteLine("");
                        Console.WriteLine("Sind Sie sicher das Sie diese Abteilung löschen wollen? <j/n>");
                        var input = Console.ReadKey();
                        Console.WriteLine("");
                        switch (input.KeyChar.ToString().ToLower())
                        {
                            default:
                                Console.WriteLine("Aktion abgebrochen!");
                                break;
                            case "j":
                                MeinFachkonzept.deleteAbteilung(zielAbteilung);
                                Console.WriteLine("Ausgewählte Abteilung wurde erfolgreich gelöcht!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Keine Abteilung mit der angegeben Nummer gefunden!");
                    }
                }
                else
                {
                    Console.WriteLine("Aktion abgebrochen!");
                }
            }
            else
            {
                Console.WriteLine("Keine Abteilungen zum löschen verfügbar!");
            }
            EndOfMenu();
            MenuAbteilung();
        }

        #endregion

        public static void EndOfMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Beliebige Taste um ins vorherige Menu zu gelangen...");
            Console.ReadKey();
            Console.Clear();
        }       
    }
}
