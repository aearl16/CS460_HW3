using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Original idea from https://stackoverflow.com/questions/722270/is-there-an-equivalent-to-the-scanner-class-in-c-sharp-for-strings
namespace PostfixCalculator
{
    /**
     * This class is similar to the Java util.Scanner class.
     * It tokenizes a string and returns a sub section of the string
     */
    class Scanner : System.IO.StringReader
    {
        //Global variables
        private string currentWord;

        /**
         * Constructor for Scanner
         */
        public Scanner(string source) : base(source)
        {
            readNextWord();
        }

        /**
         * readNextWord, reads the next word in the string
         * Sets the global variable to the string value pointed at.
         */
        private void readNextWord()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            char nextChar;
            int next;
            do
            {
                next = this.Read();
                if (next < 0)
                {
                    break;
                }

                nextChar = (char)next;
                if (char.IsWhiteSpace(nextChar))
                {
                    break;
                }

                sb.Append(nextChar);
            } while (true);
            while ((this.Peek() >= 0) && (char.IsWhiteSpace((char)this.Peek())))
            {
                this.Read();
            }

            if (sb.Length > 0)
            {
                currentWord = sb.ToString();
            }
            else
            {
                currentWord = null;
            }
        }

        /**
         * hasNextInt return a bool if the next value is an int
         */
        public bool hasNextInt()
        {
            if (currentWord == null)
            {
                return false;
            }

            int dummy;
            return int.TryParse(currentWord, out dummy);
        }

        /**
         * nextInt returns the next integer token in the input string
         */
        public int nextInt()
        {
            try
            {
                return int.Parse(currentWord);
            }
            finally
            {
                readNextWord();
            }
        }

        /**
         * hasNextDouble returns a a bool if the next value is a double
         */
        public bool hasNextDouble()
        {
            if (currentWord == null)
            {
                return false;
            }
            double dummy;
            return double.TryParse(currentWord, out dummy);
        }

        /**
         * nextDouble returns the nexe double token in the input string
         */
        public double nextDouble()
        {
            try
            {
                return double.Parse(currentWord);
            }
            finally
            {
                readNextWord();
            }
        }

        /**
         * hasNext returns a bool if there is or isn't another token in the input string
         */
        public bool hasNext()
        {
            return currentWord != null;
        }

        /**
         * next reutrns the next string token in the input string
         */
        public string next()
        {
            if (!hasNext())
            {
                readNextWord();
                return currentWord;
            }
            else
            {
                return null;
            }
        }
    }
}

