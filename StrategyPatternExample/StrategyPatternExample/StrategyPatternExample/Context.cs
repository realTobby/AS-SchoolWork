using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternExample
{
    public class Context
    {
        IUserInput cntxUserInput;

        public bool checkInput(object input)
        {
            return cntxUserInput.CheckInput(input);
        }

        public void setUserInput(IUserInput userInput)
        {
            cntxUserInput = userInput;
        }
    }
}
