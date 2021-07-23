using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankingSimulator
{
        // MainComponents basically just tells the ATM what to do
        // with that, it would be possible to include even more logic into
        // our application

        // atm returns specific things
        // the maincomponent could decide what it does with it

    public class MainComponents : IDataBus
    {
        ATM atm = new ATM();

        public void establishConnection()
        {
            atm.establishConnection();
        }

        public void PushPerson(PersonalData person)
        {
            atm.PushPerson(person);
        }

        public List<PersonalData> retrievePersons()
        {
            return atm.retrievePersons();
        }

        public bool login(PersonalData data)
        {
            var persons = retrievePersons();
            var result = persons.Where(x=>x.EMAIL == data.EMAIL && x.PASSWORD == data.PASSWORD).FirstOrDefault();

            if(result != null)
            {
                return true;
            }
            return false;
        }

        public bool RegisterPerson(PersonalData person)
        {
            if (checkDuplicates(person) == false)
            {
                PushPerson(person);
                return true;
            }
            return false;
        }

        public bool checkDuplicates(PersonalData data)
        {
            var persons = retrievePersons();
            var result = persons.Where(x => x.EMAIL == data.EMAIL).FirstOrDefault();
            if(result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetPasswordHash(string passwordClear)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(Encoding.ASCII.GetBytes(passwordClear));
            return Convert.ToBase64String(sha1data);
        }

        public PersonalData retrievePerson(string email)
        {
            return atm.retrievePerson(email);
        }

        public List<BankingAccount> retrieveBankAccounts(PersonalData owner)
        {
            return atm.retrieveBankAccounts(owner);
        }

        public bool createBankAccount(BankingAccount account)
        {
            return atm.createBankAccount(account);
        }

        public BankingAccount retrieveBankAccount(int bankid)
        {
            return atm.retrieveBankAccount(bankid);
        }

        public PersonalData retrievePerson(int id)
        {
            return atm.retrievePerson(id);
        }

        public List<string> GetTransactionRecords(BankingAccount account)
        {
            return atm.GetTransactionRecords(account);
        }

        public void clearPersonalData()
        {
            atm.clearPersonalData();
        }

        public void clearBankAccount()
        {
            atm.clearBankAccount();
        }

        public void clearTransactions()
        {
            atm.clearTransactions();
        }

        public void deposit(double moneyvalue, BankingAccount account)
        {
            atm.deposit(moneyvalue, account);
        }

        public void withdraw(double moneyvalue, BankingAccount account)
        {
            atm.withdraw(moneyvalue, account);
        }

        public void writeTransaction(int fromid, int toid, string text, double value)
        {
            atm.writeTransaction(fromid, toid, text, value);
        }
    }
}
