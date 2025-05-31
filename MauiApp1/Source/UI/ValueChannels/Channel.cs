using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MauiApp1
{
    public class Channel : Border
    {
        private Node _rootNode;
        private EventBus _eventBus;
        private StackLayout _layout;
        private Label _label;
        private Border _channelElement;
        private Brush _channelDefaultStroke;
        private Brush _channelHightlightStroke;
        private Channel? _linkedParent;
        private Channel? _linkedChild;
        public Node RootNode => _rootNode;
        private object? _value;
        private bool _isHighlighted;

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

        public object? Value
        {
            get => _value;
            set
            {
                _value = value;
                if (_linkedChild != null) _linkedChild.Value = _value;
            }
        }

        public Channel? LinkedParent
        {
            get => _linkedParent;
            set => _linkedParent = value;
        }

        public Channel? LinkedChild
        {
            get => _linkedChild;
            set => _linkedChild = value;
        }

        public bool IsHighlighted
        {
            get => _isHighlighted;
            set
            {
                _isHighlighted = value;
                _channelElement.Stroke = value ? _channelHightlightStroke : _channelDefaultStroke;
            }
        }

        public Channel(
            AppContext context,
            Node rootNode,
            string title,
            ValueChannelType type,
            object? defaultValue = null,
            Color? color = null,
            Size? size = null
        )
        {
            _eventBus = context.EventBus;
            _rootNode = rootNode;
            _layout = new StackLayout();
            _layout.Orientation = StackOrientation.Horizontal;

            _channelDefaultStroke = Colors.Black;
            _channelHightlightStroke = Colors.White;

            _channelElement = new()
            {
                HeightRequest = 12,
                WidthRequest = 12,
                BackgroundColor = color ?? Colors.Grey,
                Stroke = Colors.Black,
                StrokeShape = new RoundRectangle()
                {
                    CornerRadius = 12
                }
            };

            _label = new()
            {
                HeightRequest = 15,
                WidthRequest = 50
            };

            if (type == ValueChannelType.Input)
            {
                var options = _layout.HorizontalOptions;
                options.Alignment = LayoutAlignment.Start;
                _layout.HorizontalOptions = options;
                _layout.Add(_channelElement);
                _layout.Add(_label);
            }
            else if (type == ValueChannelType.Output)
            {
                var options = _layout.HorizontalOptions;
                options.Alignment = LayoutAlignment.End;
                _layout.HorizontalOptions = options;
                _layout.Add(_label);
                _layout.Add(_channelElement);
            }

            var tapGesture = _channelElement.AddGestureRecognizer<TapGestureRecognizer>();
            tapGesture.Tapped += _OnTapped;

            Content = _layout;

            Size = size ?? new(80, 20);
            Title = title;
            Type = type;

            //BackgroundColor = new(100, 100, 100, 255);
            BackgroundColor = new(50, 50, 50, 255);
        }

        private void _OnTapped(object? sender, TappedEventArgs args)
        {
            _eventBus.channelTapped.Invoke(this);
        }

        //private void _OnPanUpdated(object? sender, PanUpdatedEventArgs args)
        //{
        //    switch (args.StatusType)
        //    {
        //        case GestureStatus.Started:
        //            _channelElement.Stroke = _channelHightlightStroke;
        //            Debug.WriteLine("_OnPanUpdated started");
        //            break;

        //        case GestureStatus.Running:
        //            Debug.WriteLine("_OnPanUpdated running");
        //            break;

        //        case GestureStatus.Completed:
        //            _channelElement.Stroke = _channelDefaultStroke;
        //            Debug.WriteLine("_OnPanUpdated completed");
        //            break;
        //    }
        //}
    }
}
