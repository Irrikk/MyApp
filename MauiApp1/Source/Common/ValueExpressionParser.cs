using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public class ValueExpressionParser<T>
    {
        private VariableRegistry _registry;

        public ValueExpressionParser(AppContext context)
        {
            _registry = context.VariableRegistry;
        }

        //public T? Parse(string value)
        //{
        //    _registry.Get();
        //}
    }
}