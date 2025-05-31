using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class OutputNode : Node
    {
        private Channel _input; 
        private Label _text;

        public OutputNode
        (
            AppContext context,
            Vector2? position = null,
            Event<Channel>? channelTapped = null
        )
            : base
            (
                context: context,
                position: position,
                title: "Output",
                titleBarColor: Colors.IndianRed,
                nodeColor: Colors.IndianRed
            )
        {
            _input = new(context, this, "value", ValueChannelType.Input);
            AddContent(_input, LayoutAlignment.Center);

            _text = new();
            AddContent(_text, LayoutAlignment.Center);

            _text.Text = "Null";
        }

        public override void Execute()
        {
            Debug.WriteLine("OutputNode execution");
            object? value = _input.Value;
            if (value == null)
            {
                Debug.WriteLine("Output is null");
                _text.Text = "Null";
                return;
            }

            if (value is int) _text.Text = ((int)value).ToString();
            else if (value is double) _text.Text = ((double)value).ToString("f4");
            else if (value is bool) _text.Text = ((bool)value).ToString();
            else _text.Text = "UNEXPECTED TYPE";
        }
    }
}
