using System.Collections;

namespace BettingSystem.Data_Structures
{
    public class MyLinkedList<T>: IEnumerable<T>
    {
        public class Node
        {
            public Node Previous { get; internal set; }
            public Node Next { get; internal set; }

            public T Value { get; set; }

            public Node(T value)
            {
                Previous = null;
                Next = null;
                Value = value;
            }
        }

        private Node _head;
        private int _count;

        public MyLinkedList()
        {
            _count = 0;
        }
        public Node First => _head;
        public int Count => _count;

        // Add value at the head
        public Node AddFirst(T value)
        {
            Node newNode = new Node(value);
            if (_head != null)
            {
                newNode.Next = _head;
                _head.Previous = newNode;
            }
            _head = newNode;
            _count++;
            return newNode;
        }

        // remove a node
        public bool Remove(Node node)
        {
            if (_count == 0 || node == null) 
                return false;

            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }
            else
            {
                // if node removed was at the head
                _head = node.Next;
            }
            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
            }
            _count--;
            return true;
        }
        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        //make iterable
        public IEnumerator<T> GetEnumerator()
        {
            Node node = _head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
