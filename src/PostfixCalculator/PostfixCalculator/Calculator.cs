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
                WriteLine("EvaluatePostfixInput");
            }
            catch (ArgumentException e)
            {
                output = e.StackTrace;
            }
            WriteLine("\n>>> " + input + " = " + output);
            return true;
        }

        /*
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
        */

        public string EvaluatePostfixInput(string input)
        {
            if (input == null || input == "")
                throw new ArgumentException("Null or the empty string are not valid postfix expressions.");
            // Clear our stack before doing a new calculation
            stack.Clear();

            String s;   // Temporary variable for token read
            double a;   // Temporary variable for operand
            double b;   // ...for operand
            double c;   // ...for answer

            Scanner st = new Scanner(input);
            while (st.hasNext())
            {
                if (st.hasNextDouble())
                {
                    stack.Push(Convert.ToDouble(st.nextDouble()));    // if it's a number push it on the stack
                }
                else
                {
                    // Must be an operator or some other character or word.
                    if (st.hasNext())
                    {
                        s = st.next(); 
                    }
                    else
                    {
                        break;
                    }
                    if (s?.Length > 1)
                    {
                        throw new ArgumentException("Input Error: " + s + " is not an allowed number or operator");
                    }
                    // it may be an operator so pop two values off the stack and perform the indicated operation
                    if (stack.IsEmpty)
                    {
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                    }

                    b = Convert.ToDouble(stack.Pop());
                    if (stack.IsEmpty)
                        throw new ArgumentException("Improper input format. Stack became empty when expecting first operand.");
                    a = Convert.ToDouble(stack.Pop());
                    // Wrap up all operations in a single method, easy to add other binary operators this way if desired
                    c = DoOperation(a, b, s);
                    // push the answer back on the stack
                    stack.Push(Convert.ToDouble(c));
                }
            }// End while
            return Convert.ToDouble(stack.Pop()).ToString();
        }

        public double DoOperation(double a, double b, String s)
        {
            double c = 0.0D;
            if (s == "+")      // Can't use a switch-case with Strings, so we do if-else
                c = (a + b);
            else if (s == "-")
                c = (a - b);
            else if (s == "*")
                c = (a * b);
            else if (s == "/")
            {
                try
                {
                    c = (a / b);
                    if (c == double.NegativeInfinity || c == double.PositiveInfinity)
                        throw new ArgumentException("Can't divide by zero");
                }
                catch (ArithmeticException e)
                {
                    throw new ArgumentException(e.ToString());
                }
            }
            else
                throw new ArgumentException("Improper operator: " + s + ", is not one of +, -, *, or /");

            return c;
        }
    }
}
