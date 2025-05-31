using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MauiApp1
{
    public class VariableValidator
    {
        public string GetDefaultValue(VariableType type)
        {
            switch (type)
            {
                case VariableType.Bool: return "false";
                case VariableType.Int: return "0";
                case VariableType.Double: return "0.0";
                case VariableType.BoolArray: return "null";
                case VariableType.IntArray: return "null";
                case VariableType.DoubleArray: return "null";
                default: throw new NotImplementedException();
            }
        }

        public bool NameIsValid(string name) => Regex.IsMatch(name, @"^[a-zA-Z_][a-zA-Z0-9_]*$");

        public bool NameNotValid(string name) => !NameIsValid(name);

        public bool ValueIsValid(string value, VariableType type)
        {
            switch (type)
            {
                case VariableType.Bool: return _IsBool(value);
                case VariableType.Int: return _IsInt(value);
                case VariableType.Double: return _IsDouble(value);
                case VariableType.BoolArray: return _IsBoolArray(value);
                case VariableType.IntArray: return _IsIntArray(value);
                case VariableType.DoubleArray: return _IsDoubleArray(value);
                default: throw new NotImplementedException();
            }
        }

        public bool ValueNotValid(string value, VariableType type) => !ValueIsValid(value, type);

        private bool _IsBool(string value) => bool.TryParse(value, out bool result);

        private bool _IsInt(string value) => int.TryParse(value, out int result);

        private bool _IsDouble(string value) => double.TryParse(value, out double result);

        private bool _IsBoolArray(string value)
        {
            foreach (var item in value.Trim().Split())
                if (!_IsBool(item)) return false;
            return true;
        }

        private bool _IsIntArray(string value)
        {
            foreach (var item in value.Trim().Split())
                if (!_IsInt(item)) return false;
            return true;
        }

        private bool _IsDoubleArray(string value)
        {
            foreach (var item in value.Trim().Split())
                if (!_IsDouble(item)) return false;
            return true;
        }
    }
}
