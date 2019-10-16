using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Basic_Calculator
{
    class FileCalcIO
    {
        private String inputFilePath = @"D:\C#\Basic_Calculator\Basic_Calculator\IO_Files\InputFile.txt";
        private String outputFilePath = @"D:\C#\Basic_Calculator\Basic_Calculator\IO_Files\OutputFile.txt";

        private String[] textLines;

        private int operand1 = 0;
        private int operand2 = 0;
        private String calcOperator = "";

        public void exitApplication(String filename)
        {
            Console.WriteLine(filename + " Does Not Exist");
            System.Environment.Exit(0);
        }

        public String checkOperatorFormat(String input)
        {
            String result = "";
            for(int i=0;i<input.Length;i++)
            {
                if(input[i].Equals('+') || input[i].Equals('-') || input[i].Equals('*') || input[i].Equals('/'))
                {
                    result += input[i];
                    return result;
                }
            }
            return "Operator_Error";
        }

        public bool checkOperandFormat(String input1, String input2)
        {
            bool result1 = Int32.TryParse(input1, out operand1);
            bool result2 = Int32.TryParse(input2, out operand2);
            if(result1)
            {
                if(result2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public String calculation(int operand1, int operand2, String calcOperator)
        {
            CalcProcess calc = new CalcProcess();

            if(calcOperator.Equals("+"))
            {
                return "" + calc.add(operand1, operand2);
            }
            else if(calcOperator.Equals("-"))
            {
                return "" + calc.subtract(operand1, operand2);
            }
            else if(calcOperator.Equals("*"))
            {
                return "" + calc.multiply(operand1, operand2);
            }
            else
            {
                try
                {
                    return "" + calc.divide(operand1, operand2);
                }
                catch(Exception ex)
                {
                    return "" + ex.Message;
                }
                finally
                {

                }
            }
        }

        public String processData(String input)
        {
            String[] values;
            String outputString = "";
            String result = "";

            values = input.Split(',');

            calcOperator = checkOperatorFormat(values[2]);
            if(calcOperator.Equals("Operator_Error"))
            {
                outputString = values[0] + " " + values[2] + " " + values[1] + " = Operator Error !";
                return outputString;
            }

            if(checkOperandFormat(values[0], values[1]))
            {
                result = calculation(operand1, operand2, calcOperator);
                outputString = operand1 + " " + calcOperator + " " + operand2 + " = " + result;
                return outputString;
            }
            else
            {
                outputString = values[0] + " " + calcOperator + " " + values[1] + " = Invalid Operand !";
                return outputString;
            }
        }

        public void readInputData()
        {
            textLines = File.ReadAllLines(inputFilePath);
            for (int i = 0; i < textLines.Length; i++)
            {
                if (!((textLines[i].Equals("BEGIN")) || (textLines[i].Equals("END"))))
                {
                    textLines[i] = processData(textLines[i]);
                }
                else if (textLines[i].Equals("BEGIN"))
                {
                    textLines[i] = "RESULT:";
                }
                else if (textLines[i].Equals("END"))
                {
                    textLines[i] = "";
                }
            }
        }

        public void startOperation()
        {
            if(File.Exists(inputFilePath))
            {
                readInputData();
            }
            else
            {
                exitApplication("Input File");
            }

            if(File.Exists(outputFilePath))
            {
                File.WriteAllLines(outputFilePath, textLines);
            }
            else
            {
                exitApplication("Output File");
            }
            Console.WriteLine("File IO Operation Successfully Done");
        }


    }
}
