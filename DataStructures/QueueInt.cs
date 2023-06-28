using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace DataStructures
{
    public class QueueInt
    {
        private readonly Stack<int> _items = new();
        private readonly Stack<int> _flippedItems = new();

        public QueueInt()
        {
        }

        public void Push(int x)
        {
            if (_items.Count == 0)
            {
                if (_flippedItems.Count > 0)
                {
                    while (_flippedItems.Count > 0)
                    {
                        _items.Push(_flippedItems.Pop());
                    }

                    _items.Push(x);
                    while (_items.Count > 0)
                    {
                        _flippedItems.Push(_items.Pop());
                    }
                }
                else
                    _items.Push(x);

                return;
            }

            if (_items.Count >= 1)
            {
                _items.Push(x);
                while (_items.Count > 0)
                {
                    _flippedItems.Push(_items.Pop());
                }
            }
        }


        public int Pop()
        {
            if (_flippedItems.Count == 0)
                return _items.Pop();
            else
                return _flippedItems.Pop();
        }
        
        public int Peek()
        {
            if (_flippedItems.Count == 0)
                return _items.Peek();
            else
                return _flippedItems.Peek();
        }
        
        public bool Empty()
        {
            return _items.Count == 0 && _flippedItems.Count == 0;
        }
    }
}


// Your MyQueue object will be instantiated and called as such:
// MyQueue obj = new MyQueue();
// obj.Push(x);
// int param_2 = obj.Pop();
// int param_3 = obj.Peek();
// bool param_4 = obj.Empty();