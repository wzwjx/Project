using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class Stack : IEnumerable, IDisposable
    {
        private int _top = 0;
        private int _size = 0;
        private object[] _stack = null;
        private const int _defaultCapatity = 10;
        public int Top
        {
            get { return _top; }
        }
        public int Size
        {
            get { return _size; }
        }
        public Stack()
        {
            _top = 0;
            _size = _defaultCapatity;
            _stack = new object[_defaultCapatity];
        }
        public Stack(int size)
        {
            _top = 0;
            _size = size;
            _stack = new object[size];
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }
        public Stack clone()
        {
            Stack s = new Stack(_size);
            s._size = _size;
            s._top = _top;
            Array.Copy(this._stack, s._stack,_size);
            return s;
        }
        public bool IsFull()
        {
            return _top == _size;
        }
        public void Clear()
        {
            _top = 0;
        }
        public bool Push(object node)
        {
            if (!IsFull())
            {
                _stack[_top] = node;
                _top++;
                return true;
            }
            return false;
        }
        public object Pop()
        {
            object node = default(object);
            if (!IsEmpty())
            {
                _top--;
                node = _stack[_top];
            }
            return node;
        }
        public void Dispose()
        {
            _stack = null;
        }
        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < _stack.Length; i++)
            {
                if (_stack[i] != null)
                {
                    yield return _stack[i];
                }
            }
        }
        public object Peek()
        {
            return _stack[_top-1];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
