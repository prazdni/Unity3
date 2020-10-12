using System;

namespace MyLabyrinth
{
    public class MyException : Exception
    {
        public int Value { get; }

        public MyException(string message) : base(message)
        {
        }

        public MyException(string message, int val) : this(message)
        {
            Value = val;
        }
    }
}
