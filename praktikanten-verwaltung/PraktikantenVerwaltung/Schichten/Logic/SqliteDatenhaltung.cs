using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Schichten
{
    public class SqliteDatenhaltung : IDatenhaltung
    {
        private string SqliteDBName = "SQLiteDB.sqlite";

        public SqliteDatenhaltung()
        {
            if(!System.IO.File.Exists(SqliteDBName))
            {
                DatenModel newFile = new DatenModel();
                newFile.ABTEILUNGEN = new List<AbteilungModel>();
                newFile.PRAKTIKANTEN = new List<PraktikantModel>();
                save(newFile);
            }
            
        }

        #region Praktikant

        public void changePraktikant(PraktikantModel oldP, PraktikantModel newP)
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + SqliteDBName + ";Version=3;");
            sqliteConnection.Open();
            string changePraktikant = String.Format("UPDATE praktikant SET name = '{0}', abteilung_nr = '{1}'  WHERE praktikant_nr = {2}", newP.Name,newP.ZugewieseneAbteilung, oldP.Praktikant_NR);
            SQLiteCommand savePraktikant = new SQLiteCommand(sqliteConnection);
            savePraktikant.CommandText = changePraktikant;
            savePraktikant.ExecuteNonQuery();
            sqliteConnection.Close();
            sqliteConnection.Dispose();
        }

        public void createPraktikant(string name)
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + SqliteDBName + ";Version=3;");
            sqliteConnection.Open();
            string praktikantSave = String.Format("INSERT INTO praktikant (name, abteilung_nr) VALUES ('{0}', -1)", name);
            SQLiteCommand savePraktikant = new SQLiteCommand(praktikantSave, sqliteConnection);
            savePraktikant.ExecuteNonQuery();
            sqliteConnection.Close();
            sqliteConnection.Dispose();
        }


        public void deletePraktikant(PraktikantModel item)
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + SqliteDBName + ";Version=3;");
            sqliteConnection.Open();
            string praktikantSave = String.Format("DELETE FROM praktikant WHERE praktikant_nr = {0}", item.Praktikant_NR);
            SQLiteCommand savePraktikant = new SQLiteCommand(praktikantSave, sqliteConnection);
            savePraktikant.ExecuteNonQuery();
            sqliteConnection.Close();
            sqliteConnection.Dispose();
        }

        public List<PraktikantModel> getPraktikanten()
        {
            DatenModel daten = new DatenModel();
            daten.PRAKTIKANTEN = load().PRAKTIKANTEN;
            return daten.PRAKTIKANTEN;
        }

        #endregion

        #region Abteilung


        public void changeAbteilung(AbteilungModel oldA, AbteilungModel newA)
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + SqliteDBName + ";Version=3;");
            sqliteConnection.Open();
            string changeAbteilung = String.Format("UPDATE abteilung SET bezeichnung = '{0}' WHERE abteilung_nr = {1}", newA.Bezeichnung, oldA.Abteilung_NR);
            SQLiteCommand saveAbteilung = new SQLiteCommand(changeAbteilung, sqliteConnection);
            saveAbteilung.ExecuteNonQuery();
            sqliteConnection.Close();
            sqliteConnection.Dispose();
        }



        public void createAbteilung(string bezeichnung)
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + SqliteDBName + ";Version=3;");
            sqliteConnection.Open();
            string abteilungSave = String.Format("INSERT INTO abteilung (bezeichnung) VALUES ('{0}')", bezeichnung);
            SQLiteCommand saveAbteilung = new SQLiteCommand(abteilungSave, sqliteConnection);
            saveAbteilung.ExecuteNonQuery();
            sqliteConnection.Close();
            sqliteConnection.Dispose();
        }



        public void deleteAbteilung(AbteilungModel item)
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + SqliteDBName + ";Version=3;");
            sqliteConnection.Open();
            string abteilungDelete = String.Format("DELETE FROM abteilung WHERE abteilung_nr = {0}", item.Abteilung_NR);
            SQLiteCommand saveAbteilung = new SQLiteCommand(abteilungDelete, sqliteConnection);
            saveAbteilung.ExecuteNonQuery();
            sqliteConnection.Close();
            sqliteConnection.Dispose();
        }


        public List<AbteilungModel> getAbteilungen()
        {
            DatenModel daten = new DatenModel();
            daten.ABTEILUNGEN = load().ABTEILUNGEN;
            return daten.ABTEILUNGEN;
        }
        #endregion

        #region LoadAndSave
        public DatenModel load()
        {
            DatenModel daten = new DatenModel();
            daten.ABTEILUNGEN = new List<AbteilungModel>();
            daten.PRAKTIKANTEN = new List<PraktikantModel>();

            if (System.IO.File.Exists(SqliteDBName))
            {

                SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + SqliteDBName + ";Version=3;");
                sqliteConnection.Open();
                string sqlAbteilung = "SELECT * FROM abteilung";
                SQLiteCommand commandAbteilung = new SQLiteCommand(sqlAbteilung, sqliteConnection);
                SQLiteDataReader readerAbteilung = commandAbteilung.ExecuteReader();
                List<AbteilungModel> abteilungen = new List<AbteilungModel>();
                while (readerAbteilung.Read())
                {
                    string bez = readerAbteilung["bezeichnung"].ToString();
                    int abteilungNr = Convert.ToInt32(readerAbteilung["abteilung_nr"]);
                    AbteilungModel newAbt = new AbteilungModel();
                    newAbt.Abteilung_NR = abteilungNr;
                    newAbt.Bezeichnung = bez;

                    abteilungen.Add(newAbt);
                }
                string sqlPraktikant = "SELECT * FROM praktikant";
                SQLiteCommand commandPraktikant = new SQLiteCommand(sqlPraktikant, sqliteConnection);
                SQLiteDataReader readerPraktikant = commandPraktikant.ExecuteReader();
                List<PraktikantModel> praktikanten = new List<PraktikantModel>();
                while (readerPraktikant.Read())
                {
                    string bez = readerPraktikant["name"].ToString();
                    int praktikantNr = Convert.ToInt32(readerPraktikant["praktikant_nr"]);
                    int abteilungNr = Convert.ToInt32(readerPraktikant["abteilung_nr"]);
                    PraktikantModel newPrak = new PraktikantModel();
                    newPrak.Praktikant_NR = praktikantNr;
                    newPrak.Name = bez;
                    newPrak.ZugewieseneAbteilung = abteilungNr;

                    praktikanten.Add(newPrak);
                }
                sqliteConnection.Close();
                sqliteConnection.Dispose();
                daten.ABTEILUNGEN = abteilungen;
                daten.PRAKTIKANTEN = praktikanten;
            }


            return daten;
        }

        public void save(DatenModel daten)
        {
            if (!System.IO.File.Exists(SqliteDBName))
            {
                SQLiteConnection.CreateFile(SqliteDBName);
                SQLiteConnection createNewDBFileConnection = new SQLiteConnection("Data Source=" + SqliteDBName + ";Version=3;");
                createNewDBFileConnection.Open();

                string sqlCreateAbteilung = "CREATE TABLE abteilung (" +
                    "abteilung_nr INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "bezeichnung varchar(35))";

                SQLiteCommand commandAbteilung = new SQLiteCommand(sqlCreateAbteilung, createNewDBFileConnection);
                commandAbteilung.ExecuteNonQuery();

                string sqlCreatePraktikant = "CREATE TABLE praktikant (" +
                    "praktikant_nr INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "name varchar(35)," +
                    "abteilung_nr INTEGER," +
                    "FOREIGN KEY(abteilung_nr) REFERENCES abteilung(abteilung_nr))";

                SQLiteCommand commandPraktikant = new SQLiteCommand(sqlCreatePraktikant, createNewDBFileConnection);
                commandPraktikant.ExecuteNonQuery();

                createNewDBFileConnection.Close();
                createNewDBFileConnection.Dispose();
            }
            SQLiteConnection saveDataToDBConnection = new SQLiteConnection("Data Source=" + SqliteDBName + ";Version=3;");
            saveDataToDBConnection.Open();
            foreach (var item in daten.ABTEILUNGEN)
            {
                string abteilungSave = String.Format("INSERT INTO abteilung (bezeichnung) VALUES ('{0}')", item.Bezeichnung);
                SQLiteCommand saveAbteilung = new SQLiteCommand(abteilungSave, saveDataToDBConnection);
                saveAbteilung.ExecuteNonQuery();
            }
            foreach (var item in daten.PRAKTIKANTEN)
            {
                string praktikantSave = String.Format("INSERT INTO praktikant (name, abteilung_nr) VALUES ('{0}', {1})", item.Name, item.ZugewieseneAbteilung);
                SQLiteCommand saveAbteilung = new SQLiteCommand(praktikantSave, saveDataToDBConnection);
                saveAbteilung.ExecuteNonQuery();
            }
            saveDataToDBConnection.Close();
            saveDataToDBConnection.Dispose();
        }
        #endregion


    }
}
