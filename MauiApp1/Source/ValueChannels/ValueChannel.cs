using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class ValueChannel<T> : Border
    {
        private StackLayout _layout;
        private Label _label;
        private Border _passElement;

        public ValueChannelType Type { get; private set; }

        public Size Size
        {
            get => new(Width, Height);
            set
            {
                HeightRequest = value.Height;
                WidthRequest = value.Width;
            }
        }

        public string Title
        {
            get => _label.Text;
            set => _label.Text = value;
        }

        public T? Value { get; set; }

        public ValueChannel(Size size, string title, ValueChannelType type, Color passColor)
        {
            _layout = new StackLayout();
            _layout.Orientation = StackOrientation.Horizontal;

            _passElement = new();
            _passElement.HeightRequest = 12;
            _passElement.WidthRequest = 12;
            _passElement.BackgroundColor = passColor;
            _passElement.StrokeShape = new RoundRectangle()
            {
                CornerRadius = 12
            };

            _label = new();

            if (type == ValueChannelType.Input)
            {
                var options = _layout.HorizontalOptions;
                options.Alignment = LayoutAlignment.Start;
                _layout.HorizontalOptions = options;
                _layout.Add(_passElement);
                _layout.Add(_label);
            }
            else if (type == ValueChannelType.Output)
            {
                var options = _layout.HorizontalOptions;
                options.Alignment = LayoutAlignment.End;
                _layout.HorizontalOptions = options;
                _layout.Add(_label);
                _layout.Add(_passElement);
            }

            HeightRequest = size.Height;
            WidthRequest = size.Width;

            Content = _layout;

            Size = size;
            Title = title;
            Type = type;
            BackgroundColor = new(100, 100, 100, 255);
        }

    }
}
