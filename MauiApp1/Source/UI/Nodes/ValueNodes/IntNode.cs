using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class IntNode : ValueNode<int>
    {
        public IntNode
        (
            AppContext context,
            Vector2? position = null
        )
            : base
            (
                context: context,
                defaultValue: 0,
                position: position,
                title: "Int"
            )
        {
        }

        public override void Execute()
        {
            if (int.TryParse(_inputField.Text, out int result))
            {
                _output.Value = result;
            }
            else throw new Exception("Unexpected value format");
        }
    }
}
