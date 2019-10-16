using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Calculator
{
    class CalcIO
    {
        private int input1 = 0;
        private int input2 = 0;
        private ScientificCalc calc = new ScientificCalc();

        public void exitApplication()
        {
            Console.WriteLine("Program Terminated");
            System.Environment.Exit(0);
        }

        public int getInput(String serial)
        {
            int number = 0;
            String input = "";
            do
            {
                Console.WriteLine("Enter "+ serial +" input: ");
                input = Console.ReadLine();
                if(input.Equals("q"))
                {
                    exitApplication();
                }
            } while (!Int32.TryParse(input, out number));

            return number;
        }

        public void startOperation()
        {
            input1 = getInput("first");
            input2 = getInput("second");

            Console.WriteLine("All the calculations are shown below:");
            Console.WriteLine("Addition: "+ calc.add(input1, input2));
            Console.WriteLine("Subtraction: "+ calc.subtract(input1, input2));
            Console.WriteLine("Multiplication: " + calc.multiply(input1, input2));
            try
            {
                Console.WriteLine("Division: "+ calc.divide(input1, input2));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in Division: "+ ex.Message +"\n");
            }
            finally
            {
                // empty
            }

            Console.WriteLine("The Factorial of "+ input1 +" is "+ calc.factorial(input1));
            Console.WriteLine(input1 +" to the power of "+ input2 +" is "+ calc.power(input1, input2));

            startOperation();

        }
    }
}
