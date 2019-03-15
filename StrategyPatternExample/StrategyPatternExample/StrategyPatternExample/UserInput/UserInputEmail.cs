using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternExample
{
    class UserInputEmail : IUserInput
    {
        public bool CheckInput(object inp)
        {
            string input = inp.ToString();
            if(input.Contains("@") == true)
            {
                return true;
            }
            return false;
        }
    }
}
