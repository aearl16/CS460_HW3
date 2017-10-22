using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixCalculator
{
    /**
     * This class implements a postfix calculator
     * it promts the user for input and returns the result
     */
    class Calculator
    {
        //Global variables
        private LinkedStack stack = new LinkedStack();

        //Main
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

        /**
         * This method promts the user for input and 
         * begins the evaluation
         */
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
                output = e.Message;
            }
            WriteLine("\n>>> " + input + " = " + output);
            return true;
        }

        /*
         * This method pushes the numbers to the stack and 
         * does an operation if it runs into a operator
         * it does the calculation and pushes the result on the stack
         */
        public string EvaluatePostfixInput(string input)
        {
            if (input == null || input == "")
                throw new ArgumentException("Null or the empty string are not valid postfix expressions.");
            // Clear our stack before doing a new calculation
            stack.Clear();

            string token; // will store operator
            double temp; // first value, a 
            double temp2; // temp from a double output.
            double operand; // second value, b
            double answer = 0.0; // accumulator


            string[] inputs = input.Split(' ');

            for (int i = 0; i <= inputs.Length - 1; i++)
            {

                if (double.TryParse(inputs[i], out temp2))
                {
                    stack.Push(temp2);
                }
                else
                {
                    // Is the stack empty?
                    if (stack.IsEmpty)
                    {
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    // is the non-numeric item an operator?
                    else if (inputs[i].Length > 1)
                    {
                        throw new ArgumentException("Input Error: " + inputs[i] + " is not an allowed number or operator");
                    }
                    else
                    {
                        // operand a
                        Node nd1 = (Node)stack.Pop();
                        // operand b
                        Node nd2 = (Node)stack.Pop();
                        // operand a
                        temp = (double)nd1.Data;
                        // operand b
                        operand = (double)nd2.Data;
                        // operator
                        token = inputs[i];
                        // get the answer from the DoOperation method.
                        answer = DoOperation(token, temp, operand);
                        // push the answer on to the stack.
                        stack.Push(answer);
                    }

                }
            }
            // return the solution.
            return Convert.ToString(answer);
        }

        /**
         * This method 
         * 
         */
        public double DoOperation(string token, double temp, double operand)
        {
            double output = 0;
            if (token == "+")
            {
                output = temp + operand;
                //WriteLine("Plus");
            }
            else if (token == "-")
            {
                output = (operand - temp);
                //WriteLine("Minus");
            }
            else if (token == "*")
            {
                output = temp * operand;
                //WriteLine("Multiply");
            }
            else if (token == "/")
            {
                //WriteLine("Divide");
                try
                {
                    output = (operand / temp);
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

        //public string EvaluatePostfixInput(string input)
        //{
        //    if (input == null || input == "")
        //        throw new ArgumentException("Null or the empty string are not valid postfix expressions.");
        //    // Clear our stack before doing a new calculation
        //    stack.Clear();

        //    String s;   // Temporary variable for token read
        //    double a;   // Temporary variable for operand
        //    double b;   // ...for operand
        //    double c;   // ...for answer

        //    Scanner st = new Scanner(input);
        //    while (st.hasNext())
        //    {
        //        if (st.hasNextDouble())
        //        {
        //            stack.Push(Convert.ToDouble(st.nextDouble()));    // if it's a number push it on the stack
        //        }
        //        else
        //        {
        //            // Must be an operator or some other character or word.
        //            if (st.hasNext())
        //            {
        //                s = st.next(); 
        //            }
        //            else
        //            {
        //                break;
        //            }
        //            if (s?.Length > 1)
        //            {
        //                throw new ArgumentException("Input Error: " + s + " is not an allowed number or operator");
        //            }
        //            // it may be an operator so pop two values off the stack and perform the indicated operation
        //            if (stack.IsEmpty)
        //            {
        //                throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
        //            }

        //            b = (double)stack.Pop();
        //            if (stack.IsEmpty)
        //                throw new ArgumentException("Improper input format. Stack became empty when expecting first operand.");
        //            a = Convert.ToDouble(stack.Pop());
        //            // Wrap up all operations in a single method, easy to add other binary operators this way if desired
        //            c = DoOperation(a, b, s);
        //            // push the answer back on the stack
        //            stack.Push(Convert.ToDouble(c));
        //        }
        //    }// End while
        //    return stack.Pop().ToString();
        //}

        //public double DoOperation(double a, double b, String s)
        //{
        //    double c = 0.0D;
        //    if (s == "+")      // Can't use a switch-case with Strings, so we do if-else
        //        c = (a + b);
        //    else if (s == "-")
        //        c = (a - b);
        //    else if (s == "*")
        //        c = (a * b);
        //    else if (s == "/")
        //    {
        //        try
        //        {
        //            c = (a / b);
        //            if (c == double.NegativeInfinity || c == double.PositiveInfinity)
        //                throw new ArgumentException("Can't divide by zero");
        //        }
        //        catch (ArithmeticException e)
        //        {
        //            throw new ArgumentException(e.ToString());
        //        }
        //    }
        //    else
        //        throw new ArgumentException("Improper operator: " + s + ", is not one of +, -, *, or /");

        //    return c;
        //}
    }
}
