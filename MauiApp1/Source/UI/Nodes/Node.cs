using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Maui.Controls.Shapes;

namespace MauiApp1;

public abstract class Node : Border
{
    public const double CORNER_RADIUS = 8.0;

    private static int _maxZ;
    private Layout _rootLayout;
    private EventBus _eventBus;
    private Layout _layout;
    private Label _title;
    private Border _titleBar;
    private Layout _contentLayout;
    private bool _isActive;

    public Vector2 Position
    {
        get => new((float)TranslationX, (float)TranslationY);
        set
        {
            Vector2 oldPos = Position;
            TranslationX = value.X;
            TranslationY = value.Y;
            _eventBus.nodePositionChanged.Invoke(new(this, oldPos, value));
        }
    }

    public int Layer
    {
        get => ZIndex;
        set => ZIndex = value;
    }

    public string Title
    {
        get => _title.Text;
        set => _title.Text = value;
    }

    public Color TitleBarColor
    {
        get => _titleBar.BackgroundColor;
        set => _titleBar.BackgroundColor = value;
    }

    public Color NodeColor
    {
        get => BackgroundColor;
        set => BackgroundColor = value;
    }

    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            if (value) _rootLayout.Add(this);
            else _rootLayout.Remove(this);
        }
    }

    public List<Node> ParentNodes { get; private set; }

    public Node? ChildNode { get; set; }

    public Node
    (
        AppContext context,
        Vector2? position = null,
        string? title = "Node",
        Color? titleBarColor = null,
        Color? nodeColor = null,
        double cornerRadius = CORNER_RADIUS,
        bool isActive = true
    )
    {
        _rootLayout = context.RootLayout;
        _eventBus = context.EventBus;

        Layout layout = new VerticalStackLayout()
        {
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Start,
            MinimumHeightRequest = 20,
            MinimumWidthRequest = 40,
        };

        _title = new()
        {
            Text = title,
            TextColor = new(255, 255, 255, 255),
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center
        };

        _titleBar = new()
        {
            MinimumHeightRequest = 25,
            BackgroundColor = titleBarColor ?? new(0, 180, 20, 255),
            StrokeShape = new RoundRectangle()
            {
                CornerRadius = new(cornerRadius, cornerRadius, 0.0, 0.0)
            },
            Content = _title
        };

        layout.Add(_titleBar);

        _contentLayout = new VerticalStackLayout()
        {
            BackgroundColor = nodeColor ?? new(100, 100, 100, 255),
            MinimumHeightRequest = 20,
            MinimumWidthRequest = 40,
            Padding = new(2, 4, 2, 4)
        };

        layout.Add(_contentLayout);

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

        Content = layout;
        ZIndex = ++_maxZ;
        Position = position ?? new();
        IsActive = isActive;
        ParentNodes = new();
    }

    public void AddContent(View view, LayoutAlignment aligmnment)
    {
        StackLayout layout = new()
        {
            Orientation = StackOrientation.Horizontal,
            HorizontalOptions = new()
            {
                Alignment = aligmnment
            }
        };

        layout.Add(view);
        _contentLayout.Children.Add(layout);
    }

    public abstract void Execute();

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
        ZIndex = ZIndex < _maxZ ? ++_maxZ : ZIndex;
        _eventBus.nodeTapped.Invoke(this);
        //NodeTouched.Invoke(this);
    }

    private void _OnPanUpdated(object? sender, PanUpdatedEventArgs args)
    {
        if (args.StatusType == GestureStatus.Started)
        {
            _eventBus.nodeTapped.Invoke(this);
        }
        else if (args.StatusType == GestureStatus.Running)
        {
            TranslationX += args.TotalX;
            TranslationY += args.TotalY;
        }
        else if (args.StatusType == GestureStatus.Completed)
        {
            ZIndex = ZIndex < _maxZ ? ++_maxZ : ZIndex;
        }
    }

    public Channel AddChannel()
    {
        //todo реализовать удобный метод добавления каналов данных
        throw new NotImplementedException();
    }
}