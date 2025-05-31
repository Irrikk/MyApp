using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MauiApp1
{
    public abstract class MathNode : Node
    {
        protected Channel _input1;
        protected Channel _input2;
        protected Channel _output;

        public MathNode
        (
            AppContext context,
            Vector2? position = null, 
            string title = "Math"
        )
            : base
            (
                context: context,
                position: position ?? new(),
                title: title,
                titleBarColor: new(36, 98, 131, 255),
                nodeColor: new(36, 98, 131, 255)
            )
        {
            _input1 = new Channel(context, this, "value", ValueChannelType.Input);
            _input2 = new Channel(context, this, "value", ValueChannelType.Input);
            _output = new Channel(context, this, "value", ValueChannelType.Output);
            AddContent(_input1, LayoutAlignment.Start);
            AddContent(_input2, LayoutAlignment.Start);
            AddContent(_output, LayoutAlignment.End);
        }
    }
}
