using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Calculator
{
    class ScientificCalc : CalcProcess
    {
        public int factorial(int n)
        {
            if(n==0)
            {
                return 1;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }

        public int power(int x, int n)
        {
            int result = 1;
            for(int i=0;i<n;i++)
            {
                result *= x;
            }
            return result;
        }
    }
}
