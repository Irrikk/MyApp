using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1;
public abstract class Node : Border
{
    public Node(Size size, string title, Color titleBarColor, Color nodeColor)
    {
        StackLayout layout = new();

        Border titleBar = new() {
            BackgroundColor = titleBarColor,
            StrokeShape = new RoundRectangle() {
                CornerRadius = 8
            }
        };
        layout.Add(titleBar);

        Label label = new();
        label.HorizontalTextAlignment = TextAlignment.Center;
        label.Text = title;
        label.TextColor = new(255, 255, 255, 255);
        titleBar.Content = label;

        StrokeShape = new RoundRectangle(){
             CornerRadius = 8
        };

        Stroke = new LinearGradientBrush()
        {
            StartPoint = new(0, 0),
            EndPoint = new(1, 1),
            
        };

        HeightRequest = size.Height;
        WidthRequest = size.Width;

        BackgroundColor = nodeColor;

        Content = layout;
    }
}
