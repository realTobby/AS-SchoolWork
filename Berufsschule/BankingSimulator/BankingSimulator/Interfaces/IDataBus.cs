using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSimulator
{
    // Idatabus is the interface wich realizes the broader terms of data manipulation

        // for example:
        // one class could use it to get data from a local database
        // another one could implement it as a way to read data from an xml or sqlite file
        // and another one could use it as a way to connect to a server hosted online to get data

        // always program on interfaces to make adaptability easier

    interface IDataBus
    {
        // establishes the connection to the datasource
        void establishConnection();

        // get every person
        List<PersonalData> retrievePersons();

        // get a person with a unique identifier (email in this case)
        PersonalData retrievePerson(string email);

        // get a person with a unique identifier (email in this case)
        PersonalData retrievePerson(int id);

        // add a person to datasource
        void PushPerson(PersonalData person);

        // get all bank accounts accosiated with the holder
        List<BankingAccount> retrieveBankAccounts(PersonalData owner);

        // creates bank account associated to a person
        bool createBankAccount(BankingAccount account);

        // get transactions accosiated with a sepcific bank account
        List<string> GetTransactionRecords(BankingAccount account);

        void clearPersonalData();

        void clearBankAccount();

        void clearTransactions();

        void deposit(double moneyvalue, BankingAccount account);

        void withdraw(double moneyvalue, BankingAccount account);

        void writeTransaction(int fromid, int toid, string text, double value);

        BankingAccount retrieveBankAccount(int bankid);



    }
}
