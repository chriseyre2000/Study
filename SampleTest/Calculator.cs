using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTest
{
    public class Calculator
    {
        private int _register;
        
        public Calculator(int initialRegister)
        {
            _register = initialRegister;
        }

        public int Register
        {
            get { return _register; }
        }

        public void Add(int value)
        {
            _register += value;
        }
    }
}
