using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class VariableAssignmentException : Exception
    {
        public VariableAssignmentException() : base() { }

        public VariableAssignmentException(string message) : base(message) { }
    }
}