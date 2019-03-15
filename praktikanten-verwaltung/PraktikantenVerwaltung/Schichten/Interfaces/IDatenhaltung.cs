using System;
using System.Collections.Generic;
using System.Text;

namespace Schichten
{
    public interface IDatenhaltung
    {
        void save(DatenModel daten);
        DatenModel load();
        List<PraktikantModel> getPraktikanten();
        void changePraktikant(PraktikantModel oldP, PraktikantModel newP);
        void deletePraktikant(PraktikantModel item);
        void createPraktikant(string name);

        List<AbteilungModel> getAbteilungen();
        void changeAbteilung(AbteilungModel oldA, AbteilungModel newA);
        void deleteAbteilung(AbteilungModel item);
        void createAbteilung(string name);
    }
}
