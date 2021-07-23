using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSimulator
{
    public class PersonalData
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string LASTNAME { get; set; }
        public string TELEPHONE { get; set; }
        public string USERNAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        // i am pretty sure that production code should never ever 
        // have access to the password of ones account 
        //(malware could read the RAM and easily get the account
        //details ==> avoid this at all cost (using this in this 
        //example because its only for demonstrating purposes
        //and no real details are shown here)
    }
}
