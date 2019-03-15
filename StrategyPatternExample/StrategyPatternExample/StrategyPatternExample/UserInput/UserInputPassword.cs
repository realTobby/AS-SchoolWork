using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternExample
{
    public class UserInputPassword : IUserInput
    {
        public bool CheckInput(object inp)
        {
            string input = inp.ToString();
            if(input.Length >= 12)
            {
                return true;
            }
            return false;
        }
    }
}
