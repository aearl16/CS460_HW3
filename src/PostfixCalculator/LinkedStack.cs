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
        private Node top;

        public LinkedStack()
        {
            top = null;
        }

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

        public object Peek => IsEmpty ? null: top.Data;

        public void Clear()
        {
            top = null;
        }

        public bool IsEmpty => top == null;

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
