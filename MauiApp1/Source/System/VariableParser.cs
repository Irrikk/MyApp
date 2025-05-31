using System;

namespace MauiApp1
{
    public class VariableParser
    {
        public Variable Variable { get; private set; }

        public VariableParser(Variable variable)
        {
            Variable = variable;
        }

        public T? ParseTo<T>()
        {
            switch (Variable.Type)
            {
                case VariableType.Bool: return (T)(object)bool.Parse(Variable.Value);
                case VariableType.Int: return (T)(object)int.Parse(Variable.Value);
                case VariableType.Double: return (T)(object)double.Parse(Variable.Value);
                case VariableType.BoolArray: return (T)(object)Array.ConvertAll(Variable.Value.Trim().Split(), bool.Parse);
                case VariableType.IntArray: return (T)(object)Array.ConvertAll(Variable.Value.Trim().Split(), int.Parse);
                case VariableType.DoubleArray: return (T)(object)Array.ConvertAll(Variable.Value.Trim().Split(), double.Parse);
                default: return default;
            }
        }
    }
}