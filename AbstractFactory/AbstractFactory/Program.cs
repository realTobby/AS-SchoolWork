using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    { 
        static void Main(string[] args)
        {
            IFakeFactory dataFactory = new FakeDataFactory();

            IFakePerson newData = dataFactory.CreateFakePerson();

            Console.WriteLine("Name: " + newData.GetName() + "  - Surname: " + newData.GetSurname() + "  - Password: " + newData.GetPassword());

            Console.ReadLine();

        }
    }
}
