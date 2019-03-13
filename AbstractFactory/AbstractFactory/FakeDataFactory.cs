using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class FakeDataFactory : IFakeFactory
    {
        public IFakePerson CreateFakePerson()
        {
            return new FakePerson();
        }
    }
}
