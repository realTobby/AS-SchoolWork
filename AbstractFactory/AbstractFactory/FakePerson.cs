using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class FakePerson : IFakePerson
    {
        public string Name;
        public string Surname;
        public string Password;

        public FakePerson()
        {
            this.Name = Util.getRandomString(12);
            this.Surname = Util.getRandomString(12);
            this.Password = Util.getRandomString(12);
        }

        public string GetName()
        {
            return Name;
        }

        public string GetPassword()
        {
            return Password;
        }

        public string GetSurname()
        {
            return Surname;
        }
    }
}
