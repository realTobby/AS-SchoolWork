using System;

namespace Schichten
{
    public class PraktikantModel
    {
        public string Name { get; set; }
        public int Praktikant_NR { get; set; }
        public int ZugewieseneAbteilung { get; set; } = -1; // Abteilungs_NR der Abteilung // -1 == NICHT ZUGEWIESEN
    }
}
