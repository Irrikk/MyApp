using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public class VariableAlreadyExistsException  : Exception
    {
        public VariableAlreadyExistsException () : base() { }

        public VariableAlreadyExistsException (string message) : base(message) { }
    }
}