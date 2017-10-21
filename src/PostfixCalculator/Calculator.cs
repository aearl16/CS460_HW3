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
            WriteLine("Postfix Calculator.\nRecognizes these operators: +-*/ ");
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
            double temp2;
            double operand;
            double answer;
            string[] inputs = input.Split(' ');

            for (int i = 0; i <= inputs.Length - 1; i++)
            {
                if (double.TryParse(inputs[i], out temp2))
                {
                    stack.Push(temp2); //used answer for temporary storage
                    WriteLine("Stack Push double");
                    temp2 = 0.0D; //clear answer
                }
                else
                {
                    if(i == inputs.Length - 1)
                    {
                        break;
                    }
                    else
                    {
                        ++i;
                    }
                    token = inputs[i].ToString();
                    if (inputs[i].Length > 1)
                    {
                        throw new ArgumentException("Input Error: " + inputs[i] + " is not an allowed number or operator");
                    }
                    operand = Convert.ToDouble(stack.Pop().ToString());
                    if (stack.IsEmpty)
                    {
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    temp = Convert.ToDouble(stack.Pop());
                    WriteLine("Here");
                    answer = DoOperation(token, temp, operand);
                    WriteLine("After DoOperation");
                }
            }
            return Convert.ToDouble(stack.Pop()).ToString();
        }

        public double DoOperation(String token, double temp, double operand)
        {
            double output = 0.0D;
            if (token == "+")
            {
                output = temp + operand;
                WriteLine("Plus");
            }
            else if (token == "-")
            {
                output = (temp - operand);
                WriteLine("Minus");
            }
            else if (token == "*")
            {
                output = temp * operand;
                WriteLine("Multiply");
            }
            else if (token == "/")
            {
                WriteLine("Divide");
                try
                {
                    output = (temp / operand);
                    if (output == Double.NegativeInfinity || output == Double.PositiveInfinity)
                        throw new ArgumentException("Can't divide by zero");
                }
                catch (ArithmeticException e)
                {
                    throw new ArgumentException(e.ToString());
                }
            }
            else
            {
                throw new ArgumentException("Improper operator: " + token + ", is not one of +, -, *, or /");
            }

            return output;
        }
    }
}
