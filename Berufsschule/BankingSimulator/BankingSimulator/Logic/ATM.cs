using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSimulator
{
    // atm is the main focus in this applications
    // it implements the IDataBus interface and gives it, the functionality
    // atm handles the user process (user login / user register)
    // atm handles transactions with the TRANSACT object

    class ATM : IDataBus
    {
        SqlConnection CONNECTION;

        public ATM()
        {
            establishConnection();
        }

        public List<BankingAccount> retrieveBankAccounts(PersonalData owner)
        {
            List<BankingAccount> accountList = new List<BankingAccount>();
            string sqlBankAccounts = "SELECT * FROM BankAccount WHERE OWNER = " + owner.ID + ";";
            CONNECTION.Open();
            SqlCommand command = new SqlCommand(sqlBankAccounts, CONNECTION);
            SqlDataReader sReader;
            command.Parameters.Clear();
            sReader = command.ExecuteReader();

            while (sReader.Read())
            {
                BankingAccount account = new BankingAccount();
                account.NAME = sReader["NAME"].ToString();
                account.ID = Convert.ToInt32(sReader["Id"].ToString());
                account.BALANCE = Convert.ToDouble(sReader["BALANCE"].ToString());
                accountList.Add(account);
            }
            CONNECTION.Close();
            return accountList;
        }

        public void establishConnection()
        {
            CONNECTION = new SqlConnection();
            // VERY IMPORTANT ====> YOU NEED TO CHANGE THE 'AttachDbFilename=' PATH TO THE PATH OF THE MDF WHEN ITS ON YOUR MACHINE !!!
            CONNECTION.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=U:\Tobias K Berufsschule\BankingSimulator\BankingSimulator\Databases\Banking.mdf;Integrated Security=True";
            
        }

        public void PushPerson(PersonalData person)
        {
            CONNECTION.Open();
            string sqlInsertPerson = "INSERT INTO PersonalData (NAME, LASTNAME, TELEPHONE, USERNAME, EMAIL, PASSWORD) VALUES ('" + person.NAME + "', '" + person.LASTNAME + "', '" + person.TELEPHONE+"', '" + person.USERNAME + "', '"+person.EMAIL + "', '" + person.PASSWORD + "');";
            SqlCommand command = new SqlCommand(sqlInsertPerson, CONNECTION);
            int i = command.ExecuteNonQuery();
            CONNECTION.Close();
        }

        public List<string> GetTransactionRecords(BankingAccount account)
        {
            List<string> transactions = new List<string>();
            string sqlSelectTransactions = "SELECT * FROM Transactions WHERE FROMACCOUNT = " + account.ID + " or TOACCOUNT = " + account.ID + ";";
            CONNECTION.Open();
            SqlCommand command = new SqlCommand(sqlSelectTransactions, CONNECTION);
            SqlDataReader sReader;
            command.Parameters.Clear();
            sReader = command.ExecuteReader();

            while (sReader.Read())
            {
                transactions.Add("TRANS-ID: " + sReader["Id"].ToString() + "FROM: " + sReader["FROMACCOUNT"].ToString() + " TO: " + sReader["TOACCOUNT"].ToString() + " Usage: " + sReader["USAGE"].ToString() + " Money: " + sReader["MONEY"]);
            }
            CONNECTION.Close();
            return transactions;
        }

        public PersonalData retrievePerson(string email)
        {
            PersonalData person = new PersonalData();
            string sqlSelectUniquePerson = "SELECT * FROM PersonalData WHERE Convert(varchar, EMAIL) = '" + email + "';";
            CONNECTION.Open();
            SqlCommand command = new SqlCommand(sqlSelectUniquePerson, CONNECTION);
            SqlDataReader sReader;
            command.Parameters.Clear();
            sReader = command.ExecuteReader();

            while (sReader.Read())
            {
                person.NAME = sReader["NAME"].ToString();
                person.ID = Convert.ToInt32(sReader["Id"].ToString());
                person.LASTNAME = sReader["LASTNAME"].ToString();
                person.TELEPHONE = sReader["TELEPHONE"].ToString();
                person.EMAIL = sReader["EMAIL"].ToString();
                person.PASSWORD = sReader["PASSWORD"].ToString();
                person.USERNAME = sReader["USERNAME"].ToString();
            }
            CONNECTION.Close();
            return person;
        }

        public List<PersonalData> retrievePersons()
        {
            List<PersonalData> persons = new List<PersonalData>();
            string sqlSelectPersons = "SELECT * FROM PersonalData;";
            CONNECTION.Open();
            SqlCommand command = new SqlCommand(sqlSelectPersons, CONNECTION);
            SqlDataReader sReader;
            command.Parameters.Clear();
            sReader = command.ExecuteReader();
            
            while (sReader.Read())
            {
                var tmpData = new PersonalData();
                tmpData.NAME = sReader["NAME"].ToString();
                tmpData.ID = Convert.ToInt32(sReader["Id"].ToString());
                tmpData.LASTNAME = sReader["LASTNAME"].ToString();
                tmpData.TELEPHONE = sReader["TELEPHONE"].ToString();
                tmpData.EMAIL = sReader["EMAIL"].ToString();
                tmpData.PASSWORD = sReader["PASSWORD"].ToString();
                tmpData.USERNAME = sReader["USERNAME"].ToString();
                persons.Add(tmpData);
            }
            CONNECTION.Close();
            return persons;
        }

        public bool createBankAccount(BankingAccount account)
        {
            var bankaccounts = retrieveBankAccounts(retrievePerson(account.OWNER));

            var result = bankaccounts.Where(x => x.NAME == account.NAME).FirstOrDefault();
            if(result == null)
            {
                CONNECTION.Open();
                string sqlInsertBankAccount = "INSERT INTO BankAccount (NAME, OWNER, BALANCE) VALUES ('" + account.NAME + "', " + account.OWNER + ", 0);";
                SqlCommand command = new SqlCommand(sqlInsertBankAccount, CONNECTION);
                int i = command.ExecuteNonQuery();
                CONNECTION.Close();
                return true;
            }
            return false;
        }

        public PersonalData retrievePerson(int id)
        {
            PersonalData person = new PersonalData();
            string sqlSelectUniquePerson = "SELECT * FROM PersonalData WHERE Id = " + id + ";";
            CONNECTION.Open();
            SqlCommand command = new SqlCommand(sqlSelectUniquePerson, CONNECTION);
            SqlDataReader sReader;
            command.Parameters.Clear();
            sReader = command.ExecuteReader();

            while (sReader.Read())
            {
                person.NAME = sReader["NAME"].ToString();
                person.ID = Convert.ToInt32(sReader["Id"].ToString());
                person.LASTNAME = sReader["LASTNAME"].ToString();
                person.TELEPHONE = sReader["TELEPHONE"].ToString();
                person.EMAIL = sReader["EMAIL"].ToString();
                person.PASSWORD = sReader["PASSWORD"].ToString();
                person.USERNAME = sReader["USERNAME"].ToString();
            }
            CONNECTION.Close();
            return person;
        }

        public void clearPersonalData()
        {
            CONNECTION.Open();
            string sqlClearPersonalData = "alter table PersonalData nocheck constraint all;" +
                "DELETE FROM PersonalData;"
                + "alter table PersonalData check constraint all;";
            SqlCommand command = new SqlCommand(sqlClearPersonalData, CONNECTION);
            int i = command.ExecuteNonQuery();
            CONNECTION.Close();
        }

        public void clearBankAccount()
        {
            CONNECTION.Open();
            string sqlClearBankAccount= "alter table BankAccount nocheck constraint all;" +
                "DELETE FROM BankAccount;"
                + "alter table BankAccount check constraint all;";
            SqlCommand command = new SqlCommand(sqlClearBankAccount, CONNECTION);
            int i = command.ExecuteNonQuery();
            CONNECTION.Close();
        }

        public void clearTransactions()
        {
            CONNECTION.Open();
            string sqlClearTransactions = "alter table Transactions nocheck constraint all;" +
                "DELETE FROM Transactions;"
                + "alter table Transactions check constraint all;";
            SqlCommand command = new SqlCommand(sqlClearTransactions, CONNECTION);
            int i = command.ExecuteNonQuery();
            CONNECTION.Close();
        }

        public void deposit(double moneyvalue, BankingAccount account)
        {
            

            // get current balance
            double newBalance = GetAccountBalance(account) + moneyvalue;
            CONNECTION.Open();
            string sqlUpdateBalance = "UPDATE BankAccount SET BALANCE = " + newBalance + " WHERE Id = " + account.ID;
            SqlCommand command = new SqlCommand(sqlUpdateBalance, CONNECTION);
            int i = command.ExecuteNonQuery();
            CONNECTION.Close();
        }

        private double GetAccountBalance(BankingAccount account)
        {
            double BALANCE = 0;
            string sqlSelectAccount = "SELECT BALANCE FROM BankAccount WHERE Id = " + account.ID + ";";
            CONNECTION.Open();
            SqlCommand command = new SqlCommand(sqlSelectAccount, CONNECTION);
            SqlDataReader sReader;
            command.Parameters.Clear();
            sReader = command.ExecuteReader();

            while (sReader.Read())
            {
                BALANCE = Convert.ToDouble(sReader["BALANCE"].ToString());
            }
            CONNECTION.Close();
            return BALANCE;
        }

        public void withdraw(double moneyvalue, BankingAccount account)
        {
            // get current balance
            double newBalance = GetAccountBalance(account) - moneyvalue;
            CONNECTION.Open();
            string sqlUpdateBalance = "UPDATE BankAccount SET BALANCE = " + newBalance + " WHERE Id = " + account.ID;
            SqlCommand command = new SqlCommand(sqlUpdateBalance, CONNECTION);
            int i = command.ExecuteNonQuery();
            CONNECTION.Close();
        }

        public void writeTransaction(int fromid, int toid, string text, double value)
        {
            CONNECTION.Open();
            string sqlInsertBankAccount = "INSERT INTO Transactions (FROMACCOUNT, TOACCOUNT, MONEY, USAGE) VALUES ('" + fromid + "', " + toid + ", " + value + ", '" + text + "');";
            SqlCommand command = new SqlCommand(sqlInsertBankAccount, CONNECTION);
            int i = command.ExecuteNonQuery();
            CONNECTION.Close();
        }

        public BankingAccount retrieveBankAccount(int bankid)
        {
            BankingAccount account = new BankingAccount();
            string sqlSelectAccount = "SELECT * FROM BankAccount WHERE Id = " + bankid + ";";
            CONNECTION.Open();
            SqlCommand command = new SqlCommand(sqlSelectAccount, CONNECTION);
            SqlDataReader sReader;
            command.Parameters.Clear();
            sReader = command.ExecuteReader();

            while (sReader.Read())
            {
                account.NAME = sReader["NAME"].ToString();
                account.ID = Convert.ToInt32(sReader["Id"].ToString());
                account.BALANCE = Convert.ToDouble(sReader["BALANCE"].ToString());
            }
            CONNECTION.Close();
            return account;
        }
    }
}
