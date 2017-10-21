using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixCalculator
{
    class Node
    {
        private static object data;
        public static Node next;

        public Node()
        {
            data = null;
            next = null;
        }

        public Node(object data, Node next)
        {
            Node.data = data;
            Node.next = next;
        }

        /**
        public object Data
        {
            set => data = value;
            get => data;
        }
        */

        //More CSharpish way to do it
        public object Data { get; set; } = data;

        public Node Next { set; get; } = next;
    }
}
