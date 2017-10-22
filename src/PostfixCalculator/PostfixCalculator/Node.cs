using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixCalculator
{
    /**
     * Class Node, used for type generics
     */
    class Node
    {
        //Global variables
        object data;
        Node next;

        /**
         * Default constructor for Node
         */
        public Node()
        {
            data = null;
            next = null;
        }

        /**
         * Constructor for Node
         * input object the data to be input, Node the pointer to the
         * next element
         */
        public Node(object newData, Node newNext)
        {
            data = newData;
            next = newNext;
        }

        /**
        public object Data
        {
            set => data = value;
            get => data;
        }
        */

        //More CSharpish way to do it, previous is also valid
        public object Data { get { return data; } set { data = value; } }

        public Node Next { get { return next; } set { next = value; } }
    }
}
