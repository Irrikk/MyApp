using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public abstract class ValueNode<T> : Node
    {

        protected Entry _inputField;
        protected Channel _output;

        public string? Name { get; set; }

        public ValueNode
        (
            AppContext context,
            T? defaultValue,
            Vector2? position = null,
            string title = "Value"
        )
            : base
            (
                context: context,
                position: position ?? new(),
                title: title,
                titleBarColor: new(131, 49, 74, 255),
                nodeColor: new(100, 100, 100, 255),
                cornerRadius: CORNER_RADIUS
            )
        {

            string typeName = typeof(T).Name;
            if (typeName == "Boolean") _output = new BoolChannel(context, this, ValueChannelType.Output, "value");
            else if (typeName == "Int32") _output = new IntChannel(context, this, ValueChannelType.Output, "value");
            else if (typeName == "Single") _output = new DoubleChannel(context, this, ValueChannelType.Output, "value");
            else throw new NotImplementedException();

            _inputField = new()
            {
                Text = defaultValue?.ToString() ?? "Null",
                HeightRequest = 40,
                WidthRequest = 40,
                FontSize = 14,
                TextColor = Colors.Black,
                BackgroundColor = Colors.DarkGray,
            };

            AddContent(_output, LayoutAlignment.End);
            AddContent(_inputField, LayoutAlignment.Center);
        }
    }
}
