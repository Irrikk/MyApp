using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MauiApp1
{
    public class AndNode : MathNode
    {
        public AndNode
        (
            AppContext context,
            Vector2? position = null
        )
            : base
            (
                context: context,
                position: position ?? new(),
                title: "And"
            )
        {

        }

        public override void Execute()
        {
            if (_input1.Value == null && _input2.Value == null) return;
            if (_input1.Value is bool v1 && _input2.Value is bool v2) _output.Value = v1 && v2;
            else throw new NotImplementedException();
        }
    }
}
