using System;
using System.Text;

namespace DataStructures
{
    public class Node
    {
        public Node(int val)
        {
            this.val = val;
            prev = null;
            next = null;
        }

        public int val;
        public Node? next;
        public Node? prev;

        public bool HasNext()
        {
            return next != null && next.val != Int32.MaxValue;
        }
    }

    public class LinkedIntList
    {
        private const int Start = Int32.MinValue;
        private const int End = Int32.MaxValue;
        private Node head;
        private Node end;

        public LinkedIntList()
        {
            head = new Node(Start);
            end = new Node(End);
            head.next = end;
            end.prev = head;
        }

        public string Test()
        {
            var result = new StringBuilder();
            var node = head;

            while (node != null)
            {
                if (node.val is Start or End)
                {
                    node = node.next;
                    continue;
                }

                result.Append(node.val);
                if (node.HasNext())
                    result.Append("->");
                node = node.next;
            }

            return result.ToString();
        }

        public int Get(int index)
        {
            var node = GetNode(index);
            if (node == null)
                return -1;

            return node.val;
        }

        private Node? GetNode(int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException(index.ToString());

            var node = head.next;
            if (node == null)
                return node;

            while (index > 0 )
            {
                node = node.next;
                if (node == null)
                    return node;
                index--;
            }

            return node;
        }

        public void AddAtHead(int val)
        {
            var makeSecond = head.next;
            if (makeSecond == null)
                return;

            var makeFirst = new Node(val)
            {
                prev = head
            };

            head.next = makeFirst;

            makeFirst.next = makeSecond;
            makeSecond.prev = makeFirst;
        }

        public void AddAtTail(int val)
        {
            var last = new Node(val);
            var makePrev = end.prev;
            
            if(makePrev == null)
                return;
            
            makePrev.next = last;
            last.prev = makePrev;
            
            last.next = end;
            end.prev = last;
        }

        public void AddAtIndex(int index, int val)
        {
            var node = GetNode(index);
            if(node == null)
                return;
            
            var newNode = new Node(val);
            
            var prev = node.prev;
            
            if(prev == null)
                return;

            prev.next = newNode;
            newNode.prev = prev;
            newNode.next = node;
        }

        public void DeleteAtIndex(int index)
        {
            var node = GetNode(index);
            
            if(node == null)
                return;

            var prev = node.prev;
            var next = node.next;
            
            if(prev == null || next == null)
                return;
            
            prev.next = next;
            next.prev = prev;
        }
    }

    // Your MyLinkedList object will be instantiated and called as such:
    // MyLinkedList obj = new MyLinkedList();
    // int param_1 = obj.Get(index);
    // obj.AddAtHead(val);
    // obj.AddAtTail(val);
    // obj.AddAtIndex(index,val);
    // obj.DeleteAtIndex(index);
}