using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class Queue
    {
        private Stack _stack1;
        private Stack tailstack2;
        private int _tail;
        private int _size;

        public int tail
        {
            get { return this._tail; }
        }
        public Queue(int capacity)
        {
            _stack1 = new Stack(capacity);
            tailstack2 = new Stack(capacity);
            _tail = 0;
            _size = capacity;
        }
        public void Enqueus(Object obj)
        {
            _stack1.Push(obj);
            Stack s = _stack1.clone();
            tailstack2.Clear();
            int j = s.Top;
            for(int i = 0; i<j; i++)
            {
                tailstack2.Push(s.Pop());
            }
            _tail++;
        }
        public object Dequeue()
        {
            object head=tailstack2.Pop();
            Stack s = tailstack2.clone();
            _stack1.Clear();
            for (int i = 0; i < s.Top; i++)
            {
                _stack1.Push(s.Pop());
            }
            _tail--;
            return head;
        }
        public object peek()
        {
            return tailstack2.Peek();
        }
        public IEnumerator GetEnumerator()
        {
            return tailstack2.GetEnumerator();
        }

        public Queue Clone()
        {
            Queue queue = new Queue(this._size);
            queue._stack1 = this._stack1.clone();
            queue.tailstack2 = this.tailstack2.clone();
            queue._tail = this._tail;
            return queue;
        }

    }
}
