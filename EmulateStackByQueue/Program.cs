using System;
using System.Collections;
using System.Collections.Generic;
namespace EmulateStackByQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var intQueue = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                intQueue.Enqueue(i);
            }
            foreach (var item in intQueue)
            {
                Console.WriteLine(item);
            }
            var emStack = new EmulateStack<int>();
            for (int i = 0; i < 10; i++)
            {
                emStack.Push(i);
            }

            foreach (var item in emStack)
            {
                Console.WriteLine(item);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(emStack.Pop());
            }
            Console.ReadLine();
        }
    }

    public class EmulateStack<T>:IEnumerable<T>
    {
        private Queue<T> _firstQueue;
        private Queue<T> _secondQueue;
        public EmulateStack()
        {
            _firstQueue = new Queue<T>();
            _secondQueue = new Queue<T>();
        }
        public void Push(T value)
        {
            if(_firstQueue.Count == 0 && _secondQueue.Count == 0)
            {
                _firstQueue.Enqueue(value);
            }
            else if(_firstQueue.Count != 0)
            {
                _firstQueue.Enqueue(value);
            }
            else if(_secondQueue.Count != 0)
            {
                _secondQueue.Enqueue(value);
            }
            else
            {
                _firstQueue.Enqueue(value);
            }
        }
        public T Pop()
        {
            if (_firstQueue.Count > 0)
            {
                while (_firstQueue.Count > 1)
                {
                    _secondQueue.Enqueue(_firstQueue.Dequeue());
                }
                return _firstQueue.Dequeue();
            }
            if (_secondQueue.Count > 0)
            {
                while (_secondQueue.Count > 1)
                {
                    _firstQueue.Enqueue(_secondQueue.Dequeue());
                }
                return _secondQueue.Dequeue();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if(_firstQueue.Count > 0)
            {
                foreach (var item in _firstQueue)
                {
                    yield return item;
                }
            }
            if(_secondQueue.Count > 0)
            {
                foreach (var item in _secondQueue)
                {
                    yield return item;
                }
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
