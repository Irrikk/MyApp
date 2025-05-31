using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MauiApp1
{
    public class NotEqualsNode : MathNode
    {
        public NotEqualsNode
        (
            AppContext context,
            Vector2? position = null
        )
            : base
            (
                context: context,
                position: position ?? new(),
                title: "Not Equals"
            )
        {

        }

        public override void Execute()
        {
            if (_input1.Value == null && _input2.Value == null) return;
            if (_input1.Value is int v1 && _input2.Value is int v2) _output.Value = v1 != v2;
            else if (_input1.Value is double d1 && _input2.Value is double d2) _output.Value = d1 != d2;
            else throw new NotImplementedException();
        }
    }
}
