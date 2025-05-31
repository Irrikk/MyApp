using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public class IllegalVariableNameException : Exception
    {
        public IllegalVariableNameException() : base() { }

        public IllegalVariableNameException(string message) : base(message) { }
    }
}