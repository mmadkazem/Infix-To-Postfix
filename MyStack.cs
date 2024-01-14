using System;

namespace Infix_To_Postfix
{
  
    public class MyStack<T>
    {
        private T[] values;
        public int Count = 0;


        public MyStack()
        {
            values = new T[10];
        }

        public void Push(T value)
        {

            if (IsFull())
            {


                values = Expansion();
            }

            values[++Count] = value;
        }
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }
            return values[Count--];
        }

        public bool IsFull()
        {
            return Count == values.Length - 1;
        }
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public T Peek()
        {
            return values[Count];
        }

        private T[] Expansion()
        {
            var result = new T[Count * 2];

            for (int i = 0; i < values.Length; i++)
            {
                result[i] = values[i];
            }
            return result;
        }

    }
}
