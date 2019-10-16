using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Calculator
{
    class CalcProcess
    {
        public int add(int x, int y)
        {
            int result = x + y;
            return result;
        }

        public int subtract(int x, int y)
        {
            int result = x - y;
            return result;
        }

        public int multiply(int x, int y)
        {
            int result = x * y;
            return result;
        }

        public int divide(int x, int y)
        {
            if(y==0)
            {
                throw new Exception("Division by 0 cannot be done !");
            }
            int result = x / y;
            return result;
        }
    }
}
