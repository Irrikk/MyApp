using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public class VariableRegistry
    {
        private Dictionary<string, Variable> _variables;

        public VariableRegistry()
        {
            _variables = new();
        }

        public void Add(Variable variable) => _variables[variable.Name] = variable;

        public void Remove(Variable variable) => _variables.Remove(variable.Name);

        public bool Contains(string name) => _variables.ContainsKey(name);

        public Variable Get(string name) => _variables[name];
    }
}
