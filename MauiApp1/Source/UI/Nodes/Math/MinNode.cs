using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MauiApp1
{
    public class MinNode : MathNode
    {
        public MinNode
        (
            AppContext context,
            Vector2? position = null
        )
            : base
            (
                context: context,
                position: position ?? new(),
                title: "Min"
            )
        {

        }

        public override void Execute()
        {
            if (_input1.Value == null && _input2.Value == null) return;
            if (_input1.Value is int && _input2.Value is int)
                _output.Value = int.Min( (int)_input1.Value, (int)_input2.Value);
            else if (_input1.Value is float && _input2.Value is float)
                _output.Value = float.Min((float)_input1.Value, (float)_input2.Value);
            else throw new NotImplementedException();
        }
    }
}
