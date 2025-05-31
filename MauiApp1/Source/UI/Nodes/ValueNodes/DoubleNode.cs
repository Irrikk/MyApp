using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Diagnostics;

namespace MauiApp1
{
    public class DoubleNode : ValueNode<float>
    {
        public DoubleNode
        (
            AppContext context,
            Vector2? position = null
        )
            : base
            (
                context: context,
                defaultValue: 0.0f,
                position: position,
                title: "Double"
            )
        {
        }

        public override void Execute()
        {
            if (float.TryParse(_inputField.Text, out float result))
            {
                _output.Value = result;
            }
            else throw new Exception("Unexpected value format");
        }
    }
}
