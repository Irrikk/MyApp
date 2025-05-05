using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Maui.Controls.Shapes;

namespace MauiApp1;

public class Node : Border, INode
{
    private Label _label;
    private Border _titleBar;

    public Vector2 Position
    {
        get => new((float)TranslationX, (float)TranslationY);
        set
        {
            TranslationX = value.X;
            TranslationY = value.Y;
        }
    }

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

    public Color TitleBarColor
    {
        get => _titleBar.BackgroundColor;
        set => _titleBar.BackgroundColor = value;
    }

    public Color BodyColor
    {
        get => BackgroundColor;
        set => BackgroundColor = value;
    }

    public double CornerRadius
    {
        get
        {
            RoundRectangle? shape = StrokeShape as RoundRectangle;
            if (shape == null) throw new Exception("Shape is not round!");
            return shape.CornerRadius.TopLeft;
        }
        set
        {
            RoundRectangle? shape = StrokeShape as RoundRectangle;
            if (shape == null) throw new Exception("Shape is not round!");
            shape.CornerRadius = value;

            shape = _titleBar.StrokeShape as RoundRectangle;
            if (shape == null) throw new Exception("Shape is not round!");
            shape.CornerRadius = new(value, value, 0.0, 0.0);
        }
    }

    public Event<INode> NodeTouched { get; private set; }

    public IDrawable Drawable => throw new NotImplementedException();

    public Node(
        Vector2 position,
        Size size,
        string title,
        Color titleBarColor,
        Color bodyColor,
        double cornerRadius = 8.0,
        Event<INode>? nodeTouched = null
    )
    {
        StackLayout layout = new();

        _label = new()
        {
            Text = title,
            TextColor = new(255, 255, 255, 255),
            HorizontalTextAlignment = TextAlignment.Center,
        };

        _titleBar = new()
        {
            BackgroundColor = titleBarColor,
            StrokeShape = new RoundRectangle()
            {
                CornerRadius = new(cornerRadius, cornerRadius, 0.0, 0.0)
            },
            Content = _label
        };

        layout.Add(_titleBar);

        TapGestureRecognizer tapGesture = new();
        tapGesture.Tapped += _OnTapped;
        layout.GestureRecognizers.Add(tapGesture);

        PanGestureRecognizer panGesture = new();
        panGesture.PanUpdated += _OnPanUpdated;
        layout.GestureRecognizers.Add(panGesture);

        StrokeShape = new RoundRectangle()
        {
            CornerRadius = cornerRadius
        };

        Stroke = new LinearGradientBrush()
        {
            StartPoint = new(0, 0),
            EndPoint = new(1, 1)
        };

        HeightRequest = size.Height;
        WidthRequest = size.Width;
        BackgroundColor = bodyColor;
        Content = layout;

        NodeTouched = nodeTouched ?? new();
    }

    public virtual Node Copy()
    {
        throw new NotImplementedException();
    }

    public virtual void Remove()
    {
        throw new NotImplementedException();
    }

    private void _OnTapped(object? sender, TappedEventArgs args)
    {
        NodeTouched.Invoke(this);
    }

    private void _OnPanUpdated(object? sender, PanUpdatedEventArgs args)
    {
        if(args.StatusType == GestureStatus.Started)
        {
            NodeTouched.Invoke(this);
        }
        else if (args.StatusType == GestureStatus.Running)
        {
            TranslationX += args.TotalX;
            TranslationY += args.TotalY;
        }
    }
}