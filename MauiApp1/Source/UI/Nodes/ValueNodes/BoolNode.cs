using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Diagnostics;

namespace MauiApp1
{
    public class BoolNode : ValueNode<bool>
    {
        public BoolNode
        (
            AppContext context,
            Vector2? position = null
        ) 
            : base
            (
                context: context,
                defaultValue: false,
                position: position,
                title: "Bool"
            )
        {
        }

        public override void Execute()
        {
            if (bool.TryParse(_inputField.Text, out bool result))
            {
                _output.Value = result;
            }
            else throw new Exception("Unexpected value format");
        }
    }
}
