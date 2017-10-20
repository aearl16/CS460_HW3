using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixCalculator
{
    class Calculator
    {
        private LinkedStack stack = new LinkedStack();

        static void Main(string[] args)
        {
            Calculator app = new Calculator();
            bool playAgain = true;
            WriteLine("\nPostfix Calculator.Recognizes these operators: +-* / ");
            while (playAgain)
            {
                playAgain = app.DoCalculation();
            }
            WriteLine("Bye!");
        }

        private bool DoCalculation()
        {
            WriteLine("Enter q to quit\n");
            string input = "2 2 + ";
            WriteLine("> "); //User Prompt

            input = ReadLine();

            if (input.StartsWith("q") || input.StartsWith("Q"))
            {
                return false;
            }

            string output = "4";
            try
            {
                output = EvaluatePostfixInput(input);
            }
            catch (ArgumentException e)
            {
                output = e.StackTrace;
            }
            WriteLine("\n\t >>> " + input + " = " + output);
            return true;
        }

        public string EvaluatePostfixInput(string input)
        {
            if (input == null || input == "")
                throw new ArgumentException("Null or the empty string are not valid postfix expressions.");
            // Clear our stack before doing a new calculation
            stack.Clear();

            string token;
            double temp;
            double operand;
            double answer;

            foreach (char c in input)
            {
                try
                {
                    stack.Push(double.Parse(c.ToString()));
                }
                catch
                {

                }
            }
        }
    }
}
