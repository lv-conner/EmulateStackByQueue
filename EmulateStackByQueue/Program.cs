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

            var emQueue = new EmulateStack<int>();
            for (int i = 0; i < 10; i++)
            {
                emQueue.Push(i);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(emQueue.Pop());
            }
            Console.ReadLine();
        }
    }

    public class EmulateStack<T>
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
            _firstQueue.Enqueue(value);
        }
        public T Pop()
        {
            if(_firstQueue.Count == 0)
            {
                throw new Exception("Stack was empty");
            }
            else
            {
                while(_firstQueue.Count > 1)
                {
                    _secondQueue.Enqueue(_firstQueue.Dequeue());
                }
                var popValue = _firstQueue.Dequeue();
                while(_secondQueue.Count > 0)
                {
                    _firstQueue.Enqueue(_secondQueue.Dequeue());
                }
                return popValue;
            }
        }
    }
}
