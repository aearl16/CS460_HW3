using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixCalculator
{
    /**
    * A singly linked stack implementation.
    */
    class LinkedStack : IStackADT
    {
        //Global variables
        private Node top;

        //Constructor
        public LinkedStack()
        {
            top = null;
        }

        //Stack Pop method
        public object Pop()
        {
            if (IsEmpty)
            {
                return null;
            }
            object topItem = top;
            top = top.Next;
            return topItem;
        }

        //Stack Peek method
        public object Peek => IsEmpty ? null : top.Data; //returns null if empty and top.Data if it isn't

        //Clear, sets top pointer to null
        public void Clear()
        {
            top = null;
        }

        //IsEmpty, Checks if top is null
        public bool IsEmpty => top == null;

        //Push method, pushes the new object onto the stack
        public object Push(object newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            Node newNode = new Node(newItem, top);
            top = newNode;
            return newItem;
        }
    }
}
